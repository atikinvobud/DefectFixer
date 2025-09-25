using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MongoDocumentId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    HashPassword = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    DeadlinaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CurrentEngeneerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defects_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Defects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Defects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Defects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Defects_Users_CurrentEngeneerId",
                        column: x => x.CurrentEngeneerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userInfos_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefectId = table.Column<int>(type: "integer", nullable: false),
                    UploadedById = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MongoPictureId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UploadedById",
                        column: x => x.UploadedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefectId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NewStatusId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Statuses_NewStatusId",
                        column: x => x.NewStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_DefectId",
                table: "Applications",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UploadedById",
                table: "Applications",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DefectId",
                table: "Comments",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_AuthorId",
                table: "Defects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_CurrentEngeneerId",
                table: "Defects",
                column: "CurrentEngeneerId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_PriorityId",
                table: "Defects",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_ProjectId",
                table: "Defects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_StatusId",
                table: "Defects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_DefectId",
                table: "Histories",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_NewStatusId",
                table: "Histories",
                column: "NewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployers_ProjectId",
                table: "ProjectEmployers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployers_UserId",
                table: "ProjectEmployers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectId",
                table: "Reports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "ProjectEmployers");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "userInfos");

            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
