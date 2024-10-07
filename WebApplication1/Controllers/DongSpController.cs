namespace MinkyShop.Server.Controllers
{
    public class DongSpController : Controller
    {
        private DongSpRepository _dongSpRepository;

        public DongSpController(DongSpRepository dongSpRepository)
        {
            _dongSpRepository = dongSpRepository;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(_dongSpRepository.Fetch());
        }

        [Route("/dongsp/create")]
        public IActionResult Add(DongSp obj)
        {
            TempData["Message"] = _dongSpRepository.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _dongSpRepository.Remove(_dongSpRepository.Fetch(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_dongSpRepository.Fetch(id));
        }

        [Route("/dongsp/update")]
        public IActionResult Update(DongSp obj)
        {
            TempData["Message"] = _dongSpRepository.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "DongSp");
        }
    }
}
