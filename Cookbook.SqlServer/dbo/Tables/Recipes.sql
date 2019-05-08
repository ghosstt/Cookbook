CREATE TABLE [dbo].[Recipes]
(
	  [RecipeId] INT NOT NULL IDENTITY(1, 1)
	--, [UserId] INT NOT NULL
    , [UserId] UNIQUEIDENTIFIER NOT NULL
	, [Name] VARCHAR(128) NOT NULL
	, [Description] VARCHAR(512)
	, [ImgSrc] VARCHAR(512)
	, [CreatedDate] DATETIME2  NOT NULL DEFAULT GETDATE()

    , CONSTRAINT [PK_Recipes_RecipeId]
      PRIMARY KEY NONCLUSTERED ([RecipeId] ASC)

    , CONSTRAINT [FK_Recipes_UserId]
      FOREIGN KEY ([UserId])
      REFERENCES [Security].[Users] ([UserId])
      ON UPDATE CASCADE
      ON DELETE NO ACTION

    , CONSTRAINT [CK_Recipes_Key1]
      UNIQUE ([UserId], [Name])
);
