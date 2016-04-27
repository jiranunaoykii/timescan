
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2016 19:05:31
-- Generated from EDMX file: C:\Users\AOYKII\Desktop\Project\Project\TimeScanner\TimeScanner.DSA\EF\TimeScannerDB.edmx
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
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TimeScanSet'
CREATE TABLE [dbo].[TimeScanSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeIn] datetime  NULL,
    [TimeOut] datetime  NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'AbsenceSet'
CREATE TABLE [dbo].[AbsenceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AbsenceDate] datetime  NOT NULL,
    [Document] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'CalendarSet'
CREATE TABLE [dbo].[CalendarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueDate] datetime  NOT NULL,
    [Activity] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [IsWorkingDay] bit  NOT NULL
);
GO

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeCode] nvarchar(max)  NOT NULL,
    [PID] nvarchar(max)  NOT NULL,
    [TitleName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Tel] nvarchar(max)  NULL
);
GO

-- Creating table 'TempEmployeeSet'
CREATE TABLE [dbo].[TempEmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitleName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [PID] nvarchar(max)  NOT NULL,
    [Token] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TimeScanSet'
ALTER TABLE [dbo].[TimeScanSet]
ADD CONSTRAINT [PK_TimeScanSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AbsenceSet'
ALTER TABLE [dbo].[AbsenceSet]
ADD CONSTRAINT [PK_AbsenceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarSet'
ALTER TABLE [dbo].[CalendarSet]
ADD CONSTRAINT [PK_CalendarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TempEmployeeSet'
ALTER TABLE [dbo].[TempEmployeeSet]
ADD CONSTRAINT [PK_TempEmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'TimeScanSet'
ALTER TABLE [dbo].[TimeScanSet]
ADD CONSTRAINT [FK_EmployeeTimeScan]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTimeScan'
CREATE INDEX [IX_FK_EmployeeTimeScan]
ON [dbo].[TimeScanSet]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'AbsenceSet'
ALTER TABLE [dbo].[AbsenceSet]
ADD CONSTRAINT [FK_EmployeeAbsence]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeAbsence'
CREATE INDEX [IX_FK_EmployeeAbsence]
ON [dbo].[AbsenceSet]
    ([EmployeeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------