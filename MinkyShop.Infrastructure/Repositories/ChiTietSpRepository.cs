namespace MinkyShop.Data.Repositories
{
    public class ChiTietSpRepository : IApplicationRepository<ChiTietSp>
    {
        public ChiTietSpRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(ChiTietSp obj)
        {
            try
            {
                _context.ChiTietSp.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<ChiTietSp> Fetch()
        {
            return _context.ChiTietSp.ToList();
        }

        public override ChiTietSp Fetch(Guid id)
        {
            return _context.ChiTietSp.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var chiTietSp = _context.ChiTietSp.Find(id);

                if (chiTietSp == null) return false;

                _context.ChiTietSp.Remove(chiTietSp);

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(ChiTietSp obj)
        {
            try
            {
                _context.ChiTietSp.Update(obj);
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
