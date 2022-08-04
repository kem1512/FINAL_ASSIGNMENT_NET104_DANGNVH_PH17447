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

        public string Ma { get; set; }

        public string Ten { get; set; }

        public List<NhanVien> NhanViens { get; set; }
    }
}
