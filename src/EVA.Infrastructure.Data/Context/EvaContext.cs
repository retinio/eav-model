using EVA.Infrastructure.Data.Abstractions.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EVA.Infrastructure.Data.Context
{
    public class EvaContext : DbContext
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;

        private string MigrationsAssembly => GetType().Assembly.FullName;
        private static string MigrationsHistoryTable => "migrations_histories";
        private static string MigrationsSchema => "public";

        public EvaContext(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbSettings.Value.ConnectionString, builder =>
            {
                builder.MigrationsAssembly(MigrationsAssembly);
                builder.MigrationsHistoryTable(MigrationsHistoryTable, MigrationsSchema);
            });
        }
    }
}