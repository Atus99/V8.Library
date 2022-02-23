using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using V8.Domain.Models.V8;

namespace V8.Infrastructure.Contexts
{
    public class V8Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public V8Context(DbContextOptions<V8Context> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public V8Context() : base()
        { }

        public V8Context(DbContextOptions<V8Context> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("V8Context"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.Property(p => p.HasOrganPermission).HasDefaultValue(false);
                e.Property(p => p.CountLoginFail).HasDefaultValue(0);
            });
        }

        #region V8
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<GroupPermission> GroupPermission { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionGroupPer> PermissionGroupPer { get; set; }
        #endregion
    }
}
