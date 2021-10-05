﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StayOver.Data;

namespace StayOver.Migrations
{
    [DbContext(typeof(StayOverDbContext))]
    [Migration("20211001135838_addShowPhoneNumberToAccommodation")]
    partial class addShowPhoneNumberToAccommodation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StayOver.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StayOver.Models.Accommodation", b =>
                {
                    b.Property<int>("AccommodationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<bool>("ShowPhoneNumber")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccommodationId");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("StayOver.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Banovići"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "Banja Luka"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Bihać"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "Bijeljina"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Brčko"
                        },
                        new
                        {
                            CityId = 6,
                            Name = "Cazin"
                        },
                        new
                        {
                            CityId = 7,
                            Name = "Kakanj"
                        },
                        new
                        {
                            CityId = 8,
                            Name = "Konjic"
                        },
                        new
                        {
                            CityId = 9,
                            Name = "Mostar"
                        },
                        new
                        {
                            CityId = 10,
                            Name = " Neum"
                        },
                        new
                        {
                            CityId = 11,
                            Name = "Sanski Most"
                        },
                        new
                        {
                            CityId = 12,
                            Name = "Sarajevo"
                        },
                        new
                        {
                            CityId = 13,
                            Name = "Tuzla"
                        },
                        new
                        {
                            CityId = 14,
                            Name = "Velika Kladuša"
                        },
                        new
                        {
                            CityId = 15,
                            Name = "Stolac"
                        },
                        new
                        {
                            CityId = 16,
                            Name = "Tešanj"
                        },
                        new
                        {
                            CityId = 17,
                            Name = "Travnik"
                        },
                        new
                        {
                            CityId = 18,
                            Name = "Trebinje"
                        },
                        new
                        {
                            CityId = 19,
                            Name = "Zenica"
                        },
                        new
                        {
                            CityId = 20,
                            Name = "Zvornik"
                        });
                });

            modelBuilder.Entity("StayOver.Models.GalleryModel", b =>
                {
                    b.Property<int>("GalleryModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalleryModelId");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("StayOver.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisiterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReservationId");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("VisiterId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("StayOver.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StayOver.Models.Accommodation", b =>
                {
                    b.HasOne("StayOver.Models.City", "City")
                        .WithMany("Accommodation")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", "Owner")
                        .WithMany("Accommodations")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("OwnerAccommodation_FK");

                    b.Navigation("City");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StayOver.Models.GalleryModel", b =>
                {
                    b.HasOne("StayOver.Models.Accommodation", "Accommodation")
                        .WithMany("Gallery")
                        .HasForeignKey("AccommodationId");

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("StayOver.Models.Reservation", b =>
                {
                    b.HasOne("StayOver.Models.Accommodation", "Accommodation")
                        .WithMany("Reservations")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", "Visiter")
                        .WithMany("Reservations")
                        .HasForeignKey("VisiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Visiter");
                });

            modelBuilder.Entity("StayOver.Models.Review", b =>
                {
                    b.HasOne("StayOver.Models.Accommodation", "Accommodation")
                        .WithMany("Reviews")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StayOver.Areas.Identity.Data.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("StayOver.Models.Reservation", "Reservation")
                        .WithOne("Review")
                        .HasForeignKey("StayOver.Models.Review", "ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Reservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StayOver.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Navigation("Accommodations");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("StayOver.Models.Accommodation", b =>
                {
                    b.Navigation("Gallery");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("StayOver.Models.City", b =>
                {
                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("StayOver.Models.Reservation", b =>
                {
                    b.Navigation("Review");
                });
#pragma warning restore 612, 618
        }
    }
}
