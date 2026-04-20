use master;
go

if exists (select name from sys.databases where name = 'VotingSystemDB')
begin
    alter database VotingSystemDB set single_user with rollback immediate;
    drop database VotingSystemDB;
end
go

create database VotingSystemDB;
go

use VotingSystemDB;
go

-- layer 1: identity layer
create table UserAccount (
    UserId int identity(1,1) primary key,
    Username nvarchar(50) not null unique,
    PasswordHash nvarchar(256) not null,
    Email nvarchar(100) not null unique,
    AccountType nvarchar(10) not null default 'voter',
    IsActive bit not null default 1,
    CreatedDate datetime2 not null default getdate(),
    LastLogin datetime2 null,
    FailedLoginAttempts int default 0,
    LockedUntil datetime2 null,

    constraint CK_UserAccount_AccountType
    check (AccountType in ('voter', 'admin'))
);

create index idx_UserAccount_Username on UserAccount(Username);
create index idx_UserAccount_Email on UserAccount(Email);
create index idx_UserAccount_IsActive on UserAccount(IsActive);

-- layer 2: profile layer
create table VoterProfile (
    VoterId int identity(1,1) primary key,
    UserId int not null unique foreign key references UserAccount(UserId) on delete cascade,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    DateOfBirth date not null,
    StreetAddress nvarchar(100) not null,
    City nvarchar(50) not null,
    State nvarchar(2) not null,
    ZipCode nvarchar(10) not null,
    PrecinctId int not null,
    IsRegistered bit not null default 1,
    RegistrationDate datetime2 not null default getdate()
);

create table AdminProfile (
    AdminId int identity(1,1) primary key,
    UserId int not null unique foreign key references UserAccount(UserId) on delete cascade,
    EmployeeId nvarchar(20) not null unique,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    PositionTitle nvarchar(100) not null,
    PermissionsLevel nvarchar(50) not null,
    CreatedDate datetime2 not null default getdate(),
    IsActive bit not null default 1
);

-- layer 3: election structure layer
create table Elections (
    ElectionId int identity(1,1) primary key,
    AdminId int not null foreign key references AdminProfile(AdminId),
    ElectionName nvarchar(100) not null,
    Description nvarchar(500),
    StartDate datetime2 not null,
    EndDate datetime2 not null,
    IsPublished bit not null default 0,
    CreatedDate datetime2 not null default getdate(),
    LastModified datetime2 not null default getdate()
);

create table Offices (
    OfficeId int identity(1,1) primary key,
    ElectionId int not null foreign key references Elections(ElectionId) on delete cascade,
    OfficeTitle nvarchar(100) not null,
    Description nvarchar(500),
    SeatsAvailable int not null default 1,
    DisplayOrder int not null default 0
);

create table Candidates (
    CandidateId int identity(1,1) primary key,
    OfficeId int not null foreign key references Offices(OfficeId) on delete cascade,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    PartyAffiliation nvarchar(50),
    Biography nvarchar(1000),
    DisplayOrder int not null default 0
);

create table Measures (
    MeasureId int identity(1,1) primary key,
    ElectionId int not null foreign key references Elections(ElectionId) on delete cascade,
    MeasureTitle nvarchar(200) not null,
    MeasureText nvarchar(2000) not null,
    YesDescription nvarchar(500),
    NoDescription nvarchar(500),
    DisplayOrder int not null default 0
);

-- layer 4: voting layer
create table Ballots (
    BallotId int identity(1,1) primary key,
    VoterId int not null foreign key references VoterProfile(VoterId),
    ElectionId int not null foreign key references Elections(ElectionId),
    SubmissionStatus nvarchar(20) not null default 'draft',
    CastAt datetime2 null,
    CreatedAt datetime2 not null default getdate(),
    SessionToken nvarchar(256) not null unique
);

create unique index uq_BallotVoterElection on Ballots(VoterId, ElectionId);

create table Votes (
    VoteId int identity(1,1) primary key,
    BallotId int not null foreign key references Ballots(BallotId) on delete cascade,
    OfficeId int null foreign key references Offices(OfficeId),
    CandidateId int null foreign key references Candidates(CandidateId),
    MeasureId int null foreign key references Measures(MeasureId),
    SelectionValue nvarchar(200) not null,
    RecordedAt datetime2 not null default getdate()
);

-- layer 5: audit
create table AuditLog (
    AuditId int identity(1,1) primary key,
    AdminId int null foreign key references AdminProfile(AdminId),
    Action nvarchar(100) not null,
    TableName nvarchar(50) not null,
    RecordId int null,
    OldValues nvarchar(max),
    NewValues nvarchar(max),
    ActionDate datetime2 not null default getdate(),
    IpAddress nvarchar(50)
);
go

-- views
create view VotingResultsSummary as
select 
    e.ElectionId,
    e.ElectionName,
    count(distinct b.BallotId) as TotalBallotsCreated,
    sum(case when b.SubmissionStatus = 'cast' then 1 else 0 end) as CastVotes,
    cast(sum(case when b.SubmissionStatus = 'cast' then 1 else 0 end) * 100.0 
         / nullif(count(distinct b.BallotId), 0) as decimal(5,2)) as VoteTurnoutPercent
from Elections e
left join Ballots b on e.ElectionId = b.ElectionId
group by e.ElectionId, e.ElectionName;
go

create view CandidateVoteCount as
select 
    c.CandidateId,
    c.FirstName,
    c.LastName,
    c.PartyAffiliation,
    o.OfficeId,
    o.OfficeTitle,
    e.ElectionId,
    e.ElectionName,
    count(v.VoteId) as VoteCount
from Candidates c
inner join Offices o on c.OfficeId = o.OfficeId
inner join Elections e on o.ElectionId = e.ElectionId
left join Votes v on c.CandidateId = v.CandidateId
group by c.CandidateId, c.FirstName, c.LastName, c.PartyAffiliation,
         o.OfficeId, o.OfficeTitle, e.ElectionId, e.ElectionName;
go

create view MeasureVoteCount as
select 
    m.MeasureId,
    m.MeasureTitle,
    e.ElectionId,
    e.ElectionName,
    sum(case when v.SelectionValue = 'yes' then 1 else 0 end) as YesVotes,
    sum(case when v.SelectionValue = 'no' then 1 else 0 end) as NoVotes,
    count(v.VoteId) as TotalVotes
from Measures m
inner join Elections e on m.ElectionId = e.ElectionId
left join Votes v on m.MeasureId = v.MeasureId
group by m.MeasureId, m.MeasureTitle, e.ElectionId, e.ElectionName;
go