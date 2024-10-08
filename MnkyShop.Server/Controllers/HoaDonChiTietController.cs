namespace MinkyShop.Server.Controllers
{
    public class HoaDonChiTietController : Controller
    {
        private readonly ChiTietSpRepository _chiTietSpRepository;
        private readonly HoaDonRepository _hoaDonRepository;
        private readonly HoaDonChiTietRepository _hoaDonChiTietRepository;

        public HoaDonChiTietController(ChiTietSpRepository chiTietSpRepository, HoaDonRepository hoaDonRepository, HoaDonChiTietRepository hoaDonChiTietRepository)
        {
            _chiTietSpRepository = chiTietSpRepository;
            _hoaDonRepository = hoaDonRepository;
            _hoaDonChiTietRepository = hoaDonChiTietRepository;
        }

        [Route("/hoadonchitiet/{id}")]
        public IActionResult Index(Guid id)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            var tuple = new Tuple<List<HoaDonViewModel>, List<SanPhamViewModel>>(_iHoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.Id == id).ToList(), _iChiTietSpService.GetSanPhamViewModel());
            return View(tuple);
        }

        [Route("/hoadonchitiet/update")]
        public IActionResult Update(HoaDonChiTiet obj)
        {
            TempData["Message"] = _iHoaDonChiTietService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return View("Index", new Tuple<List<HoaDonViewModel>, List<SanPhamViewModel>>(
                _iHoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.Id == obj.HoaDon.Id).ToList(),
                _iChiTietSpService.GetSanPhamViewModel()));
        }

        [Route("/hoadonchitiet/add")]
        public IActionResult Add(HoaDonChiTiet obj)
        {
            if (_iHoaDonChiTietService.GetAll().Exists(c => c.IdChiTietSp == obj.IdChiTietSp))
            {
                TempData["Message"] = "Sản phẩm đã tồn tại";
                RedirectToAction("Index", "HoaDon");
            }
            else
            {
                obj.DonGia = _iChiTietSpService.GetById(obj.IdChiTietSp).GiaBan;
                TempData["Message"] = _iHoaDonChiTietService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            }
            return RedirectToAction("Index", "HoaDon");
        }
    }
}
