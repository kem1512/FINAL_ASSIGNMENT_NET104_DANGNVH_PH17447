using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    public class ChucVu
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập mã")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Phải nhập trên 2")]
        public string Ma { get; set; }

        public string Ten { get; set; }

        public List<NhanVien> NhanViens { get; set; }
    }
}
