using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class MauSacController : Controller
    {
        private IMauSacService _iMauSacService;

        public MauSacController()
        {
            _iMauSacService = new MauSacService();
        }

        public IActionResult Index()
        {
            return View(_iMauSacService.GetAll());
        }

        [Route("/mausac/create")]
        public IActionResult Add(MauSac obj)
        {
            _iMauSacService.Add(obj);
            return RedirectToAction("Index", "MauSac");
        }

        [Route("/mausac/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iMauSacService.Remove(_iMauSacService.GetById(id));
            return RedirectToAction("Index", "MauSac");
        }

        [Route("/mausac/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iMauSacService.GetById(id));
        }

        [Route("/mausac/update")]
        public IActionResult Update(MauSac cv)
        {
            _iMauSacService.Update(cv);
            return RedirectToAction("Index", "MauSac");
        }
    }
}
