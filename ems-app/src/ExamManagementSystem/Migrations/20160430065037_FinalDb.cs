using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ExamManagementSystem.Migrations
{
    public partial class FinalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropPrimaryKey(name: "PK_Student", table: "Student");
            migrationBuilder.DropPrimaryKey(name: "PK_Faculty", table: "Faculty");
            migrationBuilder.DropPrimaryKey(name: "PK_Exam", table: "Exam");
            migrationBuilder.DropColumn(name: "Id", table: "Student");
            migrationBuilder.DropColumn(name: "Name", table: "Student");
            migrationBuilder.DropColumn(name: "Id", table: "Faculty");
            migrationBuilder.DropColumn(name: "Name", table: "Faculty");
            migrationBuilder.DropColumn(name: "Id", table: "Exam");
            migrationBuilder.DropColumn(name: "Name", table: "Exam");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegExam_Student_studentID",
                        column: x => x.studentID,
                        principalTable: "Student",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddColumn<int>(
                name: "studentID",
                table: "Student",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "commResult",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "firstName",
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
                name: "group4",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "major",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "prgResult",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "txStateID",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "zip",
                table: "Student",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "studentID");
            migrationBuilder.AddColumn<int>(
                name: "facultyID",
                table: "Faculty",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "facultyID");
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Exam",
                nullable: false);
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Exam",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "examID",
                table: "Exam",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "examType",
                table: "Exam",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "examID");
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
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Exam",
                newName: "startTime");
            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Exam",
                newName: "semester");
            migrationBuilder.RenameColumn(
                name: "RegDeadline",
                table: "Exam",
                newName: "regDeadline");
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Exam",
                newName: "location");
            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Exam",
                newName: "endTime");
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Exam",
                newName: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropPrimaryKey(name: "PK_Student", table: "Student");
            migrationBuilder.DropPrimaryKey(name: "PK_Faculty", table: "Faculty");
            migrationBuilder.DropPrimaryKey(name: "PK_Exam", table: "Exam");
            migrationBuilder.DropColumn(name: "studentID", table: "Student");
            migrationBuilder.DropColumn(name: "UserName", table: "Student");
            migrationBuilder.DropColumn(name: "address", table: "Student");
            migrationBuilder.DropColumn(name: "city", table: "Student");
            migrationBuilder.DropColumn(name: "commResult", table: "Student");
            migrationBuilder.DropColumn(name: "email", table: "Student");
            migrationBuilder.DropColumn(name: "firstName", table: "Student");
            migrationBuilder.DropColumn(name: "group1", table: "Student");
            migrationBuilder.DropColumn(name: "group2", table: "Student");
            migrationBuilder.DropColumn(name: "group3", table: "Student");
            migrationBuilder.DropColumn(name: "group4", table: "Student");
            migrationBuilder.DropColumn(name: "lastName", table: "Student");
            migrationBuilder.DropColumn(name: "major", table: "Student");
            migrationBuilder.DropColumn(name: "phone", table: "Student");
            migrationBuilder.DropColumn(name: "prgResult", table: "Student");
            migrationBuilder.DropColumn(name: "txStateID", table: "Student");
            migrationBuilder.DropColumn(name: "zip", table: "Student");
            migrationBuilder.DropColumn(name: "facultyID", table: "Faculty");
            migrationBuilder.DropColumn(name: "UserName", table: "Faculty");
            migrationBuilder.DropColumn(name: "email", table: "Faculty");
            migrationBuilder.DropColumn(name: "firstName", table: "Faculty");
            migrationBuilder.DropColumn(name: "lastName", table: "Faculty");
            migrationBuilder.DropColumn(name: "examID", table: "Exam");
            migrationBuilder.DropColumn(name: "examType", table: "Exam");
            migrationBuilder.DropTable("RegExam");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Student",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Student",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Faculty",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "Id");
            migrationBuilder.AlterColumn<DateTime>(
                name: "startTime",
                table: "Exam",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "Exam",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Exam",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exam",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");
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
            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "Exam",
                newName: "StartTime");
            migrationBuilder.RenameColumn(
                name: "semester",
                table: "Exam",
                newName: "Semester");
            migrationBuilder.RenameColumn(
                name: "regDeadline",
                table: "Exam",
                newName: "RegDeadline");
            migrationBuilder.RenameColumn(
                name: "location",
                table: "Exam",
                newName: "Location");
            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "Exam",
                newName: "EndTime");
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Exam",
                newName: "Date");
        }
    }
}
