using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol.Galaxy.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionBDSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DBO");

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.CustomerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                schema: "DBO",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "DBO",
                columns: table => new
                {
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "DBO",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    UserRol = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "DBO",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "CustomerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOption",
                schema: "DBO",
                columns: table => new
                {
                    UserOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOption", x => x.UserOptionId);
                    table.ForeignKey(
                        name: "FK_UserOption_Option_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "DBO",
                        principalTable: "Option",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOption_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "DBO",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIngresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualiza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualiza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "DBO",
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeId",
                schema: "DBO",
                table: "Customer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                schema: "DBO",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOption_OptionId",
                schema: "DBO",
                table: "UserOption",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOption_UserId",
                schema: "DBO",
                table: "UserOption",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "UserOption",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Option",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "User",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}
