CREATE TABLE [dbo].[Users]
(
	  [UserId] INT NOT NULL IDENTITY(1, 1)
	, [UserName] VARCHAR(64) NOT NULL
	, [PasswordHash] VARBINARY(260)
	, [PasswordSalt] VARBINARY(260)
	, [FirstName] VARCHAR(64)
	, [LastName] VARCHAR(64)
);

