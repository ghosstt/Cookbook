CREATE TABLE [dbo].[RecipeIngredients]
(
	  [RecipeIngredientId] INT NOT NULL IDENTITY(1, 1)
	, [RecipeId] INT NOT NULL
	, [IngredientId] INT NOT NULL

    , CONSTRAINT [PK_Recipes_RecipeIngredientId]
      PRIMARY KEY NONCLUSTERED ([RecipeIngredientId] ASC)

    , CONSTRAINT [FK_RecipeIngredients_RecipeId]
      FOREIGN KEY ([RecipeId])
      REFERENCES [dbo].[Recipes] ([RecipeId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION

    , CONSTRAINT [FK_RecipeIngredients_IngredientId]
      FOREIGN KEY ([IngredientId])
      REFERENCES [dbo].[Ingredients] ([IngredientId])
      ON UPDATE NO ACTION
      ON DELETE NO ACTION
);
