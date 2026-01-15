IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProjectPos')
BEGIN
    CREATE DATABASE ProjectPos;
END
GO
