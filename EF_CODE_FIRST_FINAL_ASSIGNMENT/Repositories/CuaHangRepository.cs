using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class CuaHangRepository : ICuaHangRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public CuaHangRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(CuaHang obj)
        {
            try
            {
                _context.CuaHang.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CuaHang> GetAll()
        {
            return _context.CuaHang.ToList();
        }

        public bool Remove(CuaHang obj)
        {
            try
            {
                _context.CuaHang.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CuaHang obj)
        {
            try
            {
                _context.CuaHang.Update(obj);
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
