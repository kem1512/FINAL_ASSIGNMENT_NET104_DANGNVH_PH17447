namespace MinkyShop.Data.Entities
{
    public class NguoiDung : IdentityUser
    {
        public string? Ten { get; set; }

        public string? TenDem { get; set; }

        public string? Ho { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string? Sdt { get; set; }

        public string? DiaChi { get; set; }

        public string? ThanhPho { get; set; }

        public string? QuocGia { get; set; }

        public virtual List<HoaDon> HoaDons { get; set; } = default!;
    }
}
