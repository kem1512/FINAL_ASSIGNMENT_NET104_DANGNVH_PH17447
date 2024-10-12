namespace MinkyShop.Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.NgayTao).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.NgayThanhToan).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.NgayShip).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.NgayNhan).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.TongTien).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.Property(c => c.TinhTrang).HasDefaultValue(0);

            builder.Property(c => c.TenNguoiNhan).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.Sdt).HasColumnType("VARCHAR").HasMaxLength(30).HasDefaultValue(null);

            builder.HasOne(c => c.KhachHang).WithMany(c => c.HoaDons).HasForeignKey(c => c.IdKh);
        }
    }
}
