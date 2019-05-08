CREATE TABLE [Security].[Permissions]
(
	  [PermissionId] INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(128) NOT NULL
    , [Description] VARCHAR(512) NULL
    , [PermissionGroupId] INT NOT NULL

    , CONSTRAINT [PK_Permissions_PermissionId]
      PRIMARY KEY NONCLUSTERED ([PermissionId] ASC)

    , CONSTRAINT [UK_Permissions_Name_PermissionGroupId]
      UNIQUE ([Name], [PermissionGroupId])

    , CONSTRAINT [FK_Permissions_PermissionGroupId]
      FOREIGN KEY ([PermissionGroupId])
      REFERENCES [Security].[PermissionGroups] ([PermissionGroupId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION
);
