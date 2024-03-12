using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_admin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom_admin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email_admin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id_admin);
                });

            migrationBuilder.CreateTable(
                name: "PlanPaiement",
                columns: table => new
                {
                    id_PlanPaiement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle_PlanPaimenet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPaiement", x => x.id_PlanPaiement);
                });

            migrationBuilder.CreateTable(
                name: "vendeurs",
                columns: table => new
                {
                    id_Vendeur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_Venduer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom_Vendeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_naissance = table.Column<DateTime>(type: "date", nullable: false),
                    email_Vendeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_telephone = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verifie_compte = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendeurs", x => x.id_Vendeur);
                });

            migrationBuilder.CreateTable(
                name: "paiements",
                columns: table => new
                {
                    id_paiement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datepaiement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendeurId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanPaiementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiements", x => x.id_paiement);
                    table.ForeignKey(
                        name: "FK_paiements_PlanPaiement_PlanPaiementId",
                        column: x => x.PlanPaiementId,
                        principalTable: "PlanPaiement",
                        principalColumn: "id_PlanPaiement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_paiements_vendeurs_VendeurId",
                        column: x => x.VendeurId,
                        principalTable: "vendeurs",
                        principalColumn: "id_Vendeur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    id_store = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom_store = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlstore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendeurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.id_store);
                    table.ForeignKey(
                        name: "FK_stores_vendeurs_VendeurId",
                        column: x => x.VendeurId,
                        principalTable: "vendeurs",
                        principalColumn: "id_Vendeur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendeurAdmin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    VendeurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendeurAdmin", x => new { x.VendeurId, x.AdminId });
                    table.ForeignKey(
                        name: "FK_VendeurAdmin_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendeurAdmin_vendeurs_VendeurId",
                        column: x => x.VendeurId,
                        principalTable: "vendeurs",
                        principalColumn: "id_Vendeur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paiements_PlanPaiementId",
                table: "paiements",
                column: "PlanPaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_paiements_VendeurId",
                table: "paiements",
                column: "VendeurId");

            migrationBuilder.CreateIndex(
                name: "IX_stores_VendeurId",
                table: "stores",
                column: "VendeurId");

            migrationBuilder.CreateIndex(
                name: "IX_VendeurAdmin_AdminId",
                table: "VendeurAdmin",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paiements");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "VendeurAdmin");

            migrationBuilder.DropTable(
                name: "PlanPaiement");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "vendeurs");
        }
    }
}
