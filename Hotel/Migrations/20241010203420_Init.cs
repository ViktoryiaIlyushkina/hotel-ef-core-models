using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServiceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ExtraServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServiceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraServiceOrders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraServiceOrders_ExtraServices_ExtraServiceId",
                        column: x => x.ExtraServiceId,
                        principalTable: "ExtraServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Wi-Fi access", 5.00m, "Wi-Fi" },
                    { 2, "Drinks and snacks in the mini-bar", 10.00m, "Mini-bar" },
                    { 3, "Check-in before standard time", 20.00m, "Early check-in" },
                    { 4, "Check-out after standard time", 25.00m, "Late check-out" },
                    { 5, "Extra bed in the room", 15.00m, "Extra bed" },
                    { 6, "Baby cot in the room", 10.00m, "Baby cot" },
                    { 7, "Ironing services", 5.00m, "Iron and ironing board" },
                    { 8, "Hairdryer", 5.00m, "Hairdryer" },
                    { 9, "Bathrobe and slippers", 10.00m, "Bathrobe and slippers" },
                    { 10, "Parking space", 15.00m, "Parking" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, "alice.johnson@example.com", "Alice", "Johnson", "555-123-4567" },
                    { 4, "bob.williams@example.com", "Bob", "Williams", "555-456-7890" },
                    { 5, "charlie.brown@example.com", "Charlie", "Brown", "555-789-0123" },
                    { 6, "david.davis@example.com", "David", "Davis", "555-012-3456" },
                    { 7, "emily.wilson@example.com", "Emily", "Wilson", "555-345-6789" },
                    { 8, "frank.moore@example.com", "Frank", "Moore", "555-678-9012" },
                    { 9, "grace.taylor@example.com", "Grace", "Taylor", "555-901-2345" },
                    { 10, "henry.anderson@example.com", "Henry", "Anderson", "555-234-5678" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Floor", "PricePerNight", "RoomType" },
                values: new object[,]
                {
                    { 1, 2, 1, 100.00m, "Standard" },
                    { 2, 4, 2, 200.00m, "Suite" },
                    { 3, 2, 1, 100.00m, "Standard" },
                    { 4, 4, 2, 200.00m, "Suite" },
                    { 5, 2, 1, 100.00m, "Standard" },
                    { 6, 4, 2, 200.00m, "Suite" },
                    { 7, 2, 1, 100.00m, "Standard" },
                    { 8, 4, 2, 200.00m, "Suite" },
                    { 9, 2, 1, 100.00m, "Standard" },
                    { 10, 4, 2, 200.00m, "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Price", "ServiceName", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Daily room cleaning", 10.00m, "Cleaning", "Cleaning" },
                    { 2, "Continental breakfast", 15.00m, "Breakfast", "Breakfast" },
                    { 3, "Laundry service", 20.00m, "Laundry", "Services" },
                    { 4, "In-room dining", 25.00m, "Room service", "Services" },
                    { 5, "Airport transfer", 30.00m, "Transfer", "Services" },
                    { 6, "Lunch at the restaurant", 15.00m, "Lunch", "Dining" },
                    { 7, "Dinner at the restaurant", 20.00m, "Dinner", "Dining" },
                    { 8, "Drinks and snacks", 10.00m, "Bar", "Services" },
                    { 9, "Wi-Fi access", 5.00m, "Wi-Fi", "Services" },
                    { 10, "Movie watching", 15.00m, "Home theater", "Services" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "FirstName", "LastName", "Position" },
                values: new object[,]
                {
                    { 1, "Administration", "Peter", "Smith", "Manager" },
                    { 2, "Administration", "Mary", "Jones", "Receptionist" },
                    { 3, "Kitchen", "David", "Brown", "Chef" },
                    { 4, "Restaurant", "Lisa", "Wilson", "Waiter" },
                    { 5, "Cleaning", "Michael", "Davis", "Maid" },
                    { 6, "Bar", "Susan", "Garcia", "Bartender" },
                    { 7, "Transfer", "John", "Rodriguez", "Driver" },
                    { 8, "Technical Department", "Jennifer", "Martinez", "Technician" },
                    { 9, "Cleaning", "Thomas", "Robinson", "Housekeeper" },
                    { 10, "Finance Department", "Patricia", "Lee", "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ArrivalDate", "DepartureDate", "GuestId", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 7, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 8, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 9, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9 },
                    { 10, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "ExtraServiceOrders",
                columns: new[] { "Id", "BookingId", "ExtraServiceId", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 6, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 7, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 8, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 9, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 10, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 300.00m, 1, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 2, 600.00m, 2, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 3, 400.00m, 3, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 4, 800.00m, 4, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 5, 500.00m, 5, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 6, 700.00m, 6, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 7, 300.00m, 7, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 8, 600.00m, 8, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 9, 400.00m, 9, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Card" },
                    { 10, 800.00m, 10, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "FirstName", "LastName", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Great hotel! Clean, cozy, friendly staff.", "John", "Doe", 4 },
                    { 2, 2, "Excellent room with a beautiful view. Highly recommend!", "Jane", "Smith", 5 },
                    { 3, 3, "Overall not bad, but breakfast could be better.", "Alice", "Johnson", 3 },
                    { 4, 4, "Good location, easy access to transportation.", "Bob", "Williams", 4 },
                    { 5, 5, "Superb service, staff very attentive.", "Charlie", "Brown", 5 },
                    { 6, 6, "Clean and comfortable room, great internet.", "David", "Davis", 4 },
                    { 7, 7, "The price is a bit overpriced for such a room.", "Emily", "Wilson", 3 },
                    { 8, 8, "Unforgettable vacation! Everything was just great!", "Frank", "Moore", 5 },
                    { 9, 9, "Good hotel for business trips.", "Grace", "Taylor", 4 },
                    { 10, 10, "Excellent choice for family vacation.", "Henry", "Anderson", 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceOrders",
                columns: new[] { "Id", "BookingId", "OrderDate", "Quantity", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, new DateTime(2023, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 3, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, 4, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, 5, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, 6, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, 7, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 8, 8, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 9, 9, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 10, 10, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraServiceOrders_BookingId",
                table: "ExtraServiceOrders",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraServiceOrders_ExtraServiceId",
                table: "ExtraServiceOrders",
                column: "ExtraServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_BookingId",
                table: "ServiceOrders",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ServiceId",
                table: "ServiceOrders",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraServiceOrders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
