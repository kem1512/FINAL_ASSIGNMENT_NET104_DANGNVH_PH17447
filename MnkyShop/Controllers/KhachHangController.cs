//namespace MinkyShop.Controllers
//{
//    public class KhachHangController : Controller
//    {
//        private KhachHangRepository _khachHangRepository;

//        public KhachHangController(KhachHangRepository khachHangRepository)
//        {
//            _khachHangRepository = khachHangRepository;
//        }

//        public IActionResult Index()
//        {
//            if (TempData["Message"] != null)
//            {
//                ViewBag.Message = TempData["Message"];
//            }
//            return View(_khachHangRepository.Fetch());
//        }

//        [Route("/khachhang/create")]
//        public IActionResult Add(NguoiDung obj)
//        {
//            TempData["Message"] = _khachHangRepository.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
//            return RedirectToAction("Index", "KhachHang");
//        }

//        [Route("/khachhang/remove/{id}")]
//        public IActionResult Remove(Guid id)
//        {
//            TempData["Message"] = _khachHangRepository.Remove(id) ? "Xóa thành công" : "Xóa thất bại";
//            return RedirectToAction("Index", "KhachHang");
//        }

//        [Route("/khachhang/detail/{id}")]
//        public IActionResult Update(Guid id)
//        {
//            return View(_iKhachHangService.GetById(id));
//        }

//        [Route("/khachhang/update")]
//        public IActionResult Update(NguoiDung obj)
//        {
//            TempData["Message"] = _iKhachHangService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
//            return RedirectToAction("Index", "KhachHang");
//        }
//    }
//}
