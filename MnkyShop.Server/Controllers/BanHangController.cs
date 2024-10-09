namespace MinkyShop.Server.Controllers
{
    public class BanHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        private IEnumerable<DongSp> ProductPaging(int currentPage, int maxRows = 4)
        {
            var dongSps = _context.DongSp.Include(c => c.ChiTietSps).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(dongSps.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = currentPage;

            dongSps = dongSps.Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();

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
            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.HoaDonChiTiets.Count(); i++)
            {
                if (cart.HoaDonChiTiets[i].IdChiTietSp.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        [Route("/banHang/addCart/{id}")]
        public IActionResult AddCart(Guid id)
        {
            var chiTietSp = _context.DongSp.SelectMany(c => c.ChiTietSps).FirstOrDefault(c => c.Id == id);

            if(chiTietSp != null)
            {
                if (HttpContext.Session.GetObjectFromJson<List<SanPham>>("cart") == null)
                {
                    var cart = new HoaDon()
                    {
                        HoaDonChiTiets = new List<HoaDonChiTiet>()
                        {
                            new HoaDonChiTiet()
                            {
                                IdChiTietSp = chiTietSp.Id,
                                DonGia = chiTietSp.GiaNhap,
                                SoLuong = 1,
                            }
                        }
                    };

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

                    // Kiểm tra sản phẩm trên session
                    int index = IsExist(id);

                    if (index != -1)
                    {
                        cart.HoaDonChiTiets[index].SoLuong++;
                    }
                    else
                    {
                        cart = new HoaDon()
                        {
                            HoaDonChiTiets = new List<HoaDonChiTiet>()
                            {
                                new HoaDonChiTiet()
                                {
                                    IdChiTietSp = chiTietSp.Id,
                                    DonGia = chiTietSp.GiaNhap,
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

            var cart = SessionHelper.GetObjectFromJson<HoaDon>(HttpContext.Session, "cart");

            if (cart != null)
            {
                var total = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);
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
