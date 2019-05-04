namespace EVA.Infrastructure.Data.Abstractions.Migrations
{
    public interface IMigrationsProvider
    {     
        bool Migrate();
    }
}