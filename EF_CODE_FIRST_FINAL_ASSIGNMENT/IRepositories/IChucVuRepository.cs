using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IChucVuRepository 
    {
        bool Add(ChucVu obj);

        bool Update(ChucVu obj);

        bool Remove(ChucVu obj);

        List<ChucVu> GetAll();
    }
}
