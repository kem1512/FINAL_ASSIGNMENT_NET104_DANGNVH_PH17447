namespace MinkyShop.Data.Entities
{
    public class MauSac
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual List<ChiTietSp> ChiTietSps { get; set; } = default!;
    }
}
