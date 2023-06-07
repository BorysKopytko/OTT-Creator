﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OTTCreator.WebApp.Data;

#nullable disable

namespace OTTCreator.WebApp.Migrations
{
    [DbContext(typeof(ApplicationIdentityDbContext))]
    [Migration("20230607220308_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OTTCreator.WebApp.Areas.Identity.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CodesAndUse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FavoriteContentItemsIDs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                });

            modelBuilder.Entity("OTTCreator.WebApp.Models.Role", b =>
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
                });

            modelBuilder.Entity("OTTCreator.WebApp.Models.ContentItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CroppedImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasVideo")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ContentItems");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = "Test category A",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = true,
                            Image = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            Name = "Test content 1",
                            Stream = "https://bloomberg.com/media-manifest/streams/eu.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 2,
                            Category = "Test category A",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = true,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 2",
                            Stream = "https://i.mjh.nz/PlutoTV/5a6b92f6e22a617379789618-alt.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 3,
                            Category = "Test category B",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = true,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 3",
                            Stream = "https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 4,
                            Category = "Test category B",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = true,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 4",
                            Stream = "https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 5,
                            Category = "Test category C",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = false,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 5",
                            Stream = "https://online.hitfm.ua/HitFM_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 6,
                            Category = "Test category C",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = false,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 6",
                            Stream = "https://online.radioroks.ua/RadioROKS_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 7,
                            Category = "Test category D",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = false,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 7",
                            Stream = "https://online.hitfm.ua/HitFM_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 8,
                            Category = "Test category D",
                            CroppedImage = "https://www.photos-public-domain.com/wp-content/uploads/2016/08/tortie-cat-300x300.jpg",
                            HasVideo = true,
                            Image = "https://cdn.pixabay.com/photo/2023/04/11/22/08/flower-7918323_960_720.jpg",
                            Name = "Test content 8",
                            Stream = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                            Type = "Радіостанції"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("OTTCreator.WebApp.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OTTCreator.WebApp.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OTTCreator.WebApp.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("OTTCreator.WebApp.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OTTCreator.WebApp.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OTTCreator.WebApp.Areas.Identity.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
