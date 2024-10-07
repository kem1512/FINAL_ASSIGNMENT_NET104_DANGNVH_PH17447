namespace MinkyShop.Data.Repositories
{
    public class GioHangChiTietRepository : IApplicationRepository<GioHangChiTiet>
    {
        public GioHangChiTietRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(GioHangChiTiet obj)
        {
            try
            {
                _context.GioHangChiTiet.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<GioHangChiTiet> Fetch()
        {
            return _context.GioHangChiTiet.ToList();
        }

        public override GioHangChiTiet Fetch(Guid id)
        {
            return _context.GioHangChiTiet.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var gioHangChiTiet = _context.GioHangChiTiet.Find(id);

                if (gioHangChiTiet == null) return false;

                _context.GioHangChiTiet.Remove(gioHangChiTiet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(GioHangChiTiet obj)
        {
            try
            {
                _context.GioHangChiTiet.Update(obj);
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
