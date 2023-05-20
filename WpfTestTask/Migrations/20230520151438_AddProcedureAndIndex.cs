using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfTestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddProcedureAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
CREATE PROCEDURE getCustomers
@name NVARCHAR(50) =  NULL,
@companyName NVARCHAR(50) =  NULL,
@phone NVARCHAR(50) =  NULL,
@email NVARCHAR(50) =  NULL
as
BEGIN
SELECT c.Id, c.Name, c.CompanyName, c.Phone, c.Email FROM Customers c
WHERE (@name IS NULL OR c.Name LIKE '%'+@name+'%') AND
(@companyName IS NULL OR c.CompanyName LIKE '%'+@companyName+'%') AND
(@phone IS NULL OR c.Phone LIKE '%'+@phone+'%') AND
(@email IS NULL OR c.Email LIKE '%'+@email+'%');
END
");

            migrationBuilder.Sql("CREATE INDEX name_index ON Customers (Name);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX name_index ON Customers");
            migrationBuilder.Sql("DROP PROCEDURE getCustomers");
        }
    }
}
