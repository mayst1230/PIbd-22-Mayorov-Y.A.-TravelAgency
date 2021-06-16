using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TravelAgencyBusinnesLogic.ViewModels;

namespace TravelAgencyClientApp
{
    public class Program
    {
        public static int pageSize = 4;
        public static ClientViewModel Client { get; set; }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
