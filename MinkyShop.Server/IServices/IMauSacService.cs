using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IMauSacService
    {
        bool Add(MauSac obj);

        bool Update(MauSac obj);

        bool Remove(MauSac obj);

        List<MauSac> GetAll();
        MauSac GetById(Guid id);
    }
}
