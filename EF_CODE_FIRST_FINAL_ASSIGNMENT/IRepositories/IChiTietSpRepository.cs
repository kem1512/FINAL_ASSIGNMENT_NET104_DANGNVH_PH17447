using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IChiTietSpRepository
    {
        bool Add(ChiTietSp obj);

        bool Update(ChiTietSp obj);

        bool Remove(ChiTietSp obj);

        List<ChiTietSp> GetAll();
    }
}
