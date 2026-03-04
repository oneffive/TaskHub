using System;
using Api.DiScopes;

namespace Api.DiScopes;

public abstract class DisposedService : IHasInstanceId, IDisposable
{
    public Guid InstanceId { get; } = Guid.NewGuid();

    protected DisposedService()
    {
        Console.WriteLine($"{GetType().Name} CREATED with Id: {InstanceId}");
    }

    public void Dispose()
    {
        Console.WriteLine($"{GetType().Name} DISPOSED with Id: {InstanceId}");
    }
}