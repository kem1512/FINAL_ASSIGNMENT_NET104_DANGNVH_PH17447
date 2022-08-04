using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public KhachHangRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(KhachHang obj)
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

        public List<KhachHang> GetAll()
        {
            return _context.KhachHang.ToList();
        }

        public bool Remove(KhachHang obj)
        {
            try
            {
                _context.KhachHang.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(KhachHang obj)
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
