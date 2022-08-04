using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class HoaDonChiTiet
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }

        public HoaDon HoaDon { get; set; }

        public ChiTietSp ChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }
    }
}
