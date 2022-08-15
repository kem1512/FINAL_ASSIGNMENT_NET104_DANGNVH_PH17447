using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class NsxService : INsxService
    {
        private INsxRepository _iNsxRepository;

        public NsxService(FinalAssignmentContext context)
        {
            _iNsxRepository = new NsxRepository(context);
        }

        public bool Add(Nsx obj)
        {
            return _iNsxRepository.Add(obj);
        }

        public List<Nsx> GetAll()
        {
            return _iNsxRepository.GetAll();
        }

        public Nsx GetById(Guid id)
        {
            return _iNsxRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(Nsx obj)
        {
            return _iNsxRepository.Remove(obj);
        }

        public bool Update(Nsx obj)
        {
            return _iNsxRepository.Update(obj);
        }
    }
}
