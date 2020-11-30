using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AssociateEntity> Associates { get; set; }
        public DbSet<ElectedEntity> Electeds { get; set; }
        public DbSet<ElectionEntity> Elections { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            // .UseLazyLoadingProxies()
            .UseNpgsql("Server=192.168.0.17;Port=5432;Database=nomeacoes;User Id=postgres;Password=P@ssword00;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<AssociateEntity>(new AssociateMap().Configure);
            modelBuilder.Entity<ElectedEntity>(new ElectedMap().Configure);
            modelBuilder.Entity<ElectionEntity>(new ElectionMap().Configure);
            modelBuilder.Entity<MemberEntity>(new MemberMap().Configure);
            modelBuilder.Entity<OfficeEntity>(new OfficeMap().Configure);


            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "mfrinfo@mail.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                }
            );

            Guid EleId = Guid.NewGuid();

            modelBuilder.Entity<ElectionEntity>().HasData(
                new ElectionEntity
                {
                    Id = EleId,
                    Name = "Eleições 2020",
                    CreateAt = DateTime.Now
                }
            );

            modelBuilder.Entity<OfficeEntity>().HasData(
                new OfficeEntity
                {
                    Id = Guid.NewGuid(),
                    ElectionId = EleId,
                    Name = "Aventureiros",
                    CreateAt = DateTime.Now
                }
            );

            modelBuilder.Entity<MemberEntity>().HasData(
                new MemberEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Marcelle",
                    CreateAt = DateTime.Now
                },
                new MemberEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Fabiana",
                    CreateAt = DateTime.Now
                },
                new MemberEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Carolina",
                    CreateAt = DateTime.Now
                }
            );

            // UfSeeds.Ufs(modelBuilder);
        }
    }
}
