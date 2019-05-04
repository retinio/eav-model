using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422170019_AddEntityRelations")]
    public class AddEntityRelationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity_relations",
                columns: table => new
                {
                    relation_id = table.Column<Guid>(),
                    referenced_entity_id = table.Column<Guid>(),
                    referencing_entity_id = table.Column<Guid>(),                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("entity_relations_pk", x => new { x.relation_id, x.referenced_entity_id, x.referencing_entity_id });
                    table.ForeignKey(
                        name: "relation_id_fk",
                        column: x => x.relation_id,
                        principalTable: "relations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "referenced_entity_id_fk",
                        column: x => x.referenced_entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "referencing_entity_id_fk",
                        column: x => x.referencing_entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "relation_id_ix",
                table: "entity_relations",
                columns: new[] { "relation_id" }
            );

            migrationBuilder.CreateIndex(
                name: "referenced_entity_id_ix",
                table: "entity_relations",
                columns: new[] { "referenced_entity_id" }
            );

            migrationBuilder.CreateIndex(
                name: "referencing_entity_id_ix",
                table: "entity_relations",
                columns: new[] { "referenced_entity_id" }
            );
        }
    }
}