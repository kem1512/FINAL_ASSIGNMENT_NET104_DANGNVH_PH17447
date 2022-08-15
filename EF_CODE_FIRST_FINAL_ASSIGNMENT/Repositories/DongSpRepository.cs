using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class DongSpRepository : IDongSpRepository
    {
        private readonly FinalAssignmentContext _context;
        public DongSpRepository(FinalAssignmentContext context)
        {
            _context = context;
        }

        public bool Add(DongSp obj)
        {
            try
            {
                _context.DongSp.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DongSp> GetAll()
        {
            return _context.DongSp.ToList();
        }

        public bool Remove(DongSp obj)
        {
            try
            {
                _context.DongSp.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(DongSp obj)
        {
            try
            {
                _context.DongSp.Update(obj);
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
