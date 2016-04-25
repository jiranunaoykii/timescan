-- Creating table 'AbsenceSet'
CREATE TABLE [dbo].[AbsenceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AbsenceDate] datetime  NOT NULL,
    [Document] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [EmployeeId] int  NOT NULL
);
GO
-- Creating foreign key on [EmployeeId] in table 'AbsenceSet'
ALTER TABLE [dbo].[AbsenceSet]
ADD CONSTRAINT [FK_EmployeeAbsence]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'AbsenceSet'
ALTER TABLE [dbo].[AbsenceSet]
ADD CONSTRAINT [PK_AbsenceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeAbsence'
CREATE INDEX [IX_FK_EmployeeAbsence]
ON [dbo].[AbsenceSet]
    ([EmployeeId]);