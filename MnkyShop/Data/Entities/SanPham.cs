namespace MinkyShop.Data.Entities
{
    public class SanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn dòng sản phẩm")]
        public int? IdDongSp { get; set; }

        public string Ten { get; set; } = default!;

        public DateTime NgayRaMat { get; set; }

        [ForeignKey(nameof(IdDongSp))]
        public virtual DongSp DongSp { get; set; } = default!;

        public virtual List<ChiTietSp> ChiTietSps { get; set; } = default!;
    }
}
