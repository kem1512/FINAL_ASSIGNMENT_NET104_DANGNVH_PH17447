using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class GioHangChiTietRepository : IGioHangChiTietRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public GioHangChiTietRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(GioHangChiTiet obj)
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

        public List<GioHangChiTiet> GetAll()
        {
            return _context.GioHangChiTiet.ToList();
        }

        public bool Remove(GioHangChiTiet obj)
        {
            try
            {
                _context.GioHangChiTiet.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(GioHangChiTiet obj)
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
