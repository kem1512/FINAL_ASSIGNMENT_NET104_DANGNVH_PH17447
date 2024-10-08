namespace MinkyShop.Infrastructure.Data.Entities
{
    public class Nsx
    {
        public Guid Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; } = new List<ChiTietSp>();
    }
}
