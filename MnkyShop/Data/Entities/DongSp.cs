namespace MinkyShop.Data.Entities
{
    public class DongSp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn nhà sản xuất")]
        public int IdNsx { get; set; }

        public string Ten { get; set; } = default!;

        [ForeignKey(nameof(IdNsx))]
        public virtual Nsx Nsx { get; set; } = default!;

        public virtual List<SanPham> SanPhams { get; set; } = default!;
    }
}
