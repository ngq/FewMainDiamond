
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/13/2017 17:29:00
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

IF OBJECT_ID(N'[dbo].[FK_FewMainAddress_FewMainUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainAddress] DROP CONSTRAINT [FK_FewMainAddress_FewMainUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainCart_FewMainCartType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainCart] DROP CONSTRAINT [FK_FewMainCart_FewMainCartType];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainCart_FewMainUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainCart] DROP CONSTRAINT [FK_FewMainCart_FewMainUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainComment_FewMainProTemplet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainComment] DROP CONSTRAINT [FK_FewMainComment_FewMainProTemplet];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainOrder_FewMainOrderType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainOrder] DROP CONSTRAINT [FK_FewMainOrder_FewMainOrderType];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainOrder_FewMainUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainOrder] DROP CONSTRAINT [FK_FewMainOrder_FewMainUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_FewMainOrderFewMainOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FewMainOrderDetail] DROP CONSTRAINT [FK_FewMainOrderFewMainOrderDetail];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FewMainAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainAddress];
GO
IF OBJECT_ID(N'[dbo].[FewMainArticle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainArticle];
GO
IF OBJECT_ID(N'[dbo].[FewMainCart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCart];
GO
IF OBJECT_ID(N'[dbo].[FewMainCartDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCartDetail];
GO
IF OBJECT_ID(N'[dbo].[FewMainCartType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainCartType];
GO
IF OBJECT_ID(N'[dbo].[FewMainComment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainComment];
GO
IF OBJECT_ID(N'[dbo].[FewMainFactory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainFactory];
GO
IF OBJECT_ID(N'[dbo].[FewMainHandSize]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainHandSize];
GO
IF OBJECT_ID(N'[dbo].[FewMainImgs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainImgs];
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
IF OBJECT_ID(N'[dbo].[FewMainProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainProduct];
GO
IF OBJECT_ID(N'[dbo].[FewMainProTemplet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainProTemplet];
GO
IF OBJECT_ID(N'[dbo].[FewMainProType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainProType];
GO
IF OBJECT_ID(N'[dbo].[FewMainSeries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainSeries];
GO
IF OBJECT_ID(N'[dbo].[FewMainSku]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainSku];
GO
IF OBJECT_ID(N'[dbo].[FewMainTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainTag];
GO
IF OBJECT_ID(N'[dbo].[FewMainType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainType];
GO
IF OBJECT_ID(N'[dbo].[FewMainUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FewMainUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FewMainAddress'
CREATE TABLE [dbo].[FewMainAddress] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Province] nvarchar(50)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Town] nvarchar(50)  NOT NULL,
    [Street] nvarchar(500)  NULL,
    [ProvinceId] int  NOT NULL,
    [CityId] int  NOT NULL,
    [TownId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [AddTime] datetime  NOT NULL
);
GO

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

-- Creating table 'FewMainCart'
CREATE TABLE [dbo].[FewMainCart] (
    [Id] int  NOT NULL,
    [CartId] nvarchar(100)  NOT NULL,
    [CartTypeId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainCartDetail'
CREATE TABLE [dbo].[FewMainCartDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FewMainCartId] nvarchar(100)  NOT NULL,
    [ProductId] int  NOT NULL,
    [ProName] nvarchar(max)  NOT NULL,
    [ProType] int  NOT NULL,
    [ProTypeName] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [HandSize] nvarchar(50)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Material] nvarchar(50)  NOT NULL,
    [ProInfo] nvarchar(max)  NOT NULL,
    [ProImg] nvarchar(max)  NOT NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainCartType'
CREATE TABLE [dbo].[FewMainCartType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FewMainComment'
CREATE TABLE [dbo].[FewMainComment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProTempId] int  NOT NULL,
    [Contents] nvarchar(500)  NOT NULL,
    [ImgList] nvarchar(max)  NULL,
    [Tag] nvarchar(500)  NULL,
    [UserId] int  NULL,
    [UserName] nvarchar(max)  NULL,
    [IsEvaluation] int  NOT NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainFactory'
CREATE TABLE [dbo].[FewMainFactory] (
    [Id] int  NOT NULL
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

-- Creating table 'FewMainImgs'
CREATE TABLE [dbo].[FewMainImgs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImgSrc] nvarchar(max)  NULL,
    [ProductId] int  NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainOrder'
CREATE TABLE [dbo].[FewMainOrder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] nvarchar(max)  NOT NULL,
    [OrderTypeId] int  NOT NULL,
    [OrderStatus] int  NOT NULL,
    [StatusName] nvarchar(500)  NOT NULL,
    [UserId] int  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Consignee] nvarchar(50)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [TotalMoney] decimal(18,2)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [AddTime] datetime  NOT NULL,
    [UpdateTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainOrderDetail'
CREATE TABLE [dbo].[FewMainOrderDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [ProImg] nvarchar(max)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Count] int  NOT NULL,
    [Material] nvarchar(max)  NOT NULL,
    [HandSize] nvarchar(500)  NOT NULL,
    [ProInfo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FewMainOrderType'
CREATE TABLE [dbo].[FewMainOrderType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FewMainProduct'
CREATE TABLE [dbo].[FewMainProduct] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProName] nvarchar(500)  NOT NULL,
    [ProTypeId] int  NOT NULL,
    [ProTypeName] nvarchar(500)  NOT NULL,
    [ProSeriesId] int  NOT NULL,
    [ProSeriesName] nvarchar(500)  NOT NULL,
    [ImgSrcList] nvarchar(max)  NOT NULL,
    [ProImgDetail] nvarchar(max)  NOT NULL,
    [WebTitle] nvarchar(500)  NOT NULL,
    [WebKeyword] nvarchar(500)  NOT NULL,
    [WebDescription] nvarchar(500)  NOT NULL,
    [DefaultSKU] nvarchar(500)  NULL,
    [SetSKU] nvarchar(500)  NULL,
    [IsShow] int  NOT NULL,
    [AddTime] datetime  NOT NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'FewMainProTemplet'
CREATE TABLE [dbo].[FewMainProTemplet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProTypeId] int  NOT NULL,
    [ProTypeName] nvarchar(max)  NOT NULL,
    [ProSeriesId] int  NOT NULL,
    [ProSeriesName] nvarchar(max)  NOT NULL,
    [ImgSrcList] nvarchar(max)  NOT NULL,
    [ProImgDetail] nvarchar(max)  NOT NULL,
    [WebTitle] nvarchar(max)  NOT NULL,
    [WebKeyword] nvarchar(max)  NOT NULL,
    [WebDescription] nvarchar(max)  NOT NULL,
    [IsShow] int  NOT NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- Creating table 'FewMainProType'
CREATE TABLE [dbo].[FewMainProType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [ParentId] int  NOT NULL
);
GO

-- Creating table 'FewMainSeries'
CREATE TABLE [dbo].[FewMainSeries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SeriesName] nvarchar(50)  NOT NULL,
    [ParentId] int  NOT NULL
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

-- Creating table 'FewMainTag'
CREATE TABLE [dbo].[FewMainTag] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TabName] nvarchar(50)  NULL,
    [Remark] nvarchar(500)  NULL
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
    [ImgSrc] nvarchar(max)  NULL,
    [Weixin] nvarchar(max)  NULL,
    [AddTime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FewMainAddress'
ALTER TABLE [dbo].[FewMainAddress]
ADD CONSTRAINT [PK_FewMainAddress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainArticle'
ALTER TABLE [dbo].[FewMainArticle]
ADD CONSTRAINT [PK_FewMainArticle]
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

-- Creating primary key on [Id] in table 'FewMainCartType'
ALTER TABLE [dbo].[FewMainCartType]
ADD CONSTRAINT [PK_FewMainCartType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainComment'
ALTER TABLE [dbo].[FewMainComment]
ADD CONSTRAINT [PK_FewMainComment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainFactory'
ALTER TABLE [dbo].[FewMainFactory]
ADD CONSTRAINT [PK_FewMainFactory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainHandSize'
ALTER TABLE [dbo].[FewMainHandSize]
ADD CONSTRAINT [PK_FewMainHandSize]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainImgs'
ALTER TABLE [dbo].[FewMainImgs]
ADD CONSTRAINT [PK_FewMainImgs]
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

-- Creating primary key on [Id] in table 'FewMainProduct'
ALTER TABLE [dbo].[FewMainProduct]
ADD CONSTRAINT [PK_FewMainProduct]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainProTemplet'
ALTER TABLE [dbo].[FewMainProTemplet]
ADD CONSTRAINT [PK_FewMainProTemplet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainProType'
ALTER TABLE [dbo].[FewMainProType]
ADD CONSTRAINT [PK_FewMainProType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainSeries'
ALTER TABLE [dbo].[FewMainSeries]
ADD CONSTRAINT [PK_FewMainSeries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainSku'
ALTER TABLE [dbo].[FewMainSku]
ADD CONSTRAINT [PK_FewMainSku]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainTag'
ALTER TABLE [dbo].[FewMainTag]
ADD CONSTRAINT [PK_FewMainTag]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FewMainType'
ALTER TABLE [dbo].[FewMainType]
ADD CONSTRAINT [PK_FewMainType]
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

-- Creating foreign key on [UserId] in table 'FewMainAddress'
ALTER TABLE [dbo].[FewMainAddress]
ADD CONSTRAINT [FK_FewMainAddress_FewMainUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[FewMainUsers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainAddress_FewMainUsers'
CREATE INDEX [IX_FK_FewMainAddress_FewMainUsers]
ON [dbo].[FewMainAddress]
    ([UserId]);
GO

-- Creating foreign key on [CartTypeId] in table 'FewMainCart'
ALTER TABLE [dbo].[FewMainCart]
ADD CONSTRAINT [FK_FewMainCart_FewMainCartType]
    FOREIGN KEY ([CartTypeId])
    REFERENCES [dbo].[FewMainCartType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainCart_FewMainCartType'
CREATE INDEX [IX_FK_FewMainCart_FewMainCartType]
ON [dbo].[FewMainCart]
    ([CartTypeId]);
GO

-- Creating foreign key on [UserId] in table 'FewMainCart'
ALTER TABLE [dbo].[FewMainCart]
ADD CONSTRAINT [FK_FewMainCart_FewMainUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[FewMainUsers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainCart_FewMainUsers'
CREATE INDEX [IX_FK_FewMainCart_FewMainUsers]
ON [dbo].[FewMainCart]
    ([UserId]);
GO

-- Creating foreign key on [Id] in table 'FewMainComment'
ALTER TABLE [dbo].[FewMainComment]
ADD CONSTRAINT [FK_FewMainComment_FewMainProTemplet]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FewMainProTemplet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FewMainOrder'
ALTER TABLE [dbo].[FewMainOrder]
ADD CONSTRAINT [FK_FewMainOrder_FewMainOrderType]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FewMainOrderType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'FewMainOrder'
ALTER TABLE [dbo].[FewMainOrder]
ADD CONSTRAINT [FK_FewMainOrder_FewMainUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[FewMainUsers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainOrder_FewMainUsers'
CREATE INDEX [IX_FK_FewMainOrder_FewMainUsers]
ON [dbo].[FewMainOrder]
    ([UserId]);
GO

-- Creating foreign key on [OrderId] in table 'FewMainOrderDetail'
ALTER TABLE [dbo].[FewMainOrderDetail]
ADD CONSTRAINT [FK_FewMainOrderFewMainOrderDetail]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[FewMainOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FewMainOrderFewMainOrderDetail'
CREATE INDEX [IX_FK_FewMainOrderFewMainOrderDetail]
ON [dbo].[FewMainOrderDetail]
    ([OrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------