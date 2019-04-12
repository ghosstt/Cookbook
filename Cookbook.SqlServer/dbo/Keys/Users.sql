﻿ALTER TABLE [dbo].[Users]
	ADD CONSTRAINT [PK_Users_UserId]
	PRIMARY KEY NONCLUSTERED([UserId]);
GO

ALTER TABLE [dbo].[Users]
	ADD CONSTRAINT [UK_Users_UserName]
	UNIQUE([UserName]);
GO
