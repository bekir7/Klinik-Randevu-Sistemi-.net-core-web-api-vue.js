using Microsoft.EntityFrameworkCore;
using RandevuSistemiv2.Models;

namespace RandevuSistemiv2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Patient configurations
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TcNumber).IsRequired().HasMaxLength(11);
                entity.HasIndex(e => e.TcNumber).IsUnique();
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Address).HasMaxLength(500);
            });

            // Doctor configurations
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TcNumber).IsRequired().HasMaxLength(11);
                entity.HasIndex(e => e.TcNumber).IsUnique();
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Specialty).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LicenseNumber).HasMaxLength(20);
            });

            // Appointment configurations
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Scheduled");
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.Diagnosis).HasMaxLength(500);
                entity.Property(e => e.Prescription).HasMaxLength(500);

                // Foreign key relationships
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.Appointments)
                      .HasForeignKey(e => e.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Index for appointment date and time
                entity.HasIndex(e => new { e.DoctorId, e.AppointmentDate, e.StartTime })
                      .IsUnique();
            });

            // DoctorSchedule configurations
            modelBuilder.Entity<DoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DurationMinutes).HasDefaultValue(30);

                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.Schedules)
                      .HasForeignKey(e => e.DoctorId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Unique constraint for doctor's schedule per day
                entity.HasIndex(e => new { e.DoctorId, e.DayOfWeek, e.StartTime })
                      .IsUnique();
            });

            // Clinic configurations
            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed clinic data
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    Id = 1,
                    Name = "Merkez Klinik",
                    Address = "Merkez Mahallesi, Sağlık Caddesi No:1",
                    PhoneNumber = "0212-555-0101",
                    Email = "info@merkezklinik.com",
                    Description = "Genel sağlık hizmetleri sunan merkez klinik",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seed doctor data
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Dr. Ahmet",
                    LastName = "Yılmaz",
                    TcNumber = "12345678901",
                    PhoneNumber = "0532-555-0101",
                    Email = "ahmet.yilmaz@merkezklinik.com",
                    Specialty = "Genel Cerrahi",
                    LicenseNumber = "GC001",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Dr. Ayşe",
                    LastName = "Demir",
                    TcNumber = "12345678902",
                    PhoneNumber = "0532-555-0102",
                    Email = "ayse.demir@merkezklinik.com",
                    Specialty = "Kardiyoloji",
                    LicenseNumber = "KAR001",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seed doctor schedules
            modelBuilder.Entity<DoctorSchedule>().HasData(
                // Dr. Ahmet Yılmaz - Pazartesi, Çarşamba, Cuma
                new DoctorSchedule
                {
                    Id = 1,
                    DoctorId = 1,
                    DayOfWeek = DayOfWeek.Monday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    DurationMinutes = 30,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new DoctorSchedule
                {
                    Id = 2,
                    DoctorId = 1,
                    DayOfWeek = DayOfWeek.Wednesday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    DurationMinutes = 30,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new DoctorSchedule
                {
                    Id = 3,
                    DoctorId = 1,
                    DayOfWeek = DayOfWeek.Friday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    DurationMinutes = 30,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                // Dr. Ayşe Demir - Salı, Perşembe, Cumartesi
                new DoctorSchedule
                {
                    Id = 4,
                    DoctorId = 2,
                    DayOfWeek = DayOfWeek.Tuesday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    DurationMinutes = 45,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new DoctorSchedule
                {
                    Id = 5,
                    DoctorId = 2,
                    DayOfWeek = DayOfWeek.Thursday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    DurationMinutes = 45,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new DoctorSchedule
                {
                    Id = 6,
                    DoctorId = 2,
                    DayOfWeek = DayOfWeek.Saturday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    DurationMinutes = 45,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

