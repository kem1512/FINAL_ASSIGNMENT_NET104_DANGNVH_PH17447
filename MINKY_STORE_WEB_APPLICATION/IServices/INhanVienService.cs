using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using MINKY_STORE_WEB_APPLICATION.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface INhanVienService
    {
        bool Add(NhanVien obj);

        bool Update(NhanVien obj);

        bool Remove(NhanVien obj);

        List<NhanVien> GetAll();

        List<NhanVienViewModel> GetNhanVienViewModel();

        NhanVien GetById(Guid id);
    }
}
