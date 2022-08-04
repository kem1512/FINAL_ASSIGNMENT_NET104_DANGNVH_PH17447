using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface IMauSacRepository
    {
        bool Add(MauSac obj);

        bool Update(MauSac obj);

        bool Remove(MauSac obj);

        List<MauSac> GetAll();
    }
}
