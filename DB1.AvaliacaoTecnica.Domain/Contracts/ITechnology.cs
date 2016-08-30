using System;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface ITechnology
    {
        Guid Id { get; }
        string Description { get; }
    }
}
