using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    Place = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adverts_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ad8358-07d1-486d-9e8a-3d54aa2ff75a", null, "Öğretmen", "Teacher", "TEACHER" },
                    { "bb699baa-9c56-450f-805e-9d94a049fd23", null, "Yönetici", "Admin", "ADMIN" },
                    { "bf227cc0-1b37-4cae-9ac0-0ccc5f143b91", null, "Öğrenci", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CreatedDate", "DateofBirth", "Description", "District", "Email", "EmailConfirmed", "FirstName", "Gender", "IsApproved", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Place", "SecurityStamp", "TwoFactorEnabled", "Url", "UserName" },
                values: new object[,]
                {
                    { "0588abca-4ab4-4905-b958-fbb070346b03", 0, "İstanbul", "84774bba-ca82-4a02-9796-a379a8ec81d3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Öğrenciyim", "Fatih", "veli@hotmail.com", true, "Veli", "Erkek", false, "Sarı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VELI@HOTMAIL.COM", "OGRENCIVELI", "VELI", "AQAAAAIAAYagAAAAEMf+kQAdCZe2PtJODl94HwKbuAc+ivyfi/fzl/tQqZ52IfsryZPol8ETRv//sN0pHQ==", null, false, "Online", "c6f4b8d3-ab29-4572-b494-c2b2527d8c8f", false, null, "veli" },
                    { "3b9d102e-bd3b-4123-9f83-66e638f5401a", 0, "İstanbul", "faa8be0c-a6d5-49a2-bbe0-26632fd50c48", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Öğretmenim", "Beşiktaş", "ekin@hotmail.com", true, "Ekin", "Kadın", false, "Cömert", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ekin@hotmail.com", "OGRETMENEKIN", "EKIN", null, null, false, "Online", "ccaf0e9c-b4f2-4043-98f3-69373422ac0d", false, null, "ekin" },
                    { "6258e3a1-287d-4291-9e9d-610ae12961a2", 0, "İstanbul", "03e8a8d6-ac33-4799-ac7c-3570b09529ec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Öğretmenim", "Kadıköy", "mehmet@gmail.com", true, "Mehmet", "Erkek", false, "Yılmaz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@gmail.com", "OGRETMENMEHMET", "MEHMET", null, null, false, "Fiziksel", "9d152573-9a59-4bad-8c0e-609664a50816", false, null, "mehmet" },
                    { "7a3a52e5-7314-4bc6-bd6d-8a1f8a019af0", 0, "Ankara", "cb74d8ec-634c-497a-8873-79437bb6b4d0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Öğretmenim", "Çankaya", "ayse@gmail.com", true, "Ayşe", "Kadın", false, "Ertaş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse@gmail.com", "OGRENCIAYSE", "AYSE", null, null, false, "Fiziksel", "5ca1d0d7-8884-4d54-91af-c57c48c67178", false, null, "ayse" },
                    { "8c455eb9-154d-4978-9f61-de614570416b", 0, "İstanbul", "441b2d29-49f0-482b-8c2d-ceb6e2fb6826", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "Küçükçekmece", "cem@hotmail.com", true, "Cem", "Erkek", false, "ADmin", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CEM@HOTMAIL.COM", "ADMINCEM", "CEM", "AQAAAAIAAYagAAAAEF5KIR/U3VdHywgiugthvAmLKU5aFFqsUjKvrWZ7n3BOKo6HEyfFBhH1GCIWgCGpKQ==", null, false, "Online", "4ba9c8dc-53f1-4f9a-b8aa-925a53ac550f", false, null, "cem" },
                    { "bd3e9102-9085-4c78-a1bf-6db66d30fd13", 0, "İstanbul", "5faafe10-57d0-496b-a894-cb1221ea5870", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Öğretmenim", "Beşiktaş", "ali@hotmail.com", true, "Ali", "Erkek", false, "Aktaş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI@HOTMAIL.COM", "OGRETMENALI", "ALI", "AQAAAAIAAYagAAAAEJae6XeRhDAEhOiycJ4E8CdfByJmgURbnauUqsX8yuJ4FVUphPMXsylfrNfoZK7O8Q==", null, false, "Online", "dfdf9b1e-0c9a-440a-b663-f42902576b65", false, null, "ali" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4491), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4494), "Matematik", "matematik" },
                    { 2, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4497), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4501), "Fizik", "fizik" },
                    { 3, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4513), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4513), "Kimya", "kimya" },
                    { 4, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4514), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4515), "Biyoloji", "biyoloji" },
                    { 5, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4516), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4517), "İngilizce", "ingilizce" },
                    { 6, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4518), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4518), "Almanca", "almanca" },
                    { 7, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4519), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4520), "Fransızca", "fransızca" },
                    { 8, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4521), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4521), "İspanyolca", "ispanyolca" },
                    { 9, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4522), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4523), "İtalyanca", "italyanca" },
                    { 10, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4524), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4524), "Japonca", "japonca" },
                    { 11, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4525), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4526), "Çince", "cince" },
                    { 12, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4527), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4527), "Türkçe", "turkce" },
                    { 14, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4528), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4529), "Sosyal bilimler", "sosyal-bilimler" },
                    { 15, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4530), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4530), "Tarih", "tarih" },
                    { 16, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4531), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4532), "Coğrafya", "cografya" },
                    { 17, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4533), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4533), "Sanat tarihi", "sanat-tarihi" },
                    { 18, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4534), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4535), "Müzik", "muzik" },
                    { 19, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4536), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4537), "Resim", "resim" },
                    { 20, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4538), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4538), "Dans", "dans" },
                    { 21, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4539), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4540), "Drama", "drama" },
                    { 22, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4541), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4541), "Üniversite sınavı hazırlık dersleri", "üniversite-sınavı-hazırlık-dersleri" },
                    { 23, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4542), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4543), "Dil sınavı hazırlık dersleri", "dil-sınavı-hazırlık-dersleri" },
                    { 24, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4544), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4545), "Programlama dilleri", "programlama-dilleri" },
                    { 25, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4546), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4546), "İşletme ve finans dersleri", "işletme-ve-finans-dersleri" },
                    { 26, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4547), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(4548), "Mühendislik dersleri", "mühendislik-dersleri" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bf227cc0-1b37-4cae-9ac0-0ccc5f143b91", "0588abca-4ab4-4905-b958-fbb070346b03" },
                    { "bb699baa-9c56-450f-805e-9d94a049fd23", "8c455eb9-154d-4978-9f61-de614570416b" },
                    { "06ad8358-07d1-486d-9e8a-3d54aa2ff75a", "bd3e9102-9085-4c78-a1bf-6db66d30fd13" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2732), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2736), "1.jpg", "8c455eb9-154d-4978-9f61-de614570416b" },
                    { 2, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2737), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2738), "3.jpg", "bd3e9102-9085-4c78-a1bf-6db66d30fd13" },
                    { 3, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2739), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2739), "4.jpg", "0588abca-4ab4-4905-b958-fbb070346b03" },
                    { 4, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2741), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2741), "2.jpg", "7a3a52e5-7314-4bc6-bd6d-8a1f8a019af0" },
                    { 5, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2742), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2742), "5.jpg", "6258e3a1-287d-4291-9e9d-610ae12961a2" },
                    { 6, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2744), new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(2744), "6.jpg", "3b9d102e-bd3b-4123-9f83-66e638f5401a" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "0588abca-4ab4-4905-b958-fbb070346b03" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "IsApproved", "UserId" },
                values: new object[,]
                {
                    { 1, false, "bd3e9102-9085-4c78-a1bf-6db66d30fd13" },
                    { 2, false, "7a3a52e5-7314-4bc6-bd6d-8a1f8a019af0" },
                    { 3, false, "6258e3a1-287d-4291-9e9d-610ae12961a2" },
                    { 4, false, "3b9d102e-bd3b-4123-9f83-66e638f5401a" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "Comment", "CreatedDate", "Description", "ImageId", "LessonId", "ModifiedDate", "Name", "Price", "TeacherId", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik alanından mezunum.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(402), "Matematik dersi verebilirim", null, 1, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(416), "Matematik Özel Dersi", 200m, 1, "matematik-ozel-dersi" },
                    { 2, "Fizik alanından mezunum.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(424), "Fizik dersi verebilirim", null, 2, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(425), "Fizik Özel Dersi", 220m, 3, "fizik-ozel-dersi" },
                    { 3, "Kimya alanından mezunum.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(427), "Kimya dersi verebilirim", null, 3, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(428), "Kimya Özel Dersi", 210m, 2, "kimya-ozel-dersi" },
                    { 4, "Biyoloji öğretmeniyim.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(430), "Biyoloji dersi verebilirim", null, 4, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(430), "Biyoloji Özel Dersi", 250m, 4, "biyoloji-ozel-dersi" },
                    { 5, "Tarih alanında deneyimliyim.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(432), "Tarih dersi verebilirim", null, 15, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(432), "Tarih Özel Dersi", 280m, 3, "tarih-ozel-dersi" },
                    { 6, "Müzik öğretmeniyim.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(434), "Müzik dersi verebilirim", null, 18, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(435), "Müzik Özel Dersi", 320m, 1, "muzik-ozel-dersi" },
                    { 7, "Edebiyat alanında uzmanım.", new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(437), "Edebiyat dersi verebilirim", null, 12, new DateTime(2023, 5, 16, 0, 0, 53, 120, DateTimeKind.Local).AddTicks(437), "Edebiyat Özel Dersi", 280m, 2, "edebiyat-ozel-dersi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ImageId",
                table: "Adverts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_LessonId",
                table: "Adverts",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
