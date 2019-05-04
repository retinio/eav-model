using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422163702_AddIntegerEav")]
    public class AddIntegerEavMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "integer_entity_attribute_values",
                columns: table => new
                {
                    entity_id = table.Column<Guid>(),
                    attribute_id = table.Column<Guid>(),
                    value = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("integer_entity_attribute_values_pk", x => new { x.entity_id, x.attribute_id });
                    table.ForeignKey(
                        name: "integer_entity_attribute_values_entity_id_fk",
                        column: x => x.entity_id,
                        principalTable: "entities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "integer_entity_attribute_values_attribute_id_fk",
                        column: x => x.attribute_id,
                        principalTable: "attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "integer_entity_attribute_values_entity_id_ix",
                table: "integer_entity_attribute_values",
                columns: new[] { "entity_id" }
            );

            migrationBuilder.CreateIndex(
                name: "integer_entity_attribute_values_attribute_id_ix",
                table: "integer_entity_attribute_values",
                columns: new[] { "attribute_id" }
            );
        }
    }
}