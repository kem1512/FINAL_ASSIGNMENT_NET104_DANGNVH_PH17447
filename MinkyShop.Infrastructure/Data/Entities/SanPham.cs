using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MinkyShop.Infrastructure.Data.Entities
{
    public class SanPham
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public List<ChiTietSp> ChiTietSps { get; set; }
    }
}
