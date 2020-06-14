
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/10/2020 17:07:25
-- Generated from EDMX file: C:\Users\GENC\source\repos\Hastane\Hastane\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Hastane];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Calisanlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calisanlar];
GO
IF OBJECT_ID(N'[dbo].[CalisanTc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalisanTc];
GO
IF OBJECT_ID(N'[dbo].[Doktorlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doktorlar];
GO
IF OBJECT_ID(N'[dbo].[DoktorTc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoktorTc];
GO
IF OBJECT_ID(N'[dbo].[HastaTc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HastaTc];
GO
IF OBJECT_ID(N'[dbo].[Musteriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Musteriler];
GO
IF OBJECT_ID(N'[dbo].[Randevular]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Randevular];
GO
IF OBJECT_ID(N'[dbo].[Raporlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Raporlar];
GO
IF OBJECT_ID(N'[dbo].[Reçeteler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reçeteler];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Calisanlar'
CREATE TABLE [dbo].[Calisanlar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CalisanAdi] nvarchar(50)  NULL,
    [CalisanSifre] nvarchar(50)  NULL,
    [CalisanTc] nvarchar(50)  NULL
);
GO

-- Creating table 'Doktorlar'
CREATE TABLE [dbo].[Doktorlar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DoktorAdi] nvarchar(50)  NULL,
    [Bolum] nvarchar(50)  NULL,
    [DoktorTc] nvarchar(50)  NULL,
    [DoktorSifre] nvarchar(50)  NULL
);
GO

-- Creating table 'Musteriler'
CREATE TABLE [dbo].[Musteriler] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MusteriAdi] nvarchar(50)  NULL,
    [MusteriSifre] nvarchar(50)  NULL,
    [MusteriTc] nvarchar(50)  NULL
);
GO

-- Creating table 'Randevular'
CREATE TABLE [dbo].[Randevular] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HastaAdi] nvarchar(50)  NULL,
    [DoktorAdi] nvarchar(50)  NULL,
    [Bolum] nvarchar(50)  NULL,
    [RandevuSaati] nvarchar(50)  NULL,
    [HastaTc] nvarchar(50)  NULL,
    [DoktorTc] nvarchar(50)  NULL
);
GO

-- Creating table 'DoktorTc'
CREATE TABLE [dbo].[DoktorTc] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tcNoDoktor] nvarchar(50)  NULL
);
GO

-- Creating table 'HastaTc'
CREATE TABLE [dbo].[HastaTc] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tcNoHasta] nvarchar(50)  NULL,
    [HastaAdi] nvarchar(50)  NULL
);
GO

-- Creating table 'Reçeteler'
CREATE TABLE [dbo].[Reçeteler] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HastaAdi] nvarchar(50)  NULL,
    [Tarih] datetime  NULL,
    [DoktorAdi] nvarchar(50)  NULL,
    [Ilaclar] nvarchar(50)  NULL,
    [Tutar] nvarchar(50)  NULL
);
GO

-- Creating table 'CalisanTc'
CREATE TABLE [dbo].[CalisanTc] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tcNoCalisan] nvarchar(50)  NULL
);
GO

-- Creating table 'Raporlar'
CREATE TABLE [dbo].[Raporlar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HastaAdi] nvarchar(50)  NULL,
    [Tarih] datetime  NULL,
    [RaporBaslangic] datetime  NULL,
    [RaporBitis] datetime  NULL,
    [RaporSebebi] nvarchar(50)  NULL,
    [RaporuVerenDoktor] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Calisanlar'
ALTER TABLE [dbo].[Calisanlar]
ADD CONSTRAINT [PK_Calisanlar]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doktorlar'
ALTER TABLE [dbo].[Doktorlar]
ADD CONSTRAINT [PK_Doktorlar]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Musteriler'
ALTER TABLE [dbo].[Musteriler]
ADD CONSTRAINT [PK_Musteriler]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Randevular'
ALTER TABLE [dbo].[Randevular]
ADD CONSTRAINT [PK_Randevular]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoktorTc'
ALTER TABLE [dbo].[DoktorTc]
ADD CONSTRAINT [PK_DoktorTc]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HastaTc'
ALTER TABLE [dbo].[HastaTc]
ADD CONSTRAINT [PK_HastaTc]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reçeteler'
ALTER TABLE [dbo].[Reçeteler]
ADD CONSTRAINT [PK_Reçeteler]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalisanTc'
ALTER TABLE [dbo].[CalisanTc]
ADD CONSTRAINT [PK_CalisanTc]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Raporlar'
ALTER TABLE [dbo].[Raporlar]
ADD CONSTRAINT [PK_Raporlar]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------