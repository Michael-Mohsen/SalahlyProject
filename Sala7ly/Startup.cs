using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sala7ly.EF;
using Sala7ly.Core.Interfaces;
using Sala7ly.EF.Repositories;
using Sala7ly.Core;
using Sala7ly.EF.Mapping;
using AutoMapper;


namespace Sala7ly
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("DefaultConnection");
			Console.WriteLine($"Connection String: {connectionString}");

			services.AddDbContext<Sala7lyDbContext>(options =>{
				options.UseSqlServer(connectionString,
					b => b.MigrationsAssembly(typeof(Sala7lyDbContext).Assembly.FullName));
			});

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			services.AddAutoMapper(typeof(MappingProfile).Assembly);

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sala7ly", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sala7ly v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
