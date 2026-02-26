CREATE PROCEDURE ReadSmartPhoneById
    @SmartPhoneId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SmartPhoneId, Brand, Model, Price, Storage
    FROM SmartPhone
    WHERE SmartPhoneId = @SmartPhoneId;
END
