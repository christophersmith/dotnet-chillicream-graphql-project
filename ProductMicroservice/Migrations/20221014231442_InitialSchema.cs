using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMicroservice.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKU = table.Column<string>(type: "varchar(32)", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    ProductDescription = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    UnitMSRP = table.Column<decimal>(type: "money", precision: 6, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSellable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeType",
                columns: table => new
                {
                    ProductAttributeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeTypeCode = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    ProductAttributeTypeName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    AreMultipleEntriesAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeType", x => x.ProductAttributeTypeId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeValue = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.ProductAttributeId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_ProductAttributeType_ProductAttributeTypeId",
                        column: x => x.ProductAttributeTypeId,
                        principalTable: "ProductAttributeType",
                        principalColumn: "ProductAttributeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName",
                table: "Product",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SKU",
                table: "Product",
                column: "SKU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductAttributeTypeId",
                table: "ProductAttribute",
                column: "ProductAttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductId",
                table: "ProductAttribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductId_ProductAttributeTypeId",
                table: "ProductAttribute",
                columns: new[] { "ProductId", "ProductAttributeTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductId_ProductAttributeTypeId_AttributeValue",
                table: "ProductAttribute",
                columns: new[] { "ProductId", "ProductAttributeTypeId", "AttributeValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeType_ProductAttributeTypeCode",
                table: "ProductAttributeType",
                column: "ProductAttributeTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeType_ProductAttributeTypeName",
                table: "ProductAttributeType",
                column: "ProductAttributeTypeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductAttributeType");
        }
    }
}
