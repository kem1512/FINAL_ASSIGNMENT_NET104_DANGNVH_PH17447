using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Linq;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class ChucVuController : Controller
    {
        private IChucVuService _iChucVuService;
        public ChucVuController()
        {
            _iChucVuService = new ChucVuService();
        }

        public IActionResult Index()
        {
            return View(_iChucVuService.GetAll());
        }

        [Route("/chucvu/create")]
        public IActionResult Add(ChucVu obj)
        {
            _iChucVuService.Add(obj);
            return RedirectToAction("Index", "ChucVu");
        }

        [Route("/chucvu/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iChucVuService.Remove(_iChucVuService.GetById(id));
            return RedirectToAction("Index", "ChucVu");
        }

        [Route("/chucvu/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iChucVuService.GetById(id));
        }

        [Route("/chucvu/update")]
        public IActionResult Update(ChucVu cv)
        {
            _iChucVuService.Update(cv);
            return RedirectToAction("Index", "ChucVu");
        }
    }
}
