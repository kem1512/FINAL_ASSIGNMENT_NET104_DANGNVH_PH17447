namespace MinkyShop.Data.Entities
{
    [PrimaryKey(nameof(IdHoaDon), nameof(IdChiTietSp))]
    public class HoaDonChiTiet
    {
        public int IdHoaDon { get; set; }

        public int IdChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        [ForeignKey(nameof(IdHoaDon))]
        public virtual HoaDon HoaDon { get; set; } = default!;

        [ForeignKey(nameof(IdChiTietSp))]
        public virtual ChiTietSp ChiTietSp { get; set; } = default!;
    }
}
