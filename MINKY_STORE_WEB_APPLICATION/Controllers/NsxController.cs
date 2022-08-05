using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class NsxController : Controller
    {
        private INsxService _iNsxService;

        public NsxController()
        {
            _iNsxService = new NsxService();
        }

        public IActionResult Index()
        {
            return View(_iNsxService.GetAll());
        }

        [Route("/nsx/create")]
        public IActionResult Add(Nsx obj)
        {
            _iNsxService.Add(obj);
            return RedirectToAction("Index", "Nsx");
        }

        [Route("/nsx/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iNsxService.Remove(_iNsxService.GetById(id));
            return RedirectToAction("Index", "Nsx");
        }

        [Route("/nsx/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iNsxService.GetById(id));
        }

        [Route("/nsx/update")]
        public IActionResult Update(Nsx cv)
        {
            _iNsxService.Update(cv);
            return RedirectToAction("Index", "Nsx");
        }
    }
}
