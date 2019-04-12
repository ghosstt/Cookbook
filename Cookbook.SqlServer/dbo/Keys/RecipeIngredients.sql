ALTER TABLE [dbo].[RecipeIngredients]
	ADD CONSTRAINT [PK_Recipes_RecipeIngredientId]
	PRIMARY KEY NONCLUSTERED([RecipeIngredientId]);
GO

ALTER TABLE [dbo].[RecipeIngredients]
	ADD CONSTRAINT [FK_RecipeIngredients_RecipeId]
	FOREIGN KEY([RecipeId])
	REFERENCES [dbo].[Recipes]([RecipeId])
	ON UPDATE CASCADE
	ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[RecipeIngredients]
	ADD CONSTRAINT [FK_RecipeIngredients_IngredientId]
	FOREIGN KEY([IngredientId])
	REFERENCES [dbo].[Ingredients]([IngredientId])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;
GO
