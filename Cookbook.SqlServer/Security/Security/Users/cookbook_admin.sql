CREATE USER [cookbook_admin] FOR LOGIN [cookbook_admin];
GO

EXEC sp_addrolemember N'db_owner', N'cookbook_admin';
GO

GRANT CONNECT TO [cookbook_admin];
GO
