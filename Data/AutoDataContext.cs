using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class AutoDataContext : IdentityDbContext
    {
        public AutoDataContext()
        {
        }

        public AutoDataContext(DbContextOptions<AutoDataContext> options)
           : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<EngineModel> EngineModels { get; set; }
        public DbSet<GearBoxType> GearsBoxTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server = DESKTOP-F2FA450; Database = AutoData; Trusted_connection=True;");
        }
    }
}
