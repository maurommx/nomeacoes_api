using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<RolePermissionEntity> RolePermission { get; set; }
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
            .UseNpgsql("Server=localhost;Port=5432;Database=nomeacoes;User Id=postgres;Password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RolePermissionEntity>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });


            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<AssociateEntity>(new AssociateMap().Configure);
            modelBuilder.Entity<ElectedEntity>(new ElectedMap().Configure);
            modelBuilder.Entity<ElectionEntity>(new ElectionMap().Configure);
            modelBuilder.Entity<MemberEntity>(new MemberMap().Configure);
            modelBuilder.Entity<OfficeEntity>(new OfficeMap().Configure);

            Guid RoleId = Guid.NewGuid();

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity
                {
                    Id = RoleId,
                    Name = "Administrador",
                    CreateAt = DateTime.Now
                }
            );

            Guid perm_users_id_list = Guid.NewGuid();
            Guid perm_users_id_insert = Guid.NewGuid();
            Guid perm_users_id_update = Guid.NewGuid();
            Guid perm_users_id_delete = Guid.NewGuid();

            Guid perm_permissions_id_list = Guid.NewGuid();
            Guid perm_permissions_id_insert = Guid.NewGuid();
            Guid perm_permissions_id_update = Guid.NewGuid();
            Guid perm_permissions_id_delete = Guid.NewGuid();

            Guid perm_roles_id_list = Guid.NewGuid();
            Guid perm_roles_id_insert = Guid.NewGuid();
            Guid perm_roles_id_update = Guid.NewGuid();
            Guid perm_roles_id_delete = Guid.NewGuid();

            modelBuilder.Entity<PermissionEntity>().HasData(
                new PermissionEntity
                {
                    Id = perm_users_id_list,
                    Name = "Usuários Listar",
                    Slug = "user-list"
                },
                new PermissionEntity
                {
                    Id = perm_users_id_insert,
                    Name = "Usuários Inserir",
                    Slug = "user-insert"
                },
                new PermissionEntity
                {
                    Id = perm_users_id_update,
                    Name = "Usuários Alterar",
                    Slug = "user-Update"
                },
                new PermissionEntity
                {
                    Id = perm_users_id_delete,
                    Name = "Usuários Apagar",
                    Slug = "user-delete"
                },

                new PermissionEntity
                {
                    Id = perm_permissions_id_list,
                    Name = "Permissões Listar",
                    Slug = "permission-list"
                },
                new PermissionEntity
                {
                    Id = perm_permissions_id_insert,
                    Name = "Permissões Inserir",
                    Slug = "permission-insert"
                },
                new PermissionEntity
                {
                    Id = perm_permissions_id_update,
                    Name = "Permissões Alterar",
                    Slug = "permission-Update"
                },
                new PermissionEntity
                {
                    Id = perm_permissions_id_delete,
                    Name = "Permissões Apagar",
                    Slug = "permission-delete"
                },

                new PermissionEntity
                {
                    Id = perm_roles_id_list,
                    Name = "Papeis Listar",
                    Slug = "roles-list"
                },
                new PermissionEntity
                {
                    Id = perm_roles_id_insert,
                    Name = "Papeis Inserir",
                    Slug = "roles-insert"
                },
                new PermissionEntity
                {
                    Id = perm_roles_id_update,
                    Name = "Papeis Alterar",
                    Slug = "roles-Update"
                },
                new PermissionEntity
                {
                    Id = perm_roles_id_delete,
                    Name = "Papeis Apagar",
                    Slug = "roles-delete"
                }
            );

            modelBuilder.Entity<RolePermissionEntity>().HasData(
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_users_id_list,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_users_id_insert,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_users_id_update,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_users_id_delete,
                    CreateAt = DateTime.Now
                },

                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_permissions_id_list,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_permissions_id_insert,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_permissions_id_update,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_permissions_id_delete,
                    CreateAt = DateTime.Now
                },

                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_roles_id_list,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_roles_id_insert,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_roles_id_update,
                    CreateAt = DateTime.Now
                },
                new RolePermissionEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    PermissionId = perm_roles_id_delete,
                    CreateAt = DateTime.Now
                }
            );


            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    RoleId = RoleId,
                    Name = "Mauro Meneses Xavier",
                    Email = "mauro.mmx@gmail.com",
                    Senha = "698dc19d489c4e4db73e28a713eab07b", /*teste*/
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
