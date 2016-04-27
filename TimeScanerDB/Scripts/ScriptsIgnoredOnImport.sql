
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2016 00:56:10
-- Generated from EDMX file: c:\Users\phatcharin\Documents\Visual Studio 2015\Projects\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2016 01:18:52
-- Generated from EDMX file: c:\Users\phatcharin\Documents\Visual Studio 2015\Projects\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2016 20:30:49
-- Generated from EDMX file: E:\Project\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanerDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeTimeScan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeScanSet] DROP CONSTRAINT [FK_EmployeeTimeScan];
GO

IF OBJECT_ID(N'[dbo].[FK_EmployeeAbsence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbsenceSet] DROP CONSTRAINT [FK_EmployeeAbsence];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2016 22:15:55
-- Generated from EDMX file: C:\Users\BugLord\Desktop\Project\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanerDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeTimeScan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeScanSet] DROP CONSTRAINT [FK_EmployeeTimeScan];
GO

IF OBJECT_ID(N'[dbo].[FK_EmployeeAbsence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbsenceSet] DROP CONSTRAINT [FK_EmployeeAbsence];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2016 22:49:17
-- Generated from EDMX file: C:\Users\BugLord\Desktop\Project\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanerDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeTimeScan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeScanSet] DROP CONSTRAINT [FK_EmployeeTimeScan];
GO

IF OBJECT_ID(N'[dbo].[FK_EmployeeAbsence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbsenceSet] DROP CONSTRAINT [FK_EmployeeAbsence];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO

IF OBJECT_ID(N'[dbo].[TempEmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TempEmployeeSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/26/2016 22:41:44
-- Generated from EDMX file: C:\Users\joker\Documents\Git\timescan\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanerDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeTimeScan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeScanSet] DROP CONSTRAINT [FK_EmployeeTimeScan];
GO

IF OBJECT_ID(N'[dbo].[FK_EmployeeAbsence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbsenceSet] DROP CONSTRAINT [FK_EmployeeAbsence];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO

IF OBJECT_ID(N'[dbo].[TempEmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TempEmployeeSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/26/2016 22:48:43
-- Generated from EDMX file: C:\Users\joker\Documents\Git\timescan\TimeScanner.DSA\EF\TimeScannerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [TimeScanerDB];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeTimeScan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeScanSet] DROP CONSTRAINT [FK_EmployeeTimeScan];
GO

IF OBJECT_ID(N'[dbo].[FK_EmployeeAbsence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbsenceSet] DROP CONSTRAINT [FK_EmployeeAbsence];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeScanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeScanSet];
GO

IF OBJECT_ID(N'[dbo].[AbsenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbsenceSet];
GO

IF OBJECT_ID(N'[dbo].[CalendarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarSet];
GO

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO

IF OBJECT_ID(N'[dbo].[TempEmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TempEmployeeSet];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO
