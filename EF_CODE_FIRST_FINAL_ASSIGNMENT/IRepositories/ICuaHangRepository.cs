using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface ICuaHangRepository
    {
        bool Add(CuaHang obj);

        bool Update(CuaHang obj);

        bool Remove(CuaHang obj);

        List<CuaHang> GetAll();
    }
}
