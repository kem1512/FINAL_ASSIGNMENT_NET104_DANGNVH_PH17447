using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class DongSpController : Controller
    {
        private IDongSpService _iDongSpService;

        public DongSpController()
        {
            _iDongSpService = new DongSpService();
        }

        public IActionResult Index()
        {
            return View(_iDongSpService.GetAll());
        }

        [Route("/dongsp/create")]
        public IActionResult Add(DongSp obj)
        {
            _iDongSpService.Add(obj);
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iDongSpService.Remove(_iDongSpService.GetById(id));
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iDongSpService.GetById(id));
        }

        [Route("/dongsp/update")]
        public IActionResult Update(DongSp cv)
        {
            _iDongSpService.Update(cv);
            return RedirectToAction("Index", "DongSp");
        }
    }
}
