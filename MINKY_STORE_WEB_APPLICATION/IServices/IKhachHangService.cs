using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IKhachHangService
    {
        bool Add(KhachHang obj);

        bool Update(KhachHang obj);

        bool Remove(KhachHang obj);

        List<KhachHang> GetAll();
    }
}
