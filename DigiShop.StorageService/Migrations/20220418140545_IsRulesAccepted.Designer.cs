﻿// <auto-generated />
using System;
using DigiShop.StorageService.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigiShop.StorageService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220418140545_IsRulesAccepted")]
    partial class IsRulesAccepted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Permission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permission")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rolename")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.RolePermission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("permissionId")
                        .HasColumnType("int");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("permissionId");

                    b.HasIndex("roleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Documents.Document", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("AuthStatus")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ShabaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.OTP.Otp", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTimeOffset>("expiretime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.SiteSettings.SiteSetting", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsApi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsSender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SiteSettings");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ParentId");

                    b.ToTable("StoreCategories");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Stores.Store", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMailActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPhonenumberActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRuleAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreStatus")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("UserId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs.SignInLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignInTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("SignInLogs");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Users.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRulesAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.Property<string>("Userserial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.RolePermission", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("permissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Documents.Document", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.Users.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.OTP.Otp", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.Users.User", "User")
                        .WithMany("Otps")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Stores.Store", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.Users.User", "User")
                        .WithOne("Store")
                        .HasForeignKey("DigiShop.CoreBussiness.EfCoreDomains.Stores.Store", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs.SignInLog", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.Users.User", "User")
                        .WithMany("SignInLogs")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Users.User", b =>
                {
                    b.HasOne("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DigiShop.CoreBussiness.EfCoreDomains.Users.User", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Otps");

                    b.Navigation("SignInLogs");

                    b.Navigation("Store");
                });
#pragma warning restore 612, 618
        }
    }
}
