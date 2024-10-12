namespace MinkyShop.Controllers
{
    public class DongSpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DongSpController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var dongSps = _context.DongSp.ToList();

            ViewBag.PageCount = (int)Math.Ceiling(dongSps.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            dongSps = dongSps.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.DongSp = dongSps;
            ViewBag.Nsx = _context.Nsx;

            return View();
        }

        public IActionResult Create(DongSp obj)
        {
            _context.DongSp.Add(obj);

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var sanPham = _context.DongSp.Find(id);

            if (sanPham == null)
            {
                TempData["Message"] = "Không Tìm Thấy Sản Phẩm";
            }
            else
            {
                _context.DongSp.Remove(sanPham);

                var result = _context.SaveChanges();

                TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Nsx = _context.Nsx;

            return View(_context.DongSp.Find(id));
        }

        [HttpPost]
        public IActionResult Update(int id, DongSp obj)
        {
            var sanPham = _context.DongSp.Find(id);

            if (sanPham != null)
            {
                if (sanPham.Id != id)
                {
                    TempData["Message"] = "Dữ Liệu Không Đồng Nhất";
                }
                else
                {
                    sanPham.Ten = obj.Ten;
                    var result = _context.SaveChanges();
                    TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";
                }
            }
            else
            {
                TempData["Message"] = "Không Tìm Thấy Sản Phẩm";
            }

            return RedirectToAction("Index");
        }
    }
}
