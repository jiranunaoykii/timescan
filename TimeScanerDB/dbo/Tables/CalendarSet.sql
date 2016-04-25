-- Creating table 'CalendarSet'
CREATE TABLE [dbo].[CalendarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IssueDate] datetime  NOT NULL,
    [Activity] nvarchar(max)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL
);
GO
-- Creating primary key on [Id] in table 'CalendarSet'
ALTER TABLE [dbo].[CalendarSet]
ADD CONSTRAINT [PK_CalendarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);