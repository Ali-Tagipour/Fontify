using Fontify.Managers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fontify.Forms
{
    public partial class MainForm : Form
    {
        private readonly FontManager fontManager;

        public MainForm(FontManager fm)
        {
            fontManager = fm;
            InitializeComponent();
            LoadIcon();
            EnableDragDrop();
        }

        private void LoadIcon()
        {
            try
            {
                var stream = System.Reflection.Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("Fontify.Assets.Images.AppIcon.ico");
                if (stream != null) this.Icon = new Icon(stream);
            }
            catch { }
        }

        private void EnableDragDrop()
        {
            AllowDrop = true;
            DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
            };
            DragDrop += async (s, e) =>
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files?.Length > 0 && Directory.Exists(files[0]))
                    await InstallFonts(files[0]);
            };
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "پوشه فونت‌ها رو انتخاب کن";
                fbd.ShowNewFolderButton = false;

                if (fbd.ShowDialog() == DialogResult.OK)
                    await InstallFonts(fbd.SelectedPath);
            }
        }

        private async Task InstallFonts(string folder)
        {
            var files = GetFonts(folder);

            if (files.Length == 0)
            {
                MessageBox.Show("هیچ فونتی پیدا نشد!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            progressBar1.Maximum = files.Length;
            progressBar1.Value = 0;
            lblStatus.Text = $"در حال نصب {files.Length} فونت...";

            await Task.Run(() =>
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string currentFile = files[i];

                    try { fontManager.InstallFont(currentFile); }
                    catch { }

                    int cur = i + 1;
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        if (!this.IsDisposed)
                        {
                            progressBar1.Value = cur;
                            lblStatus.Text = $"نصب شد: {Path.GetFileName(currentFile)} ({cur}/{files.Length})";
                        }
                    });
                }
            });

            this.BeginInvoke((MethodInvoker)delegate
            {
                if (!this.IsDisposed)
                {
                    lblStatus.Text = $"تموم شد! {files.Length} فونت نصب شد";
                    MessageBox.Show($"همه فونت‌ها با موفقیت نصب شدند!\nتعداد: {files.Length}", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }

        private string[] GetFonts(string folder)
        {
            return Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".otf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".ttc", StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
    }
}