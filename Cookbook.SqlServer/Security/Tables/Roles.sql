CREATE TABLE [Security].[Roles]
(
	  [RoleId] INT NOT NULL IDENTITY(1, 1)
	, [Name] VARCHAR(128) NOT NULL

    , CONSTRAINT [PK_Roles_RoleId]
      PRIMARY KEY NONCLUSTERED ([RoleId] ASC)

    , CONSTRAINT [UK_Roles_Name]
      UNIQUE ([Name])
);
