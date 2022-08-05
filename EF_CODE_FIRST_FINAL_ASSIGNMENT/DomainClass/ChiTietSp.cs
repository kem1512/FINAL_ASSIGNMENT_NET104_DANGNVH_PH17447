using System;
using System.Collections.Generic;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class ChiTietSp
    {
        public Guid Id { get; set; }

        public int NamBh { get; set; }

        public string MoTa { get; set; }

        public int SoLuongTon { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaBan { get; set; }

        public Guid? IdSp { get; set; }

        public Guid? IdNsx { get; set; }

        public Guid? IdMauSac { get; set; }

        public Guid? IdDongSp { get; set; }

        public SanPham SanPham { get; set; }

        public Nsx Nsx { get; set; }

        public MauSac MauSac { get; set; }

        public DongSp DongSp { get; set; }

        public List<GioHangChiTiet> GioHangChiTiets { get; set; }

        public List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
