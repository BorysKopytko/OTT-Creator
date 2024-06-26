﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OTTCreator.WebApp.Data;

#nullable disable

namespace OTTCreator.WebApp.Migrations
{
    [DbContext(typeof(ApplicationIdentityDbContext))]
    partial class ApplicationIdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsAllowed")
                        .HasColumnType("bit");

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
                            Category = "Новинні",
                            CroppedImage = "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4",
                            Name = "Суспільне Новини",
                            Stream = "https://bloomberg.com/media-manifest/streams/eu.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 2,
                            Category = "Новинні",
                            CroppedImage = "https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s1.vcdn.biz/static/f/5898897271/image.jpg/pt/r300x423x4",
                            Name = "АРМІЯ ТБ",
                            Stream = "https://euronews-euronews-world-1-au.samsung.wurl.com/manifest/playlist.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 3,
                            Category = "Пізнавальні",
                            CroppedImage = "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s6.vcdn.biz/static/f/4632098541/image.jpg/pt/r300x423x4",
                            Name = "Суспільне Культура",
                            Stream = "https://ythls.onrender.com/channel/UCH9H_b9oJtSHBovh94yB5HA.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 4,
                            Category = "Новинні",
                            CroppedImage = "https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s9.vcdn.biz/static/f/4632113151/image.jpg/pt/r300x423x4",
                            Name = "Перший",
                            Stream = "https://ythls.onrender.com/channel/UCMEiyV8N2J93GdPNltPYM6w.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 5,
                            Category = "Новинні",
                            CroppedImage = "https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s8.vcdn.biz/static/f/6004218941/image.jpg/pt/r300x423x4",
                            Name = "Київ",
                            Stream = "https://fashiontv-fashiontv-1-eu.rakuten.wurl.tv/playlist.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 6,
                            Category = "Новинні",
                            CroppedImage = "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s1.vcdn.biz/static/f/333958501/image.jpg/pt/r300x423x4",
                            Name = "5 канал",
                            Stream = "https://ythls.onrender.com/channel/UCQfwfsi5VrQ8yKZ-UWmAEFg.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 7,
                            Category = "Новинні",
                            CroppedImage = "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s2.vcdn.biz/static/f/4961863001/image.jpg/pt/r300x423x4",
                            Name = "Еспресо TV",
                            Stream = "https://live-tf1-hls-dai.cdn-1.diff.tf1.fr/out/v1/c2e382be3aa2486e8753747e7bb6157e/index.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 8,
                            Category = "Новинні",
                            CroppedImage = "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s1.vcdn.biz/static/f/672118741/image.jpg/pt/r300x423x4",
                            Name = "BBC World News",
                            Stream = "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 9,
                            Category = "Новинні",
                            CroppedImage = "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4",
                            Name = "TVP World",
                            Stream = "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 10,
                            Category = "Пізнавальні",
                            CroppedImage = "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s9.vcdn.biz/static/f/5354553681/image.jpg/pt/r300x423x4",
                            Name = "Суспільне Новини",
                            Stream = "https://bloomberg.com/media-manifest/streams/eu.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 11,
                            Category = "Міжнародні",
                            CroppedImage = "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4",
                            HasVideo = true,
                            Image = "https://s9.vcdn.biz/static/f/5016844881/image.jpg/pt/r300x423x4",
                            Name = "TVP World",
                            Stream = "https://cnn-cnninternational-1-eu.rakuten.wurl.tv/playlist.m3u8",
                            Type = "Телеканали"
                        },
                        new
                        {
                            ID = 12,
                            Category = "Національні",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png",
                            HasVideo = false,
                            Image = "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png",
                            Name = "Хіт FM",
                            Stream = "https://online.hitfm.ua/HitFM_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 13,
                            Category = "Національні",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png",
                            HasVideo = false,
                            Image = "https://play.tavr.media/static/image/header_menu/roks_efir_162x162.png",
                            Name = "Radio Roks",
                            Stream = "https://online.radioroks.ua/RadioROKS_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 14,
                            Category = "Національні",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png",
                            HasVideo = false,
                            Image = "https://play.tavr.media/static/image/header_menu/kiss_efir_210x210.png",
                            Name = "Kiss FM",
                            Stream = "https://online.kissfm.ua/KissFM_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 15,
                            Category = "Національні",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png",
                            HasVideo = false,
                            Image = "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png",
                            Name = "Relax",
                            Stream = "https://online.radiorelax.ua/RadioRelax_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 16,
                            Category = "Місцеві",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png",
                            HasVideo = false,
                            Image = "https://play.tavr.media/static/image/header_menu/hit_efir_210x210.png",
                            Name = "Хіт FM",
                            Stream = "https://online.hitfm.ua/HitFM_HD",
                            Type = "Радіостанції"
                        },
                        new
                        {
                            ID = 17,
                            Category = "Розмовні",
                            CroppedImage = "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png",
                            HasVideo = true,
                            Image = "https://play.tavr.media/static/image/header_menu/Relax_Efir_228x228.png",
                            Name = "Relax",
                            Stream = "https://online.radiorelax.ua/RadioRelax_HD",
                            Type = "Радіостанції"
                        });
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
