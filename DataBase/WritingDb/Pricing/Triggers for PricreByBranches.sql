USE [ProductWritingDb]
GO

ALTER TABLE [AuditPricing]
ADD OperationType NVARCHAR(10) NULL;

-- Triggers for PricreByBranches

-- Trigger: UPDATE
CREATE TRIGGER trg_PricreByBranches_Update
ON dbo.PricreByBranches
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditPricing (RecordId, BarcodeId, BranchId, SmallestUnitPrice, LowestPriceForSalePerSmallestUnit)
    SELECT
        d.Id,
        d.BarcodeId,
        d.BranchId,
        d.SmallestUnitPrice,
        d.LowestPriceForSalePerSmallestUnit
    FROM deleted d;
END
GO


-- Trigger: DELETE
CREATE TRIGGER trg_PricreByBranches_Delete
ON dbo.PricreByBranches
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditPricing (RecordId, BarcodeId, BranchId, SmallestUnitPrice, LowestPriceForSalePerSmallestUnit)
    SELECT
        d.Id,
        d.BarcodeId,
        d.BranchId,
        d.SmallestUnitPrice,
        d.LowestPriceForSalePerSmallestUnit
    FROM deleted d;
END
GO
