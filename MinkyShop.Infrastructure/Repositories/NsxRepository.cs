﻿namespace MinkyShop.Data.Repositories
{
    public class NsxRepository : IApplicationRepository<Nsx>
    {
        public NsxRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override bool Add(Nsx obj)
        {
            try
            {
                _context.Nsx.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override IEnumerable<Nsx> Fetch()
        {
            return _context.Nsx.ToList();
        }

        public override Nsx Fetch(Guid id)
        {
            return _context.Nsx.Find(id);
        }

        public override bool Remove(Guid id)
        {
            try
            {
                var nsx = _context.Nsx.Find(id);

                if (nsx == null) return false;

                _context.Nsx.Remove(nsx);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(Nsx obj)
        {
            try
            {
                _context.Nsx.Update(obj);
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
