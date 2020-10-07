﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Api.Domain.Entities.AssociateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Wishes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("MemberId", "OfficeId")
                        .IsUnique();

                    b.ToTable("Associate");
                });

            modelBuilder.Entity("Api.Domain.Entities.ElectedEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Wishes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("MemberId", "OfficeId")
                        .IsUnique();

                    b.ToTable("Elected");
                });

            modelBuilder.Entity("Api.Domain.Entities.ElectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Election");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd3c0f5d-87a9-4bac-8cd8-73c671cb368c"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(1732),
                            Name = "Eleições 2020"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.MemberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f060a687-65f2-4663-ba0c-0fd2d7622f96"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4182),
                            Name = "Marcelle"
                        },
                        new
                        {
                            Id = new Guid("0baf70b3-82ea-4231-82f4-ca1db046afef"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4227),
                            Name = "Fabiana"
                        },
                        new
                        {
                            Id = new Guid("4ac45dda-7443-465c-b0a5-497f19944cc9"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(4232),
                            Name = "Carolina"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.OfficeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ElectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<int>("QtdeAssociates")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ElectionId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Office");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80c6df2f-2b29-470b-9a1e-dc6a057df3da"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 685, DateTimeKind.Local).AddTicks(3217),
                            ElectionId = new Guid("bd3c0f5d-87a9-4bac-8cd8-73c671cb368c"),
                            Name = "Aventureiros",
                            QtdeAssociates = 0
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4b2e5b9-95e4-4008-867f-c2b15e67a1f1"),
                            CreateAt = new DateTime(2020, 10, 5, 10, 8, 52, 682, DateTimeKind.Local).AddTicks(6853),
                            Email = "mfrinfo@mail.com",
                            Name = "Administrador",
                            UpdateAt = new DateTime(2020, 10, 5, 10, 8, 52, 684, DateTimeKind.Local).AddTicks(77)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.AssociateEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.MemberEntity", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.OfficeEntity", "Office")
                        .WithMany("Associates")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Domain.Entities.ElectedEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.MemberEntity", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.OfficeEntity", "Office")
                        .WithMany("Electeds")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Domain.Entities.OfficeEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.ElectionEntity", "Election")
                        .WithMany("Offices")
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}