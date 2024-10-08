namespace MinkyShop.Server.Controllers
{
    public class BanHangController : Controller
    {
        private readonly DongSpRepository _dongSpRepository;

        public BanHangController(DongSpRepository dongSpRepository)
        {
            _dongSpRepository = dongSpRepository;
        }

        private IEnumerable<DongSp> ProductPaging(int currentPage, int maxRows = 4)
        {
            var dongSps = _dongSpRepository.Fetch();
            var productPaging = _dongSpRepository.Fetch().Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(dongSps.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = currentPage;

            return dongSps;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(ProductPaging(1));
        }

        [Route("/banHang/page={currentPage}")]
        public IActionResult Index(int currentPage)
        {
            return View(ProductPaging(currentPage));
        }

        [NonAction]
        private int IsExist(Guid id)
        {
            var cart = SessionHelper.GetObjectFromJson<GioHang>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.GioHangChiTiets.Count(); i++)
            {
                if (cart.GioHangChiTiets[i].IdChiTietSp.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        [Route("/banHang/addCart/{id}")]
        public IActionResult AddCart(Guid id)
        {
            var chiTietSp = _dongSpRepository.Fetch().SelectMany(c => c.ChiTietSps).FirstOrDefault(c => c.Id == id);

            if(chiTietSp != null)
            {
                if (HttpContext.Session.GetObjectFromJson<List<SanPham>>("cart") == null)
                {
                    var cart = new GioHang()
                    {
                        GioHangChiTiets = new List<GioHangChiTiet>()
                        {
                            new GioHangChiTiet()
                            {
                                IdChiTietSp = chiTietSp.Id,
                                DonGia = chiTietSp.GiaNhap,
                                DonGiaKhiGiam = chiTietSp.GiaBan,
                                SoLuong = 1,
                            }
                        }
                    };

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    var cart = SessionHelper.GetObjectFromJson<GioHang>(HttpContext.Session, "cart");

                    // Kiểm tra sản phẩm trên session
                    int index = IsExist(id);

                    if (index != -1)
                    {
                        cart.GioHangChiTiets[index].SoLuong++;
                    }
                    else
                    {
                        cart = new GioHang()
                        {
                            GioHangChiTiets = new List<GioHangChiTiet>()
                            {
                                new GioHangChiTiet()
                                {
                                    IdChiTietSp = chiTietSp.Id,
                                    DonGia = chiTietSp.GiaNhap,
                                    DonGiaKhiGiam = chiTietSp.GiaBan,
                                    SoLuong = 1,
                                }
                            }
                        };
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }

            TempData["Message"] = chiTietSp != null ? "Thêm Thất Bại" : "Thêm Thành Công";

            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var cart = SessionHelper.GetObjectFromJson<GioHang>(HttpContext.Session, "cart");

            if (cart != null)
            {
                var total = cart.GioHangChiTiets.Sum(c => c.DonGiaKhiGiam * c.SoLuong);
                return View(cart);
            }

            return RedirectToAction("Index");
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


        //[Route("/banhang/updatecart")]
        //public IActionResult UpdateCart(ItemViewModel obj)
        //{
        //    List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
        //    int index = IsExist(obj.SanPhamViewModel.ChiTietSp.Id);
        //    if (index != -1)
        //    {
        //        cart[index].Quantity = obj.Quantity;
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //        TempData["Message"] = "Sửa thành công";
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Sửa thất bại";
        //    }
        //    return RedirectToAction("Cart", "BanHang");
        //}

        //[Route("/banhang/removecart/{id}")]
        //public IActionResult RemoveCart(Guid id)
        //{

        //    List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
        //    int index = IsExist(id);
        //    if (index != -1)
        //    {
        //        cart.RemoveAt(index);
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //        TempData["Message"] = "Xóa thành công";
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Xóa thất bại";
        //    }
        //    return RedirectToAction("Cart");
        //}
    }
}
