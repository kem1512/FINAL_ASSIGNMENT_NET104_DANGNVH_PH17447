using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IGioHangChiTietService
    {
        bool Add(GioHangChiTiet obj);

        bool Update(GioHangChiTiet obj);

        bool Remove(GioHangChiTiet obj);

        List<GioHangChiTiet> GetAll();
    }
}
