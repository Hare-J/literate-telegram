using CanadaGames.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CanadaGames.Data
{
    public class CanadaGamesContext : DbContext
    {
        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }

        public CanadaGamesContext(DbContextOptions<CanadaGamesContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            UserName = UserName ?? "Unknown";
        }

        public CanadaGamesContext(DbContextOptions<CanadaGamesContext> options)
            : base(options)
        {
            UserName = "SeedData";
        }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Contingent> Contingents { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<AthleteSport> AthleteSports { get; set; }
        public DbSet<Hometown> Hometowns { get; set; }
        public DbSet<AthletePhoto> AthletePhotos { get; set; }
        public DbSet<AthleteDocument> AthleteDocuments { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<AthleteThumbnail> AthleteThumbnails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Placement> Placements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("CG");

            //Add a composite primary key to AthleteSport
            modelBuilder.Entity<AthleteSport>()
            .HasKey(p => new { p.AthleteID, p.SportID });

            //Add a unique index to the combined foreign keys
            modelBuilder.Entity<Placement>()
            .HasIndex(p => new { p.AthleteID, p.EventID })
            .IsUnique();

            //Add a composite unique constraint key Hometown
            modelBuilder.Entity<Hometown>()
            .HasIndex(p => new { p.Name, p.ContingentID})
            .IsUnique();

            //Prevent Cascade Deletes
            modelBuilder.Entity<Sport>()
                .HasMany<Athlete>(d => d.Athletes)
                .WithOne(p => p.Sport)
                .HasForeignKey(p => p.SportID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
            .HasMany<Placement>(d => d.Placements)
            .WithOne(p => p.Event)
            .HasForeignKey(p => p.EventID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gender>()
                .HasMany<Athlete>(d => d.Athletes)
                .WithOne(p => p.Gender)
                .HasForeignKey(p => p.GenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contingent>()
                .HasMany<Athlete>(d => d.Athletes)
                .WithOne(p => p.Contingent)
                .HasForeignKey(p => p.ContingentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contingent>()
                .HasMany<Hometown>(d => d.Hometowns)
                .WithOne(p => p.Contingent)
                .HasForeignKey(p => p.ContingentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sport>()
                .HasMany<AthleteSport>(d => d.AthleteSports)
                .WithOne(p => p.Sport)
                .HasForeignKey(p => p.SportID)
                .OnDelete(DeleteBehavior.Restrict);

            //Note: Because CoachID is nullable in Athlete,
            //      Cascade Delete is already restricted

            //Add a unique index to the AthleteCode Number
            modelBuilder.Entity<Athlete>()
            .HasIndex(p => p.AthleteCode)
            .IsUnique();

            //Add a unique indexs to the Codes for Contingent, Gender and Sport
            modelBuilder.Entity<Contingent>()
            .HasIndex(p => p.Code)
            .IsUnique();
            modelBuilder.Entity<Gender>()
            .HasIndex(p => p.Code)
            .IsUnique();
            modelBuilder.Entity<Sport>()
            .HasIndex(p => p.Code)
            .IsUnique();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }
    }
}
