﻿// <auto-generated />
using System;
using GameSetBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240412074758_AddedFirstNameSeedLastName")]
    partial class AddedFirstNameSeedLastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Booking identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time booking is created");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the booking");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Client identifier");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Client's name");

                    b.Property<int>("CourtId")
                        .HasColumnType("int")
                        .HasComment("Court identifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Deleted on date and time");

                    b.Property<int>("Hour")
                        .HasColumnType("int")
                        .HasComment("Hour of the booking");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit")
                        .HasComment("is the the booking available");

                    b.Property<bool>("IsBookedByOwnerOrAdmin")
                        .HasColumnType("bit")
                        .HasComment("Is the booking created by administrator or club owner");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("is the booking canceled");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Client's phone number");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Booking price");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CourtId");

                    b.ToTable("Bookings");

                    b.HasComment("Booking entity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookedOn = new DateTime(2024, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingDate = new DateTime(2024, 3, 14, 17, 9, 0, 0, DateTimeKind.Unspecified),
                            ClientId = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                            ClientName = "Petar Atanasov",
                            CourtId = 1,
                            Hour = 17,
                            IsAvailable = false,
                            IsBookedByOwnerOrAdmin = false,
                            IsDeleted = false,
                            PhoneNumber = "+359000111",
                            Price = 20.00m
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("City identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasComment("Country identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("City name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasComment("City entity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Bucharest"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Constanta"
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Club identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Address of the club");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasComment("Club's city identifier");

                    b.Property<string>("ClubOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Club owner's identifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Deleted on date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Club description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Club's email");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit")
                        .HasComment("Is car parking for clients available");

                    b.Property<bool>("HasShop")
                        .HasColumnType("bit")
                        .HasComment("Is tennis shop available");

                    b.Property<bool>("HasShower")
                        .HasColumnType("bit")
                        .HasComment("Is shower for clients available");

                    b.Property<bool>("IsAproovedByAdmin")
                        .HasColumnType("bit")
                        .HasComment("Is the club aprooved from app admin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("IsDeleted the record deleted");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasComment("Club's logo Url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Club name");

                    b.Property<int?>("NumberOfCoaches")
                        .HasColumnType("int")
                        .HasComment("Number of coaches in the club");

                    b.Property<int>("NumberOfCourts")
                        .HasColumnType("int")
                        .HasComment("Numbber of courts in the club");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Club's phone number");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time the club has been created");

                    b.Property<int>("WorkingTimeEnd")
                        .HasColumnType("int")
                        .HasComment("Club working time end");

                    b.Property<int>("WorkingTimeStart")
                        .HasColumnType("int")
                        .HasComment("Club working time start");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ClubOwnerId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clubs");

                    b.HasComment("Club entity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "First Club Address",
                            CityId = 1,
                            ClubOwnerId = "82cd50ca-b023-42e5-8344-227d5c45877c",
                            Description = "First Club Description",
                            Email = "firstClub@mail.com",
                            HasParking = true,
                            HasShop = true,
                            HasShower = true,
                            IsAproovedByAdmin = true,
                            IsDeleted = false,
                            LogoUrl = "images/club_logo/default_club_logo.png",
                            Name = "First Club",
                            NumberOfCoaches = 2,
                            NumberOfCourts = 2,
                            PhoneNumber = "+359123456",
                            RegisteredOn = new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkingTimeEnd = 20,
                            WorkingTimeStart = 8
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Country identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("Country name");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasComment("Country entity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Romania"
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Court identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClubId")
                        .HasColumnType("int")
                        .HasComment("Club identifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is the court enable");

                    b.Property<bool>("IsIndoor")
                        .HasColumnType("bit")
                        .HasComment("Is the court indoor");

                    b.Property<bool>("IsLighted")
                        .HasColumnType("bit")
                        .HasComment("Is the court lighted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Court name");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for renting court per one hour");

                    b.Property<int>("Surface")
                        .HasColumnType("int")
                        .HasComment("Court surface");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Courts");

                    b.HasComment("Court entity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClubId = 1,
                            IsActive = true,
                            IsIndoor = false,
                            IsLighted = false,
                            Name = "No.1",
                            PricePerHour = 20m,
                            Surface = 3
                        },
                        new
                        {
                            Id = 2,
                            ClubId = 1,
                            IsActive = true,
                            IsIndoor = false,
                            IsLighted = false,
                            Name = "No.2",
                            PricePerHour = 20m,
                            Surface = 2
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", b =>
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User first name");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User last name");

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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("Extension of the identoty user");

                    b.HasData(
                        new
                        {
                            Id = "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cea279a1-42b5-4646-963b-3b5fb5e5ca90",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Petar",
                            LastName = "Atanasov",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBSIdYkNQvZt6EAaBsUboL8nSVdi0+ovH0fTUalTEtE0yChU5ULdLuwJRA+bsnYsEg==",
                            PhoneNumber = "0000000000",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fabe68a3-51d6-4003-bd4a-491fb45a3498",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "82cd50ca-b023-42e5-8344-227d5c45877c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7940fead-1015-45c3-8f6a-d0cc62e818af",
                            Email = "clubowner@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Atanas",
                            LastName = "Atanasov",
                            LockoutEnabled = false,
                            NormalizedEmail = "CLUBOWNER@MAIL.COM",
                            NormalizedUserName = "CLUBOWNER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE58cVeLKbf7RE0RLgSaPZr2m7zXF2LvYXmZBVWlH8A9XyG31/xKzC3WgunCno8Viw==",
                            PhoneNumber = "1111111111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "63a0b184-eb93-4062-8c90-ba579e88cfbb",
                            TwoFactorEnabled = false,
                            UserName = "clubowner@mail.com"
                        },
                        new
                        {
                            Id = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2784153-f6b4-44aa-9584-41abe99153a2",
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Encho",
                            LastName = "Georgiev",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@MAIL.COM",
                            NormalizedUserName = "USER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEA8m03p9tKuHpcwI5yCdKRlBiOlNvIJr+Ln2H/RtL6Irfu29gHnJEnTMTApuNxKsuQ==",
                            PhoneNumber = "2222222222",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5d4a0bce-cd7f-471d-a7e1-8a3ee744b81f",
                            TwoFactorEnabled = false,
                            UserName = "user@mail.com"
                        });
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Review identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasComment("Current review's booking identifier");

                    b.Property<int>("ClubId")
                        .HasColumnType("int")
                        .HasComment("Current review's club identifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date the reviews was added");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Review description");

                    b.Property<int>("Rate")
                        .HasColumnType("int")
                        .HasComment("Review rating");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Current review's reviewer identifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Review title");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("ClubId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");

                    b.HasComment("Club's review entity");
                });

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

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                            ConcurrencyStamp = "b2a23e17-a717-4dd4-aaa9-49b210ee0d5b",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                            ConcurrencyStamp = "9ab9f183-3056-41c8-b280-5582c8b75bc0",
                            Name = "ClubOwner",
                            NormalizedName = "CLUBOWNER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                            RoleId = "18906160-6956-4ecc-9b7c-fa5d0a4d0f82"
                        },
                        new
                        {
                            UserId = "82cd50ca-b023-42e5-8344-227d5c45877c",
                            RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                        });
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Booking", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameSetBook.Infrastructure.Models.Court", "Court")
                        .WithMany("Bookings")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Court");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.City", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Club", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.City", "City")
                        .WithMany("Clubs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", "ClubOwner")
                        .WithOne("Club")
                        .HasForeignKey("GameSetBook.Infrastructure.Models.Club", "ClubOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ClubOwner");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Court", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Club", "Club")
                        .WithMany("Courts")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Review", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Booking", "Booking")
                        .WithOne("Review")
                        .HasForeignKey("GameSetBook.Infrastructure.Models.Review", "BookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GameSetBook.Infrastructure.Models.Club", "Club")
                        .WithMany("Reviews")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Club");

                    b.Navigation("Reviewer");
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
                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", null)
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

                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Booking", b =>
                {
                    b.Navigation("Review");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.City", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Club", b =>
                {
                    b.Navigation("Courts");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Court", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("GameSetBook.Infrastructure.Models.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Club");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
