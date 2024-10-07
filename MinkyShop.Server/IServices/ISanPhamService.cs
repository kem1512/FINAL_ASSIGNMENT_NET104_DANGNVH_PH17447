using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface ISanPhamService
    {
        bool Add(SanPham obj);

        bool Update(SanPham obj);

        bool Remove(SanPham obj);

        List<SanPham> GetAll();

        SanPham GetById(Guid id);
    }
}
