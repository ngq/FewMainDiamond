
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/12/2017 08:59:11
-- Generated from EDMX file: H:\我的\我的TFS项目\FewMainDiamond\FewMain.Model\FewMainEntity.edmx
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

IF OBJECT_ID(N'[dbo].[FK_FewMainCartFewMainCartDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainCartDetail] DROP CONSTRAINT [FK_FewMainCartFewMainCartDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainOrderTypeFewMainOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainOrder] DROP CONSTRAINT [FK_FewMainOrderTypeFewMainOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainOrderFewMainOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainOrderDetail] DROP CONSTRAINT [FK_FewMainOrderFewMainOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainCartFewMainCartType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainCartType] DROP CONSTRAINT [FK_FewMainCartFewMainCartType];
GO

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
IF OBJECT_ID(N'[dbo].[FewMainCart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCart];
GO
IF OBJECT_ID(N'[dbo].[FewMainCartDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCartDetail];
GO
IF OBJECT_ID(N'[dbo].[FewMainOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainOrder];
GO
IF OBJECT_ID(N'[dbo].[FewMainOrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[FewMainOrderType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainOrderType];
GO
IF OBJECT_ID(N'[dbo].[FewMainCartType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCartType];
GO
IF OBJECT_ID(N'[dbo].[FewMainProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainProduct];
GO
IF OBJECT_ID(N'[dbo].[FewMainImgs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainImgs];
GO
IF OBJECT_ID(N'[dbo].[FewMainSku]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainSku];
GO
IF OBJECT_ID(N'[dbo].[FewMainHandSize]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainHandSize];
GO
IF OBJECT_ID(N'[dbo].[FewMainTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainTag];
GO
IF OBJECT_ID(N'[dbo].[FewMainUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainUsers];
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

-- Creating table 'FewMainCart'
CREATE TABLE [dbo].[FewMainCart] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CartId] nvarchar(max)  NOT NULL
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
    [OrderId] nvarchar(max)  NOT NULL,
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
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FewMainCartType'
CREATE TABLE [dbo].[FewMainCartType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [FewMainCartId] int  NOT NULL
);
GO

-- Creating table 'FewMainProduct'
CREATE TABLE [dbo].[FewMainProduct] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProName] nvarchar(500)  NULL,
    [ProTypeId] int  NULL,
    [ProTypeName] nvarchar(500)  NULL,
    [ProSeriesId] int  NULL,
    [ProSeriesName] nvarchar(500)  NULL,
    [ImgSrcList] nvarchar(max)  NULL,
    [ProImgDetail] nvarchar(max)  NULL,
    [AddTime] datetime  NULL,
    [WebTitle] nvarchar(500)  NULL,
    [WebKeyword] nvarchar(500)  NULL,
    [WebDescription] nvarchar(500)  NULL
);
GO

-- Creating table 'FewMainImgs'
CREATE TABLE [dbo].[FewMainImgs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImgSrc] nvarchar(max)  NULL,
    [ProductId] int  NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainSku'
CREATE TABLE [dbo].[FewMainSku] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SKUNo] nvarchar(500)  NOT NULL,
    [Weight] decimal(18,2)  NOT NULL,
    [Shape] int  NOT NULL,
    [Color] nvarchar(50)  NOT NULL,
    [Clarity] nvarchar(50)  NOT NULL,
    [Cut] nvarchar(50)  NOT NULL,
    [Polishing] nvarchar(50)  NOT NULL,
    [Symmetry] nvarchar(50)  NOT NULL,
    [Fluorescence] nvarchar(50)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Coffee] nvarchar(50)  NULL,
    [Milk] nvarchar(50)  NULL,
    [AddTime] datetime  NULL,
    [UpdateTime] datetime  NULL
);
GO

-- Creating table 'FewMainHandSize'
CREATE TABLE [dbo].[FewMainHandSize] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Size] decimal(18,1)  NOT NULL,
    [ProductId] int  NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainTag'
CREATE TABLE [dbo].[FewMainTag] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TabName] nvarchar(50)  NULL,
    [Remark] nvarchar(500)  NULL
);
GO

-- Creating table 'FewMainUsers'
CREATE TABLE [dbo].[FewMainUsers] (
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

-- Creating primary key on [Id] in table 'FewMainProduct'
ALTER TABLE [dbo].[FewMainProduct]
ADD CONSTRAINT [PK_FewMainProduct]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainImgs'
ALTER TABLE [dbo].[FewMainImgs]
ADD CONSTRAINT [PK_FewMainImgs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainSku'
ALTER TABLE [dbo].[FewMainSku]
ADD CONSTRAINT [PK_FewMainSku]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainHandSize'
ALTER TABLE [dbo].[FewMainHandSize]
ADD CONSTRAINT [PK_FewMainHandSize]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainTag'
ALTER TABLE [dbo].[FewMainTag]
ADD CONSTRAINT [PK_FewMainTag]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'FewMainUsers'
ALTER TABLE [dbo].[FewMainUsers]
ADD CONSTRAINT [PK_FewMainUsers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
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

-- Creating foreign key on [FewMainCartId] in table 'FewMainCartType'
ALTER TABLE [dbo].[FewMainCartType]
ADD CONSTRAINT [FK_FewMainCartFewMainCartType]
    FOREIGN KEY ([FewMainCartId])
    REFERENCES [dbo].[FewMainCart]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainCartFewMainCartType'
CREATE INDEX [IX_FK_FewMainCartFewMainCartType]
ON [dbo].[FewMainCartType]
    ([FewMainCartId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------