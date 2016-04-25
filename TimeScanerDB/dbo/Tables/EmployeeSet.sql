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
-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);