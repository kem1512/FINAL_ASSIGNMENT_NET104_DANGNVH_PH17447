namespace MinkyShop.Controllers
{
    public class BanHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<NguoiDung> _signInManager;

        public BanHangController(ApplicationDbContext context, SignInManager<NguoiDung> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index(int? idNsx, int? idMauSac, string? tenSp, int page = 1, int maxRows = 8)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            // Truy vấn sản phẩm và bao gồm các chi tiết liên quan
            var sanPhams = _context.SanPham
                .Include(c => c.ChiTietSps)
                .Where(c => c.ChiTietSps.Count > 0);

            // Áp dụng điều kiện lọc nếu có
            if (idNsx.HasValue)
            {
                sanPhams = sanPhams.Where(c => c.DongSp.Nsx.Id == idNsx.Value);
            }
            if (idMauSac.HasValue)
            {
                sanPhams = sanPhams.Where(c => c.ChiTietSps.Any(ct => ct.IdMauSac == idMauSac.Value));
            }
            if (!string.IsNullOrEmpty(tenSp))
            {
                sanPhams = sanPhams.Where(c => c.Ten.Contains(tenSp));
            }

            // Sắp xếp theo ngày ra mắt
            sanPhams = sanPhams.OrderByDescending(c => c.NgayRaMat);

            // Tính tổng số trang
            ViewBag.PageCount = (int)Math.Ceiling(sanPhams.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;
            ViewBag.MauSac = _context.MauSac.ToList();
            ViewBag.Nsx = _context.Nsx.ToList();

            // Phân trang
            sanPhams = sanPhams.Skip((page - 1) * maxRows).Take(maxRows);

            return View(sanPhams.ToList());
        }

        [Route("BanHang/Detail/{idSp}")]
        public IActionResult Detail(int idSp, int page, int maxRows = 4)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var chiTietSps = _context.ChiTietSp.Include(c => c.SanPham).Include(c => c.MauSac).Where(c => c.IdSp == idSp).ToList();

            ViewBag.PageCount = (int)Math.Ceiling(chiTietSps.Count() / (decimal)maxRows);
            ViewBag.CurrentPageIndex = page;

            chiTietSps = chiTietSps.Skip((page - 1) * maxRows).Take(maxRows).ToList();

            return View(chiTietSps);
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

            string refererUrl = Request.Headers["Referer"].ToString();
            return Redirect(refererUrl);
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
                if(soLuong <= 0)
                {
                    RemoveCart(index);
                }
                else
                {
                    cart.HoaDonChiTiets[index].SoLuong = soLuong;
                    cart.TongTien = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
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
                cart.TongTien = cart.HoaDonChiTiets.Sum(c => c.DonGia * c.SoLuong);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            TempData["Message"] = "Xóa thành công";

            return Json(new { success = true, redirectUrl = Url.Action("Cart") });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "BanHang");
        }
    }
}
