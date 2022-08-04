using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IGioHangChiTietRepository
    {
        bool Add(GioHangChiTiet obj);

        bool Update(GioHangChiTiet obj);

        bool Remove(GioHangChiTiet obj);

        List<GioHangChiTiet> GetAll();
    }
}
