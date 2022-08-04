using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IHoaDonChiTietRepository
    {
        bool Add(HoaDonChiTiet obj);

        bool Update(HoaDonChiTiet obj);

        bool Remove(HoaDonChiTiet obj);

        List<HoaDonChiTiet> GetAll();
    }
}
