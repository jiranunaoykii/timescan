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
-- Creating primary key on [Id] in table 'TempEmployeeSet'
ALTER TABLE [dbo].[TempEmployeeSet]
ADD CONSTRAINT [PK_TempEmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);