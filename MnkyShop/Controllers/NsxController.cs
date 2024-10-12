namespace MinkyShop.Controllers
{
    public class NsxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NsxController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var nsxs = _context.Nsx.ToList();

            ViewBag.PageCount = (int)Math.Ceiling(nsxs.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            nsxs = nsxs.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.Nsx = nsxs;
            ViewBag.DongSp = _context.Nsx;

            return View();
        }

        public IActionResult Create(Nsx obj)
        {
            _context.Nsx.Add(obj);

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var sanPham = _context.Nsx.Find(id);

            if (sanPham == null)
            {
                TempData["Message"] = "Không Tìm Thấy Sản Phẩm";
            }
            else
            {
                _context.Nsx.Remove(sanPham);

                var result = _context.SaveChanges();

                TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.DongSp = _context.DongSp;

            return View(_context.Nsx.Find(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Nsx obj)
        {
            var sanPham = _context.Nsx.Find(id);

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
