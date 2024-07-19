using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soft.Migrations
{
    /// <inheritdoc />
    public partial class project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories1",
                columns: table => new
                {
                    category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories1", x => x.category_Id);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products1",
                columns: table => new
                {
                    product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products1", x => x.product_Id);
                    table.ForeignKey(
                        name: "FK_products1_Categories1_category_Id",
                        column: x => x.category_Id,
                        principalTable: "Categories1",
                        principalColumn: "category_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartsId);
                    table.ForeignKey(
                        name: "FK_Carts_usersData_Id",
                        column: x => x.Id,
                        principalTable: "usersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries1",
                columns: table => new
                {
                    deliveries_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries1", x => x.deliveries_Id);
                    table.ForeignKey(
                        name: "FK_Deliveries1_usersData_Id",
                        column: x => x.Id,
                        principalTable: "usersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingOrders",
                columns: table => new
                {
                    order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingOrders", x => x.order_Id);
                    table.ForeignKey(
                        name: "FK_ShoppingOrders_usersData_Id",
                        column: x => x.Id,
                        principalTable: "usersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSolds",
                columns: table => new
                {
                    product_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    productsold_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSolds", x => new { x.product_Id, x.Id });
                    table.ForeignKey(
                        name: "FK_ProductSolds_products1_product_Id",
                        column: x => x.product_Id,
                        principalTable: "products1",
                        principalColumn: "product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSolds_usersData_Id",
                        column: x => x.Id,
                        principalTable: "usersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_Id = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemsId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "CartsId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_Id = table.Column<int>(type: "int", nullable: true),
                    totalprice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.payment_Id);
                    table.ForeignKey(
                        name: "FK_Payments_ShoppingOrders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "ShoppingOrders",
                        principalColumn: "order_Id");
                });

            migrationBuilder.CreateTable(
                name: "productVSshoppingorder1",
                columns: table => new
                {
                    product_Id = table.Column<int>(type: "int", nullable: false),
                    order_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVSshoppingorder1", x => new { x.product_Id, x.order_Id });
                    table.ForeignKey(
                        name: "FK_productVSshoppingorder1_ShoppingOrders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "ShoppingOrders",
                        principalColumn: "order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productVSshoppingorder1_products1_product_Id",
                        column: x => x.product_Id,
                        principalTable: "products1",
                        principalColumn: "product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionReports1",
                columns: table => new
                {
                    Report_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    order_Id = table.Column<int>(type: "int", nullable: false),
                    product_Id = table.Column<int>(type: "int", nullable: false),
                    payment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionReports1", x => x.Report_Id);
                    table.ForeignKey(
                        name: "FK_TransactionReports1_Payments_payment_Id",
                        column: x => x.payment_Id,
                        principalTable: "Payments",
                        principalColumn: "payment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionReports1_ShoppingOrders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "ShoppingOrders",
                        principalColumn: "order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionReports1_products1_product_Id",
                        column: x => x.product_Id,
                        principalTable: "products1",
                        principalColumn: "product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionReports1_usersData_Id",
                        column: x => x.Id,
                        principalTable: "usersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartsId",
                table: "CartItems",
                column: "CartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id",
                table: "Carts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries1_Id",
                table: "Deliveries1",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_order_Id",
                table: "Payments",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_products1_category_Id",
                table: "products1",
                column: "category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSolds_Id",
                table: "ProductSolds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_productVSshoppingorder1_order_Id",
                table: "productVSshoppingorder1",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrders_Id",
                table: "ShoppingOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports1_Id",
                table: "TransactionReports1",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports1_order_Id",
                table: "TransactionReports1",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports1_payment_Id",
                table: "TransactionReports1",
                column: "payment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports1_product_Id",
                table: "TransactionReports1",
                column: "product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Deliveries1");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "ProductSolds");

            migrationBuilder.DropTable(
                name: "productVSshoppingorder1");

            migrationBuilder.DropTable(
                name: "TransactionReports1");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "products1");

            migrationBuilder.DropTable(
                name: "ShoppingOrders");

            migrationBuilder.DropTable(
                name: "Categories1");

            migrationBuilder.DropTable(
                name: "usersData");
        }
    }
}
