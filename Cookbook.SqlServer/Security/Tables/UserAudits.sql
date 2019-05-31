CREATE TABLE [Security].[UserAudits]
(
      [UserAuditId] INT NOT NULL IDENTITY(1, 1)
    , [UserId] UNIQUEIDENTIFIER NOT NULL
	, [FirstName] VARCHAR(128) NOT NULL
	, [LastName] VARCHAR(128) MASKED WITH (FUNCTION='partial(2, "----", 0)') NOT NULL
	, [UserName] VARCHAR(128) MASKED WITH (FUNCTION='default()') NOT NULL
    , [EmailAddress] VARCHAR(128) MASKED WITH (FUNCTION='email()') NULL
    , [PasswordHash] VARBINARY(260) NOT NULL
	, [PasswordSalt] VARBINARY(260) NOT NULL

    -- , [CreatedBy] INT NOT NULL
    , [CreatedDate] DATETIME NOT NULL
    , [AuditCreatedDate] DATETIME NOT NULL DEFAULT (GETUTCDATE())
    -- , [LastUpdatedBy] INT NOT NULL
    -- , [LastUpdatedDate] DATETIME NOT NULL DEFAULT (GETUTCDATE())
    --, [OptimisticLockField] ROWVERSION NOT NULL
    , [Operation] CHAR(3) NOT NULL
    , CHECK([Operation] = 'INS' OR [Operation] = 'DEL')

    , CONSTRAINT [PK_UserAudits_UserAuditId]
      PRIMARY KEY NONCLUSTERED ([UserAuditId] ASC)

    , CONSTRAINT [UK_UserAudits_UserName]
      UNIQUE ([UserName])
)
