namespace MinkyShop.Infrastructure.Data.Entities
{
    public class SanPham
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public List<ChiTietSp> ChiTietSps { get; set; }
    }
}
