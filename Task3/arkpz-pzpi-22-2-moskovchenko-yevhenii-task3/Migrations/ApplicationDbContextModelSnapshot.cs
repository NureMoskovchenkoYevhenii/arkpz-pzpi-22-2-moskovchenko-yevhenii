﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StaffFlow_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChangeRequest", b =>
                {
                    b.Property<int>("ChangeRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChangeRequestId"));

                    b.Property<int>("DayTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ChangeRequestId");

                    b.HasIndex("DayTypeId");

                    b.ToTable("ChangeRequests");
                });

            modelBuilder.Entity("DayType", b =>
                {
                    b.Property<int>("DayTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DayTypeId"));

                    b.Property<string>("DayTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DayTypeId");

                    b.ToTable("DayTypes");
                });

            modelBuilder.Entity("SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Humidity")
                        .HasColumnType("numeric")
                        .HasColumnName("humidity");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("numeric")
                        .HasColumnName("temperature");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserChangeRequest", b =>
                {
                    b.Property<int>("UserChangeRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserChangeRequestId"));

                    b.Property<int>("ChangeRequestId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserChangeRequestId");

                    b.HasIndex("ChangeRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChangeRequests");
                });

            modelBuilder.Entity("UserWorkingDay", b =>
                {
                    b.Property<int>("UserWorkingDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserWorkingDayId"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkingDayId")
                        .HasColumnType("integer");

                    b.HasKey("UserWorkingDayId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkingDayId");

                    b.ToTable("UserWorkingDays");
                });

            modelBuilder.Entity("WorkingDay", b =>
                {
                    b.Property<int>("WorkingDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkingDayId"));

                    b.Property<int>("DayTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("WorkingDayId");

                    b.HasIndex("DayTypeId");

                    b.ToTable("WorkingDays");
                });

            modelBuilder.Entity("ChangeRequest", b =>
                {
                    b.HasOne("DayType", "DayType")
                        .WithMany("ChangeRequests")
                        .HasForeignKey("DayTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayType");
                });

            modelBuilder.Entity("UserChangeRequest", b =>
                {
                    b.HasOne("ChangeRequest", "ChangeRequest")
                        .WithMany("UserChangeRequests")
                        .HasForeignKey("ChangeRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("UserChangeRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChangeRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserWorkingDay", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("UserWorkingDays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkingDay", "WorkingDay")
                        .WithMany("UserWorkingDays")
                        .HasForeignKey("WorkingDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkingDay");
                });

            modelBuilder.Entity("WorkingDay", b =>
                {
                    b.HasOne("DayType", "DayType")
                        .WithMany("WorkingDays")
                        .HasForeignKey("DayTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayType");
                });

            modelBuilder.Entity("ChangeRequest", b =>
                {
                    b.Navigation("UserChangeRequests");
                });

            modelBuilder.Entity("DayType", b =>
                {
                    b.Navigation("ChangeRequests");

                    b.Navigation("WorkingDays");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("UserChangeRequests");

                    b.Navigation("UserWorkingDays");
                });

            modelBuilder.Entity("WorkingDay", b =>
                {
                    b.Navigation("UserWorkingDays");
                });
#pragma warning restore 612, 618
        }
    }
}
