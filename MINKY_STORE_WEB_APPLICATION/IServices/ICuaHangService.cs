using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface ICuaHangService
    {
        bool Add(CuaHang obj);

        bool Update(CuaHang obj);

        bool Remove(CuaHang obj);

        List<CuaHang> GetAll();

        CuaHang GetById(Guid id);
    }
}
