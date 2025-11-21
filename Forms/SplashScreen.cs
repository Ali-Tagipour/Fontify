using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fontify.Managers;

namespace Fontify.Forms
{
    public partial class SplashScreen : Form
    {
        private readonly FontManager fontManager = new FontManager();

        public SplashScreen()
        {
            InitializeComponent();
            this.Load += SplashScreen_Load;
        }

        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "در حال آماده‌سازی Fontify...";
            progressBar.Value = 0;

            // فقط انیمیشن خفن — هیچ متد غیرپیاده‌سازی شده‌ای صدا نمیشه
            for (int i = 0; i <= 100; i += 5)
            {
                progressBar.Value = i;
                lblStatus.Text = $"در حال بارگذاری... {i}%";
                await Task.Delay(45);
            }

            lblStatus.Text = "همه چیز آماده است!";
            await Task.Delay(500);

            var mainForm = new MainForm(fontManager);
            mainForm.FormClosed += (s, a) => this.Close();
            mainForm.Show();
            this.Hide();
        }
    }
}