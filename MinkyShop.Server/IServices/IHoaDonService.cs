using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;
using MINKY_STORE_WEB_APPLICATION.Models;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IHoaDonService
    {
        bool Add(HoaDon obj);

        bool Update(HoaDon obj);

        bool Remove(HoaDon obj);

        List<HoaDon> GetAll();

        List<HoaDonViewModel> GetHoaDonViewModel();
    }
}
