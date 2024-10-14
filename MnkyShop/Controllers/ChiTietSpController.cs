namespace MinkyShop.Controllers
{
    [Authorize(Roles = "Administrator")]
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
        [Route("ChiTietSp/Create")]
        public IActionResult Create(ChiTietSp obj, IFormFile image)
        {
            // Kiểm tra nếu sản phẩm với màu sắc đã tồn tại
            if (_context.ChiTietSp.Any(x => x.IdMauSac == obj.IdMauSac && x.IdSp == obj.IdSp))
            {
                TempData["Message"] = "Sản phẩm đã tồn tại";
                return RedirectToAction("Index", new { obj.IdSp });
            }

            // Nếu có ảnh được upload
            if (image != null && image.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                obj.Anh = $"/images/{fileName}";
            }

            _context.ChiTietSp.Add(obj);
            TempData["Message"] = _context.SaveChanges() > 0 ? "Thêm thành công" : "Thêm thất bại";

            return RedirectToAction("Index", "ChiTietSp", new { idSp = obj.IdSp });
        }

        [HttpPost]
        [Route("ChiTietSp/Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var chiTietSp = _context.ChiTietSp.Find(id);

            if (chiTietSp != null)
            {
                _context.ChiTietSp.Remove(chiTietSp);
                TempData["Message"] = _context.SaveChanges() > 0 ? "Xóa thành công" : "Xóa thất bại";
            }

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
        [Route("ChiTietSp/Update/{id}")]
        public IActionResult Update(int id, ChiTietSp obj, IFormFile image)
        {
            var chiTietSp = _context.ChiTietSp.Include(c => c.SanPham).FirstOrDefault(c => c.Id == id);

            if (chiTietSp == null)
            {
                TempData["Message"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index", "ChiTietSp");
            }

            // Kiểm tra nếu chi tiết sản phẩm với màu sắc đã tồn tại và khác ID hiện tại
            if (_context.ChiTietSp.Any(c => c.IdMauSac == obj.IdMauSac && c.IdSp == obj.IdSp && c.Id != id))
            {
                TempData["Message"] = "Chi tiết sản phẩm đã tồn tại";
                return RedirectToAction("Update", new { id });
            }

            // Cập nhật các trường khác
            chiTietSp.IdSp = obj.IdSp;
            chiTietSp.IdMauSac = obj.IdMauSac;
            chiTietSp.MoTa = obj.MoTa;
            chiTietSp.GiaBan = obj.GiaBan;
            chiTietSp.GiaNhap = obj.GiaNhap;
            chiTietSp.SoLuongTon = obj.SoLuongTon;

            // Nếu có ảnh mới được upload
            if (image != null && image.Length > 0)
            {
                if(chiTietSp.Anh != null)
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", chiTietSp.Anh.TrimStart('/'));

                    // Xóa ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(chiTietSp.Anh) && System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                chiTietSp.Anh = $"/images/{fileName}";
            }

            TempData["Message"] = _context.SaveChanges() > 0 ? "Sửa thành công" : "Sửa thất bại";

            return RedirectToAction("Index", "ChiTietSp", new { idSp = chiTietSp.SanPham.Id });
        }
    }
}