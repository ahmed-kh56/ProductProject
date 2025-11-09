CREATE TABLE [AuditLog] (
    [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    [TableName] NVARCHAR(128) NOT NULL,
    [OperationType] NVARCHAR(10) NOT NULL,
    [RecordId] NVARCHAR(50) NULL,
    [OldData] NVARCHAR(MAX) NULL,
    [NewData] NVARCHAR(MAX) NULL,
    [ChangedAt] DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE [AuditPricing](
    [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    [RecordId] [uniqueidentifier] NOT NULL,
	[BarcodeId] [uniqueidentifier] NOT NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[SmallestUnitPrice] [decimal](18, 2) NOT NULL,
	[LowestPriceForSalePerSmallestUnit] [decimal](18, 2) NULL,
    [ChangedAt] DATETIME NOT NULL DEFAULT GETDATE())
GO


