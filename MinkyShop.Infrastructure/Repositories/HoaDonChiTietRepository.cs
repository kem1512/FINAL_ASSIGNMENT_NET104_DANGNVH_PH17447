using MinkyShop.Infrastructure.Data.Entities;

namespace MinkyShop.Data.Repositories
{
    public class HoaDonChiTietRepository : IApplicationRepository<HoaDonChiTiet>
    {
        public HoaDonChiTietRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(HoaDonChiTiet obj)
        {
            try
            {
                _context.HoaDonChiTiet.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<HoaDonChiTiet> Fetch()
        {
            return _context.HoaDonChiTiet.ToList();
        }

        public override HoaDonChiTiet Fetch(Guid id)
        {
            return _context.HoaDonChiTiet.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var hoaDonChiTiet = _context.HoaDonChiTiet.Find(id);

                if (hoaDonChiTiet == null) return false;

                _context.HoaDonChiTiet.Remove(hoaDonChiTiet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(HoaDonChiTiet obj)
        {
            try
            {
                _context.HoaDonChiTiet.Update(obj);
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
