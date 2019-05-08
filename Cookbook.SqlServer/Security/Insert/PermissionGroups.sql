BEGIN TRY
    BEGIN TRANSACTION
        -----[ Create Temp Table ]-----
        SELECT * INTO #PermissionGroups FROM [Security].[PermissionGroups] WHERE 1 = 0;

        INSERT INTO #PermissionGroups ([Name], [Description]) VALUES ('Recipe', 'Permission Group Recipe');
        INSERT INTO #PermissionGroups ([Name], [Description]) VALUES ('Ingredient', 'Permission Group Ingredient');
        INSERT INTO #PermissionGroups ([Name], [Description]) VALUES ('User', 'Permission Group User');

        -----[ Merge ]-----
        MERGE [Security].[PermissionGroups] AS [orig]
        USING (SELECT * FROM #PermissionGroups) AS [temp]
        ON ([orig].[PermissionGroupId] = [temp].[PermissionGroupId])
        WHEN MATCHED THEN
            UPDATE SET
                  [orig].[Name] = [temp].[Name]
                , [orig].[Description] = [temp].[Description]
        WHEN NOT MATCHED THEN
            INSERT ([Name], [Description])
            VALUES ([temp].[Name], [temp].[Description]);

        -----[ Drop Temp Table ]-----
        DROP TABLE #PermissionGroups;

        COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	--IF (XACT_STATE()) = -1
    ROLLBACK TRANSACTION;

    IF EXISTS (SELECT TOP 1 1 FROM tempdb.sys.tables WHERE [name] LIKE '#PermissionGroups%')
    BEGIN
        DROP TABLE #PermissionGroups;
    END;

	-- RAISERROR(ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE());
    PRINT CONCAT(
          'Security.PermissionGroups'
        , ', Message: ', ERROR_MESSAGE()
        , ', Line: ', CAST(ERROR_LINE() AS VARCHAR(5))
        , ', Severity: ', CAST(ERROR_SEVERITY() AS VARCHAR(5))
        , ', Number: ', CAST(ERROR_NUMBER() AS VARCHAR(5))
        , ', State: ', CAST(ERROR_STATE() AS VARCHAR(5))
        , ', Procedure: ', ERROR_PROCEDURE());
END CATCH;
