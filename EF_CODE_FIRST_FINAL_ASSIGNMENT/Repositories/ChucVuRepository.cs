using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class ChucVuRepository : IChucVuRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public ChucVuRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(ChucVu obj)
        {
            try
            {
                _context.ChucVu.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChucVu> GetAll()
        {
            return _context.ChucVu.ToList();
        }

        public bool Remove(ChucVu obj)
        {
            try
            {
                _context.ChucVu.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ChucVu obj)
        {
            try
            {
                _context.ChucVu.Update(obj);
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
