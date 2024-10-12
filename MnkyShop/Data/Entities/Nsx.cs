namespace MinkyShop.Data.Entities
{
    public class Nsx
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual List<DongSp> DongSps { get; set; } = default!;
    }
}
