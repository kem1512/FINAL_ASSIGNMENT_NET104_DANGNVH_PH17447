namespace MinkyShop.Server.Controllers
{
    public class ChiTietSpController : Controller
    {
        private IChiTietSpService _iChiTietSpService;
        private ISanPhamService _iSanPhamService;
        private IMauSacService _iMauSacService;
        private IDongSpService _iDongSpService;
        private INsxService _iNsxService;

        public ChiTietSpController(ApplicationDbContext context)
        {
            _iChiTietSpService = new ChiTietSpService(context);
            _iSanPhamService = new SanPhamService(context);
            _iMauSacService = new MauSacService(context);
            _iDongSpService = new DongSpService(context);
            _iNsxService = new NsxService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            ViewBag.SanPhamViewModel = _iChiTietSpService.GetSanPhamViewModel();
            ViewBag.SanPham = _iSanPhamService.GetAll();
            ViewBag.MauSac = _iMauSacService.GetAll();
            ViewBag.DongSp = _iDongSpService.GetAll();
            ViewBag.Nsx = _iNsxService.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/chitietsp/create")]
        public IActionResult Add(ChiTietSp obj)
        {
            foreach (var x in _iChiTietSpService.GetAll())
            {
                if (obj.IdDongSp == x.IdDongSp && obj.IdMauSac == x.IdMauSac &&
                    obj.IdSp == x.IdSp && obj.IdNsx == x.IdNsx)
                {
                    TempData["Message"] = "Sản phẩm đã tồn tại";
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = _iChiTietSpService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chitietsp/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            TempData["Message"] = _iChiTietSpService.Remove(_iChiTietSpService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chitietsp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.SanPham = _iSanPhamService.GetAll();
            ViewBag.MauSac = _iMauSacService.GetAll();
            ViewBag.DongSp = _iDongSpService.GetAll();
            ViewBag.Nsx = _iNsxService.GetAll();
            return View(_iChiTietSpService.GetById(id));
        }

        [HttpPost]
        [Route("/chitietsp/update")]
        public IActionResult Update(ChiTietSp obj)
        {
            TempData["Message"] = _iChiTietSpService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "ChiTietSp");
        }
    }
}
