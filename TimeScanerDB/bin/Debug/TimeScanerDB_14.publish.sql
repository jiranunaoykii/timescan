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
PRINT N'Starting rebuilding table [dbo].[CalendarSet]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CalendarSet] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [IssueDate]    DATETIME       NOT NULL,
    [Activity]     NVARCHAR (MAX) NOT NULL,
    [Note]         NVARCHAR (MAX) NULL,
    [StartTime]    DATETIME       NOT NULL,
    [EndTime]      DATETIME       NOT NULL,
    [IsWorkingDay] BIT            NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_CalendarSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CalendarSet])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CalendarSet] ON;
        INSERT INTO [dbo].[tmp_ms_xx_CalendarSet] ([Id], [IssueDate], [Activity], [StartTime], [EndTime], [IsWorkingDay])
        SELECT   [Id],
                 [IssueDate],
                 [Activity],
                 [StartTime],
                 [EndTime],
                 [IsWorkingDay]
        FROM     [dbo].[CalendarSet]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_CalendarSet] OFF;
    END

DROP TABLE [dbo].[CalendarSet];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CalendarSet]', N'CalendarSet';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_CalendarSet]', N'PK_CalendarSet', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
