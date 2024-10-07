using MinkyShop.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface INsxService
    {
        bool Add(Nsx obj);

        bool Update(Nsx obj);

        bool Remove(Nsx obj);

        List<Nsx> GetAll();

        Nsx GetById(Guid id);
    }
}
