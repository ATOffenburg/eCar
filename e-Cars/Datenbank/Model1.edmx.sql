
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2015 15:30:28
-- Generated from EDMX file: C:\Users\Torsten\Documents\GitHub\eCar\e-Cars\Datenbank\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Projekt2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Abgabeort_Tankaeule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fahrt] DROP CONSTRAINT [FK_Abgabeort_Tankaeule];
GO
IF OBJECT_ID(N'[dbo].[FK_Abgabeort_Tankstelle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_Abgabeort_Tankstelle];
GO
IF OBJECT_ID(N'[dbo].[FK_Abholort_Tanksaeule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fahrt] DROP CONSTRAINT [FK_Abholort_Tanksaeule];
GO
IF OBJECT_ID(N'[dbo].[FK_Abholort_Tankstelle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_Abholort_Tankstelle];
GO
IF OBJECT_ID(N'[dbo].[FK_Car_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK_Car_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Fahrt_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fahrt] DROP CONSTRAINT [FK_Fahrt_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_Fahrt_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fahrt] DROP CONSTRAINT [FK_Fahrt_Kunde];
GO
IF OBJECT_ID(N'[dbo].[FK_Fahrt_Reservierung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fahrt] DROP CONSTRAINT [FK_Fahrt_Reservierung];
GO
IF OBJECT_ID(N'[dbo].[FK_Karte_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Karte] DROP CONSTRAINT [FK_Karte_Kunde];
GO
IF OBJECT_ID(N'[dbo].[FK_Kunde_Adresse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kunde] DROP CONSTRAINT [FK_Kunde_Adresse];
GO
IF OBJECT_ID(N'[dbo].[FK_Kunde_Bank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kunde] DROP CONSTRAINT [FK_Kunde_Bank];
GO
IF OBJECT_ID(N'[dbo].[FK_Rechnung_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kunde] DROP CONSTRAINT [FK_Rechnung_Kunde];
GO
IF OBJECT_ID(N'[dbo].[FK_Rechnung_Kunde1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rechnung] DROP CONSTRAINT [FK_Rechnung_Kunde1];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservierung_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_Reservierung_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservierung_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_Reservierung_Kunde];
GO
IF OBJECT_ID(N'[dbo].[FK_ResStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_ResStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Tanksaeule_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tanksaeule] DROP CONSTRAINT [FK_Tanksaeule_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_Tanksaeule_Tankstelle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tanksaeule] DROP CONSTRAINT [FK_Tanksaeule_Tankstelle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Adresse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adresse];
GO
IF OBJECT_ID(N'[dbo].[Bank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bank];
GO
IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO
IF OBJECT_ID(N'[dbo].[Fahrt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fahrt];
GO
IF OBJECT_ID(N'[dbo].[GlobaleEinstellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlobaleEinstellungen];
GO
IF OBJECT_ID(N'[dbo].[Karte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Karte];
GO
IF OBJECT_ID(N'[dbo].[Kunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunde];
GO
IF OBJECT_ID(N'[dbo].[Rechnung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rechnung];
GO
IF OBJECT_ID(N'[dbo].[Reservierung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservierung];
GO
IF OBJECT_ID(N'[dbo].[ResStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResStatus];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Tanksaeule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tanksaeule];
GO
IF OBJECT_ID(N'[dbo].[Tankstelle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tankstelle];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adresse'
CREATE TABLE [dbo].[Adresse] (
    [Adress_ID] int IDENTITY(1,1) NOT NULL,
    [PLZ] varchar(10)  NOT NULL,
    [Ort] varchar(200)  NOT NULL,
    [Strasse] varchar(200)  NOT NULL,
    [Hausnummer] varchar(200)  NOT NULL
);
GO

-- Creating table 'Bank'
CREATE TABLE [dbo].[Bank] (
    [Bank_ID] int IDENTITY(1,1) NOT NULL,
    [BIC] varchar(200)  NULL,
    [IBAN] varchar(200)  NULL
);
GO

-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [Car_ID] int IDENTITY(1,1) NOT NULL,
    [Seriennummer] varchar(100)  NULL,
    [Status_ID] int  NULL,
    [Gesperrt] bit  NULL,
    [SpontaneNutzungGesperrt] bit  NULL,
    [ReservierungGesperrt] bit  NULL,
    [Tankvorgaenge] int  NOT NULL,
    [Kilometerstand] float  NULL,
    [Batterieladung] int  NULL,
    [Wartungstermin] datetime  NULL,
    [StatusGeaendert] bit  NOT NULL,
    [Gestohlen] bit  NULL,
    [breitengrad] float  NULL,
    [laengengrad] float  NULL
);
GO

-- Creating table 'Fahrt'
CREATE TABLE [dbo].[Fahrt] (
    [Fahrt_ID] int IDENTITY(1,1) NOT NULL,
    [Abholort] int  NOT NULL,
    [Abgabeort] int  NOT NULL,
    [Startzeit] datetime  NULL,
    [Endzeit] datetime  NULL,
    [Start_KM] float  NULL,
    [End_KM] float  NULL,
    [Car_ID] int  NULL,
    [Kunde_ID] int  NULL,
    [Reservierung_ID] int  NULL
);
GO

-- Creating table 'GlobaleEinstellungen'
CREATE TABLE [dbo].[GlobaleEinstellungen] (
    [Schluessel] varchar(50)  NOT NULL,
    [Wert] varchar(max)  NULL,
    [Standard] varchar(max)  NULL
);
GO

-- Creating table 'Karte'
CREATE TABLE [dbo].[Karte] (
    [Karten_ID] int IDENTITY(1,1) NOT NULL,
    [Kunde_ID] int  NOT NULL,
    [Aktiv] bit  NOT NULL,
    [Sperrdatum] datetime  NULL,
    [Sperrvermerk] nvarchar(50)  NULL,
    [Seriennummer] nvarchar(50)  NULL
);
GO

-- Creating table 'Kunde'
CREATE TABLE [dbo].[Kunde] (
    [Kunde_ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Vorname] varchar(max)  NOT NULL,
    [Passwort] varchar(max)  NOT NULL,
    [Adress_ID] int  NOT NULL,
    [RechnungAdr_ID] int  NULL,
    [Bank_ID] int  NOT NULL,
    [Gesperrt] bit  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [FKopie] varbinary(max)  NULL
);
GO

-- Creating table 'Rechnung'
CREATE TABLE [dbo].[Rechnung] (
    [Rechnung_ID] int IDENTITY(1,1) NOT NULL,
    [Kunden_ID] int  NOT NULL,
    [Betrag] float  NOT NULL,
    [Datum] datetime  NOT NULL
);
GO

-- Creating table 'Reservierung'
CREATE TABLE [dbo].[Reservierung] (
    [Reservierung_ID] int IDENTITY(1,1) NOT NULL,
    [Startzeit] datetime  NOT NULL,
    [Endzeit] datetime  NULL,
    [Abholort] int  NOT NULL,
    [Abgabeort] int  NULL,
    [Car_ID] int  NULL,
    [Kunde_ID] int  NULL,
    [Zeitstempel] datetime  NOT NULL,
    [ResStatus_ID] int  NOT NULL
);
GO

-- Creating table 'ResStatus'
CREATE TABLE [dbo].[ResStatus] (
    [ResStatus_ID] int IDENTITY(1,1) NOT NULL,
    [Statusbezeichnung] nvarchar(50)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [Status_ID] int IDENTITY(1,1) NOT NULL,
    [Statusbezeichnung] nvarchar(50)  NULL
);
GO

-- Creating table 'Tanksaeule'
CREATE TABLE [dbo].[Tanksaeule] (
    [Tanksaeule_ID] int IDENTITY(1,1) NOT NULL,
    [Tankstelle_ID] int  NOT NULL,
    [Tanksaeule_Nr] int  NOT NULL,
    [Car_ID] int  NULL
);
GO

-- Creating table 'Tankstelle'
CREATE TABLE [dbo].[Tankstelle] (
    [Tankstelle_ID] int IDENTITY(1,1) NOT NULL,
    [breitengrad] float  NULL,
    [laengengrad] float  NULL,
    [PLZ] varchar(max)  NULL,
    [Ort] varchar(max)  NULL,
    [Stasse] varchar(max)  NOT NULL,
    [Name] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Adress_ID] in table 'Adresse'
ALTER TABLE [dbo].[Adresse]
ADD CONSTRAINT [PK_Adresse]
    PRIMARY KEY CLUSTERED ([Adress_ID] ASC);
GO

-- Creating primary key on [Bank_ID] in table 'Bank'
ALTER TABLE [dbo].[Bank]
ADD CONSTRAINT [PK_Bank]
    PRIMARY KEY CLUSTERED ([Bank_ID] ASC);
GO

-- Creating primary key on [Car_ID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([Car_ID] ASC);
GO

-- Creating primary key on [Fahrt_ID] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [PK_Fahrt]
    PRIMARY KEY CLUSTERED ([Fahrt_ID] ASC);
GO

-- Creating primary key on [Schluessel] in table 'GlobaleEinstellungen'
ALTER TABLE [dbo].[GlobaleEinstellungen]
ADD CONSTRAINT [PK_GlobaleEinstellungen]
    PRIMARY KEY CLUSTERED ([Schluessel] ASC);
GO

-- Creating primary key on [Karten_ID] in table 'Karte'
ALTER TABLE [dbo].[Karte]
ADD CONSTRAINT [PK_Karte]
    PRIMARY KEY CLUSTERED ([Karten_ID] ASC);
GO

-- Creating primary key on [Kunde_ID] in table 'Kunde'
ALTER TABLE [dbo].[Kunde]
ADD CONSTRAINT [PK_Kunde]
    PRIMARY KEY CLUSTERED ([Kunde_ID] ASC);
GO

-- Creating primary key on [Rechnung_ID] in table 'Rechnung'
ALTER TABLE [dbo].[Rechnung]
ADD CONSTRAINT [PK_Rechnung]
    PRIMARY KEY CLUSTERED ([Rechnung_ID] ASC);
GO

-- Creating primary key on [Reservierung_ID] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [PK_Reservierung]
    PRIMARY KEY CLUSTERED ([Reservierung_ID] ASC);
GO

-- Creating primary key on [ResStatus_ID] in table 'ResStatus'
ALTER TABLE [dbo].[ResStatus]
ADD CONSTRAINT [PK_ResStatus]
    PRIMARY KEY CLUSTERED ([ResStatus_ID] ASC);
GO

-- Creating primary key on [Status_ID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([Status_ID] ASC);
GO

-- Creating primary key on [Tanksaeule_ID] in table 'Tanksaeule'
ALTER TABLE [dbo].[Tanksaeule]
ADD CONSTRAINT [PK_Tanksaeule]
    PRIMARY KEY CLUSTERED ([Tanksaeule_ID] ASC);
GO

-- Creating primary key on [Tankstelle_ID] in table 'Tankstelle'
ALTER TABLE [dbo].[Tankstelle]
ADD CONSTRAINT [PK_Tankstelle]
    PRIMARY KEY CLUSTERED ([Tankstelle_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Adress_ID] in table 'Kunde'
ALTER TABLE [dbo].[Kunde]
ADD CONSTRAINT [FK_Kunde_Adresse]
    FOREIGN KEY ([Adress_ID])
    REFERENCES [dbo].[Adresse]
        ([Adress_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kunde_Adresse'
CREATE INDEX [IX_FK_Kunde_Adresse]
ON [dbo].[Kunde]
    ([Adress_ID]);
GO

-- Creating foreign key on [Bank_ID] in table 'Kunde'
ALTER TABLE [dbo].[Kunde]
ADD CONSTRAINT [FK_Kunde_Bank]
    FOREIGN KEY ([Bank_ID])
    REFERENCES [dbo].[Bank]
        ([Bank_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kunde_Bank'
CREATE INDEX [IX_FK_Kunde_Bank]
ON [dbo].[Kunde]
    ([Bank_ID]);
GO

-- Creating foreign key on [Status_ID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK_Car_Status]
    FOREIGN KEY ([Status_ID])
    REFERENCES [dbo].[Status]
        ([Status_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_Status'
CREATE INDEX [IX_FK_Car_Status]
ON [dbo].[Car]
    ([Status_ID]);
GO

-- Creating foreign key on [Car_ID] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [FK_Fahrt_Car]
    FOREIGN KEY ([Car_ID])
    REFERENCES [dbo].[Car]
        ([Car_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fahrt_Car'
CREATE INDEX [IX_FK_Fahrt_Car]
ON [dbo].[Fahrt]
    ([Car_ID]);
GO

-- Creating foreign key on [Car_ID] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_Reservierung_Car]
    FOREIGN KEY ([Car_ID])
    REFERENCES [dbo].[Car]
        ([Car_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservierung_Car'
CREATE INDEX [IX_FK_Reservierung_Car]
ON [dbo].[Reservierung]
    ([Car_ID]);
GO

-- Creating foreign key on [Car_ID] in table 'Tanksaeule'
ALTER TABLE [dbo].[Tanksaeule]
ADD CONSTRAINT [FK_Tanksaeule_Car]
    FOREIGN KEY ([Car_ID])
    REFERENCES [dbo].[Car]
        ([Car_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tanksaeule_Car'
CREATE INDEX [IX_FK_Tanksaeule_Car]
ON [dbo].[Tanksaeule]
    ([Car_ID]);
GO

-- Creating foreign key on [Abgabeort] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [FK_Abgabeort_Tankaeule]
    FOREIGN KEY ([Abgabeort])
    REFERENCES [dbo].[Tankstelle]
        ([Tankstelle_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Abgabeort_Tankaeule'
CREATE INDEX [IX_FK_Abgabeort_Tankaeule]
ON [dbo].[Fahrt]
    ([Abgabeort]);
GO

-- Creating foreign key on [Abholort] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [FK_Abholort_Tanksaeule]
    FOREIGN KEY ([Abholort])
    REFERENCES [dbo].[Tankstelle]
        ([Tankstelle_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Abholort_Tanksaeule'
CREATE INDEX [IX_FK_Abholort_Tanksaeule]
ON [dbo].[Fahrt]
    ([Abholort]);
GO

-- Creating foreign key on [Kunde_ID] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [FK_Fahrt_Kunde]
    FOREIGN KEY ([Kunde_ID])
    REFERENCES [dbo].[Kunde]
        ([Kunde_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fahrt_Kunde'
CREATE INDEX [IX_FK_Fahrt_Kunde]
ON [dbo].[Fahrt]
    ([Kunde_ID]);
GO

-- Creating foreign key on [Reservierung_ID] in table 'Fahrt'
ALTER TABLE [dbo].[Fahrt]
ADD CONSTRAINT [FK_Fahrt_Reservierung]
    FOREIGN KEY ([Reservierung_ID])
    REFERENCES [dbo].[Reservierung]
        ([Reservierung_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fahrt_Reservierung'
CREATE INDEX [IX_FK_Fahrt_Reservierung]
ON [dbo].[Fahrt]
    ([Reservierung_ID]);
GO

-- Creating foreign key on [Kunde_ID] in table 'Karte'
ALTER TABLE [dbo].[Karte]
ADD CONSTRAINT [FK_Karte_Kunde]
    FOREIGN KEY ([Kunde_ID])
    REFERENCES [dbo].[Kunde]
        ([Kunde_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Karte_Kunde'
CREATE INDEX [IX_FK_Karte_Kunde]
ON [dbo].[Karte]
    ([Kunde_ID]);
GO

-- Creating foreign key on [Kunde_ID] in table 'Kunde'
ALTER TABLE [dbo].[Kunde]
ADD CONSTRAINT [FK_Rechnung_Kunde]
    FOREIGN KEY ([Kunde_ID])
    REFERENCES [dbo].[Kunde]
        ([Kunde_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Kunden_ID] in table 'Rechnung'
ALTER TABLE [dbo].[Rechnung]
ADD CONSTRAINT [FK_Rechnung_Kunde1]
    FOREIGN KEY ([Kunden_ID])
    REFERENCES [dbo].[Kunde]
        ([Kunde_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rechnung_Kunde1'
CREATE INDEX [IX_FK_Rechnung_Kunde1]
ON [dbo].[Rechnung]
    ([Kunden_ID]);
GO

-- Creating foreign key on [Kunde_ID] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_Reservierung_Kunde]
    FOREIGN KEY ([Kunde_ID])
    REFERENCES [dbo].[Kunde]
        ([Kunde_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservierung_Kunde'
CREATE INDEX [IX_FK_Reservierung_Kunde]
ON [dbo].[Reservierung]
    ([Kunde_ID]);
GO

-- Creating foreign key on [Abgabeort] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_Abgabeort_Tankstelle]
    FOREIGN KEY ([Abgabeort])
    REFERENCES [dbo].[Tankstelle]
        ([Tankstelle_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Abgabeort_Tankstelle'
CREATE INDEX [IX_FK_Abgabeort_Tankstelle]
ON [dbo].[Reservierung]
    ([Abgabeort]);
GO

-- Creating foreign key on [Abholort] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_Abholort_Tankstelle]
    FOREIGN KEY ([Abholort])
    REFERENCES [dbo].[Tankstelle]
        ([Tankstelle_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Abholort_Tankstelle'
CREATE INDEX [IX_FK_Abholort_Tankstelle]
ON [dbo].[Reservierung]
    ([Abholort]);
GO

-- Creating foreign key on [ResStatus_ID] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_ResStatus]
    FOREIGN KEY ([ResStatus_ID])
    REFERENCES [dbo].[ResStatus]
        ([ResStatus_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResStatus'
CREATE INDEX [IX_FK_ResStatus]
ON [dbo].[Reservierung]
    ([ResStatus_ID]);
GO

-- Creating foreign key on [Tankstelle_ID] in table 'Tanksaeule'
ALTER TABLE [dbo].[Tanksaeule]
ADD CONSTRAINT [FK_Tanksaeule_Tankstelle]
    FOREIGN KEY ([Tankstelle_ID])
    REFERENCES [dbo].[Tankstelle]
        ([Tankstelle_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tanksaeule_Tankstelle'
CREATE INDEX [IX_FK_Tanksaeule_Tankstelle]
ON [dbo].[Tanksaeule]
    ([Tankstelle_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------