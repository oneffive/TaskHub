using System;

namespace Api.DiScopes;

public interface IHasInstanceId
{
    Guid InstanceId { get; }
}