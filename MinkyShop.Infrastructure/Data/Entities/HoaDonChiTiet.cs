using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MinkyShop.Infrastructure.Data.Entities
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
