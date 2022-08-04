using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class NhanVienRepository : INhanVienRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public NhanVienRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(NhanVien obj)
        {
            try
            {
                _context.NhanVien.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<NhanVien> GetAll()
        {
            return _context.NhanVien.ToList();
        }

        public bool Remove(NhanVien obj)
        {
            try
            {
                _context.NhanVien.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(NhanVien obj)
        {
            try
            {
                _context.NhanVien.Update(obj);
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
