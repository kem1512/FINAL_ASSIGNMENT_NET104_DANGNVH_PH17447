namespace MinkyShop.Data.Entities
{
    public class Nsx
    {
        public Guid Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual List<ChiTietSp> ChiTietSps { get; set; } = default!;
    }
}
