CREATE TABLE [dbo].[Ingredients]
(
	  [IngredientId] INT NOT NULL IDENTITY(1, 1)
	--, [UserId] INT NOT NULL
    , [UserId] UNIQUEIDENTIFIER NOT NULL
	, [Name] VARCHAR(128) NOT NULL
	, [Description] VARCHAR(512)
	, [ImgSrc] VARCHAR(512)
	, [CreatedDate] DATETIME2  NOT NULL DEFAULT GETDATE()

    , CONSTRAINT [PK_Ingredients_IngredientId]
      PRIMARY KEY NONCLUSTERED ([IngredientId] ASC)

    , CONSTRAINT [FK_Ingredients_UserId]
      FOREIGN KEY ([UserId])
      REFERENCES [Security].[Users] ([UserId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION

    , CONSTRAINT [CK_Ingredients_Key1]
      UNIQUE ([UserId], [Name])
);
