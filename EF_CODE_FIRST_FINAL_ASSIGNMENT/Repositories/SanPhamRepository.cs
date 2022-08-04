using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public SanPhamRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(SanPham obj)
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

        public List<SanPham> GetAll()
        {
            return _context.SanPham.ToList();
        }

        public bool Remove(SanPham obj)
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

        public bool Update(SanPham obj)
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
