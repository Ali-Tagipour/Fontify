using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fontify.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnInstall;
        private ProgressBar progressBar1;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnInstall = new Button();
            this.progressBar1 = new ProgressBar();
            this.lblStatus = new Label();

            this.SuspendLayout();

            this.ClientSize = new Size(900, 600);
            this.Text = "Fontify - نصب یکجای فونت";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label title = new Label();
            title.Text = "Fontify";
            title.Font = new Font("Tahoma", 48F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(255, 111, 97);
            title.AutoSize = true;
            title.Location = new Point(50, 80);

            Label subtitle = new Label();
            subtitle.Text = "پوشه رو بکش تو برنامه یا دکمه رو بزن — همه فونت‌ها نصب میشن!";
            subtitle.Font = new Font("Tahoma", 14F);
            subtitle.ForeColor = Color.LightGray;
            subtitle.AutoSize = true;
            subtitle.Location = new Point(50, 160);

            btnInstall.Text = "انتخاب پوشه و نصب فونت‌ها";
            btnInstall.Font = new Font("Tahoma", 18F, FontStyle.Bold);
            btnInstall.Size = new Size(560, 100);
            btnInstall.Location = new Point(170, 220);
            btnInstall.BackColor = Color.FromArgb(255, 111, 97);
            btnInstall.ForeColor = Color.White;
            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.FlatAppearance.BorderSize = 0;
            btnInstall.Cursor = Cursors.Hand;
            btnInstall.Click += new EventHandler(btnInstall_Click);

            progressBar1.Size = new Size(780, 40);
            progressBar1.Location = new Point(60, 380);
            progressBar1.ForeColor = Color.FromArgb(255, 111, 97);

            lblStatus.Text = "آماده‌ام! یه پوشه بکش یا دکمه رو بزن";
            lblStatus.Font = new Font("Tahoma", 14F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Size = new Size(780, 80);
            lblStatus.Location = new Point(60, 440);

            Label footer = new Label();
            footer.Text = "Designed by A.T";
            footer.ForeColor = Color.Gray;
            footer.AutoSize = true;
            footer.Location = new Point(780, 570);

            this.Controls.Add(title);
            this.Controls.Add(subtitle);
            this.Controls.Add(btnInstall);
            this.Controls.Add(progressBar1);
            this.Controls.Add(lblStatus);
            this.Controls.Add(footer);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}