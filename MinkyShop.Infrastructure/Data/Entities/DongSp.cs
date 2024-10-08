namespace MinkyShop.Infrastructure.Data.Entities
{
    public class DongSp
    {
        public Guid Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; } = default!;
    }
}
