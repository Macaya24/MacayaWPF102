CREATE PROCEDURE UpdateSmartPhone
    @SmartPhoneId INT,
    @Brand NVARCHAR(100),
    @Model NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Storage NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE SmartPhone
    SET Brand = @Brand,
        Model = @Model,
        Price = @Price,
        Storage = @Storage
    WHERE SmartPhoneId = @SmartPhoneId;
END
