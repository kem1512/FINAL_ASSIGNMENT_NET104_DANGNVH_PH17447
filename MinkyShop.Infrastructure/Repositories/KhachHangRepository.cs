namespace MinkyShop.Data.Repositories
{
    public class KhachHangRepository : IApplicationRepository<NguoiDung>
    {
        public KhachHangRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(NguoiDung obj)
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

        public override IEnumerable<NguoiDung> Fetch()
        {
            return _context.KhachHang.ToList();
        }

        public override NguoiDung Fetch(Guid id)
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

        public override bool Update(NguoiDung obj)
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
