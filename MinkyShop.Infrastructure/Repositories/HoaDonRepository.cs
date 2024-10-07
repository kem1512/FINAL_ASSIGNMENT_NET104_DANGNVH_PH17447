namespace MinkyShop.Data.Repositories
{
    public class HoaDonRepository : IApplicationRepository<HoaDon>
    {
        public HoaDonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(HoaDon obj)
        {
            try
            {
                _context.HoaDon.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<HoaDon> Fetch()
        {
            return _context.HoaDon.ToList();
        }

        public override HoaDon Fetch(Guid id)
        {
            return _context.HoaDon.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var hoaDon = _context.HoaDon.Find(id);

                if (hoaDon == null) return false;

                _context.HoaDon.Remove(hoaDon);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(HoaDon obj)
        {
            try
            {
                _context.HoaDon.Update(obj);
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
