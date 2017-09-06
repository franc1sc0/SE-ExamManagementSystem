using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ExamManagementSystem.Migrations
{
    public partial class SimplifyingApplication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_EMSUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_EMSUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_EMSUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "address", table: "Student");
            migrationBuilder.DropColumn(name: "city", table: "Student");
            migrationBuilder.DropColumn(name: "group4", table: "Student");
            migrationBuilder.DropColumn(name: "phone", table: "Student");
            migrationBuilder.DropColumn(name: "txStateID", table: "Student");
            migrationBuilder.DropColumn(name: "zip", table: "Student");
            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Faculty",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Faculty",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Faculty",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Faculty",
                nullable: false);
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
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "group4",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "phone",
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
            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Faculty",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Faculty",
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
