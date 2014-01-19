drop table Users
drop table CompetenceAreaCategory
drop table CompetenceAreas
drop table Categories
drop table Countries


-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/02/2010 12:24:13
-- Generated from EDMX file: C:\[projects]]\MyProjects\app\TCT.Data\TCT.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TCT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_CategoryCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenceAreaCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetenceAreas] DROP CONSTRAINT [FK_CompetenceAreaCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenceAreaCategory_CompetenceArea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetenceAreaCategory] DROP CONSTRAINT [FK_CompetenceAreaCategory_CompetenceArea];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenceAreaCategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetenceAreaCategory] DROP CONSTRAINT [FK_CompetenceAreaCategory_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_CategoryCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[CompetenceAreas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetenceAreas];
GO
IF OBJECT_ID(N'[dbo].[CompetenceAreaCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetenceAreaCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [TeliaID] nvarchar(max)  NOT NULL,
    [History_CreatedBy] nvarchar(max)  NOT NULL,
    [History_Created] datetime  NOT NULL,
    [Country_Id] int  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Locale] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [History_CreatedBy] nvarchar(max)  NOT NULL,
    [History_Created] datetime  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [History_CreatedBy] nvarchar(max)  NOT NULL,
    [History_Created] datetime  NOT NULL,
    [Parent_Id] int  NULL,
    [Country_Id] int  NOT NULL
);
GO

-- Creating table 'CompetenceAreas'
CREATE TABLE [dbo].[CompetenceAreas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [History_CreatedBy] nvarchar(max)  NOT NULL,
    [History_Created] datetime  NOT NULL,
    [Country_Id] int  NOT NULL
);
GO

-- Creating table 'CompetenceAreaCategory'
CREATE TABLE [dbo].[CompetenceAreaCategory] (
    [CompetenceAreaCategory_Category_Id] int  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompetenceAreas'
ALTER TABLE [dbo].[CompetenceAreas]
ADD CONSTRAINT [PK_CompetenceAreas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CompetenceAreaCategory_Category_Id], [Categories_Id] in table 'CompetenceAreaCategory'
ALTER TABLE [dbo].[CompetenceAreaCategory]
ADD CONSTRAINT [PK_CompetenceAreaCategory]
    PRIMARY KEY NONCLUSTERED ([CompetenceAreaCategory_Category_Id], [Categories_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Country_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserCountry]
    FOREIGN KEY ([Country_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCountry'
CREATE INDEX [IX_FK_UserCountry]
ON [dbo].[Users]
    ([Country_Id]);
GO

-- Creating foreign key on [Country_Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_CategoryCountry]
    FOREIGN KEY ([Country_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCountry'
CREATE INDEX [IX_FK_CategoryCountry]
ON [dbo].[Categories]
    ([Country_Id]);
GO

-- Creating foreign key on [Country_Id] in table 'CompetenceAreas'
ALTER TABLE [dbo].[CompetenceAreas]
ADD CONSTRAINT [FK_CompetenceAreaCountry]
    FOREIGN KEY ([Country_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenceAreaCountry'
CREATE INDEX [IX_FK_CompetenceAreaCountry]
ON [dbo].[CompetenceAreas]
    ([Country_Id]);
GO

-- Creating foreign key on [CompetenceAreaCategory_Category_Id] in table 'CompetenceAreaCategory'
ALTER TABLE [dbo].[CompetenceAreaCategory]
ADD CONSTRAINT [FK_CompetenceAreaCategory_CompetenceArea]
    FOREIGN KEY ([CompetenceAreaCategory_Category_Id])
    REFERENCES [dbo].[CompetenceAreas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'CompetenceAreaCategory'
ALTER TABLE [dbo].[CompetenceAreaCategory]
ADD CONSTRAINT [FK_CompetenceAreaCategory_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenceAreaCategory_Category'
CREATE INDEX [IX_FK_CompetenceAreaCategory_Category]
ON [dbo].[CompetenceAreaCategory]
    ([Categories_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[Categories]
    ([Parent_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT [dbo].[Countries] ([Id], [Locale], [Name], [History_CreatedBy], [History_Created]) VALUES (1, N'sv-SE', N'Sverige', N'pewi31', CAST(0x00009DDE00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Countries] OFF

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [TeliaID], [History_CreatedBy], [History_Created], [Country_Id]) VALUES (1, N'Kalle', N'Anka', N'kaan21', N'pewi31', CAST(0x00009DDE00000000 AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [TeliaID], [History_CreatedBy], [History_Created], [Country_Id]) VALUES (2, N'Arne', N'Anka', N'aran31', N'pewi31', CAST(0x00009DE3009210F5 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([Id], [Name], [History_CreatedBy], [History_Created], [Country_Id]) VALUES (1, N'iPhone', N'pewi31', CAST(0x00009DDE00000000 AS DateTime), 1)
INSERT [dbo].[Categories] ([Id], [Name], [History_CreatedBy], [History_Created], [Country_Id]) VALUES (2, N'Mobilt bredband', N'pewi31', CAST(0x00009DDF00000000 AS DateTime), 1)
INSERT [dbo].[Categories] ([Id], [Name], [History_CreatedBy], [History_Created], [Country_Id], [Parent_Id]) VALUES (3, N'Epost', N'pewi31', CAST(0x00009DDF00000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[CompetenceAreas] ON
INSERT [dbo].[CompetenceAreas] ([Id], [Name], [History_CreatedBy], [History_Created], [Country_Id]) VALUES (4, N'Multimedia support', N'pewi21', CAST(0x00009DDF00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CompetenceAreas] OFF

--INSERT [dbo].[CompetenceAreaCategory] ([CompetenceAreaCategory_Category_Id], [Category_Id]) VALUES (4, 1)
--INSERT [dbo].[CompetenceAreaCategory] ([CompetenceAreaCategory_Category_Id], [Category_Id]) VALUES (4, 2)
