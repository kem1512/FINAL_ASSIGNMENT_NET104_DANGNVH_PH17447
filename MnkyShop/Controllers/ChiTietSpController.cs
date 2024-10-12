namespace MinkyShop.Controllers
{
    public class ChiTietSpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietSpController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            ViewBag.SanPham = _context.SanPham.AsNoTracking();
            ViewBag.MauSac = _context.MauSac.AsNoTracking();
            ViewBag.DongSp = _context.DongSp.AsNoTracking();
            ViewBag.Nsx = _context.Nsx.AsNoTracking();
            ViewBag.ChiTietSp = _context.ChiTietSp;

            return View();
        }

        [HttpPost]
        [Route("/chiTietSp/create")]
        public IActionResult Add(ChiTietSp obj)
        {
            foreach (var x in _context.ChiTietSp)
            {
                if (obj.IdDongSp == x.IdDongSp && obj.IdMauSac == x.IdMauSac &&
                    obj.IdSp == x.IdSp && obj.IdNsx == x.IdNsx)
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

        [Route("/chiTietSp/remove/{id}")]
        public IActionResult Delete(Guid id)
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

        [Route("/chiTietSp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.SanPham = _context.SanPham;
            ViewBag.MauSac = _context.MauSac;
            ViewBag.DongSp = _context.DongSp;
            ViewBag.Nsx = _context.Nsx;

            return View(_context.ChiTietSp.Find(id));
        }

        [HttpPost]
        [Route("/chiTietSp/update")]
        public IActionResult Update(Guid id, ChiTietSp obj)
        {
            var chiTietSp = _context.ChiTietSp.Find(id);

            if(chiTietSp != null)
            {
                _context.ChiTietSp.Update(obj);
            }

            var result = _context.SaveChanges();

            TempData["Message"] = result > 0 ? "Sửa thành công" : "Sửa thất bại";

            return RedirectToAction("Index", "ChiTietSp");
        }
    }
}
