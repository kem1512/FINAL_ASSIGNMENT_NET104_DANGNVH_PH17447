namespace MinkyShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? tinhTrang, string? input, DateTime? startDate, DateTime? endDate, int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var hoaDons = _context.HoaDon.OrderByDescending(c => c.NgayTao).ToList();

            // Lọc trạng thái hóa đơn
            if (tinhTrang != null)
            {
                hoaDons = hoaDons.Where(c => c.TinhTrang == tinhTrang).ToList();
            }

            // Lọc theo tên hoặc mã hóa đơn
            if (input != null)
            {
                hoaDons = hoaDons.Where(c => c.Id.ToString() == input || c.TenNguoiNhan.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Lọc theo ngày
            if (startDate.HasValue)
            {
                hoaDons = hoaDons.Where(c => c.NgayTao.Date >= startDate.Value.Date).ToList();
            }

            if (endDate.HasValue)
            {
                hoaDons = hoaDons.Where(c => c.NgayTao.Date <= endDate.Value.Date).ToList();
            }

            ViewBag.PageCount = (int)Math.Ceiling(hoaDons.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            hoaDons = hoaDons.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            return View(hoaDons);
        }

        public IActionResult Detail(int id)
        {
            var result = _context.HoaDon.Include(c => c.HoaDonChiTiets)
                    .ThenInclude(c => c.ChiTietSp)
                        .ThenInclude(c => c.MauSac)
                    .Include(c => c.HoaDonChiTiets)
                        .ThenInclude(c => c.ChiTietSp)
                            .ThenInclude(c => c.SanPham)
                                .ThenInclude(c => c.DongSp)
                                    .ThenInclude(c => c.Nsx)
                     .FirstOrDefault(c => c.Id == id);

            return View(result);
        }

        public IActionResult Create(HoaDon obj)
        {
            if (HttpContext.Session.GetString("cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

                foreach (var x in cart.HoaDonChiTiets)
                {
                    x.ChiTietSp = null!;
                }

                cart.TenNguoiNhan = obj.TenNguoiNhan;
                cart.DiaChi = obj.DiaChi;
                cart.Sdt = obj.Sdt;
                cart.NgayTao = DateTime.Now;

                _context.HoaDon.Add(cart);

                var result = _context.SaveChanges();

                TempData["Message"] = result > 0 ? "Thêm hóa đơn thành công" : "Thêm hóa đơn thất bại";

                HttpContext.Session.Remove("cart");
            }

            return RedirectToAction("Index", "BanHang");
        }

        public IActionResult CompleteOrder(int id)
        {
            var hoadon = _context.HoaDon.Find(id);

            if(hoadon != null)
            {
                hoadon.TinhTrang = 1;
            }

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Hoàn thành đơn hàng thành công" : "Hoàn thành đơn hàng thất bại";

            return RedirectToAction("Index");
        }
    }
}
