using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class GioHangChiTiet
    {
        public Guid IdGioHang { get; set; }

        public Guid IdChiTietSp { get; set; }

        public GioHang GioHang { get; set; }

        public ChiTietSp ChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal DonGiaKhiGiam { get; set; }
    }
}
