namespace MinkyShop.Infrastructure.Data.Entities
{
    public class MauSac
    {
        public Guid Id { get; set; }

        public string Ten { get; set; } = default!;

        public virtual List<ChiTietSp> ChiTietSps { get; set; } = new List<ChiTietSp>();
    }
}
