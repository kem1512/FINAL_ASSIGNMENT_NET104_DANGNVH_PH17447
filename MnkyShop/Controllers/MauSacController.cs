namespace MinkyShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MauSacController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MauSacController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int maxRows = 5)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var mauSacs = _context.MauSac.Include(c => c.ChiTietSps).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(mauSacs.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            mauSacs = mauSacs.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.MauSacs = mauSacs;

            return View();
        }

        public IActionResult Create(MauSac obj)
        {
            _context.MauSac.Add(obj);

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var sanPham = _context.MauSac.Find(id);

            if (sanPham == null)
            {
                TempData["Message"] = "Không Tìm Thấy Màu Sắc";
            }
            else
            {
                _context.MauSac.Remove(sanPham);

                var result = _context.SaveChanges();

                TempData["Message"] = result > 0 ? "Xóa thành công" : "Xóa thất bại";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.DongSp = _context.DongSp;

            return View(_context.MauSac.Find(id));
        }

        [HttpPost]
        public IActionResult Update(int id, MauSac obj)
        {
            var sanPham = _context.MauSac.Find(id);

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
                TempData["Message"] = "Không Tìm Thấy Màu Sắc";
            }

            return RedirectToAction("Index");
        }
    }
}
