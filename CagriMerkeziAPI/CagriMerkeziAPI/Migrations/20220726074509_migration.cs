using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CagriMerkeziAPI.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CagriDetays",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    musteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    durum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sonuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servisElemanı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cagriTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CagriDetays", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CagriDetays");
        }
    }
}
