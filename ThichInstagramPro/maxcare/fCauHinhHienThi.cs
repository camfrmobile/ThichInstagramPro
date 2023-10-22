using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MCommon;

namespace maxcare
{
	public class fCauHinhHienThi : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private BunifuCustomLabel lblStatus;

		private PictureBox pictureBox1;

		private CheckBox ckbCookie;

		private CheckBox ckbEmail;

		private CheckBox ckbTen;

		private CheckBox ckbBanBe;

		private CheckBox ckbGioiTinh;

		private CheckBox ckbMatKhau;

		private CheckBox ckbUseragent;

		private CheckBox ckbProxy;

		private CheckBox ckbTinhTrang;

		private CheckBox ckbGhiChu;

		private CheckBox ckbThuMuc;

		private CheckBox ckbFollow;

		private CheckBox ckbInteractEnd;

		private CheckBox ckbDevice;

		private CheckBox ckbMa2FA;

		public fCauHinhHienThi()
		{
			InitializeComponent();
			settings = new JSON_Settings("configDatagridview");
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(lblStatus);
			Language.GetValue(ckbTen);
			Language.GetValue(ckbFollow);
			Language.GetValue(ckbBanBe);
			Language.GetValue(ckbGioiTinh);
			Language.GetValue(ckbMatKhau);
			Language.GetValue(ckbInteractEnd);
			Language.GetValue(ckbTinhTrang);
			Language.GetValue(ckbThuMuc);
			Language.GetValue(ckbGhiChu);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			settings.Update("ckbCookie", ckbCookie.Checked);
			settings.Update("ckbEmail", ckbEmail.Checked);
			settings.Update("ckbTen", ckbTen.Checked);
			settings.Update("ckbBanBe", ckbBanBe.Checked);
			settings.Update("ckbGioiTinh", ckbGioiTinh.Checked);
			settings.Update("ckbMa2FA", ckbMa2FA.Checked);
			settings.Update("ckbMatKhau", ckbMatKhau.Checked);
			settings.Update("ckbUseragent", ckbUseragent.Checked);
			settings.Update("ckbProxy", ckbProxy.Checked);
			settings.Update("ckbTinhTrang", ckbTinhTrang.Checked);
			settings.Update("ckbThuMuc", ckbThuMuc.Checked);
			settings.Update("ckbGhiChu", ckbGhiChu.Checked);
			settings.Update("ckbFollow", ckbFollow.Checked);
			settings.Update("ckbInteractEnd", ckbInteractEnd.Checked);
			settings.Update("ckbDevice", ckbDevice.Checked);
			settings.Save();
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void bunifuCustomLabel2_Click(object sender, EventArgs e)
		{
		}

		private void fClearProfile_Load(object sender, EventArgs e)
		{
			ckbCookie.Checked = settings.GetValueBool("ckbCookie");
			ckbEmail.Checked = settings.GetValueBool("ckbEmail");
			ckbTen.Checked = settings.GetValueBool("ckbTen");
			ckbBanBe.Checked = settings.GetValueBool("ckbBanBe");
			ckbGioiTinh.Checked = settings.GetValueBool("ckbGioiTinh");
			ckbMa2FA.Checked = settings.GetValueBool("ckbMa2FA");
			ckbMatKhau.Checked = settings.GetValueBool("ckbMatKhau");
			ckbUseragent.Checked = settings.GetValueBool("ckbUseragent");
			ckbProxy.Checked = settings.GetValueBool("ckbProxy");
			ckbTinhTrang.Checked = settings.GetValueBool("ckbTinhTrang");
			ckbThuMuc.Checked = settings.GetValueBool("ckbThuMuc");
			ckbGhiChu.Checked = settings.GetValueBool("ckbGhiChu");
			ckbFollow.Checked = settings.GetValueBool("ckbFollow");
			ckbInteractEnd.Checked = settings.GetValueBool("ckbInteractEnd");
			ckbDevice.Checked = settings.GetValueBool("ckbDevice");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhHienThi));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			lblStatus = new Bunifu.Framework.UI.BunifuCustomLabel();
			ckbCookie = new System.Windows.Forms.CheckBox();
			ckbEmail = new System.Windows.Forms.CheckBox();
			ckbTen = new System.Windows.Forms.CheckBox();
			ckbBanBe = new System.Windows.Forms.CheckBox();
			ckbGioiTinh = new System.Windows.Forms.CheckBox();
			ckbMatKhau = new System.Windows.Forms.CheckBox();
			ckbUseragent = new System.Windows.Forms.CheckBox();
			ckbProxy = new System.Windows.Forms.CheckBox();
			ckbTinhTrang = new System.Windows.Forms.CheckBox();
			ckbGhiChu = new System.Windows.Forms.CheckBox();
			ckbThuMuc = new System.Windows.Forms.CheckBox();
			ckbFollow = new System.Windows.Forms.CheckBox();
			ckbInteractEnd = new System.Windows.Forms.CheckBox();
			ckbDevice = new System.Windows.Forms.CheckBox();
			ckbMa2FA = new System.Windows.Forms.CheckBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(396, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(396, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(364, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(396, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(206, 228);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(102, 228);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			lblStatus.BackColor = System.Drawing.Color.Transparent;
			lblStatus.Cursor = System.Windows.Forms.Cursors.SizeAll;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.Color.Black;
			lblStatus.Location = new System.Drawing.Point(6, 41);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(384, 32);
			lblStatus.TabIndex = 21;
			lblStatus.Text = "Vui lo\u0300ng cho\u0323n như\u0303ng cô\u0323t câ\u0300n hiê\u0309n thi\u0323!";
			lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblStatus.Click += new System.EventHandler(bunifuCustomLabel2_Click);
			ckbCookie.AutoSize = true;
			ckbCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbCookie.Location = new System.Drawing.Point(33, 85);
			ckbCookie.Name = "ckbCookie";
			ckbCookie.Size = new System.Drawing.Size(65, 20);
			ckbCookie.TabIndex = 22;
			ckbCookie.Text = "Cookie";
			ckbCookie.UseVisualStyleBackColor = true;
			ckbEmail.AutoSize = true;
			ckbEmail.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbEmail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbEmail.Location = new System.Drawing.Point(33, 111);
			ckbEmail.Name = "ckbEmail";
			ckbEmail.Size = new System.Drawing.Size(53, 20);
			ckbEmail.TabIndex = 22;
			ckbEmail.Text = "User";
			ckbEmail.UseVisualStyleBackColor = true;
			ckbTen.AutoSize = true;
			ckbTen.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTen.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbTen.Location = new System.Drawing.Point(33, 137);
			ckbTen.Name = "ckbTen";
			ckbTen.Size = new System.Drawing.Size(49, 20);
			ckbTen.TabIndex = 22;
			ckbTen.Text = "Tên";
			ckbTen.UseVisualStyleBackColor = true;
			ckbBanBe.AutoSize = true;
			ckbBanBe.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBanBe.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbBanBe.Location = new System.Drawing.Point(33, 189);
			ckbBanBe.Name = "ckbBanBe";
			ckbBanBe.Size = new System.Drawing.Size(81, 20);
			ckbBanBe.TabIndex = 22;
			ckbBanBe.Text = "Following";
			ckbBanBe.UseVisualStyleBackColor = true;
			ckbGioiTinh.AutoSize = true;
			ckbGioiTinh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGioiTinh.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbGioiTinh.Location = new System.Drawing.Point(143, 163);
			ckbGioiTinh.Name = "ckbGioiTinh";
			ckbGioiTinh.Size = new System.Drawing.Size(73, 20);
			ckbGioiTinh.TabIndex = 22;
			ckbGioiTinh.Text = "Giơ\u0301i ti\u0301nh";
			ckbGioiTinh.UseVisualStyleBackColor = true;
			ckbMatKhau.AutoSize = true;
			ckbMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbMatKhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbMatKhau.Location = new System.Drawing.Point(143, 85);
			ckbMatKhau.Name = "ckbMatKhau";
			ckbMatKhau.Size = new System.Drawing.Size(79, 20);
			ckbMatKhau.TabIndex = 22;
			ckbMatKhau.Text = "Mâ\u0323t khâ\u0309u";
			ckbMatKhau.UseVisualStyleBackColor = true;
			ckbUseragent.AutoSize = true;
			ckbUseragent.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUseragent.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbUseragent.Location = new System.Drawing.Point(143, 111);
			ckbUseragent.Name = "ckbUseragent";
			ckbUseragent.Size = new System.Drawing.Size(85, 20);
			ckbUseragent.TabIndex = 22;
			ckbUseragent.Text = "Useragent";
			ckbUseragent.UseVisualStyleBackColor = true;
			ckbProxy.AutoSize = true;
			ckbProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbProxy.Location = new System.Drawing.Point(143, 137);
			ckbProxy.Name = "ckbProxy";
			ckbProxy.Size = new System.Drawing.Size(58, 20);
			ckbProxy.TabIndex = 22;
			ckbProxy.Text = "Proxy";
			ckbProxy.UseVisualStyleBackColor = true;
			ckbTinhTrang.AutoSize = true;
			ckbTinhTrang.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTinhTrang.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbTinhTrang.Location = new System.Drawing.Point(259, 137);
			ckbTinhTrang.Name = "ckbTinhTrang";
			ckbTinhTrang.Size = new System.Drawing.Size(86, 20);
			ckbTinhTrang.TabIndex = 22;
			ckbTinhTrang.Text = "Ti\u0300nh tra\u0323ng";
			ckbTinhTrang.UseVisualStyleBackColor = true;
			ckbGhiChu.AutoSize = true;
			ckbGhiChu.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGhiChu.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbGhiChu.Location = new System.Drawing.Point(259, 189);
			ckbGhiChu.Name = "ckbGhiChu";
			ckbGhiChu.Size = new System.Drawing.Size(69, 20);
			ckbGhiChu.TabIndex = 22;
			ckbGhiChu.Text = "Ghi chú";
			ckbGhiChu.UseVisualStyleBackColor = true;
			ckbThuMuc.AutoSize = true;
			ckbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbThuMuc.Location = new System.Drawing.Point(259, 163);
			ckbThuMuc.Name = "ckbThuMuc";
			ckbThuMuc.Size = new System.Drawing.Size(78, 20);
			ckbThuMuc.TabIndex = 22;
			ckbThuMuc.Text = "Thư mục";
			ckbThuMuc.UseVisualStyleBackColor = true;
			ckbFollow.AutoSize = true;
			ckbFollow.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbFollow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbFollow.Location = new System.Drawing.Point(33, 163);
			ckbFollow.Name = "ckbFollow";
			ckbFollow.Size = new System.Drawing.Size(82, 20);
			ckbFollow.TabIndex = 22;
			ckbFollow.Text = "Followers";
			ckbFollow.UseVisualStyleBackColor = true;
			ckbInteractEnd.AutoSize = true;
			ckbInteractEnd.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteractEnd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbInteractEnd.Location = new System.Drawing.Point(259, 85);
			ckbInteractEnd.Name = "ckbInteractEnd";
			ckbInteractEnd.Size = new System.Drawing.Size(112, 20);
			ckbInteractEnd.TabIndex = 22;
			ckbInteractEnd.Text = "Tương ta\u0301c cuô\u0301i";
			ckbInteractEnd.UseVisualStyleBackColor = true;
			ckbDevice.AutoSize = true;
			ckbDevice.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDevice.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbDevice.Location = new System.Drawing.Point(259, 111);
			ckbDevice.Name = "ckbDevice";
			ckbDevice.Size = new System.Drawing.Size(76, 20);
			ckbDevice.TabIndex = 22;
			ckbDevice.Text = "LD Index";
			ckbDevice.UseVisualStyleBackColor = true;
			ckbMa2FA.AutoSize = true;
			ckbMa2FA.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbMa2FA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbMa2FA.Location = new System.Drawing.Point(143, 189);
			ckbMa2FA.Name = "ckbMa2FA";
			ckbMa2FA.Size = new System.Drawing.Size(49, 20);
			ckbMa2FA.TabIndex = 22;
			ckbMa2FA.Text = "2FA";
			ckbMa2FA.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(396, 270);
			base.Controls.Add(ckbThuMuc);
			base.Controls.Add(ckbDevice);
			base.Controls.Add(ckbGhiChu);
			base.Controls.Add(ckbInteractEnd);
			base.Controls.Add(ckbTinhTrang);
			base.Controls.Add(ckbProxy);
			base.Controls.Add(ckbUseragent);
			base.Controls.Add(ckbMatKhau);
			base.Controls.Add(ckbMa2FA);
			base.Controls.Add(ckbGioiTinh);
			base.Controls.Add(ckbFollow);
			base.Controls.Add(ckbBanBe);
			base.Controls.Add(ckbTen);
			base.Controls.Add(ckbEmail);
			base.Controls.Add(ckbCookie);
			base.Controls.Add(lblStatus);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhHienThi";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fClearProfile_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
