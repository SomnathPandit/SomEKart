IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Inventories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Price] float NOT NULL,
    [Description] nvarchar(max) NULL,
    [ImageUrl] nvarchar(max) NULL,
    [Color] int NOT NULL,
    [Size] int NOT NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [OrderDate] datetime2 NOT NULL,
    [OrderAcceptedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [OrderItem] (
    [Id] int NOT NULL IDENTITY,
    [ItemId] int NOT NULL,
    [Quantity] int NOT NULL,
    [IsDelivered] bit NOT NULL,
    [OrderId] int NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItem_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_OrderItem_OrderId] ON [OrderItem] ([OrderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200313164516_Initial', N'3.1.2');

GO

CREATE TABLE [ShoppingCartItems] (
    [Id] int NOT NULL IDENTITY,
    [ItemId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200322172251_ShoppingCartItems', N'3.1.2');

GO

ALTER TABLE [ShoppingCartItems] ADD [Amount] float NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [ShoppingCartItems] ADD [ItemName] nvarchar(max) NULL;

GO

ALTER TABLE [ShoppingCartItems] ADD [ShoppingCartId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325075532_Shopping_addon', N'3.1.2');

GO

