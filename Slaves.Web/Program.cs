using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Slaves.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>()
					.UseUrls("https://localhost:5001;https://192.168.31.175:5001;http://192.168.31.175:5000");
				});
	}
}
