using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Election",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Election", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    ElectionId = table.Column<Guid>(nullable: false),
                    QtdeAssociates = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_Election_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Election",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Associate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Wishes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Associate_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Associate_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elected",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Wishes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elected", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elected_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elected_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Election",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[] { new Guid("bd3c0f5d-87a9-4bac-8cd8-73c671cb368c"), new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(1732), "Eleições 2020", null });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "CreateAt", "Name", "Picture", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("f060a687-65f2-4663-ba0c-0fd2d7622f96"), new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4182), "Marcelle", null, null },
                    { new Guid("0baf70b3-82ea-4231-82f4-ca1db046afef"), new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4227), "Fabiana", null, null },
                    { new Guid("4ac45dda-7443-465c-b0a5-497f19944cc9"), new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4232), "Carolina", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("c4b2e5b9-95e4-4008-867f-c2b15e67a1f1"), new DateTime(2020, 10, 5, 10, 8, 52, 682, DateTimeKind.Local).AddTicks(6853), "mfrinfo@mail.com", "Administrador", new DateTime(2020, 10, 5, 10, 8, 52, 684, DateTimeKind.Local).AddTicks(77) });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Id", "CreateAt", "ElectionId", "Name", "QtdeAssociates", "UpdateAt" },
                values: new object[] { new Guid("80c6df2f-2b29-470b-9a1e-dc6a057df3da"), new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(3217), new Guid("bd3c0f5d-87a9-4bac-8cd8-73c671cb368c"), "Aventureiros", 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Associate_OfficeId",
                table: "Associate",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Associate_MemberId_OfficeId",
                table: "Associate",
                columns: new[] { "MemberId", "OfficeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elected_OfficeId",
                table: "Elected",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Elected_MemberId_OfficeId",
                table: "Elected",
                columns: new[] { "MemberId", "OfficeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Election_Name",
                table: "Election",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_Name",
                table: "Member",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Office_ElectionId",
                table: "Office",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_Name",
                table: "Office",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associate");

            migrationBuilder.DropTable(
                name: "Elected");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Election");
        }
    }
}
