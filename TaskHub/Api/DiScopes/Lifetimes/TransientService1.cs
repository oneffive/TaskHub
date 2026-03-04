using Api.DiScopes;

namespace Api.DiScopes.Lifetimes;

public interface ITransientService1 : IHasInstanceId { }

public class TransientService1 
    : DisposedService, ITransientService1
{
}