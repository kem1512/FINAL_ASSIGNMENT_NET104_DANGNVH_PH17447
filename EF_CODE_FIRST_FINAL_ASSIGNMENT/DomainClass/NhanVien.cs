using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class NhanVien
    {

        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public string TenDem { get; set; }

        public string Ho { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public string Sdt { get; set; }

        public string MatKhau { get; set; }

        public Guid IdCh { get; set; }

        public Guid IdCv { get; set; }

        public Guid? IdGuiBc { get; set; }

        public CuaHang CuaHang { get; set; }

        public ChucVu ChucVu { get; set; }

        public NhanVien Nhan_Vien { get; set; }

        public int TrangThai { get; set; }

        public List<HoaDon> HoaDons { get; set; }

        public List<NhanVien> NhanViens { get; set; }

        public List<GioHang> GioHangs { get; set; }
    }
}
