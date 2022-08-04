using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class CuaHang
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public string DiaChi { get; set; }

        public string ThanhPho { get; set; }

        public string QuocGia { get; set; }

        public List<NhanVien> NhanViens { get; set; }
    }
}
