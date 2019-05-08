CREATE TABLE [Security].[UserRoles]
(
	  [UserRoleId] INT NOT NULL IDENTITY(1, 1)
	--, [UserId] INT NOT NULL
    , [UserId] UNIQUEIDENTIFIER NOT NULL
	, [RoleId] INT NOT NULL

    , CONSTRAINT [PK_UserRoles_UserRoleId]
      PRIMARY KEY NONCLUSTERED ([UserRoleId] ASC)

    , CONSTRAINT [UK_UserRoles_UserId_RoleId]
      UNIQUE ([UserId], [RoleId])

    , CONSTRAINT [FK_UserRoles_UserId]
      FOREIGN KEY ([UserId])
      REFERENCES [Security].[Users] ([UserId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION

    , CONSTRAINT [FK_UserRoles_RoleId]
      FOREIGN KEY ([RoleId])
      REFERENCES [Security].[Roles] ([RoleId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION
);
