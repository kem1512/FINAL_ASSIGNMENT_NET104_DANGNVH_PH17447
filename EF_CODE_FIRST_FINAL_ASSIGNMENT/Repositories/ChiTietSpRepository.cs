using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class ChiTietSpRepository : IChiTietSpRepository
    {
        private readonly FinalAssignmentContext _context;
        public ChiTietSpRepository(FinalAssignmentContext context)
        {
            _context = context;
        }

        public bool Add(ChiTietSp obj)
        {
            try
            {
                _context.ChiTietSp.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChiTietSp> GetAll()
        {
            return _context.ChiTietSp.ToList();
        }

        public bool Remove(ChiTietSp obj)
        {
            try
            {
                _context.ChiTietSp.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ChiTietSp obj)
        {
            try
            {
                _context.ChiTietSp.Update(obj);
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
