// ============================================================
// فایل: FontManager.cs
// توضیح: مدیریت نصب فونت‌ها
// ============================================================
using System;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Fontify.Managers
{
    public class FontManager
    {
        private readonly string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
        public PrivateFontCollection Pfc { get; private set; } = new PrivateFontCollection();

        [DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpFileName);

        public void InstallFont(string fontPath)
        {
            try
            {
                if (!File.Exists(fontPath)) return;

                string fileName = Path.GetFileName(fontPath);
                string destPath = Path.Combine(fontsFolder, fileName);

                // فقط اگه وجود نداشت کپی و نصب کن
                if (!File.Exists(destPath))
                {
                    File.Copy(fontPath, destPath, true);
                    AddFontResource(destPath);
                }
            }
            catch { }
        }

        // اگه بعداً خواستی فونت از داخل برنامه لود کنی، اینجا بذار
        // فعلاً خالیه که برنامه کرش نکنه
        public void LoadFontFromResource()
        {
            // در آینده می‌تونی فونت‌های پیش‌فرض رو از Resources لود کنی
            // الان خالیه که خطا نده
        }
    }
}