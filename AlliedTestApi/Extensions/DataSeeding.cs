using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlliedTestApi.Extensions
{
    public static  class DataSeeding
    {
        public static void DataSeed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<MovieDbContext>();
                    dbContext.Database.Migrate();
                    dbContext.Initialize();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while migrating or seeding the database.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
