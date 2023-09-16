using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maasgroep.Database.Migrations
{
    /// <inheritdoc />
    public partial class _20230916_001_eersteOpzet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "receipts");

            migrationBuilder.EnsureSchema(
                name: "photos");

            migrationBuilder.CreateSequence(
                name: "CostCentreSeq",
                schema: "receipts");

            migrationBuilder.CreateSequence(
                name: "PhotosSeq",
                schema: "photos");

            migrationBuilder.CreateSequence(
                name: "ReceiptsSeq",
                schema: "receipts");

            migrationBuilder.CreateSequence(
                name: "StoreSeq",
                schema: "receipts");

            migrationBuilder.CreateTable(
                name: "CostCentre",
                schema: "receipts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('receipts.\"CostCentreSeq\"')"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCentre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "receipts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('receipts.\"StoreSeq\"')"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                schema: "receipts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('receipts.\"ReceiptsSeq\"')"),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    CostCentreId = table.Column<long>(type: "bigint", nullable: false),
                    Approved = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_CostCentre_CostCentreId",
                        column: x => x.CostCentreId,
                        principalSchema: "receipts",
                        principalTable: "CostCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "receipts",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "photos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('photos.\"PhotosSeq\"')"),
                    ReceiptId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Bytes = table.Column<byte[]>(type: "bytea", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalSchema: "receipts",
                        principalTable: "Receipts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCentre_Name",
                schema: "receipts",
                table: "CostCentre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ReceiptId",
                schema: "photos",
                table: "Photos",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CostCentreId",
                schema: "receipts",
                table: "Receipts",
                column: "CostCentreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_StoreId",
                schema: "receipts",
                table: "Receipts",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_Name",
                schema: "receipts",
                table: "Store",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos",
                schema: "photos");

            migrationBuilder.DropTable(
                name: "Receipts",
                schema: "receipts");

            migrationBuilder.DropTable(
                name: "CostCentre",
                schema: "receipts");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "receipts");

            migrationBuilder.DropSequence(
                name: "CostCentreSeq",
                schema: "receipts");

            migrationBuilder.DropSequence(
                name: "PhotosSeq",
                schema: "photos");

            migrationBuilder.DropSequence(
                name: "ReceiptsSeq",
                schema: "receipts");

            migrationBuilder.DropSequence(
                name: "StoreSeq",
                schema: "receipts");
        }
    }
}
