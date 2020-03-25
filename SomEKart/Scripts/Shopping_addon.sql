ALTER TABLE [ShoppingCartItems] ADD [Amount] float NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [ShoppingCartItems] ADD [ItemName] nvarchar(max) NULL;

GO

ALTER TABLE [ShoppingCartItems] ADD [ShoppingCartId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325075532_Shopping_addon', N'3.1.2');

GO

