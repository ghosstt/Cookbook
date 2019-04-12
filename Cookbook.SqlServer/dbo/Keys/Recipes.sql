ALTER TABLE [dbo].[Recipes]
	ADD CONSTRAINT [PK_Recipes_RecipeId]
	PRIMARY KEY NONCLUSTERED([RecipeId]);
GO

ALTER TABLE [dbo].[Recipes]
	ADD CONSTRAINT [FK_Recipes_UserId]
	FOREIGN KEY([UserId])
	REFERENCES [dbo].[Users]([UserId])
	ON UPDATE CASCADE
	ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Recipes]
	ADD CONSTRAINT [CK_Recipes_Key1]
	UNIQUE([UserID], [Name]);
GO
