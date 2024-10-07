namespace MinkyShop.Data.Repositories
{
    public class MauSacRepository : IApplicationRepository<MauSac>
    {
        public MauSacRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(MauSac obj)
        {
            try
            {
                _context.MauSac.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<MauSac> Fetch()
        {
            return _context.MauSac.ToList();
        }

        public override MauSac Fetch(Guid id)
        {
            return _context.MauSac.Find(id);
        }

        public override bool Remove(MauSac obj)
        {
            try
            {
                _context.MauSac.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(MauSac obj)
        {
            try
            {
                _context.MauSac.Update(obj);
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
