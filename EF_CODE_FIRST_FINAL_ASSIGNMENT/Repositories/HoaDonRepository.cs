using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly FinalAssignmentContext _context;
        public HoaDonRepository(FinalAssignmentContext context)
        {
            _context = context;
        }

        public bool Add(HoaDon obj)
        {
            try
            {
                _context.HoaDon.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDon> GetAll()
        {
            return _context.HoaDon.ToList();
        }

        public bool Remove(HoaDon obj)
        {
            try
            {
                _context.HoaDon.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(HoaDon obj)
        {
            try
            {
                _context.HoaDon.Update(obj);
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
