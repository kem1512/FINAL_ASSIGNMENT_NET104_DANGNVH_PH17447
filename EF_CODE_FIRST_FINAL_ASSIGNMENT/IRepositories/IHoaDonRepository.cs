using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IHoaDonRepository
    {
        bool Add(HoaDon obj);

        bool Update(HoaDon obj);

        bool Remove(HoaDon obj);

        List<HoaDon> GetAll();
    }
}
