using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IDongSpService
    {
        bool Add(DongSp obj);

        bool Update(DongSp obj);

        bool Remove(DongSp obj);

        List<DongSp> GetAll();

        DongSp GetById(Guid id);
    }
}
