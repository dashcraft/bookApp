
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/12/2016 10:10:15
-- Generated from EDMX file: C:\Users\daniel.ashcraft\Documents\Visual Studio 2015\Projects\WebApplication1\WebApplication1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pdfentryDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[pdf_tbl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pdf_tbl];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'pdf_tbl'
CREATE TABLE [dbo].[pdf_tbl] (
    [bookId] int IDENTITY(1,1) NOT NULL,
    [authFirstName] varchar(50)  NULL,
    [authLastName] varchar(50)  NULL,
    [bookTitle] varchar(50)  NOT NULL,
    [bookPrologue] varchar(max)  NULL
);
GO



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [bookId] in table 'pdf_tbl'
ALTER TABLE [dbo].[pdf_tbl]
ADD CONSTRAINT [PK_pdf_tbl]
    PRIMARY KEY CLUSTERED ([bookId] ASC);
GO



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------