using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IDongSpRepository
    {
        bool Add(DongSp obj);

        bool Update(DongSp obj);

        bool Remove(DongSp obj);

        List<DongSp> GetAll();
    }
}
