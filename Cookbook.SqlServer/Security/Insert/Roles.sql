BEGIN TRY
    BEGIN TRANSACTION
        -----[ Create Temp Table ]-----
        SELECT * INTO #Roles FROM [Security].[Roles] WHERE 1 = 0;

        INSERT INTO #Roles ([Name]) VALUES ('Admin');
        INSERT INTO #Roles ([Name]) VALUES ('User');

        -----[ Merge ]-----
        MERGE [Security].[Roles] AS [orig]
        USING (SELECT * FROM #Roles) AS [temp]
        ON ([orig].[RoleId] = [temp].[RoleId])
        WHEN MATCHED THEN
            UPDATE SET
                [orig].[Name] = [temp].[Name]
        WHEN NOT MATCHED THEN
            INSERT ([Name])
            VALUES ([temp].[Name]);

        -----[ Drop Temp Table ]-----
        DROP TABLE #Roles;

        COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	--IF (XACT_STATE()) = -1
    ROLLBACK TRANSACTION;

    IF EXISTS (SELECT TOP 1 1 FROM tempdb.sys.tables WHERE [name] LIKE '#Roles%')
    BEGIN
        DROP TABLE #Roles;
    END;

    -- RAISERROR(ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE());
    PRINT CONCAT(
          'Security.Roles'
        , ', Message: ', ERROR_MESSAGE()
        , ', Line: ', CAST(ERROR_LINE() AS VARCHAR(5))
        , ', Severity: ', CAST(ERROR_SEVERITY() AS VARCHAR(5))
        , ', Number: ', CAST(ERROR_NUMBER() AS VARCHAR(5))
        , ', State: ', CAST(ERROR_STATE() AS VARCHAR(5))
        , ', Procedure: ', ERROR_PROCEDURE());
END CATCH;
