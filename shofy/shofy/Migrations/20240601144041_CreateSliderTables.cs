using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shofy.Migrations
{
    public partial class CreateSliderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sliders",
                table: "sliders");

            migrationBuilder.RenameTable(
                name: "sliders",
                newName: "Sliders");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, "<p>Exclusive offer <span>-35%</span> off this week<img src=\"~/assets/icons/offer-line.svg\" alt=\"\"></p>\n", "slider-img-1.png", false, "The best tablet Collection 2024" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 2, "<p>Exclusive offer <span>-10%</span> off this week<img src=\"~/assets/icons/offer-line.svg\" alt=\"\"></p>", "slider-img-2.png", false, "The best note book Collection 2024" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 3, "<p>Exclusive offer <span>-10%</span> off this week<img src=\"~/assets/icons/offer-line-red.svg\" alt=\"\"></p>\n", "slider-img-3.png", false, "The best tablet Collection 2024" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders");

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Sliders");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sliders",
                table: "sliders",
                column: "Id");
        }
    }
}
