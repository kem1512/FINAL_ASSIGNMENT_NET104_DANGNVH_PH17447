namespace MinkyShop.Data.Entities
{
    public class HoaDonChiTiet
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; } = default!;

        public virtual ChiTietSp ChiTietSp { get; set; } = default!;
    }
}
