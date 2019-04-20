CREATE TABLE [dbo].[Ingredients]
(
	  [IngredientId] INT NOT NULL IDENTITY(1, 1)
	, [UserId] INT NOT NULL
	, [Name] VARCHAR(128) NOT NULL
	, [Description] VARCHAR(512)
	, [ImgSrc] VARCHAR(512)
	, [CreatedDate] DATETIME2  NOT NULL DEFAULT GETDATE()
);
