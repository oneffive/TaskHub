using Api.DiScopes;
using Api.DiScopes.Lifetimes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LoggingLibrary;

namespace Api;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();


        using (var scope1 = host.Services.CreateScope())
        {
            var provider = scope1.ServiceProvider;

            provider.CompareInstances<ISingletonService1>();
            provider.CompareInstances<ISingletonService2>();
            provider.CompareInstances<IScopedService1>();
            provider.CompareInstances<IScopedService2>();
            provider.CompareInstances<ITransientService1>();
            provider.CompareInstances<ITransientService2>();
        } 

        using (var scope2 = host.Services.CreateScope())
        {
            var provider = scope2.ServiceProvider;

            provider.CompareInstances<ISingletonService1>();
            provider.CompareInstances<ISingletonService2>();
            provider.CompareInstances<IScopedService1>();
            provider.CompareInstances<IScopedService2>();
            provider.CompareInstances<ITransientService1>();
            provider.CompareInstances<ITransientService2>();
        }

        host.Run(); 
    }
}