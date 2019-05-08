CREATE TABLE [Security].[PermissionGroups]
(
	  [PermissionGroupId] INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(128) NOT NULL
    , [Description] VARCHAR(512) NULL

    , CONSTRAINT [PK_PermissionGroups_PermissionId]
      PRIMARY KEY NONCLUSTERED ([PermissionGroupId] ASC)

    , CONSTRAINT [UK_PermissionGroups_Name]
      UNIQUE ([Name])
);
