namespace MinkyShop.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var sanPhams = _context.SanPham.Include(c => c.ChiTietSps).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(sanPhams.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            sanPhams = sanPhams.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.SanPham = sanPhams;
            ViewBag.DongSp = _context.DongSp;

            return View();
        }

        public IActionResult Create(SanPham obj)
        {
            _context.SanPham.Add(obj);

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var sanPham = _context.SanPham.Find(id);

            if(sanPham == null)
            {
                TempData["Message"] = "Không Tìm Thấy Sản Phẩm";
            }
            else
            {
                _context.SanPham.Remove(sanPham);

                var result = _context.SaveChanges();

                TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.DongSp = _context.DongSp;

            return View(_context.SanPham.Find(id));
        }

        [HttpPost]
        public IActionResult Update(int id, SanPham obj)
        {
            var sanPham = _context.SanPham.Find(id);

            if (sanPham != null)
            {
                if(sanPham.Id != id)
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
