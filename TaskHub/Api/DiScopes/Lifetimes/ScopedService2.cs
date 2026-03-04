using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface IScopedService2 : IHasInstanceId { }

public class ScopedService2 
    : DisposedService, IScopedService2
{
}