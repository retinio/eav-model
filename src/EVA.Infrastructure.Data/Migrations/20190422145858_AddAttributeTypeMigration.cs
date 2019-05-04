using EVA.Domain.Attributes;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVA.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaContext))]
    [Migration("20190422145858_AddAttributeType")]
    public class AddAttributeTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attribute_types",
                columns: table => new
                {
                    id = table.Column<int>(),                    
                    name = table.Column<string>(maxLength: 128)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attribute_types_pk", x => x.id);
                    table.UniqueConstraint("attribute_types_un", x => x.name);
                });

            foreach (var attribute in AttributeType.List())
            {
                migrationBuilder.InsertData(
                    table: "attribute_types",
                    columns: new[] { "id", "name" },
                    values: new object[] { attribute.Id, attribute.Name });
            }
        }
    }
}