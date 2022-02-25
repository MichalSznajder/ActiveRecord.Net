namespace DCOM.Presentation
{
    using System.IO;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class DataContextProvider : IDataContextProvider
    {
        public DataContext GetContext()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(config.GetConnectionString("Default"));

            return new DataContext(options.Options);
        }
    }
}