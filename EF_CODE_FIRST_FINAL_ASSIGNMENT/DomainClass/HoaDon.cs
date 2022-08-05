using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class HoaDon
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }


        public DateTime NgayTao { get; set; }


        public DateTime NgayThanhToan { get; set; }


        public DateTime NgayShip { get; set; }


        public DateTime NgayNhan { get; set; }

        public int TinhTrang { get; set; }

        public string TenNguoiNhan { get; set; }

        public string DiaChi { get; set; }

        public string Sdt { get; set; }

        public Guid? IdKh { get; set; }

        public Guid? IdNv { get; set; }

        public KhachHang KhachHang { get; set; }

        public NhanVien NhanVien { get; set; }

        public List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
