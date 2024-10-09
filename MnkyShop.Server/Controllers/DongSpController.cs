//namespace MinkyShop.Server.Controllers
//{
//    public class DongSpController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public DongSpController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            if (TempData["Message"] != null)
//            {
//                ViewBag.Message = TempData["Message"];
//            }

//            return View(_dongSpRepository.Fetch());
//        }

//        [Route("/dongSp/create")]
//        public IActionResult Add(DongSp obj)
//        {
//            TempData["Message"] = _dongSpRepository.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
//            return RedirectToAction("Index", "DongSp");
//        }

//        [Route("/dongSp/remove/{id}")]
//        public IActionResult Remove(Guid id)
//        {
//            TempData["Message"] = _dongSpRepository.Remove(id) ? "Xóa thành công" : "Xóa thất bại";
//            return RedirectToAction("Index", "DongSp");
//        }

//        [Route("/dongSp/detail/{id}")]
//        public IActionResult Update(Guid id)
//        {
//            return View(_dongSpRepository.Fetch(id));
//        }

//        [Route("/dongSp/update")]
//        public IActionResult Update(DongSp obj)
//        {
//            TempData["Message"] = _dongSpRepository.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
//            return RedirectToAction("Index", "DongSp");
//        }
//    }
//}
