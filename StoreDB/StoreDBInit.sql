IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StoreDB')
BEGIN
	CREATE DATABASE StoreDB;
END
GO

USE StoreDB;
GO

--CREATE CATEGORY STATE
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'CategoryState' AND xtype = 'U')
CREATE TABLE [CategoryState] (
  Id INT NOT NULL IDENTITY(1,1),
  [Name] NVARCHAR(50) NOT NULL UNIQUE,
  CONSTRAINT PKCategoryState PRIMARY KEY (Id)
)
GO

--CREATE CATEGORY
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Category' AND xtype = 'U')
CREATE TABLE [Category] (
  Id INT NOT NULL IDENTITY(1,1),
  [Name] NVARCHAR(50) NOT NULL,
  [CategoryStateId] INT NOT NULL,
CONSTRAINT PKCategory PRIMARY KEY (Id),
CONSTRAINT UXCategoryName UNIQUE (Name),
CONSTRAINT FKCategoryCategoryStateCategoryStateId FOREIGN KEY (CategoryStateId) REFERENCES CategoryState (Id)
)
GO

--CREATE PRODUCT STATE
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'ProductState' AND xtype = 'U')
CREATE TABLE [ProductState] (
  Id INT NOT NULL IDENTITY(1,1),
  [Name] NVARCHAR(50) NOT NULL,
  CONSTRAINT PKProductState PRIMARY KEY (Id)
)
GO

--CREATE PRODUCT
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Product' AND xtype = 'U')
CREATE TABLE [Product] (
  Id INT NOT NULL IDENTITY(1,1),
  [Name] NVARCHAR(50) NOT NULL,
  [Description] NVARCHAR(255) NOT NULL,
  [Price] DECIMAL(10,2) NOT NULL,
  [CategoryId] INT NOT NULL,
  [ProductStateId] INT NOT NULL,
  [Stock] INT NOT NULL,
  CONSTRAINT PKProduct PRIMARY KEY (Id),
  CONSTRAINT UXProductName UNIQUE (Name),
  CONSTRAINT FKCategoryProductCategoryId FOREIGN KEY (CategoryId) REFERENCES Category (Id),
	CONSTRAINT FKProductStateProductProductStateId FOREIGN KEY (ProductStateId) REFERENCES ProductState (Id),
)
GO

--CREATE ORDER
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Order' AND xtype = 'U')
CREATE TABLE [Order] (
  Id INT NOT NULL IDENTITY(1,1),
  [Date] DATETIME2 NOT NULL,
  [CustomerName] NVARCHAR(255) NOT NULL,
  [CustomerDocumentId] NVARCHAR(9) NOT NULL,
  [CustomerPhone] NVARCHAR(8) NOT NULL,
  [CustomerEmail] NVARCHAR(50) NOT NULL,
  [CustomerAddress] NVARCHAR(255) NOT NULL,
  [TotalPrice] DECIMAL(10,2) NOT NULL,
  CONSTRAINT PKOrder PRIMARY KEY (Id),
)
GO

--CREATE ORDERPRODUCT
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'OrderProduct' AND xtype = 'U')
CREATE TABLE [OrderProduct] (
  Id INT NOT NULL IDENTITY(1,1),
  [Quantity] INT NOT NULL,
  [OrderId] INT NOT NULL,
  [ProductId] INT NOT NULL,
  [ProductPrice] DECIMAL(10,2) NOT NULL,
  CONSTRAINT PKOrderProduct PRIMARY KEY (Id),
  CONSTRAINT FKOrderOrderProductOrderId FOREIGN KEY (OrderId) REFERENCES [Order] (Id),
  CONSTRAINT FKProductOrderProductProductId FOREIGN KEY (ProductId) REFERENCES Product (Id),
)
GO
