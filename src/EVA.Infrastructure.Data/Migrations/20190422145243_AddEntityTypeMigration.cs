using System;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422145243_AddEntityType")]
    public class AddEntityTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity_types",
                columns: table => new
                {
                    id = table.Column<Guid>(),                    
                    created_date_time = table.Column<DateTimeOffset>(),
                    modified_date_time = table.Column<DateTimeOffset>(nullable: true),
                    name = table.Column<string>(maxLength:128),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entity_types_pk", x => x.id);
                    table.UniqueConstraint("entity_types_un", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "entity_types_ix",
                table: "entity_types",
                columns: new[] { "name" }
            );
        }
    }
}