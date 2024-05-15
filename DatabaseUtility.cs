using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OyeIap.Server.Data;
using OyeIap.Server.Data.Seed;
namespace OyeIap.Server;
public static class DatabaseUtility
{
    // Method to see the database. Should not be used in production: demo purposes only.
    // options: The configured options.
    // count: The number of contacts to seed.
    public static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<ApplicationDbContext> options, int count)
    {
        // Empty to avoid logging while inserting (otherwise will flood console).
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>(options)
            .UseLoggerFactory(factory);

        using var context = new ApplicationDbContext(builder.Options);
        // Result is true if the database had to be created.
        if (await context.Database.EnsureCreatedAsync())
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var seedInstituciones = new SeedInstituciones();
                var seedAlumnos = new SeedAlumnosTutores();
                await seedInstituciones.SeedDatabaseWithInstitucionCountOfAsync(context, 10);
                await seedAlumnos.SeedDatabaseWithAlumnoCountOfAsync(context, 10);

                await transaction.CommitAsync();
            }
            catch
            {
                // Rollback the transaction if any operation fails
                await transaction.RollbackAsync();
                await context.Database.EnsureDeletedAsync();
                throw;
            }
        }
    }
}
