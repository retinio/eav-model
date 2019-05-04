using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422164904_AddRelations")]
    public class AddRelationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "relations",
                columns: table => new
                {
                    id = table.Column<Guid>(),                    
                    created_date_time = table.Column<DateTimeOffset>(),
                    modified_date_time = table.Column<DateTimeOffset>(nullable: true),
                    referenced_entity_type_id = table.Column<Guid>(),
                    referencing_entity_type_id = table.Column<Guid>(),
                    name = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("relations_pk", x => new { x.id });
                    table.ForeignKey(
                        name: "relations_referenced_entity_type_id_fk",
                        column: x => x.referenced_entity_type_id,
                        principalTable: "entity_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "referencing_entity_type_id_fk",
                        column: x => x.referencing_entity_type_id,
                        principalTable: "entity_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "relations_referenced_entity_type_id_ix",
                table: "relations",
                columns: new[] { "referenced_entity_type_id" }
            );

            migrationBuilder.CreateIndex(
                name: "referencing_entity_type_id",
                table: "relations",
                columns: new[] { "referencing_entity_type_id" }
            );
        }
    }
}