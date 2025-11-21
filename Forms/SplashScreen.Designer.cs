using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fontify.Forms
{
    partial class SplashScreen
    {
        private System.ComponentModel.IContainer components = null;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblWebsite;
        private Label lblAppName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar = new ProgressBar();
            this.lblStatus = new Label();
            this.lblWebsite = new Label();
            this.lblAppName = new Label();

            this.SuspendLayout();

            // فرم
            this.ClientSize = new Size(660, 460);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // اسم برنامه وسط و بولد
            this.lblAppName.Text = "Fontify";
            this.lblAppName.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            this.lblAppName.ForeColor = Color.White;
            this.lblAppName.AutoSize = false;
            this.lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAppName.Location = new Point(0, 80);
            this.lblAppName.Size = new Size(660, 120);

            // نوار پیشرفت
            this.progressBar.Location = new Point(80, 280);
            this.progressBar.Size = new Size(500, 35);
            this.progressBar.ForeColor = Color.FromArgb(255, 111, 97);
            this.progressBar.Style = ProgressBarStyle.Continuous;

            // وضعیت
            this.lblStatus.Location = new Point(0, 330);
            this.lblStatus.Size = new Size(660, 40);
            this.lblStatus.Text = "در حال بارگذاری...";
            this.lblStatus.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            this.lblStatus.ForeColor = Color.White;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // لینک سایت
            this.lblWebsite.Text = "alitagipour.ir";
            this.lblWebsite.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            this.lblWebsite.ForeColor = Color.FromArgb(100, 180, 255);
            this.lblWebsite.Cursor = Cursors.Hand;
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new Point((660 - 150) / 2, 390);
            this.lblWebsite.Click += (s, e) => System.Diagnostics.Process.Start("http://alitagipour.ir");

            // اضافه کردن
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWebsite);

            this.components.Add(this.progressBar);
            this.components.Add(this.lblStatus);
            this.components.Add(this.lblWebsite);
            this.components.Add(this.lblAppName);

            this.ResumeLayout(false);
        }
    }
}
