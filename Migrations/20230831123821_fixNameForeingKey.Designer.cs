﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleBank.Context;

#nullable disable

namespace SimpleBank.Migrations
{
    [DbContext(typeof(SimpleBankDbContext))]
    [Migration("20230831123821_fixNameForeingKey")]
    partial class fixNameForeingKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("SimpleBank.Models.Account", b =>
                {
                    b.Property<int>("AccoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccoutId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SimpleBank.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SimpleBank.Models.Transaction", b =>
                {
                    b.HasOne("SimpleBank.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SimpleBank.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}