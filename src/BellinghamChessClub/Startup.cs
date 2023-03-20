using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BellinghamChessClub.DataAccess;

namespace BellinghamChessClub
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ClubDbContext>(options => {
        var dataFile = _config.GetValue<string>("ClubDataFile");
        var directory = Path.GetDirectoryName(dataFile);
        Directory.CreateDirectory(directory);

        options.UseSqlite($"Data Source={dataFile}");
      });

      services.AddScoped<IPlayerRepository, PlayerRepository>();
      services.AddScoped<IGameRepository, GameRepository>();

      services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ClubDbContext context)
    {
      context.Database.EnsureCreated();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
