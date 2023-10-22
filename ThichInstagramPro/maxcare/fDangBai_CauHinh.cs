using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fDangBai_CauHinh : Form
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

		private PictureBox pictureBox1;

		private Panel panel1;

		private CheckBox ckbRepeatAll;

		private Panel plRepeatAll;

		private Label label6;

		private Label label4;

		private NumericUpDown nudDelayTurnFrom;

		private Label label5;

		private NumericUpDown nudDelayTurnTo;

		private Label label11;

		private NumericUpDown nudSoLuotChay;

		private Label label10;

		private GroupBox groupBox1;

		private CheckBox ckbRandomThuTuTaiKhoan;

		private GroupBox groupBox2;

		private Label label19;

		private Label label20;

		private NumericUpDown nudKhoangCachTo;

		private NumericUpDown nudKhoangCachFrom;

		private Label label18;

		private Label label17;

		private NumericUpDown nudSoLuongBaiTo;

		private NumericUpDown nudSoLuongBaiFrom;

		private Label label16;

		private Label label15;

		private Panel plVanBan;

		private LinkLabel linkLabel1;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbXoaNguyenLieuDaDung;

		private CheckBox ckbVanBan;

		private Button btnNhapAnh;

		private Label label1;

		private NumericUpDown nudSoAnhFrom;

		private NumericUpDown nudSoAnhTo;

		private Label label3;

		private Label label7;

		private GroupBox groupBox3;

		private Panel plLDPlayer;

		private Panel plChrome;

		private Label label2;

		private TextBox txtPathPicChrome;

		private RadioButton rbLDPlayer;

		private RadioButton rbChrome;

		private Label label12;

		private CheckBox ckbXoaAnhDaDang;

		private Label label13;

		public fDangBai_CauHinh()
		{
			InitializeComponent();
			settings = new JSON_Settings("configDangBai");
			ChangeLanguage();
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(ckbRepeatAll);
			Language.GetValue(label6);
			Language.GetValue(label5);
			Language.GetValue(label4);
			Language.GetValue(label10);
			Language.GetValue(label11);
			Language.GetValue(groupBox2);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			settings.Update("ckbRepeatAll", ckbRepeatAll.Checked);
			settings.Update("nudDelayTurnFrom", nudDelayTurnFrom.Value);
			settings.Update("nudDelayTurnTo", nudDelayTurnTo.Value);
			settings.Update("nudSoLuotChay", nudSoLuotChay.Value);
			settings.Update("RepeatAllVIP", "false");
			settings.Update("ckbRandomThuTuTaiKhoan", ckbRandomThuTuTaiKhoan.Checked);
			settings.Update("nudSoLuongBaiFrom", nudSoLuongBaiFrom.Value);
			settings.Update("nudSoLuongBaiTo", nudSoLuongBaiTo.Value);
			settings.Update("nudKhoangCachFrom", nudKhoangCachFrom.Value);
			settings.Update("nudKhoangCachTo", nudKhoangCachTo.Value);
			settings.Update("ckbVanBan", ckbVanBan.Checked);
			settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			settings.Update("ckbXoaNguyenLieuDaDung", ckbXoaNguyenLieuDaDung.Checked);
			int num = 0;
			if (rbNganCachKyTu.Checked)
			{
				num = 1;
			}
			settings.Update("typeNganCach", num);
			settings.Update("nudSoAnhFrom", nudSoAnhFrom.Value);
			settings.Update("nudSoAnhTo", nudSoAnhTo.Value);
			if (rbChrome.Checked)
			{
				settings.Update("typeRun", 0);
			}
			else
			{
				settings.Update("typeRun", 1);
			}
			settings.Update("txtPathPicChrome", txtPathPicChrome.Text.Trim());
			settings.Update("ckbXoaAnhDaDang", ckbXoaAnhDaDang.Checked);
			settings.Save();
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
			{
				Close();
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CheckedChangedFull()
		{
			ckbRepeatAll_CheckedChanged(null, null);
			rbChrome_CheckedChanged(null, null);
			ckbVanBan_CheckedChanged(null, null);
			rbLDPlayer_CheckedChanged(null, null);
		}

		private void fCauHinhTuongTac_Load(object sender, EventArgs e)
		{
			LoadSettings();
			CheckedChangedFull();
		}

		private void LoadSettings()
		{
			try
			{
				ckbRepeatAll.Checked = settings.GetValueBool("ckbRepeatAll");
				nudDelayTurnFrom.Value = settings.GetValueInt("nudDelayTurnFrom");
				nudDelayTurnTo.Value = settings.GetValueInt("nudDelayTurnTo");
				nudSoLuotChay.Value = settings.GetValueInt("nudSoLuotChay");
				ckbRandomThuTuTaiKhoan.Checked = settings.GetValueBool("ckbRandomThuTuTaiKhoan");
				nudSoLuongBaiFrom.Value = settings.GetValueInt("nudSoLuongBaiFrom", 1);
				nudSoLuongBaiTo.Value = settings.GetValueInt("nudSoLuongBaiTo", 1);
				nudKhoangCachFrom.Value = settings.GetValueInt("nudKhoangCachFrom", 5);
				nudKhoangCachTo.Value = settings.GetValueInt("nudKhoangCachTo", 10);
				ckbVanBan.Checked = settings.GetValueBool("ckbVanBan");
				txtNoiDung.Text = settings.GetValue("txtNoiDung");
				ckbXoaNguyenLieuDaDung.Checked = settings.GetValueBool("ckbXoaNguyenLieuDaDung");
				if (settings.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
				nudSoAnhFrom.Value = settings.GetValueInt("nudSoAnhFrom", 1);
				nudSoAnhTo.Value = settings.GetValueInt("nudSoAnhTo", 1);
				switch (settings.GetValueInt("typeRun"))
				{
				case 1:
					rbLDPlayer.Checked = true;
					break;
				case 0:
					rbChrome.Checked = true;
					break;
				}
				txtPathPicChrome.Text = settings.GetValue("txtPathPicChrome");
				ckbXoaAnhDaDang.Checked = settings.GetValueBool("ckbXoaAnhDaDang");
			}
			catch
			{
			}
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtNoiDung.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtNoiDung.Focus();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void txtNoiDung_TextChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtNoiDung.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtNoiDung.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch nô\u0323i dung ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbNganCachKyTu_CheckedChanged_1(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
		}

		private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void btnNhapAnh_Click_1(object sender, EventArgs e)
		{
			string pathPictureLDPlayer = ConfigHelper.GetPathPictureLDPlayer();
			if (Directory.Exists(pathPictureLDPlayer))
			{
				Process.Start(pathPictureLDPlayer);
			}
		}

		private void rbChrome_CheckedChanged(object sender, EventArgs e)
		{
			plChrome.Enabled = rbChrome.Checked;
		}

		private void rbLDPlayer_CheckedChanged(object sender, EventArgs e)
		{
			plLDPlayer.Enabled = rbLDPlayer.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fDangBai_CauHinh));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			ckbRepeatAll = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			plRepeatAll = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			nudDelayTurnFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			nudDelayTurnTo = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			nudSoLuotChay = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			ckbRandomThuTuTaiKhoan = new System.Windows.Forms.CheckBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			label12 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			plLDPlayer = new System.Windows.Forms.Panel();
			btnNhapAnh = new System.Windows.Forms.Button();
			nudSoAnhFrom = new System.Windows.Forms.NumericUpDown();
			plChrome = new System.Windows.Forms.Panel();
			ckbXoaAnhDaDang = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			txtPathPicChrome = new System.Windows.Forms.TextBox();
			nudSoAnhTo = new System.Windows.Forms.NumericUpDown();
			rbLDPlayer = new System.Windows.Forms.RadioButton();
			label3 = new System.Windows.Forms.Label();
			rbChrome = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			nudSoLuongBaiFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiTo = new System.Windows.Forms.NumericUpDown();
			label19 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			nudKhoangCachTo = new System.Windows.Forms.NumericUpDown();
			nudKhoangCachFrom = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			plVanBan = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			ckbXoaNguyenLieuDaDung = new System.Windows.Forms.CheckBox();
			label9 = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			label13 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			plRepeatAll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			plLDPlayer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).BeginInit();
			plChrome.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
			plVanBan.SuspendLayout();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.FromArgb(24, 119, 242);
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(2, 1);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1098, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1098, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 78;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(1064, -2);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1098, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Đăng ba\u0300i";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(549, 596);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(445, 596);
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
			ckbRepeatAll.AutoSize = true;
			ckbRepeatAll.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRepeatAll.Location = new System.Drawing.Point(19, 46);
			ckbRepeatAll.Name = "ckbRepeatAll";
			ckbRepeatAll.Size = new System.Drawing.Size(287, 20);
			ckbRepeatAll.TabIndex = 2;
			ckbRepeatAll.Text = "Chạy lại toàn bộ tài khoản sau khi hoàn thành";
			ckbRepeatAll.UseVisualStyleBackColor = true;
			ckbRepeatAll.CheckedChanged += new System.EventHandler(ckbRepeatAll_CheckedChanged);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1100, 638);
			panel1.TabIndex = 8;
			groupBox1.Controls.Add(plRepeatAll);
			groupBox1.Controls.Add(ckbRandomThuTuTaiKhoan);
			groupBox1.Controls.Add(ckbRepeatAll);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f);
			groupBox1.Location = new System.Drawing.Point(11, 44);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(420, 141);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tùy chọn";
			plRepeatAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plRepeatAll.Controls.Add(label6);
			plRepeatAll.Controls.Add(label4);
			plRepeatAll.Controls.Add(nudDelayTurnFrom);
			plRepeatAll.Controls.Add(label5);
			plRepeatAll.Controls.Add(nudDelayTurnTo);
			plRepeatAll.Controls.Add(label11);
			plRepeatAll.Controls.Add(nudSoLuotChay);
			plRepeatAll.Controls.Add(label10);
			plRepeatAll.Location = new System.Drawing.Point(39, 68);
			plRepeatAll.Name = "plRepeatAll";
			plRepeatAll.Size = new System.Drawing.Size(372, 64);
			plRepeatAll.TabIndex = 13;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 6);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(84, 16);
			label6.TabIndex = 5;
			label6.Text = "Sô\u0301 lươ\u0323t cha\u0323y:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 35);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(145, 16);
			label4.TabIndex = 6;
			label4.Text = "Chờ cha\u0323y lươ\u0323t tiê\u0301p theo:";
			nudDelayTurnFrom.Location = new System.Drawing.Point(154, 33);
			nudDelayTurnFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDelayTurnFrom.Name = "nudDelayTurnFrom";
			nudDelayTurnFrom.Size = new System.Drawing.Size(65, 23);
			nudDelayTurnFrom.TabIndex = 9;
			label5.Location = new System.Drawing.Point(222, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(30, 16);
			label5.TabIndex = 10;
			label5.Text = "lươ\u0323t";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudDelayTurnTo.Location = new System.Drawing.Point(252, 33);
			nudDelayTurnTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDelayTurnTo.Name = "nudDelayTurnTo";
			nudDelayTurnTo.Size = new System.Drawing.Size(65, 23);
			nudDelayTurnTo.TabIndex = 8;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(320, 36);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(33, 16);
			label11.TabIndex = 11;
			label11.Text = "phút";
			nudSoLuotChay.Location = new System.Drawing.Point(154, 4);
			nudSoLuotChay.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudSoLuotChay.Name = "nudSoLuotChay";
			nudSoLuotChay.Size = new System.Drawing.Size(65, 23);
			nudSoLuotChay.TabIndex = 7;
			label10.Location = new System.Drawing.Point(222, 36);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 12;
			label10.Text = "đến";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbRandomThuTuTaiKhoan.AutoSize = true;
			ckbRandomThuTuTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRandomThuTuTaiKhoan.Location = new System.Drawing.Point(19, 20);
			ckbRandomThuTuTaiKhoan.Name = "ckbRandomThuTuTaiKhoan";
			ckbRandomThuTuTaiKhoan.Size = new System.Drawing.Size(255, 20);
			ckbRandomThuTuTaiKhoan.TabIndex = 2;
			ckbRandomThuTuTaiKhoan.Text = "Xáo trộn thứ tự tài khoản trước khi chạy";
			ckbRandomThuTuTaiKhoan.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(groupBox3);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(nudSoLuongBaiFrom);
			groupBox2.Controls.Add(nudSoLuongBaiTo);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label17);
			groupBox2.Controls.Add(label20);
			groupBox2.Controls.Add(label18);
			groupBox2.Controls.Add(nudKhoangCachTo);
			groupBox2.Controls.Add(nudKhoangCachFrom);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(plVanBan);
			groupBox2.Controls.Add(ckbVanBan);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(445, 44);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(641, 537);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(plLDPlayer);
			groupBox3.Controls.Add(plChrome);
			groupBox3.Controls.Add(rbLDPlayer);
			groupBox3.Controls.Add(rbChrome);
			groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox3.Location = new System.Drawing.Point(21, 78);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(611, 159);
			groupBox3.TabIndex = 9;
			groupBox3.TabStop = false;
			groupBox3.Text = "Tùy chọn ảnh đăng";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(18, 24);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(83, 16);
			label12.TabIndex = 45;
			label12.Text = "Chế độ chạy:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 16);
			label1.TabIndex = 45;
			label1.Text = "Số a\u0309nh/ba\u0300i:";
			plLDPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plLDPlayer.Controls.Add(btnNhapAnh);
			plLDPlayer.Controls.Add(label1);
			plLDPlayer.Controls.Add(label3);
			plLDPlayer.Controls.Add(nudSoAnhFrom);
			plLDPlayer.Controls.Add(label7);
			plLDPlayer.Controls.Add(nudSoAnhTo);
			plLDPlayer.Location = new System.Drawing.Point(121, 98);
			plLDPlayer.Name = "plLDPlayer";
			plLDPlayer.Size = new System.Drawing.Size(489, 55);
			plLDPlayer.TabIndex = 18;
			btnNhapAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapAnh.Location = new System.Drawing.Point(4, 0);
			btnNhapAnh.Name = "btnNhapAnh";
			btnNhapAnh.Size = new System.Drawing.Size(138, 25);
			btnNhapAnh.TabIndex = 59;
			btnNhapAnh.Text = "Nhâ\u0323p danh sách a\u0309nh";
			btnNhapAnh.UseVisualStyleBackColor = true;
			btnNhapAnh.Click += new System.EventHandler(btnNhapAnh_Click_1);
			nudSoAnhFrom.Location = new System.Drawing.Point(105, 27);
			nudSoAnhFrom.Name = "nudSoAnhFrom";
			nudSoAnhFrom.Size = new System.Drawing.Size(51, 23);
			nudSoAnhFrom.TabIndex = 47;
			plChrome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plChrome.Controls.Add(ckbXoaAnhDaDang);
			plChrome.Controls.Add(label2);
			plChrome.Controls.Add(txtPathPicChrome);
			plChrome.Location = new System.Drawing.Point(121, 42);
			plChrome.Name = "plChrome";
			plChrome.Size = new System.Drawing.Size(489, 50);
			plChrome.TabIndex = 18;
			ckbXoaAnhDaDang.AutoSize = true;
			ckbXoaAnhDaDang.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXoaAnhDaDang.Location = new System.Drawing.Point(5, 26);
			ckbXoaAnhDaDang.Name = "ckbXoaAnhDaDang";
			ckbXoaAnhDaDang.Size = new System.Drawing.Size(124, 20);
			ckbXoaAnhDaDang.TabIndex = 46;
			ckbXoaAnhDaDang.Text = "Xóa ảnh đã đăng";
			ckbXoaAnhDaDang.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(2, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(141, 16);
			label2.TabIndex = 35;
			label2.Text = "Đươ\u0300ng dâ\u0303n Folder ảnh:";
			txtPathPicChrome.Location = new System.Drawing.Point(144, 3);
			txtPathPicChrome.Name = "txtPathPicChrome";
			txtPathPicChrome.Size = new System.Drawing.Size(340, 23);
			txtPathPicChrome.TabIndex = 5;
			nudSoAnhTo.Location = new System.Drawing.Point(190, 27);
			nudSoAnhTo.Name = "nudSoAnhTo";
			nudSoAnhTo.Size = new System.Drawing.Size(51, 23);
			nudSoAnhTo.TabIndex = 48;
			rbLDPlayer.AutoSize = true;
			rbLDPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLDPlayer.Location = new System.Drawing.Point(46, 101);
			rbLDPlayer.Name = "rbLDPlayer";
			rbLDPlayer.Size = new System.Drawing.Size(75, 20);
			rbLDPlayer.TabIndex = 17;
			rbLDPlayer.Text = "LDPlayer";
			rbLDPlayer.UseVisualStyleBackColor = true;
			rbLDPlayer.CheckedChanged += new System.EventHandler(rbLDPlayer_CheckedChanged);
			label3.Location = new System.Drawing.Point(159, 31);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 49;
			label3.Text = "đến";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			rbChrome.AutoSize = true;
			rbChrome.Checked = true;
			rbChrome.Cursor = System.Windows.Forms.Cursors.Hand;
			rbChrome.Location = new System.Drawing.Point(46, 45);
			rbChrome.Name = "rbChrome";
			rbChrome.Size = new System.Drawing.Size(71, 20);
			rbChrome.TabIndex = 16;
			rbChrome.TabStop = true;
			rbChrome.Text = "Chrome";
			rbChrome.UseVisualStyleBackColor = true;
			rbChrome.CheckedChanged += new System.EventHandler(rbChrome_CheckedChanged);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(245, 31);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 50;
			label7.Text = "a\u0309nh";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(18, 23);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(109, 16);
			label15.TabIndex = 49;
			label15.Text = "Số lượng bài viết:";
			nudSoLuongBaiFrom.Location = new System.Drawing.Point(139, 20);
			nudSoLuongBaiFrom.Name = "nudSoLuongBaiFrom";
			nudSoLuongBaiFrom.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiFrom.TabIndex = 51;
			nudSoLuongBaiTo.Location = new System.Drawing.Point(224, 20);
			nudSoLuongBaiTo.Name = "nudSoLuongBaiTo";
			nudSoLuongBaiTo.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiTo.TabIndex = 52;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(279, 51);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 58;
			label19.Text = "giây";
			label17.Location = new System.Drawing.Point(193, 23);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(29, 16);
			label17.TabIndex = 53;
			label17.Text = "đến";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label20.Location = new System.Drawing.Point(193, 51);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 57;
			label20.Text = "đến";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(279, 23);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(25, 16);
			label18.TabIndex = 54;
			label18.Text = "bài";
			nudKhoangCachTo.Location = new System.Drawing.Point(224, 49);
			nudKhoangCachTo.Name = "nudKhoangCachTo";
			nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachTo.TabIndex = 56;
			nudKhoangCachFrom.Location = new System.Drawing.Point(139, 49);
			nudKhoangCachFrom.Name = "nudKhoangCachFrom";
			nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachFrom.TabIndex = 55;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(18, 51);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(117, 16);
			label16.TabIndex = 50;
			label16.Text = "Khoảng cách đăng:";
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(linkLabel1);
			plVanBan.Controls.Add(button3);
			plVanBan.Controls.Add(button2);
			plVanBan.Controls.Add(rbNganCachKyTu);
			plVanBan.Controls.Add(rbNganCachMoiDong);
			plVanBan.Controls.Add(ckbXoaNguyenLieuDaDung);
			plVanBan.Controls.Add(label9);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label13);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(35, 267);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(597, 262);
			plVanBan.TabIndex = 47;
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(154, 212);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 195;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked_1);
			button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(571, 234);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 193;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(571, 211);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 194;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(412, 235);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 37;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged_1);
			rbNganCachMoiDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(412, 213);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 36;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			ckbXoaNguyenLieuDaDung.AutoSize = true;
			ckbXoaNguyenLieuDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXoaNguyenLieuDaDung.Location = new System.Drawing.Point(8, 234);
			ckbXoaNguyenLieuDaDung.Name = "ckbXoaNguyenLieuDaDung";
			ckbXoaNguyenLieuDaDung.Size = new System.Drawing.Size(152, 20);
			ckbXoaNguyenLieuDaDung.TabIndex = 45;
			ckbXoaNguyenLieuDaDung.Text = "Xóa nội dung đã đăng";
			ckbXoaNguyenLieuDaDung.UseVisualStyleBackColor = true;
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(347, 213);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 35;
			label9.Text = "Tùy chọn:";
			txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(585, 186);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 212);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 0;
			label8.Text = "(Spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(146, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(21, 243);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(74, 20);
			ckbVanBan.TabIndex = 46;
			ckbVanBan.Text = "Văn ba\u0309n";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label13.AutoSize = true;
			label13.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			label13.Location = new System.Drawing.Point(382, 5);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(215, 16);
			label13.TabIndex = 0;
			label13.Text = "(Không nhập icon khi chạy Chrome!)";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1100, 638);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fDangBai_CauHinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			plRepeatAll.ResumeLayout(false);
			plRepeatAll.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			plLDPlayer.ResumeLayout(false);
			plLDPlayer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).EndInit();
			plChrome.ResumeLayout(false);
			plChrome.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			ResumeLayout(false);
		}
	}
}
