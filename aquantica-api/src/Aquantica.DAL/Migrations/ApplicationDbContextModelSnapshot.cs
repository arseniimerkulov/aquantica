﻿// <auto-generated />
using System;
using Aquantica.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aquantica.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aquantica.Core.Entities.AccessAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessActions");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.BackgroundJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CronExpression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IrrigationSectionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("JobMethod")
                        .HasColumnType("int");

                    b.Property<int>("JobRepetitionType")
                        .HasColumnType("int");

                    b.Property<int>("JobRepetitionValue")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IrrigationSectionId");

                    b.ToTable("BackgroundJobs");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.BackgroundJobEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BackgroundJobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsStart")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundJobId");

                    b.ToTable("BackgroundJobEvents");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IrrigationRulesetId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStopped")
                        .HasColumnType("bit");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("WaterUsed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IrrigationRulesetId");

                    b.HasIndex("SectionId");

                    b.ToTable("IrrigationHistory");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationRuleset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HumidityGrowthPerLiterConsumed")
                        .HasColumnType("float");

                    b.Property<double>("HumidityGrowthPerRainMm")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("IrrigationDuration")
                        .HasColumnType("time");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIrrigationDurationEnabled")
                        .HasColumnType("bit");

                    b.Property<double>("MinSoilHumidityThreshold")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OptimalSoilHumidity")
                        .HasColumnType("float");

                    b.Property<double>("RainAmountThreshold")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("RainAvoidanceDurationThreshold")
                        .HasColumnType("time");

                    b.Property<bool>("RainAvoidanceEnabled")
                        .HasColumnType("bit");

                    b.Property<double>("RainProbabilityThreshold")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureThreshold")
                        .HasColumnType("float");

                    b.Property<double>("WaterConsumptionPerMinute")
                        .HasColumnType("float");

                    b.Property<double>("WaterConsumptionThreshold")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SectionRulesets");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IrrigationSectionTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("SectionRulesetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IrrigationSectionTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SectionRulesetId");

                    b.ToTable("IrrigationSections");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationSectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SectionTypes");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccessActionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessActionId");

                    b.HasIndex("ParentId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BackgroundJobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<int>("IrrigationSectionId")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundJobId");

                    b.HasIndex("IrrigationSectionId");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("Precipitation")
                        .HasColumnType("float");

                    b.Property<int>("PrecipitationProbability")
                        .HasColumnType("int");

                    b.Property<int>("RelativeHumidity")
                        .HasColumnType("int");

                    b.Property<double>("SoilMoisture")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("WeatherRecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("WeatherRecordId");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.WeatherRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsForecast")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WeatherRecords");
                });

            modelBuilder.Entity("RoleAccessAction", b =>
                {
                    b.Property<int>("AccessActionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AccessActionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAccessAction", (string)null);
                });

            modelBuilder.Entity("Aquantica.Core.Entities.BackgroundJob", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.IrrigationSection", "IrrigationSection")
                        .WithMany("BackgroundJobs")
                        .HasForeignKey("IrrigationSectionId");

                    b.Navigation("IrrigationSection");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.BackgroundJobEvent", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.BackgroundJob", "BackgroundJob")
                        .WithMany("BackgroundJobEvents")
                        .HasForeignKey("BackgroundJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BackgroundJob");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationEvent", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.IrrigationRuleset", "IrrigationRuleset")
                        .WithMany()
                        .HasForeignKey("IrrigationRulesetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aquantica.Core.Entities.IrrigationSection", "Section")
                        .WithMany("IrrigationEvents")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IrrigationRuleset");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationSection", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.IrrigationSectionType", "IrrigationSectionType")
                        .WithMany("IrrigationSections")
                        .HasForeignKey("IrrigationSectionTypeId");

                    b.HasOne("Aquantica.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Aquantica.Core.Entities.IrrigationSection", "ParentSection")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Aquantica.Core.Entities.IrrigationRuleset", "IrrigationRuleset")
                        .WithMany("IrrigationSections")
                        .HasForeignKey("SectionRulesetId");

                    b.Navigation("IrrigationRuleset");

                    b.Navigation("IrrigationSectionType");

                    b.Navigation("Location");

                    b.Navigation("ParentSection");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.MenuItem", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.AccessAction", "AccessAction")
                        .WithMany()
                        .HasForeignKey("AccessActionId");

                    b.HasOne("Aquantica.Core.Entities.MenuItem", "ParentMenuItem")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("AccessAction");

                    b.Navigation("ParentMenuItem");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.RefreshToken", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Aquantica.Core.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.SensorData", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.BackgroundJob", "BackgroundJob")
                        .WithMany("SensorData")
                        .HasForeignKey("BackgroundJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aquantica.Core.Entities.IrrigationSection", "IrrigationSection")
                        .WithMany("SensorData")
                        .HasForeignKey("IrrigationSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BackgroundJob");

                    b.Navigation("IrrigationSection");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.User", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.WeatherForecast", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.Location", "Location")
                        .WithMany("WeatherForecasts")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aquantica.Core.Entities.WeatherRecord", "WeatherRecord")
                        .WithMany("WeatherForecasts")
                        .HasForeignKey("WeatherRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("WeatherRecord");
                });

            modelBuilder.Entity("RoleAccessAction", b =>
                {
                    b.HasOne("Aquantica.Core.Entities.AccessAction", null)
                        .WithMany()
                        .HasForeignKey("AccessActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aquantica.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aquantica.Core.Entities.BackgroundJob", b =>
                {
                    b.Navigation("BackgroundJobEvents");

                    b.Navigation("SensorData");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationRuleset", b =>
                {
                    b.Navigation("IrrigationSections");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationSection", b =>
                {
                    b.Navigation("BackgroundJobs");

                    b.Navigation("IrrigationEvents");

                    b.Navigation("SensorData");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.IrrigationSectionType", b =>
                {
                    b.Navigation("IrrigationSections");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.Location", b =>
                {
                    b.Navigation("WeatherForecasts");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Aquantica.Core.Entities.User", b =>
                {
                    b.Navigation("RefreshToken")
                        .IsRequired();
                });

            modelBuilder.Entity("Aquantica.Core.Entities.WeatherRecord", b =>
                {
                    b.Navigation("WeatherForecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
