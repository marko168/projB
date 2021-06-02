
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 03:33:03
-- Generated from EDMX file: C:\Users\marko\Desktop\projB\projB\projB\projB\repository\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baza];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cuvar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Cuvar] DROP CONSTRAINT [FK_Cuvar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_GostSmjestaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Smjestajs] DROP CONSTRAINT [FK_GostSmjestaj];
GO
IF OBJECT_ID(N'[dbo].[FK_HotelRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_HotelRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_HotelRecepcija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recepcijas] DROP CONSTRAINT [FK_HotelRecepcija];
GO
IF OBJECT_ID(N'[dbo].[FK_HotelSoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sobas] DROP CONSTRAINT [FK_HotelSoba];
GO
IF OBJECT_ID(N'[dbo].[FK_Konobar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Konobar] DROP CONSTRAINT [FK_Konobar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_RadnikRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_RecepcijaGost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gosts] DROP CONSTRAINT [FK_RecepcijaGost];
GO
IF OBJECT_ID(N'[dbo].[FK_RecepcijaRecepcioner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Recepcioner] DROP CONSTRAINT [FK_RecepcijaRecepcioner];
GO
IF OBJECT_ID(N'[dbo].[FK_Recepcioner_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Recepcioner] DROP CONSTRAINT [FK_Recepcioner_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_RecepcionerSmjena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Recepcioner] DROP CONSTRAINT [FK_RecepcionerSmjena];
GO
IF OBJECT_ID(N'[dbo].[FK_SmjestajSoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Smjestajs] DROP CONSTRAINT [FK_SmjestajSoba];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Gosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gosts];
GO
IF OBJECT_ID(N'[dbo].[Hotels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotels];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Cuvar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Cuvar];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Konobar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Konobar];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Recepcioner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Recepcioner];
GO
IF OBJECT_ID(N'[dbo].[Recepcijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recepcijas];
GO
IF OBJECT_ID(N'[dbo].[Smjenas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Smjenas];
GO
IF OBJECT_ID(N'[dbo].[Smjestajs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Smjestajs];
GO
IF OBJECT_ID(N'[dbo].[Sobas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sobas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Gosts'
CREATE TABLE [dbo].[Gosts] (
    [MBR] int IDENTITY(1,1) NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Kontakt] nvarchar(max)  NOT NULL,
    [Datum_P] datetime  NOT NULL,
    [Vrijeme_P] nvarchar(max)  NOT NULL,
    [RecepcijaBr_Rec] int  NULL,
    [RecepcijaHotelId_Hot] int  NULL
);
GO

-- Creating table 'Hotels'
CREATE TABLE [dbo].[Hotels] (
    [Id_Hot] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Kategorija] nvarchar(max)  NOT NULL,
    [Br_Racuna] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [JMBG] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [Br_Tel] nvarchar(max)  NOT NULL,
    [RadnikJMBG] int  NOT NULL,
    [HotelId_Hot] int  NOT NULL,
    [RadnikJMBG1] int  NULL
);
GO

-- Creating table 'Smjenas'
CREATE TABLE [dbo].[Smjenas] (
    [Id_Smjene] int IDENTITY(1,1) NOT NULL,
    [Naz_Smjene] nvarchar(max)  NOT NULL,
    [Nap_Smjene] nvarchar(max)  NOT NULL,
    [Vrijeme_Od] nvarchar(max)  NOT NULL,
    [Vrijeme_Do] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Recepcijas'
CREATE TABLE [dbo].[Recepcijas] (
    [Br_Rec] int IDENTITY(1,1) NOT NULL,
    [Lokal] nvarchar(max)  NOT NULL,
    [Mjesto_Rec] nvarchar(max)  NOT NULL,
    [HotelId_Hot] int  NOT NULL
);
GO

-- Creating table 'Sobas'
CREATE TABLE [dbo].[Sobas] (
    [Br_Sobe] int IDENTITY(1,1) NOT NULL,
    [Tip] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Napomena] nvarchar(max)  NOT NULL,
    [HotelId_Hot] int  NOT NULL
);
GO

-- Creating table 'Smjestajs'
CREATE TABLE [dbo].[Smjestajs] (
    [Id_Smjestaj] int IDENTITY(1,1) NOT NULL,
    [GostMBR] int  NOT NULL,
    [SobaBr_Sobe] int  NOT NULL,
    [SobaHotelId_Hot] int  NOT NULL
);
GO

-- Creating table 'Radniks_Recepcioner'
CREATE TABLE [dbo].[Radniks_Recepcioner] (
    [JMBG] int  NOT NULL,
    [Smjena_Id_Smjene] int  NOT NULL,
    [Recepcija_Br_Rec] int  NULL,
    [Recepcija_HotelId_Hot] int  NULL
);
GO

-- Creating table 'Radniks_Konobar'
CREATE TABLE [dbo].[Radniks_Konobar] (
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Cuvar'
CREATE TABLE [dbo].[Radniks_Cuvar] (
    [JMBG] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MBR] in table 'Gosts'
ALTER TABLE [dbo].[Gosts]
ADD CONSTRAINT [PK_Gosts]
    PRIMARY KEY CLUSTERED ([MBR] ASC);
GO

-- Creating primary key on [Id_Hot] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [PK_Hotels]
    PRIMARY KEY CLUSTERED ([Id_Hot] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Id_Smjene] in table 'Smjenas'
ALTER TABLE [dbo].[Smjenas]
ADD CONSTRAINT [PK_Smjenas]
    PRIMARY KEY CLUSTERED ([Id_Smjene] ASC);
GO

-- Creating primary key on [Br_Rec], [HotelId_Hot] in table 'Recepcijas'
ALTER TABLE [dbo].[Recepcijas]
ADD CONSTRAINT [PK_Recepcijas]
    PRIMARY KEY CLUSTERED ([Br_Rec], [HotelId_Hot] ASC);
GO

-- Creating primary key on [Br_Sobe], [HotelId_Hot] in table 'Sobas'
ALTER TABLE [dbo].[Sobas]
ADD CONSTRAINT [PK_Sobas]
    PRIMARY KEY CLUSTERED ([Br_Sobe], [HotelId_Hot] ASC);
GO

-- Creating primary key on [Id_Smjestaj] in table 'Smjestajs'
ALTER TABLE [dbo].[Smjestajs]
ADD CONSTRAINT [PK_Smjestajs]
    PRIMARY KEY CLUSTERED ([Id_Smjestaj] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Recepcioner'
ALTER TABLE [dbo].[Radniks_Recepcioner]
ADD CONSTRAINT [PK_Radniks_Recepcioner]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Konobar'
ALTER TABLE [dbo].[Radniks_Konobar]
ADD CONSTRAINT [PK_Radniks_Konobar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Cuvar'
ALTER TABLE [dbo].[Radniks_Cuvar]
ADD CONSTRAINT [PK_Radniks_Cuvar]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HotelId_Hot] in table 'Recepcijas'
ALTER TABLE [dbo].[Recepcijas]
ADD CONSTRAINT [FK_HotelRecepcija]
    FOREIGN KEY ([HotelId_Hot])
    REFERENCES [dbo].[Hotels]
        ([Id_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HotelRecepcija'
CREATE INDEX [IX_FK_HotelRecepcija]
ON [dbo].[Recepcijas]
    ([HotelId_Hot]);
GO

-- Creating foreign key on [GostMBR] in table 'Smjestajs'
ALTER TABLE [dbo].[Smjestajs]
ADD CONSTRAINT [FK_GostSmjestaj]
    FOREIGN KEY ([GostMBR])
    REFERENCES [dbo].[Gosts]
        ([MBR])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GostSmjestaj'
CREATE INDEX [IX_FK_GostSmjestaj]
ON [dbo].[Smjestajs]
    ([GostMBR]);
GO

-- Creating foreign key on [HotelId_Hot] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_HotelRadnik]
    FOREIGN KEY ([HotelId_Hot])
    REFERENCES [dbo].[Hotels]
        ([Id_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HotelRadnik'
CREATE INDEX [IX_FK_HotelRadnik]
ON [dbo].[Radniks]
    ([HotelId_Hot]);
GO

-- Creating foreign key on [Smjena_Id_Smjene] in table 'Radniks_Recepcioner'
ALTER TABLE [dbo].[Radniks_Recepcioner]
ADD CONSTRAINT [FK_RecepcionerSmjena]
    FOREIGN KEY ([Smjena_Id_Smjene])
    REFERENCES [dbo].[Smjenas]
        ([Id_Smjene])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecepcionerSmjena'
CREATE INDEX [IX_FK_RecepcionerSmjena]
ON [dbo].[Radniks_Recepcioner]
    ([Smjena_Id_Smjene]);
GO

-- Creating foreign key on [HotelId_Hot] in table 'Sobas'
ALTER TABLE [dbo].[Sobas]
ADD CONSTRAINT [FK_HotelSoba]
    FOREIGN KEY ([HotelId_Hot])
    REFERENCES [dbo].[Hotels]
        ([Id_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HotelSoba'
CREATE INDEX [IX_FK_HotelSoba]
ON [dbo].[Sobas]
    ([HotelId_Hot]);
GO

-- Creating foreign key on [SobaBr_Sobe], [SobaHotelId_Hot] in table 'Smjestajs'
ALTER TABLE [dbo].[Smjestajs]
ADD CONSTRAINT [FK_SmjestajSoba]
    FOREIGN KEY ([SobaBr_Sobe], [SobaHotelId_Hot])
    REFERENCES [dbo].[Sobas]
        ([Br_Sobe], [HotelId_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmjestajSoba'
CREATE INDEX [IX_FK_SmjestajSoba]
ON [dbo].[Smjestajs]
    ([SobaBr_Sobe], [SobaHotelId_Hot]);
GO

-- Creating foreign key on [RadnikJMBG1] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_RadnikRadnik]
    FOREIGN KEY ([RadnikJMBG1])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadnikRadnik'
CREATE INDEX [IX_FK_RadnikRadnik]
ON [dbo].[Radniks]
    ([RadnikJMBG1]);
GO

-- Creating foreign key on [Recepcija_Br_Rec], [Recepcija_HotelId_Hot] in table 'Radniks_Recepcioner'
ALTER TABLE [dbo].[Radniks_Recepcioner]
ADD CONSTRAINT [FK_RecepcijaRecepcioner]
    FOREIGN KEY ([Recepcija_Br_Rec], [Recepcija_HotelId_Hot])
    REFERENCES [dbo].[Recepcijas]
        ([Br_Rec], [HotelId_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecepcijaRecepcioner'
CREATE INDEX [IX_FK_RecepcijaRecepcioner]
ON [dbo].[Radniks_Recepcioner]
    ([Recepcija_Br_Rec], [Recepcija_HotelId_Hot]);
GO

-- Creating foreign key on [RecepcijaBr_Rec], [RecepcijaHotelId_Hot] in table 'Gosts'
ALTER TABLE [dbo].[Gosts]
ADD CONSTRAINT [FK_GostRecepcija]
    FOREIGN KEY ([RecepcijaBr_Rec], [RecepcijaHotelId_Hot])
    REFERENCES [dbo].[Recepcijas]
        ([Br_Rec], [HotelId_Hot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GostRecepcija'
CREATE INDEX [IX_FK_GostRecepcija]
ON [dbo].[Gosts]
    ([RecepcijaBr_Rec], [RecepcijaHotelId_Hot]);
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Recepcioner'
ALTER TABLE [dbo].[Radniks_Recepcioner]
ADD CONSTRAINT [FK_Recepcioner_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Konobar'
ALTER TABLE [dbo].[Radniks_Konobar]
ADD CONSTRAINT [FK_Konobar_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Cuvar'
ALTER TABLE [dbo].[Radniks_Cuvar]
ADD CONSTRAINT [FK_Cuvar_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------