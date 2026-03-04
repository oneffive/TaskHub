using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface ISingletonService1 : IHasInstanceId { }

public class SingletonService1 
    : DisposedService, ISingletonService1
{
}