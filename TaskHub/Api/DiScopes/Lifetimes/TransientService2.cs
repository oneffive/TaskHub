using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface ITransientService2 : IHasInstanceId { }

public class TransientService2 
    : DisposedService, ITransientService2
{
}