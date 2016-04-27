-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TimeScanSet'
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TimeScanSet'
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
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'TimeScanSet'
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'TimeScanSet'
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
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TimeScanSet'
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TimeScanSet'
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TimeScanSet'
ALTER TABLE [dbo].[TimeScanSet]
ADD CONSTRAINT [PK_TimeScanSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTimeScan'
-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTimeScan'
-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTimeScan'
CREATE INDEX [IX_FK_EmployeeTimeScan]
ON [dbo].[TimeScanSet]
    ([EmployeeId]);