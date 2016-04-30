using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Migrations
{
    [DbContext(typeof(ExamManagementContext))]
    [Migration("20160430065037_FinalDb")]
    partial class FinalDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamManagementSystem.Models.EMSUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("ExamManagementSystem.Models.Exam", b =>
                {
                    b.Property<int>("examID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date");

                    b.Property<TimeSpan>("endTime");

                    b.Property<string>("examType");

                    b.Property<string>("location");

                    b.Property<DateTime>("regDeadline");

                    b.Property<string>("semester");

                    b.Property<TimeSpan>("startTime");

                    b.HasKey("examID");
                });

            modelBuilder.Entity("ExamManagementSystem.Models.Faculty", b =>
                {
                    b.Property<int>("facultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.HasKey("facultyID");
                });

            modelBuilder.Entity("ExamManagementSystem.Models.RegExam", b =>
                {
                    b.Property<int>("regExamID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("examID");

                    b.Property<string>("publish");

                    b.Property<string>("registered");

                    b.Property<string>("result");

                    b.Property<string>("score");

                    b.Property<int>("studentID");

                    b.Property<string>("withdraw");

                    b.HasKey("regExamID");
                });

            modelBuilder.Entity("ExamManagementSystem.Models.Student", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("commResult");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("group1");

                    b.Property<string>("group2");

                    b.Property<string>("group3");

                    b.Property<string>("group4");

                    b.Property<string>("lastName");

                    b.Property<string>("major");

                    b.Property<string>("phone");

                    b.Property<string>("prgResult");

                    b.Property<string>("txStateID");

                    b.Property<string>("zip");

                    b.HasKey("studentID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("ExamManagementSystem.Models.RegExam", b =>
                {
                    b.HasOne("ExamManagementSystem.Models.Exam")
                        .WithMany()
                        .HasForeignKey("examID");

                    b.HasOne("ExamManagementSystem.Models.Student")
                        .WithMany()
                        .HasForeignKey("studentID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExamManagementSystem.Models.EMSUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExamManagementSystem.Models.EMSUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("ExamManagementSystem.Models.EMSUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
