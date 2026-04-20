use VotingSystemDB;
go

-- 1. create admin user 
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('HuskersAdmin', 'AE4F2B96EF123FF6D8DD1C74FA7E77F8E2837F30F9E8FBFBC3B6A9EF4B5C6D7E8', 'admin@pacopolis.gov', 'admin', 1);

declare @adminUserId1 int = (select UserId from UserAccount where Username = 'HuskersAdmin');

insert into AdminProfile (UserId, EmployeeId, FirstName, LastName, PositionTitle, PermissionsLevel, IsActive)
values (@adminUserId1, 'ADM001', 'Husker', 'Administrator', 'Election Director', 'SuperAdmin', 1);

-- 2. create voter users (15 voters)

-- Voter 1
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Bob', '5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', 'bob.voter@email.com', 'voter', 1);
declare @voterUserId1 int = (select UserId from UserAccount where Username = 'Bob');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId1, 'Billy', 'Bob', '1985-03-15', '123 Main Street', 'Pacopolis', 'CA', '12345', 1, 1);

-- Voter 2
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Jdoe', '1A2B3C4D5E6F7G8H9I0J1K2L3M4N5O6P', 'jane.doe@email.com', 'voter', 1);
declare @voterUserId2 int = (select UserId from UserAccount where Username = 'Jdoe');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId2, 'Jane', 'Doe', '1978-07-22', '456 Oak Avenue', 'Pacopolis', 'CA', '12345', 1, 1);

-- Voter 3
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Tbrown', '2B3C4D5E6F7G8H9I0J1K2L3M4N5O6P7Q', 'tom.brown@email.com', 'voter', 1);
declare @voterUserId3 int = (select UserId from UserAccount where Username = 'Tbrown');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId3, 'Tom', 'Brown', '1990-11-08', '789 Elm Street', 'Pacopolis', 'CA', '12346', 1, 1);

-- Voter 4
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Sjones', '3C4D5E6F7G8H9I0J1K2L3M4N5O6P7Q8R', 'sarah.jones@email.com', 'voter', 1);
declare @voterUserId4 int = (select UserId from UserAccount where Username = 'Sjones');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId4, 'Sarah', 'Jones', '1992-05-12', '321 Pine Road', 'Pacopolis', 'CA', '12346', 1, 1);

-- Voter 5
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Mgarcia', '4D5E6F7G8H9I0J1K2L3M4N5O6P7Q8R9S', 'maria.garcia@email.com', 'voter', 1);
declare @voterUserId5 int = (select UserId from UserAccount where Username = 'Mgarcia');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId5, 'Maria', 'Garcia', '1988-09-30', '654 Maple Drive', 'Pacopolis', 'CA', '12347', 2, 1);

-- Voter 6
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Dchen', '5E6F7G8H9I0J1K2L3M4N5O6P7Q8R9S0T', 'david.chen@email.com', 'voter', 1);
declare @voterUserId6 int = (select UserId from UserAccount where Username = 'Dchen');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId6, 'David', 'Chen', '1995-02-14', '987 Birch Lane', 'Pacopolis', 'CA', '12347', 2, 1);

-- Voter 7
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Alopez', '6F7G8H9I0J1K2L3M4N5O6P7Q8R9S0T1U', 'anna.lopez@email.com', 'voter', 1);
declare @voterUserId7 int = (select UserId from UserAccount where Username = 'Alopez');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId7, 'Anna', 'Lopez', '1986-12-25', '147 Cedar Court', 'Pacopolis', 'CA', '12348', 2, 1);

-- Voter 8
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Ckim', '7G8H9I0J1K2L3M4N5O6P7Q8R9S0T1U2V', 'chris.kim@email.com', 'voter', 1);
declare @voterUserId8 int = (select UserId from UserAccount where Username = 'Ckim');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId8, 'Chris', 'Kim', '1991-06-18', '258 Spruce Street', 'Pacopolis', 'CA', '12348', 3, 1);

-- Voter 9
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Rmiller', '8H9I0J1K2L3M4N5O6P7Q8R9S0T1U2V3W', 'rachel.miller@email.com', 'voter', 1);
declare @voterUserId9 int = (select UserId from UserAccount where Username = 'Rmiller');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId9, 'Rachel', 'Miller', '1989-08-07', '369 Walnut Avenue', 'Pacopolis', 'CA', '12349', 3, 1);

-- Voter 10
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Ptaylor', '9I0J1K2L3M4N5O6P7Q8R9S0T1U2V3W4X', 'paul.taylor@email.com', 'voter', 1);
declare @voterUserId10 int = (select UserId from UserAccount where Username = 'Ptaylor');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId10, 'Paul', 'Taylor', '1987-01-20', '741 Chestnut Road', 'Pacopolis', 'CA', '12349', 3, 1);

-- Voter 11
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Lwhite', 'AJ0K1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5', 'laura.white@email.com', 'voter', 1);
declare @voterUserId11 int = (select UserId from UserAccount where Username = 'Lwhite');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId11, 'Laura', 'White', '1993-04-11', '852 Hickory Street', 'Pacopolis', 'CA', '12350', 4, 1);

-- Voter 12
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Jhall', 'BK1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6', 'james.hall@email.com', 'voter', 1);
declare @voterUserId12 int = (select UserId from UserAccount where Username = 'Jhall');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId12, 'James', 'Hall', '1980-10-03', '963 Ash Lane', 'Pacopolis', 'CA', '12350', 4, 1);

-- Voter 13
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Emorgan', 'CL2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7', 'emma.morgan@email.com', 'voter', 1);
declare @voterUserId13 int = (select UserId from UserAccount where Username = 'Emorgan');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId13, 'Emma', 'Morgan', '1994-03-26', '159 Willow Court', 'Pacopolis', 'CA', '12351', 4, 1);

-- Voter 14
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Bking', 'DM3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7B8', 'brian.king@email.com', 'voter', 1);
declare @voterUserId14 int = (select UserId from UserAccount where Username = 'Bking');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId14, 'Brian', 'King', '1982-07-09', '357 Sycamore Street', 'Pacopolis', 'CA', '12351', 5, 1);

-- Voter 15
insert into UserAccount (Username, PasswordHash, Email, AccountType, IsActive)
values ('Vscott', 'EN4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7B8C9', 'victoria.scott@email.com', 'voter', 1);
declare @voterUserId15 int = (select UserId from UserAccount where Username = 'Vscott');

insert into VoterProfile (UserId, FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PrecinctId, IsRegistered)
values (@voterUserId15, 'Victoria', 'Scott', '1996-09-02', '486 Poplar Drive', 'Pacopolis', 'CA', '12351', 5, 1);

-- 3. create elections
declare @adminId int = (select AdminId from AdminProfile where UserId = @adminUserId1);

insert into Elections (AdminId, ElectionName, Description, StartDate, EndDate, IsPublished)
values (@adminId, '2026 Mayoral Election', 'Election for Mayor of Pacopolis.', '2026-04-09 08:00:00', '2026-04-30 20:00:00', 1);

declare @electionId1 int = (select top 1 ElectionId from Elections where ElectionName = '2026 Mayoral Election' order by ElectionId desc);

-- 4. create office
insert into Offices (ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder)
values (@electionId1, 'Mayor', 'Chief Executive Officer of Pacopolis', 1, 1);

declare @officeId1 int = (select top 1 OfficeId from Offices where OfficeTitle = 'Mayor' order by OfficeId desc);

-- 5. create candidates
insert into Candidates (OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder)
values 
(@officeId1, 'Pat', 'Mann', 'Independent', '20 years of community service.', 1),
(@officeId1, 'Dawn', 'Keykong', 'Republican', 'Environmental sustainability focus.', 2),
(@officeId1, 'Richard', 'Silverstein', 'Democratic', 'Focus on education and healthcare.', 3);

-- 6. create measures
insert into Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder)
values 
(@electionId1, 'Measure A: Increase Sales Tax', 'Increase sales tax by 0.5% for infrastructure?', 'Support roads/bridges', 'Oppose tax', 1),
(@electionId1, 'Measure B: Park Expansion', 'Allocate $5M for city parks?', 'Support green spaces', 'Oppose spending', 2);

-- 7. create ballot (FIXED)
insert into Ballots (VoterId, ElectionId, SubmissionStatus, CastAt, SessionToken)
select VoterId, @electionId1, 'cast', getdate(), 'SESSION_' + convert(varchar(50), newid())
from VoterProfile
where UserId = @voterUserId1;

declare @ballotId1 int = scope_identity();

-- votes
insert into Votes (BallotId, OfficeId, CandidateId, SelectionValue)
select @ballotId1, @officeId1, CandidateId, 'Pat Mann'
from Candidates where FirstName = 'Pat' and LastName = 'Mann';

insert into Votes (BallotId, MeasureId, SelectionValue)
select @ballotId1, MeasureId, 'yes'
from Measures where MeasureTitle = 'Measure A: Increase Sales Tax';