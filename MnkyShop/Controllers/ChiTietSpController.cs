namespace MinkyShop.Controllers
{
    public class ChiTietSpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietSpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("ChiTietSp/{idSp?}")]
        public IActionResult Index(int? idSp, int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var chiTietSps = _context.ChiTietSp.Include(c => c.SanPham).Include(c => c.MauSac).ToList();

            if (idSp != null)
            {
                chiTietSps = chiTietSps.Where(c => c.IdSp == idSp).ToList();
            }

            ViewBag.PageCount = (int)Math.Ceiling(chiTietSps.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            chiTietSps = chiTietSps.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.MauSac = _context.MauSac;
            ViewBag.ChiTietSp = chiTietSps;
            ViewBag.SanPham = _context.SanPham;
            ViewBag.IdSp = idSp;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ChiTietSp obj)
        {
            foreach (var x in _context.ChiTietSp)
            {
                // Nếu sản phẩm có màu sắc đó rồi thì không cho tạo nữa
                if (obj.IdMauSac == x.IdMauSac && obj.IdSp == x.IdSp)
                {
                    TempData["Message"] = "Sản phẩm đã tồn tại";
                    return RedirectToAction("Index");
                }
            }

            _context.ChiTietSp.Add(obj);

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index", "ChiTietSp");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var chiTietSp = _context.ChiTietSp.Find(id);

            if(chiTietSp != null)
            {
                _context.ChiTietSp.Remove(chiTietSp);
            }

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";

            return RedirectToAction("Index", "ChiTietSp");
        }

        public IActionResult Update(int id)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            ViewBag.MauSac = _context.MauSac;
            ViewBag.SanPham = _context.SanPham;

            return View(_context.ChiTietSp.Find(id));
        }

        [HttpPost]
        public IActionResult Update(int id, ChiTietSp obj)
        {
            var chiTietSp = _context.ChiTietSp.Find(id);

            if(_context.ChiTietSp.Any(c => c.IdMauSac == obj.IdMauSac && c.IdSp == obj.IdSp))
            {
                TempData["Message"] = "Chi tiết sản phẩm đã tồn tại";
                return RedirectToAction("Update", "ChiTietSp", new { id });
            }

            if (chiTietSp != null)
            {
                chiTietSp.IdSp = obj.IdSp;
                chiTietSp.IdMauSac = obj.IdMauSac;
                chiTietSp.MoTa = obj.MoTa;
                chiTietSp.GiaBan = obj.GiaBan;
                chiTietSp.GiaNhap = obj.GiaNhap;
                chiTietSp.SoLuongTon = obj.SoLuongTon;
            }

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Sửa thành công" : "Sửa thất bại";

            return RedirectToAction("Index", "ChiTietSp");
        }
    }
}
