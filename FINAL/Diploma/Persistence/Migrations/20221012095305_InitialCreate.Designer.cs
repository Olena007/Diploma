﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20221012095305_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domen.Models.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasketId"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("PhoneId")
                        .HasColumnType("int");

                    b.HasKey("BasketId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("Domen.Models.BasketComp", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasketId"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("PhoneId")
                        .HasColumnType("int");

                    b.HasKey("BasketId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("PhoneId");

                    b.ToTable("BasketComp");
                });

            modelBuilder.Entity("Domen.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Domen.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComputerId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComputerId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("Domen.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryId"), 1L, 1);

                    b.Property<int?>("BasketId")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.HasIndex("BasketId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Domen.Models.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("Domen.Models.Basket", b =>
                {
                    b.HasOne("Domen.Models.Client", "Client")
                        .WithMany("Baskets")
                        .HasForeignKey("ClientId");

                    b.HasOne("Domen.Models.Computer", "Computer")
                        .WithMany("Baskets")
                        .HasForeignKey("ComputerId");

                    b.HasOne("Domen.Models.Phone", "Phone")
                        .WithMany("Baskets")
                        .HasForeignKey("PhoneId");

                    b.Navigation("Client");

                    b.Navigation("Computer");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("Domen.Models.BasketComp", b =>
                {
                    b.HasOne("Domen.Models.Client", "Client")
                        .WithMany("BasketComps")
                        .HasForeignKey("ClientId");

                    b.HasOne("Domen.Models.Computer", "Computer")
                        .WithMany("BasketComps")
                        .HasForeignKey("ComputerId");

                    b.HasOne("Domen.Models.Phone", "Phone")
                        .WithMany("BasketComps")
                        .HasForeignKey("PhoneId");

                    b.Navigation("Client");

                    b.Navigation("Computer");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("Domen.Models.History", b =>
                {
                    b.HasOne("Domen.Models.Basket", "Basket")
                        .WithMany("Histories")
                        .HasForeignKey("BasketId");

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("Domen.Models.Basket", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("Domen.Models.Client", b =>
                {
                    b.Navigation("BasketComps");

                    b.Navigation("Baskets");
                });

            modelBuilder.Entity("Domen.Models.Computer", b =>
                {
                    b.Navigation("BasketComps");

                    b.Navigation("Baskets");
                });

            modelBuilder.Entity("Domen.Models.Phone", b =>
                {
                    b.Navigation("BasketComps");

                    b.Navigation("Baskets");
                });
#pragma warning restore 612, 618
        }
    }
}
