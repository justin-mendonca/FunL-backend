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
    [Migration("20230702190412_UpdateSchemaWithFlattenedStreamingInfo")]
    partial class UpdateSchemaWithFlattenedStreamingInfo
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("FunL_backend.Models.StreamingPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StreamingPlatforms");
                });

            modelBuilder.Entity("FunL_backend.Models.StreamingServiceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AudiosJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AvailableSince")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Leaving")
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreamingPlatformId")
                        .HasColumnType("int");

                    b.Property<string>("SubtitlesJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WatchLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StreamingPlatformId");

                    b.HasIndex("TitleId");

                    b.ToTable("StreamingServiceInfos");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Runtime")
                        .HasColumnType("int");

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

            modelBuilder.Entity("FunL_backend.Models.TitleGenre", b =>
                {
                    b.Property<int?>("TitleId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("TitleId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("TitleGenre");
                });

            modelBuilder.Entity("FunL_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FunL_backend.Models.UserStreamingPlatform", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("StreamingPlatformId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "StreamingPlatformId");

                    b.HasIndex("StreamingPlatformId");

                    b.ToTable("UserStreamingPlatforms");
                });

            modelBuilder.Entity("FunL_backend.Models.UserTitle", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<int?>("StreamingServiceInfoId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TitleId");

                    b.HasIndex("StreamingServiceInfoId");

                    b.HasIndex("TitleId");

                    b.ToTable("UserTitles");
                });

            modelBuilder.Entity("FunL_backend.Models.StreamingServiceInfo", b =>
                {
                    b.HasOne("FunL_backend.Models.StreamingPlatform", "StreamingPlatform")
                        .WithMany("TitlesAvailable")
                        .HasForeignKey("StreamingPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunL_backend.Models.Title", "Title")
                        .WithMany("StreamingServices")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StreamingPlatform");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("FunL_backend.Models.TitleGenre", b =>
                {
                    b.HasOne("FunL_backend.Models.Genre", "Genre")
                        .WithMany("TitleGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunL_backend.Models.Title", "Title")
                        .WithMany("TitleGenres")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("FunL_backend.Models.UserStreamingPlatform", b =>
                {
                    b.HasOne("FunL_backend.Models.StreamingPlatform", "StreamingPlatform")
                        .WithMany("UserStreamingPlatforms")
                        .HasForeignKey("StreamingPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunL_backend.Models.User", "User")
                        .WithMany("UserStreamingPlatforms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StreamingPlatform");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FunL_backend.Models.UserTitle", b =>
                {
                    b.HasOne("FunL_backend.Models.StreamingServiceInfo", null)
                        .WithMany("UserTitles")
                        .HasForeignKey("StreamingServiceInfoId");

                    b.HasOne("FunL_backend.Models.Title", "Title")
                        .WithMany("UserTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunL_backend.Models.User", "User")
                        .WithMany("UserTitles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Title");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FunL_backend.Models.Genre", b =>
                {
                    b.Navigation("TitleGenres");
                });

            modelBuilder.Entity("FunL_backend.Models.StreamingPlatform", b =>
                {
                    b.Navigation("TitlesAvailable");

                    b.Navigation("UserStreamingPlatforms");
                });

            modelBuilder.Entity("FunL_backend.Models.StreamingServiceInfo", b =>
                {
                    b.Navigation("UserTitles");
                });

            modelBuilder.Entity("FunL_backend.Models.Title", b =>
                {
                    b.Navigation("StreamingServices");

                    b.Navigation("TitleGenres");

                    b.Navigation("UserTitles");
                });

            modelBuilder.Entity("FunL_backend.Models.User", b =>
                {
                    b.Navigation("UserStreamingPlatforms");

                    b.Navigation("UserTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
