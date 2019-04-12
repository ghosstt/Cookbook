CREATE TABLE [dbo].[RecipeIngredients]
(
	  [RecipeIngredientId] INT NOT NULL IDENTITY(1, 1)
	, [RecipeId] INT NOT NULL
	, [IngredientId] INT NOT NULL
);
