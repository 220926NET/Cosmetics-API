IF db_id('cosmetics') IS NULL
	CREATE DATABASE [Cosmo]
GO

USE [cosmetics]
GO

DROP TABLE IF EXISTS [Logs];
DROP TABLE IF EXISTS [OrderDetails];
DROP TABLE IF EXISTS [Orders];
DROP TABLE IF EXISTS [Reviews];
DROP TABLE IF EXISTS [WishlistDetails];
DROP TABLE IF EXISTS [Wishlists];
DROP TABLE IF EXISTS [Deals];
DROP TABLE IF EXISTS [Products];
DROP TABLE IF EXISTS [Users];


CREATE TABLE [Users] (
  [ID] INT PRIMARY KEY IDENTITY(1, 1),
  [FirstName] NVARCHAR(255) NOT NULL,
  [LastName] NVARCHAR(255) NOT NULL,
  [Email] NVARCHAR(255) UNIQUE NOT NULL,
  [Password] NVARCHAR(MAX) NOT NULL
)
GO

CREATE TABLE [Products] (
  [ProductID] INT PRIMARY KEY IDENTITY(1, 1),
  [API_ID] INT NOT NULL,
  [ProductName] NVARCHAR(MAX) NOT NULL,
  [ProductType] NVARCHAR(50) NOT NULL,
  [Brand] NVARCHAR(50) NOT NULL,
  [Inventory] INT NOT NULL DEFAULT (20),
  [Price] MONEY NOT NULL,
  [Description] NVARCHAR(MAX),
  [Image] NVARCHAR(MAX),
  [ColourName] NVARCHAR(150),
  [HexValue] NVARCHAR(20)
)
GO

CREATE TABLE [Orders] (
  [OrderID] INT PRIMARY KEY IDENTITY(1, 1),
  [Purchaser] INT NOT NULL,
  [TimeStamp] DATETIME NOT NULL DEFAULT getDate(),
  [Amount] MONEY NOT NULL
)
GO

CREATE TABLE [OrderDetails] (
  [OrderID] INT,
  [ProductID] INT NOT NULL,
  [Quantity] INT NOT NULL DEFAULT (1)
)
GO

CREATE TABLE [Reviews] (
  [ID] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT NOT NULL,
  [ProductID] INT NOT NULL,
  [Review] NVARCHAR(MAX) NOT NULL,
  [Rating] INT NOT NULL
)
GO

CREATE TABLE [Wishlists] (
  [ID] INT PRIMARY KEY IDENTITY(1, 1),
  [UserID] INT NOT NULL
)
GO

CREATE TABLE [WishlistDetails] (
  [DetailId] INT PRIMARY KEY IDENTITY(1, 1),
  [ID] INT NOT NULL,
  [ProductID] INT NOT NULL
)
GO

CREATE TABLE [Deals] (
  [ID] INT PRIMARY KEY IDENTITY(1, 1),
  [Discount] DECIMAL NOT NULL,
  [StartTime] DATETIME NOT NULL,
  [EndTime] DATETIME NOT NULL,
  [Product] INT NOT NULL
)
GO

CREATE TABLE [Logs] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Message] NVARCHAR(MAX) NOT NULL,
  [MessageTemplate] NVARCHAR(MAX),
  [Level] NVARCHAR(MAX),
  [TimeStamp] DATETIME DEFAULT getDate(),
  [Exception] NVARCHAR(MAX),
  [Properties] NVARCHAR(MAX)
)
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([Purchaser]) REFERENCES [Users] ([ID])
GO

ALTER TABLE [OrderDetails] ADD FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID])
GO

ALTER TABLE [OrderDetails] ADD FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID])
GO

ALTER TABLE [Reviews] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([ID])
GO

ALTER TABLE [Reviews] ADD FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID])
GO

ALTER TABLE [Wishlists] ADD FOREIGN KEY ([UserID]) REFERENCES [Users] ([ID])
GO

ALTER TABLE [WishlistDetails] ADD FOREIGN KEY ([ID]) REFERENCES [Wishlists] ([ID])
GO

ALTER TABLE [WishlistDetails] ADD FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID])
GO

ALTER TABLE [Deals] ADD FOREIGN KEY ([Product]) REFERENCES [Products] ([ProductID])
GO