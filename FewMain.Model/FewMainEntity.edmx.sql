
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2016 10:14:45
-- Generated from EDMX file: H:\我的\我的TFS项目\项目\FewMainDiamond\FewMain.Model\FewMainEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FewMainDiamond];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Content]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Content];
GO
IF OBJECT_ID(N'[dbo].[FewMainType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainType];
GO
IF OBJECT_ID(N'[dbo].[Tag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tag];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int  NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [NickName] nvarchar(50)  NULL,
    [RealName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Mobile] nvarchar(max)  NULL,
    [QQ] nvarchar(max)  NULL,
    [HeaderImgSrc] nvarchar(max)  NULL,
    [AddTime] datetime  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Content'
CREATE TABLE [dbo].[Content] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Author] nvarchar(50)  NULL,
    [Type] int  NULL,
    [WebTitle] nvarchar(500)  NULL,
    [WebKeyword] nvarchar(500)  NULL,
    [WebDescription] nvarchar(500)  NULL,
    [Title] nvarchar(500)  NULL,
    [Contents] nvarchar(max)  NULL,
    [ClickCount] int  NULL,
    [Tag] int  NULL,
    [AddTime] datetime  NULL,
    [AppId] int  NULL
);
GO

-- Creating table 'FewMainType'
CREATE TABLE [dbo].[FewMainType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(50)  NULL,
    [ParentId] int  NULL,
    [Remark] nvarchar(500)  NULL,
    [AddTime] datetime  NULL
);
GO

-- Creating table 'Tag'
CREATE TABLE [dbo].[Tag] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TabName] nvarchar(50)  NULL,
    [Remark] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Content'
ALTER TABLE [dbo].[Content]
ADD CONSTRAINT [PK_Content]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainType'
ALTER TABLE [dbo].[FewMainType]
ADD CONSTRAINT [PK_FewMainType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tag'
ALTER TABLE [dbo].[Tag]
ADD CONSTRAINT [PK_Tag]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------