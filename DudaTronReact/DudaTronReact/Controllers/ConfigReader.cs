using Microsoft.Extensions.Configuration;
using System;

namespace DudaTronReact.Controllers
{
	public static class ConfigReader
	{
		public static IConfiguration config = GetConfig();

		public static IConfiguration GetConfig()
		{
			var builder = new ConfigurationBuilder()
		   .SetBasePath(Environment.CurrentDirectory)
		   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
		   .AddEnvironmentVariables();
			var config = builder.Build();
			return config;
		}
	}
}