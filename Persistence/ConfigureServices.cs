﻿using Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class ConfigureServices
{
	public static IServiceCollection AddPersistenceServices
		(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContextFactory<DataContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
				throw new InvalidOperationException("connection string 'DefaultConnection' not found")),
			ServiceLifetime.Transient);

		services.AddScoped<IUnitOfWork, UnitOfWork>();
		return services;
	}
}
