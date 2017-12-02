using System;

namespace Eventure.ReadModel
{
    public interface IReadModel : IReadModel<Guid>
    {
    }
    
    public interface IReadModel<TId>
    {
        TId Id { get; set; }
        int Version { get; set; }
    }
}