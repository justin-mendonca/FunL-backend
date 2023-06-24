﻿// <auto-generated />
using System;
using FunL_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FunL_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230623125639_UpdateSchemaWithAdditionalNestedProperties")]
    partial class UpdateSchemaWithAdditionalNestedProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FunL_backend.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("FunL_backend.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdvisedMinimumAudienceAge")
                        .HasColumnType("int");

                    b.Property<string>("BackdropPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackdropURLsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountriesJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenresJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ImdbRating")
                        .HasColumnType("float");

                    b.Property<int?>("ImdbVoteCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterURLsJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Runtime")
                        .HasColumnType("int");

                    b.Property<string>("StreamingInfoJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StreamingInfo");

                    b.Property<string>("Tagline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TmdbId")
                        .HasColumnType("int");

                    b.Property<double?>("TmdbRating")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.Property<string>("YoutubeTrailerVideoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeTrailerVideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("GenreTitle", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("GenreTitle");
                });

            modelBuilder.Entity("GenreTitle", b =>
                {
                    b.HasOne("FunL_backend.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunL_backend.Models.Title", null)
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}