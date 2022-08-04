using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface INhanVienRepository
    {
        bool Add(NhanVien obj);

        bool Update(NhanVien obj);

        bool Remove(NhanVien obj);

        List<NhanVien> GetAll();
    }
}
