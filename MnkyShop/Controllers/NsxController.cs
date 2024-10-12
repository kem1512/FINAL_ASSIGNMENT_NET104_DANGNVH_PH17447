//namespace MinkyShop.Controllers
//{
//    public class NsxController : Controller
//    {
//        private INsxService _iNsxService;

//        public NsxController(ApplicationDbContext context)
//        {
//            _iNsxService = new NsxService(context);
//        }

//        public IActionResult Index()
//        {
//            if (TempData["Message"] != null)
//            {
//                ViewBag.Message = TempData["Message"];
//            }

//            return View(_iNsxService.GetAll());
//        }

//        [Route("/nsx/create")]
//        public IActionResult Add(Nsx obj)
//        {
//            TempData["Message"] = _iNsxService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
//            return RedirectToAction("Index", "Nsx");
//        }

//        [Route("/nsx/remove/{id}")]
//        public IActionResult Remove(Guid id)
//        {
//            TempData["Message"] = _iNsxService.Remove(_iNsxService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
//            return RedirectToAction("Index", "Nsx");
//        }

//        [Route("/nsx/detail/{id}")]
//        public IActionResult Update(Guid id)
//        {
//            return View(_iNsxService.GetById(id));
//        }

//        [Route("/nsx/update")]
//        public IActionResult Update(Nsx obj)
//        {
//            TempData["Message"] = _iNsxService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
//            return RedirectToAction("Index", "Nsx");
//        }
//    }
//}
