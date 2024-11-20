using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvertisingAgencyApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    contract_code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    current_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.contract_code);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    person_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Advertising",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<DateTime>(type: "date", nullable: false),
                    end_time = table.Column<DateTime>(type: "date", nullable: false),
                    advertising_type = table.Column<string>(type: "text", nullable: true),
                    campaign_code = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertising", x => x.id);
                    table.ForeignKey(
                        name: "advertising_fk_campaign_code",
                        column: x => x.campaign_code,
                        principalTable: "Campaign",
                        principalColumn: "contract_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    person_id = table.Column<long>(type: "bigint", nullable: false),
                    started_work = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.person_id);
                    table.ForeignKey(
                        name: "manager_fk_person_id",
                        column: x => x.person_id,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdsRate",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cost_per_click = table.Column<float>(type: "real", nullable: false),
                    click_through_rate = table.Column<float>(type: "real", nullable: false),
                    conversion_rate = table.Column<float>(type: "real", nullable: false),
                    avg_quality_score = table.Column<float>(type: "real", nullable: false),
                    AdvertisingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsRate", x => x.id);
                    table.ForeignKey(
                        name: "ads_rate_fk_advertising_id",
                        column: x => x.AdvertisingId,
                        principalTable: "Advertising",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    contract_code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_designed = table.Column<DateTime>(type: "date", nullable: false),
                    valid_from = table.Column<DateTime>(type: "date", nullable: false),
                    valid_to = table.Column<DateTime>(type: "date", nullable: false),
                    manager_id = table.Column<long>(type: "bigint", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.contract_code);
                    table.ForeignKey(
                        name: "contract_fk_client_id",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contract_fk_manager_id",
                        column: x => x.manager_id,
                        principalTable: "Manager",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdsRate_AdvertisingId",
                table: "AdsRate",
                column: "AdvertisingId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertising_campaign_code",
                table: "Advertising",
                column: "campaign_code");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_client_id",
                table: "Contract",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_manager_id",
                table: "Contract",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "Person",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_phone_number",
                table: "Person",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdsRate");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Advertising");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
