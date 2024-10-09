namespace MinkyShop.Infrastructure.Data.Entities
{
    public class ChiTietSp
    {
        public Guid Id { get; set; }

        public string MoTa { get; set; } = default!;

        public int SoLuongTon { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaBan { get; set; }

        [Url(ErrorMessage = "Sai đường dẫn rồi bạn ơi")]
        public string? Anh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn sản phẩm")]
        public Guid IdSp { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn nhà sản xuất")]
        public Guid? IdNsx { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn màu sắc")]
        public Guid? IdMauSac { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn dòng sản phẩm")]
        public Guid? IdDongSp { get; set; }

        public virtual SanPham SanPham { get; set; } = default!;

        public virtual Nsx Nsx { get; set; } = default!;

        public virtual MauSac MauSac { get; set; } = default!;

        public virtual DongSp DongSp { get; set; } = default!;

        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; } = default!;
    }
}
