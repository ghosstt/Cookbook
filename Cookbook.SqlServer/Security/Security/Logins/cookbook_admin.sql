CREATE LOGIN [cookbook_admin]
      WITH PASSWORD = N'xfemxSywKoMlzUczfxcXnvvVmsFT7_&#$!~<ogmwizqaaong'
    , SID = 0x1FAC72DFF0E24A42B1785027513DEED7
    , DEFAULT_DATABASE = [WFS]
    , DEFAULT_LANGUAGE = [us_english]
    , CHECK_POLICY = OFF
    , CHECK_EXPIRATION = OFF;
GO

EXEC sp_addsrvrolemember 
      @loginame = N'cookbook_admin'
    , @rolename = N'sysadmin';
GO
