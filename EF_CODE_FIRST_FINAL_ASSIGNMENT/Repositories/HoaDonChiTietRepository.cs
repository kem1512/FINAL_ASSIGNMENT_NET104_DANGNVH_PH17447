﻿using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories
{
    public class HoaDonChiTietRepository : IHoaDonChiTietRepository
    {
        private FinalAssignmentContext _context = new FinalAssignmentContext();
        public HoaDonChiTietRepository()
        {
            _context = new FinalAssignmentContext();
        }

        public bool Add(HoaDonChiTiet obj)
        {
            try
            {
                _context.HoaDonChiTiet.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return _context.HoaDonChiTiet.ToList();
        }

        public bool Remove(HoaDonChiTiet obj)
        {
            try
            {
                _context.HoaDonChiTiet.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(HoaDonChiTiet obj)
        {
            try
            {
                _context.HoaDonChiTiet.Update(obj);
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
