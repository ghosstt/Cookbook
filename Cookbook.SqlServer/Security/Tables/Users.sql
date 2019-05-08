CREATE TABLE [Security].[Users]
(
	  --[UserId] INT NOT NULL IDENTITY(1, 1)
      [UserId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
	, [FirstName] VARCHAR(128) NOT NULL
	, [LastName] VARCHAR(128) MASKED WITH (FUNCTION='partial(2, "----", 0)') NOT NULL
	, [UserName] VARCHAR(128) MASKED WITH (FUNCTION='default()') NOT NULL
    , [EmailAddress] VARCHAR(128) MASKED WITH (FUNCTION='email()') NULL
    , [PasswordHash] VARBINARY(260) NOT NULL
	, [PasswordSalt] VARBINARY(260) NOT NULL

    -- , [CreatedBy] INT NOT NULL
    , [CreatedDate] DATETIME NOT NULL DEFAULT (GETUTCDATE())
    -- , [LastUpdatedBy] INT NOT NULL
    -- , [LastUpdatedDate] DATETIME NOT NULL DEFAULT (GETUTCDATE())
    --, [OptimisticLockField] ROWVERSION NOT NULL

    , CONSTRAINT [PK_Users_UserId]
      PRIMARY KEY NONCLUSTERED ([UserId] ASC)

    , CONSTRAINT [UK_Users_UserName]
      UNIQUE ([UserName])
);
