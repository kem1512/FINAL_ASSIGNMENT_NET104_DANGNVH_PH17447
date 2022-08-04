using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IHoaDonService
    {
        bool Add(HoaDon obj);

        bool Update(HoaDon obj);

        bool Remove(HoaDon obj);

        List<HoaDon> GetAll();
    }
}
