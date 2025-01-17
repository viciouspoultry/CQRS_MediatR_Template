﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ConfigureServices
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		return services;
	}
}
