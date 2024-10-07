namespace MinkyShop.Data.Repositories
{
    public class SanPhamRepository : IApplicationRepository<SanPham>
    {
        public SanPhamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(SanPham obj)
        {
            try
            {
                _context.SanPham.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<SanPham> Fetch()
        {
            return _context.SanPham.ToList();
        }

        public override SanPham Fetch(Guid id)
        {
            return _context.SanPham.Find(id);
        }

        public override bool Remove(SanPham obj)
        {
            try
            {
                _context.SanPham.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(SanPham obj)
        {
            try
            {
                _context.SanPham.Update(obj);
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
