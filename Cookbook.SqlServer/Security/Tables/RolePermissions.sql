CREATE TABLE [Security].[RolePermissions]
(
	  [RolePermissionId] INT NOT NULL IDENTITY(1, 1)
    , [RoleId] INT NOT NULL
    , [PermissionId] INT NOT NULL

    , CONSTRAINT [PK_RolePermissions_RolePermissionId]
      PRIMARY KEY NONCLUSTERED ([RolePermissionId] ASC)

    , CONSTRAINT [UK_RolePermissions_RoleId_PermissionId]
      UNIQUE ([RoleId], [PermissionId])

    , CONSTRAINT [FK_RolePermissions_RoleId]
      FOREIGN KEY ([RoleId])
      REFERENCES [Security].[Roles] ([RoleId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION

    , CONSTRAINT [FK_RolePermissions_PermissionId]
      FOREIGN KEY ([PermissionId])
      REFERENCES [Security].[Permissions] ([PermissionId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION
);
