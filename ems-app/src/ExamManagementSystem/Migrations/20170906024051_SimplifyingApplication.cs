using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ExamManagementSystem.Migrations
{
    public partial class SimplifyingApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "commResult", table: "Student");
            migrationBuilder.DropColumn(name: "group1", table: "Student");
            migrationBuilder.DropColumn(name: "group2", table: "Student");
            migrationBuilder.DropColumn(name: "group3", table: "Student");
            migrationBuilder.DropColumn(name: "prgResult", table: "Student");
            migrationBuilder.DropTable("RegExam");
            migrationBuilder.DropTable("Exam");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_EMSUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_EMSUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_EMSUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    examID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<TimeSpan>(nullable: false),
                    examType = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    regDeadline = table.Column<DateTime>(nullable: false),
                    semester = table.Column<string>(nullable: true),
                    startTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.examID);
                });
            migrationBuilder.CreateTable(
                name: "RegExam",
                columns: table => new
                {
                    regExamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    examID = table.Column<int>(nullable: false),
                    publish = table.Column<string>(nullable: true),
                    registered = table.Column<string>(nullable: true),
                    result = table.Column<string>(nullable: true),
                    score = table.Column<string>(nullable: true),
                    studentID = table.Column<int>(nullable: false),
                    withdraw = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegExam", x => x.regExamID);
                    table.ForeignKey(
                        name: "FK_RegExam_Exam_examID",
                        column: x => x.examID,
                        principalTable: "Exam",
                        principalColumn: "examID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegExam_Student_studentID",
                        column: x => x.studentID,
                        principalTable: "Student",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<string>(
                name: "commResult",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "group1",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "group2",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "group3",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "prgResult",
                table: "Student",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_EMSUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_EMSUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_EMSUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
