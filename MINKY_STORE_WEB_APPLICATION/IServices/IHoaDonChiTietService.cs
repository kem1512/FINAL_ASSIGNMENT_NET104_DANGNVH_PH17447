using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IHoaDonChiTietService
    {
        bool Add(HoaDonChiTiet obj);

        bool Update(HoaDonChiTiet obj);

        bool Remove(HoaDonChiTiet obj);

        List<HoaDonChiTiet> GetAll();
    }
}
