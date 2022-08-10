using System;
using System.Collections.Generic;
using System.Text;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Configurations
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(newid())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.TenDem).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.Ho).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.NgaySinh).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.Sdt).HasColumnType("VARCHAR").HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.ThanhPho).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.QuocGia).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.MatKhau).HasColumnType("VARCHAR(MAX)").HasDefaultValue(null);

        }
    }
}
