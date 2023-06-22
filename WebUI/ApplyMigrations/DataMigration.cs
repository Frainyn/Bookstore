using Json.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI
{
    public static class DataMigration
    {
        
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ConsoleAppDatabase>();
            db.Database.Migrate();
            return app;
        }
        
    }
}
