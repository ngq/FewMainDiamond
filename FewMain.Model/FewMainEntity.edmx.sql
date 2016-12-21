
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2016 23:57:06
-- Generated from EDMX file: H:\Git项目管理\FewMainDiamond\FewMain.Model\FewMainEntity.edmx
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

IF OBJECT_ID(N'[dbo].[FewMainArticle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainArticle];
GO
IF OBJECT_ID(N'[dbo].[FewMainProType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainProType];
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

-- Creating table 'FewMainArticle'
CREATE TABLE [dbo].[FewMainArticle] (
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

-- Creating table 'FewMainProType'
CREATE TABLE [dbo].[FewMainProType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [ParentId] int  NOT NULL
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [NickName] nvarchar(50)  NULL,
    [RealName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Mobile] nvarchar(max)  NULL,
    [QQ] nvarchar(max)  NULL,
    [HeaderImgSrc] nvarchar(max)  NULL,
    [Weixin] nvarchar(max)  NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainCart'
CREATE TABLE [dbo].[FewMainCart] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FewMainCartTypeId] int  NOT NULL
);
GO

-- Creating table 'FewMainCartDetail'
CREATE TABLE [dbo].[FewMainCartDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FewMainCartId] int  NOT NULL
);
GO

-- Creating table 'FewMainOrder'
CREATE TABLE [dbo].[FewMainOrder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FewMainOrderTypeId] int  NOT NULL
);
GO

-- Creating table 'FewMainOrderDetail'
CREATE TABLE [dbo].[FewMainOrderDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FewMainOrderId] int  NOT NULL
);
GO

-- Creating table 'FewMainOrderType'
CREATE TABLE [dbo].[FewMainOrderType] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FewMainCartType'
CREATE TABLE [dbo].[FewMainCartType] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FewMainArticle'
ALTER TABLE [dbo].[FewMainArticle]
ADD CONSTRAINT [PK_FewMainArticle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainProType'
ALTER TABLE [dbo].[FewMainProType]
ADD CONSTRAINT [PK_FewMainProType]
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

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainCart'
ALTER TABLE [dbo].[FewMainCart]
ADD CONSTRAINT [PK_FewMainCart]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainCartDetail'
ALTER TABLE [dbo].[FewMainCartDetail]
ADD CONSTRAINT [PK_FewMainCartDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainOrder'
ALTER TABLE [dbo].[FewMainOrder]
ADD CONSTRAINT [PK_FewMainOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainOrderDetail'
ALTER TABLE [dbo].[FewMainOrderDetail]
ADD CONSTRAINT [PK_FewMainOrderDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainOrderType'
ALTER TABLE [dbo].[FewMainOrderType]
ADD CONSTRAINT [PK_FewMainOrderType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainCartType'
ALTER TABLE [dbo].[FewMainCartType]
ADD CONSTRAINT [PK_FewMainCartType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FewMainCartId] in table 'FewMainCartDetail'
ALTER TABLE [dbo].[FewMainCartDetail]
ADD CONSTRAINT [FK_FewMainCartFewMainCartDetail]
    FOREIGN KEY ([FewMainCartId])
    REFERENCES [dbo].[FewMainCart]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainCartFewMainCartDetail'
CREATE INDEX [IX_FK_FewMainCartFewMainCartDetail]
ON [dbo].[FewMainCartDetail]
    ([FewMainCartId]);
GO

-- Creating foreign key on [FewMainCartTypeId] in table 'FewMainCart'
ALTER TABLE [dbo].[FewMainCart]
ADD CONSTRAINT [FK_FewMainCartFewMainCartType]
    FOREIGN KEY ([FewMainCartTypeId])
    REFERENCES [dbo].[FewMainCartType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainCartFewMainCartType'
CREATE INDEX [IX_FK_FewMainCartFewMainCartType]
ON [dbo].[FewMainCart]
    ([FewMainCartTypeId]);
GO

-- Creating foreign key on [FewMainOrderTypeId] in table 'FewMainOrder'
ALTER TABLE [dbo].[FewMainOrder]
ADD CONSTRAINT [FK_FewMainOrderTypeFewMainOrder]
    FOREIGN KEY ([FewMainOrderTypeId])
    REFERENCES [dbo].[FewMainOrderType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainOrderTypeFewMainOrder'
CREATE INDEX [IX_FK_FewMainOrderTypeFewMainOrder]
ON [dbo].[FewMainOrder]
    ([FewMainOrderTypeId]);
GO

-- Creating foreign key on [FewMainOrderId] in table 'FewMainOrderDetail'
ALTER TABLE [dbo].[FewMainOrderDetail]
ADD CONSTRAINT [FK_FewMainOrderFewMainOrderDetail]
    FOREIGN KEY ([FewMainOrderId])
    REFERENCES [dbo].[FewMainOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainOrderFewMainOrderDetail'
CREATE INDEX [IX_FK_FewMainOrderFewMainOrderDetail]
ON [dbo].[FewMainOrderDetail]
    ([FewMainOrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------