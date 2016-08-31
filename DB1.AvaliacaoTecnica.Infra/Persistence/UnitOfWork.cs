using DB1.AvaliacaoTecnica.Infrastructure.Data;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreDataContext _context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
