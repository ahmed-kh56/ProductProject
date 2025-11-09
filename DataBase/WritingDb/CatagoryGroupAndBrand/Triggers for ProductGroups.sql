USE [ProductWritingDb]
GO

-- Triggers for ProductGroups

-- Trigger: UPDATE
CREATE TRIGGER trg_ProductGroups_Update
ON dbo.ProductGroups
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, OperationType, RecordId, OldData, NewData)
    SELECT 
        'ProductGroups' AS TableName,
        'UPDATE' AS OperationType,
        CAST(I.Id AS NVARCHAR(50)) AS RecordId,
        (
            SELECT D.*
            FROM DELETED D
            WHERE D.Id = I.Id
            FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ) AS OldData,
        (
            SELECT I2.*
            FROM INSERTED I2
            WHERE I2.Id = I.Id
            FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ) AS NewData
    FROM INSERTED I;
END;
GO

-- Trigger: DELETE
CREATE TRIGGER trg_ProductGroups_Delete
ON dbo.ProductGroups
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, OperationType, RecordId, OldData)
    SELECT 
        'ProductGroups' AS TableName,
        'DELETE' AS OperationType,
        CAST(D.Id AS NVARCHAR(50)) AS RecordId,
        (
            SELECT D.*
            FROM DELETED D
            WHERE D.Id = D.Id
            FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ) AS OldData
    FROM DELETED D;
END;
GO
