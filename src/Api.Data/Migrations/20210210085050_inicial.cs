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
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Slug = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "RolePermission",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                values: new object[] { new Guid("fe241124-3909-41bf-b398-0a1ca4306c7d"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(3548), "Eleições 2020", null });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "CreateAt", "Name", "Picture", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("768459fe-e8c9-4a4d-bcf4-bfff1db1451a"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(5958), "Marcelle", null, null },
                    { new Guid("6cb7c6e2-80d4-4ca7-8a96-9db7d23e8067"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(6008), "Fabiana", null, null },
                    { new Guid("0b7c0995-98b5-4963-be58-386e90d9419f"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(6011), "Carolina", null, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreateAt", "Name", "Slug", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1545a018-6e16-4f7f-96f6-0eeb52cb0b54"), null, "Papeis Alterar", "roles-Update", null },
                    { new Guid("d97c2c7b-14d1-4417-b048-44d186b7fff2"), null, "Papeis Inserir", "roles-insert", null },
                    { new Guid("6ad1f182-e175-431a-8a46-6f0b7af24895"), null, "Papeis Listar", "roles-list", null },
                    { new Guid("c8e3b20a-038d-4ff1-a608-2671a6b1217c"), null, "Permissões Apagar", "permission-delete", null },
                    { new Guid("16c724e3-2ee6-4d7e-a3b6-5293d92e4941"), null, "Permissões Alterar", "permission-Update", null },
                    { new Guid("1fd4b7d5-fc03-4b92-a785-d3f5cc312c69"), null, "Permissões Listar", "permission-list", null },
                    { new Guid("8e757f20-953e-4f79-8fb0-938e52951871"), null, "Papeis Apagar", "roles-delete", null },
                    { new Guid("ec954b71-9b02-499e-91d6-3e2f4ee39eda"), null, "Usuários Apagar", "user-delete", null },
                    { new Guid("14d38cf2-c5c2-4baf-91b3-abc2a2c29079"), null, "Usuários Alterar", "user-Update", null },
                    { new Guid("aee40c5c-d8ad-43d4-9de6-4cd0539441db"), null, "Usuários Inserir", "user-insert", null },
                    { new Guid("67963d11-d9c2-4b05-9315-fff08c07733f"), null, "Usuários Listar", "user-list", null },
                    { new Guid("77c32c2d-cacb-47c4-979a-4f7ac5dba98f"), null, "Permissões Inserir", "permission-insert", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[] { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new DateTime(2021, 2, 10, 5, 50, 49, 864, DateTimeKind.Local).AddTicks(5423), "Administrador", null });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Id", "CreateAt", "ElectionId", "Name", "QtdeAssociates", "UpdateAt" },
                values: new object[] { new Guid("0865ba8a-f3be-4778-993d-6c7646806f4f"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(4903), new Guid("fe241124-3909-41bf-b398-0a1ca4306c7d"), "Aventureiros", 0, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RoleId", "PermissionId", "CreateAt", "Id", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("67963d11-d9c2-4b05-9315-fff08c07733f"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(106), new Guid("bb2370ab-a560-469c-9d7c-76f571200182"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("aee40c5c-d8ad-43d4-9de6-4cd0539441db"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(185), new Guid("df5b3183-8595-4f6c-9fec-a98737c4b418"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("14d38cf2-c5c2-4baf-91b3-abc2a2c29079"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(198), new Guid("f13814d9-5ce8-4113-ab66-dea3cf76eb2b"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("ec954b71-9b02-499e-91d6-3e2f4ee39eda"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(201), new Guid("7ed650bd-aad8-4cbe-aa50-7b4c97f70d02"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("1fd4b7d5-fc03-4b92-a785-d3f5cc312c69"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(205), new Guid("e6fa2b1b-5c5f-48b7-abe3-c832f5a4e06f"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("77c32c2d-cacb-47c4-979a-4f7ac5dba98f"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(208), new Guid("48a1dece-b73a-4245-9608-a40f822ae48f"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("16c724e3-2ee6-4d7e-a3b6-5293d92e4941"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(210), new Guid("99e86087-ba90-4e08-ae93-2a8312623ddc"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("c8e3b20a-038d-4ff1-a608-2671a6b1217c"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(213), new Guid("fd1a1934-237f-45e3-8986-c226b895cd08"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("6ad1f182-e175-431a-8a46-6f0b7af24895"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(215), new Guid("3de4f1e7-b412-46b2-8c96-d1ffdd397411"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("d97c2c7b-14d1-4417-b048-44d186b7fff2"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(218), new Guid("647360a1-ae78-4b55-b8ab-10c9ec1d7422"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("1545a018-6e16-4f7f-96f6-0eeb52cb0b54"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(223), new Guid("ec372f7d-5bf1-46c5-a6e6-b473efb3239c"), null },
                    { new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), new Guid("8e757f20-953e-4f79-8fb0-938e52951871"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(226), new Guid("7a601b11-63a5-42fe-868e-119279b26f37"), null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "RoleId", "Senha", "UpdateAt" },
                values: new object[] { new Guid("d7276da4-917d-42d8-8d09-a996f91f98b0"), new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(2257), "mauro.mmx@gmail.com", "Mauro Meneses Xavier", new Guid("78e54a43-4fd4-4e01-9980-a9a64fbc5d4b"), "698dc19d489c4e4db73e28a713eab07b", new DateTime(2021, 2, 10, 5, 50, 49, 867, DateTimeKind.Local).AddTicks(2268) });

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
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associate");

            migrationBuilder.DropTable(
                name: "Elected");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Election");
        }
    }
}
