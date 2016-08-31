using System;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
