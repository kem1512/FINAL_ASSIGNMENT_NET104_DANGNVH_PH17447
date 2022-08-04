using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class NsxRepository : INsxRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public NsxRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(Nsx obj)
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

        public List<Nsx> GetAll()
        {
            return _context.Nsx.ToList();
        }

        public bool Remove(Nsx obj)
        {
            try
            {
                _context.Nsx.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Nsx obj)
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
