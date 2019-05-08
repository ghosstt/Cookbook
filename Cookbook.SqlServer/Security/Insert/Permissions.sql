BEGIN TRY
    BEGIN TRANSACTION
        -----[ Create Temp Table ]-----
        SELECT * INTO #Permissions FROM [Security].[Permissions] WHERE 1 = 0;

        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Recipe.Add', 'Add Recipe', 1);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Recipe.Edit', 'Edit Recipe', 1);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Recipe.Delete', 'Delete Recipe', 1);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Recipe.Get', 'Get Recipe', 1);

        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Ingredient.Add', 'Add Ingredient', 2);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Ingredient.Edit', 'Edit Ingredient', 2);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Ingredient.Delete', 'Delete Ingredient', 2);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('Ingredient.Get', 'Get Ingredient', 2);

        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('User.Add', 'Add User', 3);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('User.Edit', 'Edit User', 3);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('User.Delete', 'Delete User', 3);
        INSERT INTO #Permissions ([Name], [Description], [PermissionGroupId]) VALUES ('User.Get', 'Get User', 3);

        -----[ Merge ]-----
        MERGE [Security].[Permissions] AS [orig]
        USING (SELECT * FROM #Permissions) AS [temp]
        ON ([orig].[PermissionId] = [temp].[PermissionId])
        WHEN MATCHED THEN
            UPDATE SET
                  [orig].[Name] = [temp].[Name]
                , [orig].[Description] = [temp].[Description]
                , [orig].[PermissionGroupId] = [temp].[PermissionGroupId]
        WHEN NOT MATCHED THEN
            INSERT ([Name], [Description], [PermissionGroupId])
            VALUES ([temp].[Name], [temp].[Description], [temp].[PermissionGroupId]);

        -----[ Drop Temp Table ]-----
        DROP TABLE #Permissions;

        COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	--IF (XACT_STATE()) = -1
    ROLLBACK TRANSACTION;

    IF EXISTS (SELECT TOP 1 1 FROM tempdb.sys.tables WHERE [name] LIKE '#Permissions%')
    BEGIN
        DROP TABLE #Permissions;
    END;

	-- RAISERROR(ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE());
    PRINT CONCAT(
          'Security.Permissions'
        , ', Message: ', ERROR_MESSAGE()
        , ', Line: ', CAST(ERROR_LINE() AS VARCHAR(5))
        , ', Severity: ', CAST(ERROR_SEVERITY() AS VARCHAR(5))
        , ', Number: ', CAST(ERROR_NUMBER() AS VARCHAR(5))
        , ', State: ', CAST(ERROR_STATE() AS VARCHAR(5))
        , ', Procedure: ', ERROR_PROCEDURE());
END CATCH;
