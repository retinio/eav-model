using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422160829_AddEntityType")]
    public class AddEntityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entities",
                columns: table => new
                {
                    id = table.Column<Guid>(),
                    type_id = table.Column<Guid>(),
                    created_date_time = table.Column<DateTimeOffset>(),
                    modified_date_time = table.Column<DateTimeOffset>(nullable: true),                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("entities_pk", x => x.id);
                    table.ForeignKey(
                        name: "entities_type_id_fk",
                        column: x => x.type_id,
                        principalTable: "entity_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "entity_type_id_ix",
                table: "entities",
                columns: new[] { "type_id" }
            );
        }
    }

}