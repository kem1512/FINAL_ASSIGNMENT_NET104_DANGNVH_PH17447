namespace MinkyShop.Infrastructure.Common.Interfaces
{
    public abstract class IApplicationRepository<T>
    {
        protected readonly ApplicationDbContext _context;

        protected IApplicationRepository(ApplicationDbContext context)
        {
            _context = context;   
        }

        public abstract bool Add(T obj);

        public abstract bool Update(T obj);

        public abstract bool Remove(T obj);

        public abstract IEnumerable<T> Fetch();

        public abstract T Fetch(Guid id);
    }
}
