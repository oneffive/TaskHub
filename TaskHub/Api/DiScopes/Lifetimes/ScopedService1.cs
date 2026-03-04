using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface IScopedService1 : IHasInstanceId { }

public class ScopedService1 
    : DisposedService, IScopedService1
{
}