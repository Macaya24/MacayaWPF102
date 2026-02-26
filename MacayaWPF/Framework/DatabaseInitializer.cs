using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Framework
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InitializeAsync()
        {
            try
            {
                await EnsureTableExistsAsync();
                await EnsureStoredProceduresExistAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization error: {ex.Message}");
                throw;
            }
        }

        private async Task EnsureTableExistsAsync()
        {
            var createTableSql = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmartPhone]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE SmartPhone (
                        SmartPhoneId INT IDENTITY(1,1) PRIMARY KEY,
                        Brand NVARCHAR(100) NOT NULL,
                        Model NVARCHAR(100) NOT NULL,
                        Price DECIMAL(18,2) NOT NULL,
                        Storage NVARCHAR(100) NOT NULL
                    );
                END";

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqlCommand(createTableSql, connection);
            await command.ExecuteNonQueryAsync();
        }

        private async Task EnsureStoredProceduresExistAsync()
        {
            var procedures = new[]
            {
                ("CreateSmartPhone", @"
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
                    END"),
                
                ("UpdateSmartPhone", @"
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
                        SET Brand = @Brand, Model = @Model, Price = @Price, Storage = @Storage
                        WHERE SmartPhoneId = @SmartPhoneId;
                    END"),
                
                ("DeleteSmartPhone", @"
                    CREATE PROCEDURE DeleteSmartPhone
                        @SmartPhoneId INT
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        DELETE FROM SmartPhone WHERE SmartPhoneId = @SmartPhoneId;
                    END"),
                
                ("GetAllSmartPhones", @"
                    CREATE PROCEDURE GetAllSmartPhones
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT SmartPhoneId, Brand, Model, Price, Storage
                        FROM SmartPhone
                        ORDER BY SmartPhoneId;
                    END"),
                
                ("ReadSmartPhoneById", @"
                    CREATE PROCEDURE ReadSmartPhoneById
                        @SmartPhoneId INT
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT SmartPhoneId, Brand, Model, Price, Storage
                        FROM SmartPhone
                        WHERE SmartPhoneId = @SmartPhoneId;
                    END")
            };

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            foreach (var (name, sql) in procedures)
            {
                // Check if procedure exists
                var checkSql = $"SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{name}]') AND type in (N'P', N'PC')";
                using var checkCommand = new SqlCommand(checkSql, connection);
                var exists = (int)await checkCommand.ExecuteScalarAsync() > 0;

                if (!exists)
                {
                    using var command = new SqlCommand(sql, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
