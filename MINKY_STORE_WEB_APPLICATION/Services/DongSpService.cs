using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class DongSpService : IDongSpService
    {
        private IDongSpRepository _iDongSpRepository;

        public DongSpService(FinalAssignmentContext context)
        {
            _iDongSpRepository = new DongSpRepository(context);
        }

        public bool Add(DongSp obj)
        {
            return _iDongSpRepository.Add(obj);
        }

        public List<DongSp> GetAll()
        {
            return _iDongSpRepository.GetAll();
        }

        public DongSp GetById(Guid id)
        {
            return _iDongSpRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(DongSp obj)
        {
            return _iDongSpRepository.Remove(obj);
        }

        public bool Update(DongSp obj)
        {
            return _iDongSpRepository.Update(obj);
        }
    }
}
