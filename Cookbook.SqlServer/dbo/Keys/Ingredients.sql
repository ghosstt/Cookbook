ALTER TABLE [dbo].[Ingredients]
	ADD CONSTRAINT [PK_Ingredients_IngredientId]
	PRIMARY KEY NONCLUSTERED([IngredientId]);
GO

ALTER TABLE [dbo].[Ingredients]
	ADD CONSTRAINT [FK_Ingredients_UserId]
	FOREIGN KEY([UserId])
	REFERENCES [dbo].[Users]([UserId])
	ON UPDATE CASCADE
	ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Ingredients]
	ADD CONSTRAINT [CK_Ingredients_Key1]
	UNIQUE([UserID], [Name]);
GO
