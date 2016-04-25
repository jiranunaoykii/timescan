﻿/*
Deployment script for TimeScanerDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TimeScanerDB"
:setvar DefaultFilePrefix "TimeScanerDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[AbsenceSet].[EmployeeCode] is being dropped, data loss could occur.

The column [dbo].[AbsenceSet].[EmployeeId] on table [dbo].[AbsenceSet] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[AbsenceSet])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[AbsenceSet]...';


GO
ALTER TABLE [dbo].[AbsenceSet] DROP COLUMN [EmployeeCode];


GO
ALTER TABLE [dbo].[AbsenceSet]
    ADD [EmployeeId] INT NOT NULL;


GO
PRINT N'Creating [dbo].[AbsenceSet].[IX_FK_EmployeeAbsence]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeAbsence]
    ON [dbo].[AbsenceSet]([EmployeeId] ASC);


GO
PRINT N'Creating [dbo].[CalendarSet]...';


GO
CREATE TABLE [dbo].[CalendarSet] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [IssueDate] DATETIME       NOT NULL,
    [Activity]  NVARCHAR (MAX) NOT NULL,
    [StartTime] DATETIME       NOT NULL,
    [EndTime]   DATETIME       NOT NULL,
    CONSTRAINT [PK_CalendarSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[EmployeeSet]...';


GO
CREATE TABLE [dbo].[EmployeeSet] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeCode] NVARCHAR (MAX) NOT NULL,
    [PID]          NVARCHAR (MAX) NOT NULL,
    [TitleName]    NVARCHAR (MAX) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [LastName]     NVARCHAR (MAX) NOT NULL,
    [Position]     NVARCHAR (MAX) NOT NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [Tel]          NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_EmployeeSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TimeScanSet]...';


GO
CREATE TABLE [dbo].[TimeScanSet] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [TimeIn]     DATETIME NOT NULL,
    [TimeOut]    DATETIME NOT NULL,
    [EmployeeId] INT      NOT NULL,
    CONSTRAINT [PK_TimeScanSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TimeScanSet].[IX_FK_EmployeeTimeScan]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeTimeScan]
    ON [dbo].[TimeScanSet]([EmployeeId] ASC);


GO
PRINT N'Creating [dbo].[FK_EmployeeTimeScan]...';


GO
ALTER TABLE [dbo].[TimeScanSet] WITH NOCHECK
    ADD CONSTRAINT [FK_EmployeeTimeScan] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[EmployeeSet] ([Id]);


GO
PRINT N'Creating [dbo].[FK_EmployeeAbsence]...';


GO
ALTER TABLE [dbo].[AbsenceSet] WITH NOCHECK
    ADD CONSTRAINT [FK_EmployeeAbsence] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[EmployeeSet] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[TimeScanSet] WITH CHECK CHECK CONSTRAINT [FK_EmployeeTimeScan];

ALTER TABLE [dbo].[AbsenceSet] WITH CHECK CHECK CONSTRAINT [FK_EmployeeAbsence];


GO
PRINT N'Update complete.';


GO
