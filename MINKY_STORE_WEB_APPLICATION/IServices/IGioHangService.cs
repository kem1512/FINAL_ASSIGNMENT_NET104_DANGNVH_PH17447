using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IGioHangRepository
    {
        bool Add(GioHang obj);

        bool Update(GioHang obj);

        bool Remove(GioHang obj);

        List<GioHang> GetAll();
    }
}
