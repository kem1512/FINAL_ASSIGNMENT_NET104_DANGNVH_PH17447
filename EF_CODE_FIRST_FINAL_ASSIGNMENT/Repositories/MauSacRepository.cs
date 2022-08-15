using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class MauSacRepository : IMauSacRepository
    {
        private readonly FinalAssignmentContext _context;
        public MauSacRepository(FinalAssignmentContext context)
        {
            _context = context;
        }

        public bool Add(MauSac obj)
        {
            try
            {
                _context.MauSac.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MauSac> GetAll()
        {
            return _context.MauSac.ToList();
        }

        public bool Remove(MauSac obj)
        {
            try
            {
                _context.MauSac.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(MauSac obj)
        {
            try
            {
                _context.MauSac.Update(obj);
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
