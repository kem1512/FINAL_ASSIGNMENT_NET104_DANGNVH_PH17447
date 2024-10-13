namespace MinkyShop.Extensions
{
    public static class Helper
    {
        public static string FormatVietNamDong(this decimal value)
        {
            return value.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));
        }
    }
}
