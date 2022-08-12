using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;
using MINKY_STORE_WEB_APPLICATION.Models;

namespace MINKY_STORE_WEB_APPLICATION.IServices
{
    public interface IChiTietSpService
    {
        bool Add(ChiTietSp obj);

        bool Update(ChiTietSp obj);

        bool Remove(ChiTietSp obj);

        List<ChiTietSp> GetAll();

        List<SanPhamViewModel> GetSanPhamViewModel();

        ChiTietSp GetById(Guid id);

        bool AddSanPhamViewModel(SanPhamViewModel obj);

        int CurrentPage { get; set; }
    }
}
