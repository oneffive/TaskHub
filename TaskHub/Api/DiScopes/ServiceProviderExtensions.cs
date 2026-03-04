using System;
using Microsoft.Extensions.DependencyInjection;
using Api.DiScopes;

namespace Api.DiScopes;

public static class ServiceProviderExtensions
{
    public static void CompareInstances<TService>(this IServiceProvider provider)
        where TService : IHasInstanceId
    {
        var first = provider.GetRequiredService<TService>();
        var second = provider.GetRequiredService<TService>();

        Console.WriteLine($"Service: {typeof(TService).Name}");
        Console.WriteLine($"First Id: {first.InstanceId}");
        Console.WriteLine($"Second Id: {second.InstanceId}");
        Console.WriteLine($"Same object: {ReferenceEquals(first, second)}");
        Console.WriteLine();
    }
}