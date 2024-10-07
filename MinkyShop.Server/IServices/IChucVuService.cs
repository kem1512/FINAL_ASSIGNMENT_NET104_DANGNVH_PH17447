using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IChucVuService
    {
        bool Add(ChucVu obj);

        bool Update(ChucVu obj);

        bool Remove(ChucVu obj);

        List<ChucVu> GetAll();

        ChucVu GetById(Guid id);
    }
}
