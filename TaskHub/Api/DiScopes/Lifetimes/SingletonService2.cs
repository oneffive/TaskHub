using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface ISingletonService2 : IHasInstanceId { }

public class SingletonService2 
    : DisposedService, ISingletonService2
{
}