namespace MinkyShop.Server.Controllers
{
    public class ChiTietSpController : Controller
    {
        private readonly ChiTietSpRepository _chiTietSpRepository;
        private readonly SanPhamRepository _sanPhamService;
        private readonly MauSacRepository _mauSacService;
        private readonly DongSpRepository _dongSpService;
        private readonly NsxRepository _nsxService;

        public ChiTietSpController(ChiTietSpRepository chiTietSpRepository, SanPhamRepository sanPhamService, MauSacRepository mauSacService, DongSpRepository dongSpService, NsxRepository nsxService)
        {
            _chiTietSpRepository = chiTietSpRepository;
            _sanPhamService = sanPhamService;
            _mauSacService = mauSacService;
            _dongSpService = dongSpService;
            _nsxService = nsxService;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            ViewBag.SanPham = _sanPhamService.Fetch();
            ViewBag.MauSac = _mauSacService.Fetch();
            ViewBag.DongSp = _dongSpService.Fetch();
            ViewBag.Nsx = _nsxService.Fetch();
            return View();
        }

        [HttpPost]
        [Route("/chiTietSp/create")]
        public IActionResult Add(ChiTietSp obj)
        {
            foreach (var x in _chiTietSpRepository.Fetch())
            {
                if (obj.IdDongSp == x.IdDongSp && obj.IdMauSac == x.IdMauSac &&
                    obj.IdSp == x.IdSp && obj.IdNsx == x.IdNsx)
                {
                    TempData["Message"] = "Sản phẩm đã tồn tại";
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = _chiTietSpRepository.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chiTietSp/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            TempData["Message"] = _chiTietSpRepository.Remove(id) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chiTietSp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.SanPham = _sanPhamService.Fetch();
            ViewBag.MauSac = _mauSacService.Fetch();
            ViewBag.DongSp = _dongSpService.Fetch();
            ViewBag.Nsx = _nsxService.Fetch();

            return View(_chiTietSpRepository.Fetch(id));
        }

        [HttpPost]
        [Route("/chiTietSp/update")]
        public IActionResult Update(ChiTietSp obj)
        {
            TempData["Message"] = _chiTietSpRepository.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }
    }
}
