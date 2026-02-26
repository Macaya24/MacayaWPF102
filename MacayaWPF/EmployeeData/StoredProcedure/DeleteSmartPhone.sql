CREATE PROCEDURE DeleteSmartPhone
    @SmartPhoneId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM SmartPhone
    WHERE SmartPhoneId = @SmartPhoneId;
END
