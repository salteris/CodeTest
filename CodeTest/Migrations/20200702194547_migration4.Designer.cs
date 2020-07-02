﻿// <auto-generated />
using System;
using CodeTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeTest.Migrations
{
    [DbContext(typeof(CodeTestContext))]
    [Migration("20200702194547_migration4")]
    partial class migration4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeTest.Domain.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CharacterID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("CodeTest.Domain.Class", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClassId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<int>("ClassLevel")
                        .HasColumnType("int");

                    b.Property<int>("HitDiceValue")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("CodeTest.Domain.Defense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DefenseId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Protection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Defense");
                });

            modelBuilder.Entity("CodeTest.Domain.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ItemId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("CodeTest.Domain.Character", b =>
                {
                    b.OwnsOne("CodeTest.Domain.HitPoints", "HitPoints", b1 =>
                        {
                            b1.Property<long>("CharacterId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Current")
                                .HasColumnName("CurrentHitPoints")
                                .HasColumnType("int");

                            b1.Property<int>("Max")
                                .HasColumnName("MaximumHitPoints")
                                .HasColumnType("int");

                            b1.Property<int>("Temp")
                                .HasColumnName("TemporaryHitPoints")
                                .HasColumnType("int");

                            b1.HasKey("CharacterId");

                            b1.ToTable("Character");

                            b1.WithOwner()
                                .HasForeignKey("CharacterId");
                        });

                    b.OwnsOne("CodeTest.Domain.Name", "Name", b1 =>
                        {
                            b1.Property<long>("CharacterId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CharacterName")
                                .HasColumnName("CharacterName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PlayerName")
                                .HasColumnName("PlayerName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CharacterId");

                            b1.ToTable("Character");

                            b1.WithOwner()
                                .HasForeignKey("CharacterId");
                        });

                    b.OwnsOne("CodeTest.Domain.Stats", "Stats", b1 =>
                        {
                            b1.Property<long>("CharacterId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Charisma")
                                .HasColumnName("Charisma")
                                .HasColumnType("int");

                            b1.Property<int>("Constitution")
                                .HasColumnName("Constitution")
                                .HasColumnType("int");

                            b1.Property<int>("Dexterity")
                                .HasColumnName("Dexterity")
                                .HasColumnType("int");

                            b1.Property<int>("Intelligence")
                                .HasColumnName("Intelligence")
                                .HasColumnType("int");

                            b1.Property<int>("Strength")
                                .HasColumnName("Strength")
                                .HasColumnType("int");

                            b1.Property<int>("Wisdom")
                                .HasColumnName("Wisdom")
                                .HasColumnType("int");

                            b1.HasKey("CharacterId");

                            b1.ToTable("Character");

                            b1.WithOwner()
                                .HasForeignKey("CharacterId");
                        });
                });

            modelBuilder.Entity("CodeTest.Domain.Class", b =>
                {
                    b.HasOne("CodeTest.Domain.Character", "Character")
                        .WithMany("Classes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CodeTest.Domain.Defense", b =>
                {
                    b.HasOne("CodeTest.Domain.Character", "Character")
                        .WithMany("Defenses")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CodeTest.Domain.Item", b =>
                {
                    b.HasOne("CodeTest.Domain.Character", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("CodeTest.Domain.Modifier", "Modifier", b1 =>
                        {
                            b1.Property<long>("ItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AffectedObject")
                                .HasColumnName("AffectedObject")
                                .HasColumnType("int");

                            b1.Property<string>("AffectedValue")
                                .HasColumnName("AffectedValue")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Value")
                                .HasColumnName("Value")
                                .HasColumnType("int");

                            b1.HasKey("ItemId");

                            b1.ToTable("Item");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}