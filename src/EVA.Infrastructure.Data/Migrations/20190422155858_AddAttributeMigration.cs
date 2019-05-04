using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422155858_AddAttributeType")]
    public class AddAttributeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    id = table.Column<Guid>(),
                    type_id = table.Column<int>(),
                    created_date_time = table.Column<DateTimeOffset>(),
                    modified_date_time = table.Column<DateTimeOffset>(nullable: true),
                    name = table.Column<string>(maxLength: 128),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attributes_pk", x => x.id);
                    table.UniqueConstraint("attributes_un", x => x.name);
                    table.ForeignKey(
                        name: "attributes_type_id",
                        column: x => x.type_id,
                        principalTable: "attribute_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "attributes_name_ix",
                table: "attributes",
                columns: new[] { "name" }
            );

            migrationBuilder.CreateIndex(
                name: "attributes_type_id_ix",
                table: "attributes",
                columns: new[] { "type_id" }
            );
        }
    }
}