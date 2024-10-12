namespace MinkyShop.Data.Entities
{
    public class HoaDon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgayThanhToan { get; set; }

        public DateTime NgayShip { get; set; }

        public DateTime NgayNhan { get; set; }

        public int TinhTrang { get; set; }

        public string TenNguoiNhan { get; set; } = default!;

        public string DiaChi { get; set; } = default!;

        public string Sdt { get; set; } = default!;

        public decimal TongTien { get; set; }

        public string? GhiChu { get; set; } = default!;

        public string? IdKh { get; set; }

        [ForeignKey(nameof(IdKh))]
        public virtual NguoiDung KhachHang { get; set; } = default!;

        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; } = default!;
    }
}
