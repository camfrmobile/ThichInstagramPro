using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fDoiThongTin_CauHinh : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private Label label6;

		private Label label4;

		private NumericUpDown nudDelayTurnFrom;

		private Label label5;

		private NumericUpDown nudDelayTurnTo;

		private Label label11;

		private NumericUpDown nudSoLuotChay;

		private Panel gbBio;

		private Button button3;

		private Button button2;

		private CheckBox ckbXoaNguyenLieuDaDung;

		private Label lblStatus;

		private CheckBox ckbBio;

		private Label label10;

		private Button btnCancel;

		private Button btnAdd;

		private GroupBox groupBox1;

		private Panel plRepeatAll;

		private CheckBox ckbRandomThuTuTaiKhoan;

		private CheckBox ckbRepeatAll;

		private GroupBox groupBox2;

		private CheckBox ckbNgaySinh;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private BunifuCustomLabel bunifuCustomLabel1;

		private BunifuDragControl bunifuDragControl1;

		private Panel panel1;

		private Button button1;

		private CheckBox ckbWedsite;

		private GroupBox gbGoiTinh;

		private GroupBox gbNgaySinh;

		private CheckBox ckbGioiTinh;

		private Panel gbWedsite;

		private Button button4;

		private CheckBox checkBox1;

		private RichTextBox txtWedsite;

		private Label label3;

		private Label label2;

		private Label label13;

		private NumericUpDown nudNamFrom;

		private NumericUpDown nudNamTo;

		private Label label15;

		private Label label8;

		private NumericUpDown nudThangFrom;

		private NumericUpDown nudThangTo;

		private Label label12;

		private Label label1;

		private NumericUpDown nudDayTo;

		private NumericUpDown nudDayFrom;

		private Label label7;

		private Label label14;

		private Label label9;

		private RadioButton rbNothing;

		private RadioButton rbNu;

		private RadioButton rbNam;

		private RichTextBox txtNoiDung;

		private RadioButton rbRandomGender;

		public fDoiThongTin_CauHinh()
		{
			InitializeComponent();
			settings = new JSON_Settings("configDoiThongTin");
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			settings.Update("ckbRepeatAll", ckbRepeatAll.Checked);
			settings.Update("nudDelayTurnFrom", nudDelayTurnFrom.Value);
			settings.Update("nudDelayTurnTo", nudDelayTurnTo.Value);
			settings.Update("nudSoLuotChay", nudSoLuotChay.Value);
			settings.Update("RepeatAllVIP", "false");
			settings.Update("ckbRandomThuTuTaiKhoan", ckbRandomThuTuTaiKhoan.Checked);
			settings.Update("ckbBio", ckbBio.Checked);
			settings.Update("txtNoiDung", txtNoiDung.Text);
			settings.Update("ckbWedsite", ckbWedsite.Checked);
			settings.Update("txtWedsite", txtWedsite.Text);
			settings.Update("ckbNgaySinh", ckbNgaySinh.Checked);
			settings.Update("nudDayFrom", nudDayFrom.Value);
			settings.Update("nudDayTo", nudDayTo.Value);
			settings.Update("nudThangFrom", nudThangFrom.Value);
			settings.Update("nudThangTo", nudThangTo.Value);
			settings.Update("nudNamFrom", nudNamFrom.Value);
			settings.Update("nudNamTo", nudNamTo.Value);
			settings.Update("ckbGioiTinh", ckbGioiTinh.Checked);
			settings.Update("rbNam", rbNam.Checked);
			settings.Update("rbNu", rbNu.Checked);
			settings.Update("rbNothing", rbNothing.Checked);
			settings.Update("rbRandomGender", rbRandomGender.Checked);
			settings.Save();
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
			{
				Close();
			}
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
				ckbBio.Checked = settings.GetValueBool("ckbBio");
				txtNoiDung.Text = settings.GetValue("txtNoiDung");
				ckbWedsite.Checked = settings.GetValueBool("ckbWedsite");
				txtWedsite.Text = settings.GetValue("txtWedsite");
				ckbNgaySinh.Checked = settings.GetValueBool("ckbNgaySinh");
				nudDayFrom.Value = settings.GetValueInt("nudDayFrom");
				nudDayTo.Value = settings.GetValueInt("nudDayTo");
				nudThangFrom.Value = settings.GetValueInt("nudThangFrom");
				nudThangTo.Value = settings.GetValueInt("nudThangTo");
				nudNamFrom.Value = settings.GetValueInt("nudNamFrom");
				nudNamTo.Value = settings.GetValueInt("nudNamTo");
				ckbGioiTinh.Checked = settings.GetValueBool("ckbGioiTinh");
				rbNam.Checked = settings.GetValueBool("rbNam");
				rbNothing.Checked = settings.GetValueBool("rbNothing");
				rbNu.Checked = settings.GetValueBool("rbNu");
				rbRandomGender.Checked = settings.GetValueBool("rbRandomGender");
			}
			catch
			{
			}
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ckbBio_CheckedChanged(object sender, EventArgs e)
		{
			gbBio.Enabled = ckbBio.Checked;
		}

		private void ckbWedsite_CheckedChanged(object sender, EventArgs e)
		{
			gbWedsite.Enabled = ckbWedsite.Checked;
		}

		private void ckbNgaySinh_CheckedChanged(object sender, EventArgs e)
		{
			gbNgaySinh.Enabled = ckbNgaySinh.Checked;
		}

		private void ckbGioiTinh_CheckedChanged(object sender, EventArgs e)
		{
			gbGoiTinh.Enabled = ckbGioiTinh.Checked;
		}

		private void rbTuChinhGioiTinh_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void CheckedChangedFull()
		{
			ckbGioiTinh_CheckedChanged(null, null);
			ckbNgaySinh_CheckedChanged(null, null);
			ckbWedsite_CheckedChanged(null, null);
			ckbBio_CheckedChanged(null, null);
			ckbRepeatAll_CheckedChanged(null, null);
		}

		private void fDoiThongTin_CauHinh_Load(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
		}

		private void txtNoiDung_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtNoiDung_TextChanged_1(object sender, EventArgs e)
		{
			string[] lines = txtNoiDung.Lines;
			foreach (string text in lines)
			{
				if (text.Length > 150)
				{
					txtNoiDung.Undo();
				}
			}
			txtNoiDung.ClearUndo();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fDoiThongTin_CauHinh));
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			nudDelayTurnFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			nudDelayTurnTo = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			nudSoLuotChay = new System.Windows.Forms.NumericUpDown();
			gbBio = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			ckbXoaNguyenLieuDaDung = new System.Windows.Forms.CheckBox();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			lblStatus = new System.Windows.Forms.Label();
			ckbBio = new System.Windows.Forms.CheckBox();
			label10 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			plRepeatAll = new System.Windows.Forms.Panel();
			ckbRandomThuTuTaiKhoan = new System.Windows.Forms.CheckBox();
			ckbRepeatAll = new System.Windows.Forms.CheckBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			gbGoiTinh = new System.Windows.Forms.GroupBox();
			rbNothing = new System.Windows.Forms.RadioButton();
			rbNu = new System.Windows.Forms.RadioButton();
			rbNam = new System.Windows.Forms.RadioButton();
			gbNgaySinh = new System.Windows.Forms.GroupBox();
			label14 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			nudNamFrom = new System.Windows.Forms.NumericUpDown();
			nudNamTo = new System.Windows.Forms.NumericUpDown();
			label15 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			nudThangFrom = new System.Windows.Forms.NumericUpDown();
			nudThangTo = new System.Windows.Forms.NumericUpDown();
			label12 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			nudDayTo = new System.Windows.Forms.NumericUpDown();
			nudDayFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			ckbGioiTinh = new System.Windows.Forms.CheckBox();
			gbWedsite = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			txtWedsite = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			ckbWedsite = new System.Windows.Forms.CheckBox();
			ckbNgaySinh = new System.Windows.Forms.CheckBox();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			rbRandomGender = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			gbBio.SuspendLayout();
			groupBox1.SuspendLayout();
			plRepeatAll.SuspendLayout();
			groupBox2.SuspendLayout();
			gbGoiTinh.SuspendLayout();
			gbNgaySinh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudNamFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudNamTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThangFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThangTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDayFrom).BeginInit();
			gbWedsite.SuspendLayout();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
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
			gbBio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			gbBio.Controls.Add(button1);
			gbBio.Controls.Add(button3);
			gbBio.Controls.Add(button2);
			gbBio.Controls.Add(ckbXoaNguyenLieuDaDung);
			gbBio.Controls.Add(txtNoiDung);
			gbBio.Controls.Add(lblStatus);
			gbBio.Enabled = false;
			gbBio.Location = new System.Drawing.Point(34, 42);
			gbBio.Name = "gbBio";
			gbBio.Size = new System.Drawing.Size(415, 207);
			gbBio.TabIndex = 47;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button1.Cursor = System.Windows.Forms.Cursors.Help;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.Location = new System.Drawing.Point(389, 179);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(21, 23);
			button1.TabIndex = 193;
			button1.Text = "?";
			button1.UseVisualStyleBackColor = true;
			button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(480, 179);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 193;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(480, 156);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 194;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			ckbXoaNguyenLieuDaDung.AutoSize = true;
			ckbXoaNguyenLieuDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXoaNguyenLieuDaDung.Location = new System.Drawing.Point(157, 235);
			ckbXoaNguyenLieuDaDung.Name = "ckbXoaNguyenLieuDaDung";
			ckbXoaNguyenLieuDaDung.Size = new System.Drawing.Size(152, 20);
			ckbXoaNguyenLieuDaDung.TabIndex = 45;
			ckbXoaNguyenLieuDaDung.Text = "Xóa nội dung đã đăng";
			ckbXoaNguyenLieuDaDung.UseVisualStyleBackColor = true;
			txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNoiDung.Location = new System.Drawing.Point(11, 23);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(399, 150);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged_1);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(146, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
			ckbBio.AutoSize = true;
			ckbBio.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBio.Location = new System.Drawing.Point(20, 18);
			ckbBio.Name = "ckbBio";
			ckbBio.Size = new System.Drawing.Size(44, 20);
			ckbBio.TabIndex = 46;
			ckbBio.Text = "Bio";
			ckbBio.UseVisualStyleBackColor = true;
			ckbBio.CheckedChanged += new System.EventHandler(ckbBio_CheckedChanged);
			label10.Location = new System.Drawing.Point(222, 36);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 12;
			label10.Text = "đến";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(466, 611);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(362, 611);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			groupBox1.Controls.Add(plRepeatAll);
			groupBox1.Controls.Add(ckbRandomThuTuTaiKhoan);
			groupBox1.Controls.Add(ckbRepeatAll);
			groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f);
			groupBox1.Location = new System.Drawing.Point(11, 44);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(879, 141);
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
			plRepeatAll.Enabled = false;
			plRepeatAll.Location = new System.Drawing.Point(39, 68);
			plRepeatAll.Name = "plRepeatAll";
			plRepeatAll.Size = new System.Drawing.Size(363, 64);
			plRepeatAll.TabIndex = 13;
			ckbRandomThuTuTaiKhoan.AutoSize = true;
			ckbRandomThuTuTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRandomThuTuTaiKhoan.Location = new System.Drawing.Point(19, 20);
			ckbRandomThuTuTaiKhoan.Name = "ckbRandomThuTuTaiKhoan";
			ckbRandomThuTuTaiKhoan.Size = new System.Drawing.Size(255, 20);
			ckbRandomThuTuTaiKhoan.TabIndex = 2;
			ckbRandomThuTuTaiKhoan.Text = "Xáo trộn thứ tự tài khoản trước khi chạy";
			ckbRandomThuTuTaiKhoan.UseVisualStyleBackColor = true;
			ckbRepeatAll.AutoSize = true;
			ckbRepeatAll.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRepeatAll.Location = new System.Drawing.Point(19, 46);
			ckbRepeatAll.Name = "ckbRepeatAll";
			ckbRepeatAll.Size = new System.Drawing.Size(287, 20);
			ckbRepeatAll.TabIndex = 2;
			ckbRepeatAll.Text = "Chạy lại toàn bộ tài khoản sau khi hoàn thành";
			ckbRepeatAll.UseVisualStyleBackColor = true;
			ckbRepeatAll.CheckedChanged += new System.EventHandler(ckbRepeatAll_CheckedChanged);
			groupBox2.Controls.Add(gbGoiTinh);
			groupBox2.Controls.Add(gbNgaySinh);
			groupBox2.Controls.Add(ckbGioiTinh);
			groupBox2.Controls.Add(gbWedsite);
			groupBox2.Controls.Add(ckbWedsite);
			groupBox2.Controls.Add(gbBio);
			groupBox2.Controls.Add(ckbNgaySinh);
			groupBox2.Controls.Add(ckbBio);
			groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(11, 191);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(879, 401);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			gbGoiTinh.Controls.Add(rbRandomGender);
			gbGoiTinh.Controls.Add(rbNothing);
			gbGoiTinh.Controls.Add(rbNu);
			gbGoiTinh.Controls.Add(rbNam);
			gbGoiTinh.Enabled = false;
			gbGoiTinh.Location = new System.Drawing.Point(464, 278);
			gbGoiTinh.Name = "gbGoiTinh";
			gbGoiTinh.Size = new System.Drawing.Size(409, 117);
			gbGoiTinh.TabIndex = 63;
			gbGoiTinh.TabStop = false;
			rbNothing.AutoSize = true;
			rbNothing.Location = new System.Drawing.Point(9, 83);
			rbNothing.Name = "rbNothing";
			rbNothing.Size = new System.Drawing.Size(82, 20);
			rbNothing.TabIndex = 2;
			rbNothing.TabStop = true;
			rbNothing.Text = "Không nói";
			rbNothing.UseVisualStyleBackColor = true;
			rbNu.AutoSize = true;
			rbNu.Location = new System.Drawing.Point(9, 52);
			rbNu.Name = "rbNu";
			rbNu.Size = new System.Drawing.Size(42, 20);
			rbNu.TabIndex = 1;
			rbNu.TabStop = true;
			rbNu.Text = "Nữ";
			rbNu.UseVisualStyleBackColor = true;
			rbNam.AutoSize = true;
			rbNam.Location = new System.Drawing.Point(9, 20);
			rbNam.Name = "rbNam";
			rbNam.Size = new System.Drawing.Size(52, 20);
			rbNam.TabIndex = 0;
			rbNam.TabStop = true;
			rbNam.Text = "Nam";
			rbNam.UseVisualStyleBackColor = true;
			gbNgaySinh.Controls.Add(label14);
			gbNgaySinh.Controls.Add(label9);
			gbNgaySinh.Controls.Add(label2);
			gbNgaySinh.Controls.Add(label13);
			gbNgaySinh.Controls.Add(nudNamFrom);
			gbNgaySinh.Controls.Add(nudNamTo);
			gbNgaySinh.Controls.Add(label15);
			gbNgaySinh.Controls.Add(label8);
			gbNgaySinh.Controls.Add(nudThangFrom);
			gbNgaySinh.Controls.Add(nudThangTo);
			gbNgaySinh.Controls.Add(label12);
			gbNgaySinh.Controls.Add(label1);
			gbNgaySinh.Controls.Add(nudDayTo);
			gbNgaySinh.Controls.Add(nudDayFrom);
			gbNgaySinh.Controls.Add(label7);
			gbNgaySinh.Enabled = false;
			gbNgaySinh.Location = new System.Drawing.Point(34, 278);
			gbNgaySinh.Name = "gbNgaySinh";
			gbNgaySinh.Size = new System.Drawing.Size(415, 117);
			gbNgaySinh.TabIndex = 62;
			gbNgaySinh.TabStop = false;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(77, 82);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(20, 16);
			label14.TabIndex = 30;
			label14.Text = "từ";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(77, 53);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(20, 16);
			label9.TabIndex = 29;
			label9.Text = "từ";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(77, 25);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(20, 16);
			label2.TabIndex = 28;
			label2.Text = "từ";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 82);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(39, 16);
			label13.TabIndex = 23;
			label13.Text = "Năm:";
			nudNamFrom.Location = new System.Drawing.Point(115, 80);
			nudNamFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudNamFrom.Name = "nudNamFrom";
			nudNamFrom.Size = new System.Drawing.Size(65, 23);
			nudNamFrom.TabIndex = 25;
			nudNamTo.Location = new System.Drawing.Point(235, 80);
			nudNamTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudNamTo.Name = "nudNamTo";
			nudNamTo.Size = new System.Drawing.Size(65, 23);
			nudNamTo.TabIndex = 24;
			label15.Location = new System.Drawing.Point(194, 83);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(29, 16);
			label15.TabIndex = 27;
			label15.Text = "đến";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(9, 53);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(49, 16);
			label8.TabIndex = 18;
			label8.Text = "Tháng:";
			nudThangFrom.Location = new System.Drawing.Point(115, 51);
			nudThangFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudThangFrom.Name = "nudThangFrom";
			nudThangFrom.Size = new System.Drawing.Size(65, 23);
			nudThangFrom.TabIndex = 20;
			nudThangTo.Location = new System.Drawing.Point(235, 51);
			nudThangTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudThangTo.Name = "nudThangTo";
			nudThangTo.Size = new System.Drawing.Size(65, 23);
			nudThangTo.TabIndex = 19;
			label12.Location = new System.Drawing.Point(194, 54);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(29, 16);
			label12.TabIndex = 22;
			label12.Text = "đến";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 16);
			label1.TabIndex = 13;
			label1.Text = "Ngày:";
			nudDayTo.Location = new System.Drawing.Point(115, 22);
			nudDayTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDayTo.Name = "nudDayTo";
			nudDayTo.Size = new System.Drawing.Size(65, 23);
			nudDayTo.TabIndex = 15;
			nudDayFrom.Location = new System.Drawing.Point(235, 22);
			nudDayFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDayFrom.Name = "nudDayFrom";
			nudDayFrom.Size = new System.Drawing.Size(65, 23);
			nudDayFrom.TabIndex = 14;
			label7.Location = new System.Drawing.Point(194, 25);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 17;
			label7.Text = "đến";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbGioiTinh.AutoSize = true;
			ckbGioiTinh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGioiTinh.Location = new System.Drawing.Point(455, 255);
			ckbGioiTinh.Name = "ckbGioiTinh";
			ckbGioiTinh.Size = new System.Drawing.Size(73, 20);
			ckbGioiTinh.TabIndex = 61;
			ckbGioiTinh.Text = "Giới tính";
			ckbGioiTinh.UseVisualStyleBackColor = true;
			ckbGioiTinh.CheckedChanged += new System.EventHandler(ckbGioiTinh_CheckedChanged);
			gbWedsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			gbWedsite.Controls.Add(button4);
			gbWedsite.Controls.Add(checkBox1);
			gbWedsite.Controls.Add(txtWedsite);
			gbWedsite.Controls.Add(label3);
			gbWedsite.Enabled = false;
			gbWedsite.Location = new System.Drawing.Point(464, 42);
			gbWedsite.Name = "gbWedsite";
			gbWedsite.Size = new System.Drawing.Size(409, 207);
			gbWedsite.TabIndex = 60;
			button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button4.Cursor = System.Windows.Forms.Cursors.Help;
			button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button4.Location = new System.Drawing.Point(383, 179);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(21, 23);
			button4.TabIndex = 194;
			button4.Text = "?";
			button4.UseVisualStyleBackColor = true;
			checkBox1.AutoSize = true;
			checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			checkBox1.Location = new System.Drawing.Point(157, 235);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(152, 20);
			checkBox1.TabIndex = 45;
			checkBox1.Text = "Xóa nội dung đã đăng";
			checkBox1.UseVisualStyleBackColor = true;
			txtWedsite.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtWedsite.Location = new System.Drawing.Point(8, 23);
			txtWedsite.MaxLength = 999999999;
			txtWedsite.Name = "txtWedsite";
			txtWedsite.Size = new System.Drawing.Size(392, 150);
			txtWedsite.TabIndex = 34;
			txtWedsite.Text = "";
			txtWedsite.WordWrap = false;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(5, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(141, 16);
			label3.TabIndex = 0;
			label3.Text = "Danh sa\u0301ch website (0):";
			ckbWedsite.AutoSize = true;
			ckbWedsite.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWedsite.Location = new System.Drawing.Point(455, 16);
			ckbWedsite.Name = "ckbWedsite";
			ckbWedsite.Size = new System.Drawing.Size(73, 20);
			ckbWedsite.TabIndex = 59;
			ckbWedsite.Text = "Website";
			ckbWedsite.UseVisualStyleBackColor = true;
			ckbWedsite.CheckedChanged += new System.EventHandler(ckbWedsite_CheckedChanged);
			ckbNgaySinh.AutoSize = true;
			ckbNgaySinh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbNgaySinh.Location = new System.Drawing.Point(20, 255);
			ckbNgaySinh.Name = "ckbNgaySinh";
			ckbNgaySinh.Size = new System.Drawing.Size(82, 20);
			ckbNgaySinh.TabIndex = 44;
			ckbNgaySinh.Text = "Ngày sinh";
			ckbNgaySinh.UseVisualStyleBackColor = true;
			ckbNgaySinh.CheckedChanged += new System.EventHandler(ckbNgaySinh_CheckedChanged);
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.FromArgb(24, 119, 242);
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 1);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(905, 38);
			bunifuCards1.TabIndex = 9;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(905, 32);
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
			btnMinimize.Location = new System.Drawing.Point(871, -2);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(905, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Đổi thông tin";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(903, 653);
			panel1.TabIndex = 10;
			rbRandomGender.AutoSize = true;
			rbRandomGender.Location = new System.Drawing.Point(174, 20);
			rbRandomGender.Name = "rbRandomGender";
			rbRandomGender.Size = new System.Drawing.Size(90, 20);
			rbRandomGender.TabIndex = 3;
			rbRandomGender.TabStop = true;
			rbRandomGender.Text = "Ngẫu nhiên";
			rbRandomGender.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(903, 653);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fDoiThongTin_CauHinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "fDoiThongTin_CauHinh";
			base.Load += new System.EventHandler(fDoiThongTin_CauHinh_Load);
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).EndInit();
			gbBio.ResumeLayout(false);
			gbBio.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			plRepeatAll.ResumeLayout(false);
			plRepeatAll.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			gbGoiTinh.ResumeLayout(false);
			gbGoiTinh.PerformLayout();
			gbNgaySinh.ResumeLayout(false);
			gbNgaySinh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudNamFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudNamTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThangFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThangTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDayFrom).EndInit();
			gbWedsite.ResumeLayout(false);
			gbWedsite.PerformLayout();
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
