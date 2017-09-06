using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ExamManagementSystem.Migrations
{
    public partial class SimplifyingApplication3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropPrimaryKey(name: "PK_EMSUser", table: "AspNetUsers");
            migrationBuilder.AddPrimaryKey(
                name: "PK_EmsUser",
                table: "AspNetUsers",
                column: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_EmsUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_EmsUser_UserId",
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
                name: "FK_IdentityUserRole<string>_EmsUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameColumn(
                name: "major",
                table: "Student",
                newName: "Major");
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Student",
                newName: "LastName");
            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Student",
                newName: "FirstName");
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Student",
                newName: "Email");
            migrationBuilder.RenameColumn(
                name: "studentID",
                table: "Student",
                newName: "StudentId");
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Faculty",
                newName: "LastName");
            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Faculty",
                newName: "FirstName");
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Faculty",
                newName: "Email");
            migrationBuilder.RenameColumn(
                name: "facultyID",
                table: "Faculty",
                newName: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EmsUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EmsUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EmsUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropPrimaryKey(name: "PK_EmsUser", table: "AspNetUsers");
            migrationBuilder.AddPrimaryKey(
                name: "PK_EMSUser",
                table: "AspNetUsers",
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
                name: "Major",
                table: "Student",
                newName: "major");
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "lastName");
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "firstName");
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Student",
                newName: "email");
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student",
                newName: "studentID");
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Faculty",
                newName: "lastName");
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Faculty",
                newName: "firstName");
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Faculty",
                newName: "email");
            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Faculty",
                newName: "facultyID");
        }
    }
}
