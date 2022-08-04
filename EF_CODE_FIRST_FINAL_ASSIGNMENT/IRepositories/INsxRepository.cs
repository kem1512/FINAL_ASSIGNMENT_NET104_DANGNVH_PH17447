using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories
{
    public interface INsxRepository
    {
        bool Add(Nsx obj);

        bool Update(Nsx obj);

        bool Remove(Nsx obj);

        List<Nsx> GetAll();
    }
}
