
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2020 16:12:34
-- Generated from EDMX file: C:\Users\mitko\source\repos\TekkenProject\TekkenProject\TekkenProjectDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TekkenProjectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Characters'
CREATE TABLE [dbo].[Characters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Stats'
CREATE TABLE [dbo].[Stats] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Punishers] nvarchar(max)  NOT NULL,
    [Plus_Frame_Moves] nvarchar(max)  NOT NULL,
    [CharactersID] int  NOT NULL
);
GO

-- Creating table 'PlayStyles'
CREATE TABLE [dbo].[PlayStyles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Play_Style] nvarchar(max)  NOT NULL,
    [Difficulty] nvarchar(max)  NOT NULL,
    [CharactersID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Characters'
ALTER TABLE [dbo].[Characters]
ADD CONSTRAINT [PK_Characters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [PK_Stats]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PlayStyles'
ALTER TABLE [dbo].[PlayStyles]
ADD CONSTRAINT [PK_PlayStyles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CharactersID] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [FK_CharactersStats]
    FOREIGN KEY ([CharactersID])
    REFERENCES [dbo].[Characters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CharactersStats'
CREATE INDEX [IX_FK_CharactersStats]
ON [dbo].[Stats]
    ([CharactersID]);
GO

-- Creating foreign key on [CharactersID] in table 'PlayStyles'
ALTER TABLE [dbo].[PlayStyles]
ADD CONSTRAINT [FK_CharactersPlayStyle]
    FOREIGN KEY ([CharactersID])
    REFERENCES [dbo].[Characters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CharactersPlayStyle'
CREATE INDEX [IX_FK_CharactersPlayStyle]
ON [dbo].[PlayStyles]
    ([CharactersID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------