namespace MinkyShop.Controllers
{
    public class BanHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int currentPage, int maxRows = 4)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var sanPhams = _context.SanPham.Include(c => c.ChiTietSps).Where(c => c.ChiTietSps.Count > 0).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(sanPhams.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = currentPage;

            sanPhams = sanPhams.Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();

            return View(sanPhams);
        }

        [NonAction]
        private int IsExist(int idChiTietSp)
        {
            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.HoaDonChiTiets.Count; i++)
            {
                if (cart.HoaDonChiTiets[i].IdChiTietSp.Equals(idChiTietSp))
                {
                    return i;
                }
            }

            return -1;
        }

        [HttpPost]
        public IActionResult AddCart(int idChiTietSp)
        {
            var chiTietSp = _context.ChiTietSp.Include(c => c.MauSac).Include(c => c.SanPham).FirstOrDefault(c => c.Id == idChiTietSp);

            if (chiTietSp != null)
            {
                var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

                if (cart == null)
                {
                    // Khởi tạo giỏ hàng nếu giỏ hàng rỗng
                    cart = new HoaDon()
                    {
                        HoaDonChiTiets = new List<HoaDonChiTiet>()
                        {
                            new HoaDonChiTiet()
                            {
                                IdChiTietSp = idChiTietSp,
                                ChiTietSp = chiTietSp,
                                DonGia = chiTietSp.GiaBan,
                                SoLuong = 1,
                            }
                        }
                    };
                }
                else
                {
                    // Kiểm tra sản phẩm đã có trong giỏ hàng hay chưa
                    int index = IsExist(idChiTietSp);

                    if (index != -1)
                    {
                        cart.HoaDonChiTiets[index].SoLuong++;
                    }
                    else
                    {
                        cart.HoaDonChiTiets.Add(new HoaDonChiTiet()
                        {
                            IdChiTietSp = idChiTietSp,
                            ChiTietSp = chiTietSp,
                            DonGia = chiTietSp.GiaBan,
                            SoLuong = 1,
                        });
                    }
                }

                cart.TongTien = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                TempData["Message"] = "Thêm Thành Công";
            }
            else
            {
                TempData["Message"] = "Thêm Thất Bại";
            }

            return RedirectToAction("Index");
        }


        public IActionResult Cart()
        {
            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            if (cart != null)
            {
                var total = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);
                return View(cart);
            }

            TempData["Message"] = "Chưa Có Sản Phẩm Trong Giỏ Hàng";

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int idChiTietSp, int soLuong)
        {
            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            int index = IsExist(idChiTietSp);

            if (index != -1)
            {
                cart.HoaDonChiTiets[index].SoLuong = soLuong;
                cart.TongTien = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            TempData["Message"] = index != -1 ? "Sửa thành công" : "Sửa thất bại";

            return RedirectToAction("Cart", "BanHang");
        }

        [HttpPost]
        public IActionResult RemoveCart(int index)
        {
            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            cart.HoaDonChiTiets.RemoveAt(index);

            if (cart.HoaDonChiTiets.Count <= 0)
            {
                SessionHelper.RemoveObject(HttpContext.Session, "cart");
                return Json(new { success = true, redirectUrl = Url.Action("Index", "BanHang") });
            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            TempData["Message"] = "Xóa thành công";

            return Json(new { success = true, redirectUrl = Url.Action("Cart") });
        }

        //[Route("/banhang/filter")]
        //public IActionResult Filter(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return View("Index", _iChiTietSpService.GetSanPhamViewModel());
        //    }
        //    return View("Index", _iChiTietSpService.GetSanPhamViewModel().Where(c => c.SanPham.Ten.ToUpper().Contains(name.ToUpper().Trim())).ToList());
        //}
    }
}
