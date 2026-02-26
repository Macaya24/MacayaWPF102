CREATE PROCEDURE CreateSmartPhone
    @Brand NVARCHAR(100),
    @Model NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Storage NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO SmartPhone (Brand, Model, Price, Storage)
    VALUES (@Brand, @Model, @Price, @Storage);
END
