namespace MinkyShop.Data.Entities
{
    public class ChiTietSp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? MoTa { get; set; } = default!;

        public int SoLuongTon { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaBan { get; set; }

        [Url(ErrorMessage = "Sai đường dẫn rồi bạn ơi")]
        public string? Anh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn sản phẩm")]
        public int IdSp { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn màu sắc")]
        public int? IdMauSac { get; set; }

        [ForeignKey(nameof(IdSp))]
        public virtual SanPham SanPham { get; set; } = default!;

        [ForeignKey(nameof(IdMauSac))]
        public virtual MauSac MauSac { get; set; } = default!;

        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; } = default!;
    }
}
