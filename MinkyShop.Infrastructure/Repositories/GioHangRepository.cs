namespace MinkyShop.Data.Repositories
{
    public class GioHangRepository : IApplicationRepository<GioHang>
    {
        public GioHangRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(GioHang obj)
        {
            try
            {
                _context.GioHang.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<GioHang> Fetch()
        {
            return _context.GioHang.ToList();
        }

        public override GioHang Fetch(Guid id)
        {
            return _context.GioHang.Find(id);
        }

        public override bool Remove(GioHang obj)
        {
            try
            {
                _context.GioHang.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(GioHang obj)
        {
            try
            {
                _context.GioHang.Update(obj);
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
