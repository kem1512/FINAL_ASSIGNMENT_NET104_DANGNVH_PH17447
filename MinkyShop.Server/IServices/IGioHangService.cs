using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IGioHangService
    {
        bool Add(GioHang obj);

        bool Update(GioHang obj);

        bool Remove(GioHang obj);

        List<GioHang> GetAll();
    }
}
