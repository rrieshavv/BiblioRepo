using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiblioRepo.Web.Migrations
{
    /// <inheritdoc />
    public partial class ProductDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "DiscountRate", "DiscountedPrice", "ISBN", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Charles Duhigg", 1, "A fascinating book that explores the science behind habit formation and how it can be transformed to improve individual and organizational lives.", 0.1f, 1079.99, "9780812981605", null, "The Power of Habit", 1199.99, 50 },
                    { 2, "Jane Austen", 3, "A classic romantic novel that follows the tumultuous relationship between Elizabeth Bennet and Mr. Darcy.", 0.05f, 664.99000000000001, "9780141439518", null, "Pride and Prejudice", 699.99000000000001, 30 },
                    { 3, "Dan Brown", 4, "A gripping mystery thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre and uncovers a conspiracy.", 0.15f, 764.99000000000001, "9780307474278", null, "The Da Vinci Code", 899.99000000000001, 40 },
                    { 4, "Suzanne Collins", 5, "Set in a dystopian future, this action-packed novel follows Katniss Everdeen as she fights for survival in a televised death match.", 0.1f, 539.99000000000001, "9780439023481", null, "The Hunger Games", 599.99000000000001, 25 },
                    { 5, "Frank Herbert", 6, "A science fiction masterpiece set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice.", 0.2f, 639.99000000000001, "9780441013593", null, "Dune", 799.99000000000001, 20 },
                    { 6, "Stephen King", 8, "A chilling horror novel that follows Jack Torrance as he becomes the winter caretaker of the Overlook Hotel and descends into madness.", 0.1f, 449.99000000000001, "9780307743657", null, "The Shining", 499.99000000000001, 35 },
                    { 7, "Rupi Kaur", 9, "A collection of poetry and prose about survival, love, and the healing power of femininity.", 0.1f, 1124.99, "9781449474256", null, "Milk and Honey", 1249.99, 45 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }
    }
}
