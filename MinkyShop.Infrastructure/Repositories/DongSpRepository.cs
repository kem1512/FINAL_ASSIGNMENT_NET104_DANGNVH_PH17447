namespace MinkyShop.Data.Repositories
{
    public class DongSpRepository : IApplicationRepository<DongSp>
    {
        public DongSpRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(DongSp obj)
        {
            try
            {
                _context.DongSp.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<DongSp> Fetch()
        {
            return _context.DongSp.ToList();
        }

        public override DongSp Fetch(Guid id)
        {
            return _context.DongSp.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var dongSp = _context.DongSp.Find(id);

                if (dongSp == null) return false;

                _context.DongSp.Remove(dongSp);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(DongSp obj)
        {
            try
            {
                _context.DongSp.Update(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
