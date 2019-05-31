CREATE TRIGGER [UserTrigger]
    ON [Security].[Users]
    FOR INSERT, DELETE
    NOT FOR REPLICATION
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [Security].[UserAudits]
    (
          [UserId]
	    , [FirstName]
	    , [LastName]
	    , [UserName]
        , [EmailAddress]
        , [PasswordHash]
	    , [PasswordSalt]
        , [CreatedDate]
        , [AuditCreatedDate]
        , [Operation]
    )
    SELECT
          [UserId]
	    , [FirstName]
	    , [LastName]
	    , [UserName]
        , [EmailAddress]
        , [PasswordHash]
	    , [PasswordSalt]
        , [CreatedDate]
        , GETUTCDATE()
        'INS'
    FROM
        inserted i
    UNION ALL
    SELECT
          [UserId]
	    , [FirstName]
	    , [LastName]
	    , [UserName]
        , [EmailAddress]
        , [PasswordHash]
	    , [PasswordSalt]
        , [CreatedDate]
        , GETUTCDATE()
        'DEL'
    FROM
        deleted d;
END;
