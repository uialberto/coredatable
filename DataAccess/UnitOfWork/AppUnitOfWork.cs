using CoreWebApp.Entities;
using CoreWebApp.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataAccess.UnitOfWork
{
    public class AppUnitOfWork : DbContext
    {
        public AppUnitOfWork(DbContextOptions options) : base(options) { }
        public DbSet<Persona> Personas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<Position, string>(
                v => EnumHelper<Position>.GetDisplayValue(v),
                v => EnumHelper<Position>.Parse(v.Trim().Replace(" ", string.Empty)));
        }
    }
}
