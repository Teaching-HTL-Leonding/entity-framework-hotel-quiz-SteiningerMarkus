﻿// <auto-generated />
using System;
using Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Hotel.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotel.HotelSpecial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Special")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HotelSpecials");
                });

            modelBuilder.Entity("Hotel.RoomPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomPrices");
                });

            modelBuilder.Entity("Hotel.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DisabilityAccessible")
                        .HasColumnType("bit");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsAvailable")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelHotelSpecial", b =>
                {
                    b.Property<int>("HotelsId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialsId")
                        .HasColumnType("int");

                    b.HasKey("HotelsId", "SpecialsId");

                    b.HasIndex("SpecialsId");

                    b.ToTable("HotelHotelSpecial");
                });

            modelBuilder.Entity("Hotel.RoomPrice", b =>
                {
                    b.HasOne("Hotel.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Hotel.RoomType", b =>
                {
                    b.HasOne("Hotel.Hotel", "Hotel")
                        .WithMany("RoomTypes")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelHotelSpecial", b =>
                {
                    b.HasOne("Hotel.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.HotelSpecial", null)
                        .WithMany()
                        .HasForeignKey("SpecialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel.Hotel", b =>
                {
                    b.Navigation("RoomTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
