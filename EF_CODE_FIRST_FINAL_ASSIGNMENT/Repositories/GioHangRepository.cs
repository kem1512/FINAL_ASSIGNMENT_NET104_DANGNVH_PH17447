using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly FinalAssignmentContext _context;
        public GioHangRepository(FinalAssignmentContext context)
        {
            _context = context;
        }

        public bool Add(GioHang obj)
        {
            try
            {
                _context.GioHang.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GioHang> GetAll()
        {
            return _context.GioHang.ToList();
        }

        public bool Remove(GioHang obj)
        {
            try
            {
                _context.GioHang.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(GioHang obj)
        {
            try
            {
                _context.GioHang.Update(obj);
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
