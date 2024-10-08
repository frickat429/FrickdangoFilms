﻿// <auto-generated />
using System;
using FrickdangoFilms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FrickdangoFilms.Data.Migrations
{
    [DbContext(typeof(FrickdangoFilmsDbContext))]
    partial class FrickdangoFilmsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MovieGenre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieGenre = "Action"
                        },
                        new
                        {
                            Id = 2,
                            MovieGenre = "Romcom"
                        },
                        new
                        {
                            Id = 3,
                            MovieGenre = "Science Fiction"
                        },
                        new
                        {
                            Id = 4,
                            MovieGenre = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            MovieGenre = "Thriller"
                        },
                        new
                        {
                            Id = 6,
                            MovieGenre = "Comedy"
                        });
                });

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.MPAA_Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MovieRating")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("MPAA_Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieRating = "G"
                        },
                        new
                        {
                            Id = 2,
                            MovieRating = "PG"
                        },
                        new
                        {
                            Id = 3,
                            MovieRating = "PG-13"
                        },
                        new
                        {
                            Id = 4,
                            MovieRating = "R"
                        });
                });

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MPAA_RatingId")
                        .HasColumnType("int");

                    b.Property<string>("MovieDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RuntimeInMinutes")
                        .HasColumnType("int");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MPAA_RatingId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.Theater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TheaterName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Theaters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TheaterName = "Atlantica"
                        },
                        new
                        {
                            Id = 2,
                            TheaterName = "Star Rail"
                        },
                        new
                        {
                            Id = 3,
                            TheaterName = "Ringo"
                        },
                        new
                        {
                            Id = 4,
                            TheaterName = "Arkride"
                        },
                        new
                        {
                            Id = 5,
                            TheaterName = "Columbia"
                        },
                        new
                        {
                            Id = 6,
                            TheaterName = "Rainbow Road"
                        });
                });

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FrickdangoFilms.Data.Entities.Movies", b =>
                {
                    b.HasOne("FrickdangoFilms.Data.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrickdangoFilms.Data.Entities.MPAA_Rating", "MPAA_Rating")
                        .WithMany()
                        .HasForeignKey("MPAA_RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrickdangoFilms.Data.Entities.Theater", "Theater")
                        .WithMany()
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MPAA_Rating");

                    b.Navigation("Theater");
                });
#pragma warning restore 612, 618
        }
    }
}
