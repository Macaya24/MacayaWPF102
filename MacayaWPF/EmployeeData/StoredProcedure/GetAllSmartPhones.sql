CREATE PROCEDURE GetAllSmartPhones
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SmartPhoneId, Brand, Model, Price, Storage
    FROM SmartPhone
    ORDER BY SmartPhoneId;
END
