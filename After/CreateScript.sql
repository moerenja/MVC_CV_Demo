-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bedrijf'
CREATE TABLE [dbo].[Bedrijf] (
    [BedrijfsId]		uniqueidentifier  NOT NULL,
    [Bedrijfsnaam]		nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Persoon'
CREATE TABLE [dbo].[Persoon] (
    [PersoonId]			uniqueidentifier  NOT NULL,
    [Naam]				nvarchar(50)  NOT NULL,
    [Voornaam]			nvarchar(10)  NOT NULL,
    [Voorvoegsels]		nvarchar(50)  NULL
);
GO

CREATE TABLE [dbo].[CVItem] (
	CVItemId			uniqueidentifier  NOT NULL,
	PersoonID			uniqueidentifier  NOT NULL,
	Functienaam			nvarchar(50)	  NULL,
	PeriodeVan			DateTime		  NOT NULL,
	PeriodeTot			DateTime		  NOT NULL,
	Beschrijving		nvarchar(1000)	  NULL,
	BedrijfsID			uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------
ALTER TABLE [dbo].[Bedrijf]
ADD CONSTRAINT [PK_Bedrijf]
    PRIMARY KEY CLUSTERED ([BedrijfsId] ASC);
GO

ALTER TABLE [dbo].[Persoon]
ADD CONSTRAINT [PK_Persoon]
    PRIMARY KEY CLUSTERED ([PersoonId] ASC);
GO

ALTER TABLE [dbo].[CVItem]
ADD CONSTRAINT [PK_CVItem]
    PRIMARY KEY CLUSTERED ([CVItemId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersoonId] in table 'CVItem'
ALTER TABLE [dbo].[CVItem]
ADD CONSTRAINT [FK_CVItem_Persoon]
    FOREIGN KEY ([PersoonId])
    REFERENCES [dbo].[Persoon]
        ([PersoonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CVItem_Persoon'
CREATE INDEX [IX_FK_CVItem_Persoon]
ON [dbo].[CVItem]
    ([PersoonId]);
GO

-- Creating foreign key on [BedrijfId] in table 'CVItem'
ALTER TABLE [dbo].[CVItem]
ADD CONSTRAINT [FK_CVItem_Bedrijf]
    FOREIGN KEY ([BedrijfsId])
    REFERENCES [dbo].[Bedrijf]
        ([BedrijfsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CVItem_Bedrijf'
CREATE INDEX [IX_FK_CVItem_Bedrijf]
ON [dbo].[CVItem]
    ([BedrijfsId]);
GO

INSERT INTO Persoon(PersoonId,Naam,Voornaam,Voorvoegsels)
Values(newid(),'Werkhoven','Jan','van')

INSERT INTO Bedrijf(Bedrijfsid,Bedrijfsnaam)
Values(newid(),'KLM')

declare @persoonid as uniqueidentifier
set @persoonid=(select persoonid from persoon where naam='Werkhoven')

PRINT 'Value of @myid is: '+ CONVERT(varchar(255), @persoonid)

declare @bedrijfsid as uniqueidentifier
set @bedrijfsid=(select Bedrijfsid from Bedrijf where Bedrijfsnaam='KLM')

PRINT 'Value of @myid is: '+ CONVERT(varchar(255), @bedrijfsid)

INSERT INTO CVItem(CVItemId, PersoonID,Functienaam,PeriodeVan,PeriodeTot,Beschrijving,BedrijfsID)
VALUES(newid(),@persoonid,'Serverdouwer','2012-02-01','2013-07-31','Hij deed dit en dat en nog wat',@bedrijfsid)

select * from cvitem cvi inner join persoon per on cvi.persoonid=per.persoonid