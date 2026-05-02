use VotingSystemDB;
go

-- 1. create admin user 
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('admin', 'admin', 'admin@pacopolis.gov', 'admin', 1);

declare @adminUserId1 int = (select UserId from UserAccount where Username = 'admin');

insert into AdminProfile (UserId, EmployeeId, FirstName, LastName, PositionTitle, PermissionsLevel, IsActive)
values (@adminUserId1, 'ADM001', 'Husker', 'Administrator', 'Election Director', 'SuperAdmin', 1);

-- 2. create voter users (15 voters)

-- Voter 1
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Bob', 'Burger', 'bob.voter@email.com', 'voter', 1);
declare @voterUserId1 int = (select UserId from UserAccount where Username = 'Bob');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId1, 'Billy', 'Bob', '1985-03-15', '123 Main Street', 'Pacopolis', 'CA', '12345', 1, 1);

-- Voter 2
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Jdoe', 'Pizza', 'jane.doe@email.com', 'voter', 1);
declare @voterUserId2 int = (select UserId from UserAccount where Username = 'Jdoe');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId2, 'Jane', 'Doe', '1978-07-22', '456 Oak Avenue', 'Pacopolis', 'CA', '12345', 1, 1);

-- Voter 3
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Tbrown', 'Sandwich', 'tom.brown@email.com', 'voter', 1);
declare @voterUserId3 int = (select UserId from UserAccount where Username = 'Tbrown');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId3, 'Tom', 'Brown', '1990-11-08', '789 Elm Street', 'Pacopolis', 'CA', '12346', 1, 1);

-- Voter 4
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Sjones', 'Pasta', 'sarah.jones@email.com', 'voter', 1);
declare @voterUserId4 int = (select UserId from UserAccount where Username = 'Sjones');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId4, 'Sarah', 'Jones', '1992-05-12', '321 Pine Road', 'Pacopolis', 'CA', '12346', 1, 1);

-- Voter 5
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Mgarcia', 'Steak', 'maria.garcia@email.com', 'voter', 1);
declare @voterUserId5 int = (select UserId from UserAccount where Username = 'Mgarcia');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId5, 'Maria', 'Garcia', '1988-09-30', '654 Maple Drive', 'Pacopolis', 'CA', '12347', 2, 1);

-- Voter 6
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Dchen', 'Chicken', 'david.chen@email.com', 'voter', 1);
declare @voterUserId6 int = (select UserId from UserAccount where Username = 'Dchen');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId6, 'David', 'Chen', '1995-02-14', '987 Birch Lane', 'Pacopolis', 'CA', '12347', 2, 1);

-- Voter 7
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Alopez', 'Wings', 'anna.lopez@email.com', 'voter', 1);
declare @voterUserId7 int = (select UserId from UserAccount where Username = 'Alopez');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId7, 'Anna', 'Lopez', '1986-12-25', '147 Cedar Court', 'Pacopolis', 'CA', '12348', 2, 1);

-- Voter 8
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Ckim', 'Apple', 'chris.kim@email.com', 'voter', 1);
declare @voterUserId8 int = (select UserId from UserAccount where Username = 'Ckim');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId8, 'Chris', 'Kim', '1991-06-18', '258 Spruce Street', 'Pacopolis', 'CA', '12348', 3, 1);

-- Voter 9
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Rmiller', 'Tacos', 'rachel.miller@email.com', 'voter', 1);
declare @voterUserId9 int = (select UserId from UserAccount where Username = 'Rmiller');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId9, 'Rachel', 'Miller', '1989-08-07', '369 Walnut Avenue', 'Pacopolis', 'CA', '12349', 3, 1);

-- Voter 10
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Ptaylor', 'Buffalo', 'paul.taylor@email.com', 'voter', 1);
declare @voterUserId10 int = (select UserId from UserAccount where Username = 'Ptaylor');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId10, 'Paul', 'Taylor', '1987-01-20', '741 Chestnut Road', 'Pacopolis', 'CA', '12349', 3, 1);

-- Voter 11
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Lwhite', 'Donuts', 'laura.white@email.com', 'voter', 1);
declare @voterUserId11 int = (select UserId from UserAccount where Username = 'Lwhite');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId11, 'Laura', 'White', '1993-04-11', '852 Hickory Street', 'Pacopolis', 'CA', '12350', 4, 1);

-- Voter 12
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Jhall', 'Eggs', 'james.hall@email.com', 'voter', 1);
declare @voterUserId12 int = (select UserId from UserAccount where Username = 'Jhall');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId12, 'James', 'Hall', '1980-10-03', '963 Ash Lane', 'Pacopolis', 'CA', '12350', 4, 1);

-- Voter 13
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Emorgan', 'Coffee', 'emma.morgan@email.com', 'voter', 1);
declare @voterUserId13 int = (select UserId from UserAccount where Username = 'Emorgan');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId13, 'Emma', 'Morgan', '1994-03-26', '159 Willow Court', 'Pacopolis', 'CA', '12351', 4, 1);

-- Voter 14
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Bking', 'Water', 'brian.king@email.com', 'voter', 1);
declare @voterUserId14 int = (select UserId from UserAccount where Username = 'Bking');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId14, 'Brian', 'King', '1982-07-09', '357 Sycamore Street', 'Pacopolis', 'CA', '12351', 5, 1);

-- Voter 15
insert into UserAccount (Username, UserPassword, Email, AccountType, IsActive)
values ('Vscott', 'Muffin', 'victoria.scott@email.com', 'voter', 1);
declare @voterUserId15 int = (select UserId from UserAccount where Username = 'Vscott');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId15, 'Victoria', 'Scott', '1996-09-02', '486 Poplar Drive', 'Pacopolis', 'CA', '12351', 5, 1);

-- 3. create elections 

declare @adminId int = (select AdminId from AdminProfile where UserId = @adminUserId1);

-- Election 1: Mayor Election
insert into Elections (AdminId, ElectionName, Description, StartDate, EndDate, IsPublished)
values (@adminId, 'Mayor Election', 'Election for Mayor of Pacopolis.', '2026-04-09 08:00:00', '2026-04-30 20:00:00', 1);

declare @electionId1 int = scope_identity();

-- Election 2: City Council Election
insert into Elections (AdminId, ElectionName, Description, StartDate, EndDate, IsPublished)
values (@adminId, 'City Council Election', 'Election for Pacopolis City Council seats.', '2026-04-09 08:00:00', '2026-04-30 20:00:00', 1);

declare @electionId2 int = scope_identity();

-- Election 3: School Board Election
insert into Elections (AdminId, ElectionName, Description, StartDate, EndDate, IsPublished)
values (@adminId, 'School Board Election', 'Election for Pacopolis Unified School Board.', '2026-04-09 08:00:00', '2026-04-30 20:00:00', 1);

declare @electionId3 int = scope_identity();

-- 4. create offices

-- Election 1 office
insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId1, 'Mayor', 'Chief Executive Officer of Pacopolis', 1, 1);

declare @officeId1 int = scope_identity();

-- Election 2 offices
insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId2, 'City Council District 1', 'Representative for District 1', 1, 1);

declare @officeId2 int = scope_identity();

insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId2, 'City Council District 2', 'Representative for District 2', 1, 2);

declare @officeId3 int = scope_identity();

-- Election 3 offices
insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId3, 'School Board Seat A', 'School Board Member, Seat A', 1, 1);

declare @officeId4 int = scope_identity();

insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId3, 'School Board Seat B', 'School Board Member, Seat B', 1, 2);

declare @officeId5 int = scope_identity();

-- 5. create candidates

-- Mayor candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values 
(@officeId1, 'Pat',     'Mann',        'Independent', '20 years of community service.',       1),
(@officeId1, 'Dawn',    'Keykong',     'Republican',  'Environmental sustainability focus.',   2),
(@officeId1, 'Richard', 'Silverstein', 'Democratic',  'Focus on education and healthcare.',    3);

-- City Council District 1 candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values
(@officeId2, 'Linda',   'Foster',   'Democratic',  'Former city planner with 15 years experience.', 1),
(@officeId2, 'Marcus',  'Reed',     'Republican',  'Small business owner and community advocate.',  2);

-- City Council District 2 candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values
(@officeId3, 'Sandra',  'Wu',       'Democratic',  'Neighborhood association president.',           1),
(@officeId3, 'Derek',   'Howell',   'Independent', 'Retired police captain, public safety focus.',  2);

-- School Board Seat A candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values
(@officeId4, 'Nancy',   'Ortega',   null,          'Parent, former teacher, curriculum advocate.',  1),
(@officeId4, 'Frank',   'Adeyemi',  null,          'Principal with 12 years in Pacopolis schools.', 2);

-- School Board Seat B candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values
(@officeId5, 'Tricia',  'Bloom',    null,          'Special education coordinator.',                1),
(@officeId5, 'Carl',    'Nunes',    null,          'Youth sports coach and budget reform advocate.', 2);

-- 6. create measures

-- Mayor election measures
insert into Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder)
values 
(@electionId1, 'Measure A: Increase Sales Tax', 'Increase sales tax by 0.5% for infrastructure?', 'Support roads/bridges', 'Oppose tax increase', 1),
(@electionId1, 'Measure B: Park Expansion',     'Allocate $5M for city parks?',                   'Support green spaces',  'Oppose spending',     2);

-- City Council election measures
insert into Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder)
values
(@electionId2, 'Measure C: Downtown Parking', 'Build a new public parking structure downtown?', 'Support parking expansion', 'Oppose the project', 1);

-- School Board election measures
insert into Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder)
values
(@electionId3, 'Measure D: School Bond',      'Issue $20M bond for school facility upgrades?',   'Support school improvements', 'Oppose bond measure', 1),
(@electionId3, 'Measure E: School Start Time', 'Move high school start time to 8:30 AM?',        'Support later start time',    'Keep current schedule', 2);

-- 7. create ballots for voter 1 across all 3 elections

-- Ballot 1: Voter 1 - Mayor Election
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId1, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId1;

declare @ballotId1 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId1, @officeId1, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Pat' and LastName = 'Mann';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId1, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure A: Increase Sales Tax';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId1, MeasureId, 'no'
from Measures where MeasureTitle = 'Measure B: Park Expansion';

-- Ballot 2: Voter 1 - City Council Election
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId2, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId1;

declare @ballotId2 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId2, @officeId2, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Linda' and LastName = 'Foster';

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId2, @officeId3, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Sandra' and LastName = 'Wu';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId2, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure C: Downtown Parking';

-- Ballot 3: Voter 1 - School Board Election
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId3, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId1;

declare @ballotId3 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId3, @officeId4, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Nancy' and LastName = 'Ortega';

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId3, @officeId5, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Tricia' and LastName = 'Bloom';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId3, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure D: School Bond';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId3, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure E: School Start Time';

-- 8. additional cast ballots from other voters 

-- Voter 2 - all 3 elections
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId1, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId2;
declare @b_v2_e1 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v2_e1, @officeId1, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Dawn' and LastName = 'Keykong';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @b_v2_e1, MeasureId, 'no'
from Measures where MeasureTitle = 'Measure A: Increase Sales Tax';

insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId2, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId2;
declare @b_v2_e2 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v2_e2, @officeId2, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Marcus' and LastName = 'Reed';

insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId3, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId2;
declare @b_v2_e3 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v2_e3, @officeId4, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Frank' and LastName = 'Adeyemi';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @b_v2_e3, MeasureId, 'no'
from Measures where MeasureTitle = 'Measure D: School Bond';

-- Voter 3 - Mayor and School Board only
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId1, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId3;
declare @b_v3_e1 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v3_e1, @officeId1, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Richard' and LastName = 'Silverstein';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @b_v3_e1, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure B: Park Expansion';

insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId3, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId3;
declare @b_v3_e3 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v3_e3, @officeId5, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Carl' and LastName = 'Nunes';

-- Voter 4 - City Council only (draft, not yet cast)
insert into Ballots (VoterId, ElectionId, SubmissionStatus, StartDate, SessionToken)
select VoterId, @electionId2, 'draft', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId4;

-- Voter 5 - Mayor Election cast
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId1, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile where UserId = @voterUserId5;
declare @b_v5_e1 int = scope_identity();

insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @b_v5_e1, @officeId1, CandidateId, FirstName + ' ' + LastName
from Candidates where FirstName = 'Pat' and LastName = 'Mann';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @b_v5_e1, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure A: Increase Sales Tax';