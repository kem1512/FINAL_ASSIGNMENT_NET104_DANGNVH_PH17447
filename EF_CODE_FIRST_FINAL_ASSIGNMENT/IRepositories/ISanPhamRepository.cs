using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface ISanPhamRepository
    {
        bool Add(SanPham obj);

        bool Update(SanPham obj);

        bool Remove(SanPham obj);

        List<SanPham> GetAll();
    }
}
