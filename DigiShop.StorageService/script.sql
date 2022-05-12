IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Permissions] (
    [id] int NOT NULL IDENTITY,
    [permission] nvarchar(70) NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Roles] (
    [id] int NOT NULL IDENTITY,
    [rolename] nvarchar(70) NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([id])
);
GO

CREATE TABLE [RolePermissions] (
    [id] int NOT NULL IDENTITY,
    [roleId] int NOT NULL,
    [permissionId] int NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_RolePermissions] PRIMARY KEY ([id]),
    CONSTRAINT [FK_RolePermissions_Permissions_permissionId] FOREIGN KEY ([permissionId]) REFERENCES [Permissions] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolePermissions_Roles_roleId] FOREIGN KEY ([roleId]) REFERENCES [Roles] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Users] (
    [id] int NOT NULL IDENTITY,
    [Phonenumber] nvarchar(11) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Userserial] nvarchar(max) NULL,
    [NationalCode] nvarchar(10) NULL,
    [UserStatus] int NOT NULL,
    [roleId] int NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Users_Roles_roleId] FOREIGN KEY ([roleId]) REFERENCES [Roles] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Otps] (
    [id] int NOT NULL IDENTITY,
    [userId] int NOT NULL,
    [code] nvarchar(6) NOT NULL,
    [IsUsed] bit NOT NULL,
    [expiretime] datetimeoffset NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Otps] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Otps_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Stores] (
    [UserId] int NOT NULL,
    [Mail] nvarchar(max) NOT NULL,
    [StoreName] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Telephone] nvarchar(12) NULL,
    [Logo] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [StoreStatus] int NOT NULL,
    [IsPhonenumberActive] bit NOT NULL,
    [IsMailActive] bit NOT NULL,
    CONSTRAINT [PK_Stores] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Stores_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Otps_userId] ON [Otps] ([userId]);
GO

CREATE INDEX [IX_RolePermissions_permissionId] ON [RolePermissions] ([permissionId]);
GO

CREATE INDEX [IX_RolePermissions_roleId] ON [RolePermissions] ([roleId]);
GO

CREATE INDEX [IX_Users_roleId] ON [Users] ([roleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220329161055_init', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [SiteSettings] (
    [id] int NOT NULL IDENTITY,
    [EmailAddress] nvarchar(max) NULL,
    [EmailPassword] nvarchar(max) NULL,
    [SiteDescription] nvarchar(max) NULL,
    [SiteKey] nvarchar(max) NULL,
    [SiteName] nvarchar(max) NULL,
    [SmsApi] nvarchar(max) NULL,
    [SmsSender] nvarchar(max) NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_SiteSettings] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220401161446_SiteSettings', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [SignInLogs] (
    [id] int NOT NULL IDENTITY,
    [SignInTime] nvarchar(max) NULL,
    [Username] nvarchar(max) NULL,
    [DeviceName] nvarchar(max) NULL,
    [Browser] nvarchar(max) NULL,
    [userId] int NOT NULL,
    CONSTRAINT [PK_SignInLogs] PRIMARY KEY ([id]),
    CONSTRAINT [FK_SignInLogs_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_SignInLogs_userId] ON [SignInLogs] ([userId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220404154917_SignInLog', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [SignInLogs] ADD [UrlAction] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220405144642_UrlAction', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [StoreCategories] ADD [icon] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220407134858_icon', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Documents] (
    [id] int NOT NULL IDENTITY,
    [NationalCode] nvarchar(10) NULL,
    [Address] nvarchar(250) NULL,
    [Homephone] nvarchar(max) NULL,
    [AuthStatus] int NOT NULL,
    [filename] nvarchar(max) NULL,
    [CardNumber] nvarchar(max) NULL,
    [BankName] nvarchar(max) NULL,
    [AccountOwner] nvarchar(max) NULL,
    [ShabaCode] nvarchar(max) NULL,
    [userId] int NOT NULL,
    [CurrentTime] nvarchar(max) NULL,
    [CurrentDate] nvarchar(max) NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Documents_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Documents_userId] ON [Documents] ([userId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220417112527_Document', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Stores] ADD [IsRuleAccepted] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418134547_IsRuleAccepted', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [IsRulesAccepted] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418140545_IsRulesAccepted', N'5.0.15');
GO

COMMIT;
GO

