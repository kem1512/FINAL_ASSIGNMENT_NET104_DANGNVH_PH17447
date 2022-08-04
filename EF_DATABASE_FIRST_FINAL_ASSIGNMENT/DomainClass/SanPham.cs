using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EF_DATABASE_FIRST_FINAL_ASSIGNMENT.DomainClass
{
    [Table("SanPham")]
    [Index(nameof(Ma), Name = "UQ__SanPham__3214CC9EC10F644B", IsUnique = true)]
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietSps = new HashSet<ChiTietSp>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }

        [InverseProperty(nameof(ChiTietSp.IdSpNavigation))]
        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; }
    }
}
