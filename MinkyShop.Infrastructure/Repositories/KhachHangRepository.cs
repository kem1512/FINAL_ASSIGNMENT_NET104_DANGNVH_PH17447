namespace MinkyShop.Data.Repositories
{
    public class KhachHangRepository : IApplicationRepository<KhachHang>
    {
        public KhachHangRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(KhachHang obj)
        {
            try
            {
                _context.KhachHang.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<KhachHang> Fetch()
        {
            return _context.KhachHang.ToList();
        }

        public override KhachHang Fetch(Guid id)
        {
            return _context.KhachHang.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var khachHang = _context.KhachHang.Find(id);

                if (khachHang == null) return false;

                _context.KhachHang.Remove(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(KhachHang obj)
        {
            try
            {
                _context.KhachHang.Update(obj);
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
