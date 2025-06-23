using AutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApi.Data
{
    public class AutoContext : DbContext
    {
        public AutoContext(DbContextOptions<AutoContext> options) : base(options) {}

        public DbSet<Automerk> Automerken { get; set; }
        public DbSet<Autotype> Autotypes { get; set; }
    }
}