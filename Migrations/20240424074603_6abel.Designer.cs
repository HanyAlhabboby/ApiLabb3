﻿// <auto-generated />
using ApiLabb3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiLabb3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240424074603_6abel")]
    partial class _6abel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiLabb3.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FkPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.HasIndex("FkPersonId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("ApiLabb3.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("FkInterestId")
                        .HasColumnType("int");

                    b.Property<string>("LinkInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.HasIndex("FkInterestId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("ApiLabb3.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ApiLabb3.Models.Interest", b =>
                {
                    b.HasOne("ApiLabb3.Models.Person", "Person")
                        .WithMany("Interests")
                        .HasForeignKey("FkPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ApiLabb3.Models.Link", b =>
                {
                    b.HasOne("ApiLabb3.Models.Interest", "Interest")
                        .WithMany("Links")
                        .HasForeignKey("FkInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");
                });

            modelBuilder.Entity("ApiLabb3.Models.Interest", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("ApiLabb3.Models.Person", b =>
                {
                    b.Navigation("Interests");
                });
#pragma warning restore 612, 618
        }
    }
}
