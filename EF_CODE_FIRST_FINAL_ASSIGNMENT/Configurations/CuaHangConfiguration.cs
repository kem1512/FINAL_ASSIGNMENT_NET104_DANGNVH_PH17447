using System;
using System.Collections.Generic;
using System.Text;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Configurations
{
    public class CuaHangConfiguration : IEntityTypeConfiguration<CuaHang>
    {
        public void Configure(EntityTypeBuilder<CuaHang> builder)
        {
            builder.ToTable("CuaHang");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(newid())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)").HasMaxLength(20).IsRequired();

            builder.HasIndex(c => c.Ma).IsUnique();

            builder.Property(c => c.Ten).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.ThanhPho).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.QuocGia).HasMaxLength(50).HasDefaultValue(null);
        }
    }
}
