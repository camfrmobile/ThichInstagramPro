using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using MCommon;

namespace maxcare
{
	public class fHDDangBai : Form
	{
		private JSON_Settings setting;

		private string id_KichBan;

		private string id_TuongTac;

		private string Id_HanhDong;

		private int type;

		public static bool isSave;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel panel1;

		private TextBox txtTenHanhDong;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Label label2;

		private TextBox textBox1;

		private NumericUpDown nudSoAnhFrom;

		private Label label15;

		private NumericUpDown nudSoAnhTo;

		private CheckBox checkBox1;

		private NumericUpDown nudSoLuongBaiFrom;

		private Label label3;

		private Label label7;

		private NumericUpDown nudSoLuongBaiTo;

		private Label label19;

		private Label label17;

		private Label label20;

		private Label label18;

		private NumericUpDown nudKhoangCachTo;

		private NumericUpDown nudKhoangCachFrom;

		private Label label4;

		private Label label16;

		private Panel plVanBan;

		private LinkLabel linkLabel1;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private CheckBox ckbXoaNguyenLieuDaDung;

		private Label label9;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbVanBan;

		public fHDDangBai(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			if (InteractSQL.GetTuongTac("", text).Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\",\"MoTa\") VALUES ('" + text + "', 'Đăng bài theo ID');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", text);
				jsonStringOrPathFile = tuongTac.Rows[0]["CauHinh"].ToString();
				id_TuongTac = tuongTac.Rows[0]["Id_TuongTac"].ToString();
				txtTenHanhDong.Text = Language.GetValue(tuongTac.Rows[0]["MoTa"].ToString());
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				jsonStringOrPathFile = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
				txtTenHanhDong.Text = hanhDongById.Rows[0]["TenHanhDong"].ToString();
				break;
			}
			}
			setting = new JSON_Settings(jsonStringOrPathFile, isJsonString: true);
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label15);
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(label3);
			Language.GetValue(label2);
			Language.GetValue(label4);
			Language.GetValue(label7);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception)
			{
			}
			CheckedChangeFull();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string text = txtTenHanhDong.Text.Trim();
			if (text == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			string fullString = jSON_Settings.GetFullString();
			if (type == 0)
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
				{
					if (InteractSQL.InsertHanhDong(id_KichBan, text, id_TuongTac, fullString))
					{
						isSave = true;
						Close();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
					}
				}
			}
			else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
			{
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text, fullString))
				{
					isSave = true;
					Close();
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			if (panel1.BorderStyle == BorderStyle.FixedSingle)
			{
				int num = 1;
				int num2 = 0;
				using Pen pen = new Pen(Color.DarkViolet, 1f);
				e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
			}
		}

		private void CheckedChangeFull()
		{
			ckbDangBaiLenNhom_CheckedChanged(null, null);
			ckbDangBaiLenPage_CheckedChanged(null, null);
			ckbVanBan_CheckedChanged(null, null);
			checkBox1_CheckedChanged(null, null);
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
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

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void ckbDangBaiLenNhom_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbDangBaiLenPage_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDDangBai));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			btnAdd = new System.Windows.Forms.Button();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			label15 = new System.Windows.Forms.Label();
			nudSoLuongBaiFrom = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			nudSoAnhFrom = new System.Windows.Forms.NumericUpDown();
			nudSoAnhTo = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
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
			label4 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			bunifuCards1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
			plVanBan.SuspendLayout();
			SuspendLayout();
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(674, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Đăng bài";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(674, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(643, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 0;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(nudSoAnhFrom);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(nudSoAnhTo);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(nudSoLuongBaiFrom);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(nudSoLuongBaiTo);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(label20);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(nudKhoangCachTo);
			panel1.Controls.Add(nudKhoangCachFrom);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(plVanBan);
			panel1.Controls.Add(ckbVanBan);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(677, 541);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(245, 499);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			txtTenHanhDong.Location = new System.Drawing.Point(176, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(193, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(29, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(344, 499);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(674, 37);
			bunifuCards1.TabIndex = 28;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(29, 81);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(109, 16);
			label15.TabIndex = 63;
			label15.Text = "Số lượng bài viết:";
			nudSoLuongBaiFrom.Location = new System.Drawing.Point(176, 78);
			nudSoLuongBaiFrom.Name = "nudSoLuongBaiFrom";
			nudSoLuongBaiFrom.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiFrom.TabIndex = 65;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(29, 167);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(107, 16);
			label2.TabIndex = 45;
			label2.Text = "Số a\u0309nh/ba\u0300i đăng:";
			nudSoAnhFrom.Location = new System.Drawing.Point(176, 165);
			nudSoAnhFrom.Name = "nudSoAnhFrom";
			nudSoAnhFrom.Size = new System.Drawing.Size(51, 23);
			nudSoAnhFrom.TabIndex = 47;
			nudSoAnhTo.Location = new System.Drawing.Point(261, 165);
			nudSoAnhTo.Name = "nudSoAnhTo";
			nudSoAnhTo.Size = new System.Drawing.Size(51, 23);
			nudSoAnhTo.TabIndex = 48;
			label3.Location = new System.Drawing.Point(230, 169);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 49;
			label3.Text = "đến";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(316, 169);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 50;
			label7.Text = "a\u0309nh";
			nudSoLuongBaiTo.Location = new System.Drawing.Point(261, 78);
			nudSoLuongBaiTo.Name = "nudSoLuongBaiTo";
			nudSoLuongBaiTo.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiTo.TabIndex = 66;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(316, 109);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 72;
			label19.Text = "giây";
			label17.Location = new System.Drawing.Point(230, 81);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(29, 16);
			label17.TabIndex = 67;
			label17.Text = "đến";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label20.Location = new System.Drawing.Point(230, 109);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 71;
			label20.Text = "đến";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(316, 81);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(25, 16);
			label18.TabIndex = 68;
			label18.Text = "bài";
			nudKhoangCachTo.Location = new System.Drawing.Point(261, 107);
			nudKhoangCachTo.Name = "nudKhoangCachTo";
			nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachTo.TabIndex = 70;
			nudKhoangCachFrom.Location = new System.Drawing.Point(176, 107);
			nudKhoangCachFrom.Name = "nudKhoangCachFrom";
			nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachFrom.TabIndex = 69;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(29, 109);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(117, 16);
			label16.TabIndex = 64;
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
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(46, 219);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(597, 262);
			plVanBan.TabIndex = 62;
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(154, 212);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 195;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(571, 234);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 193;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(571, 211);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 194;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			rbNganCachKyTu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(412, 235);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 37;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
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
			ckbVanBan.Location = new System.Drawing.Point(32, 195);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(136, 20);
			ckbVanBan.TabIndex = 61;
			ckbVanBan.Text = "Đăng kèm Văn ba\u0309n";
			ckbVanBan.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(29, 139);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(141, 16);
			label4.TabIndex = 64;
			label4.Text = "Đường dẫn Folder ảnh:";
			textBox1.Location = new System.Drawing.Point(176, 136);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(467, 23);
			textBox1.TabIndex = 73;
			checkBox1.AutoSize = true;
			checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			checkBox1.Location = new System.Drawing.Point(387, 166);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(124, 20);
			checkBox1.TabIndex = 45;
			checkBox1.Text = "Xóa ảnh đã đăng";
			checkBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(677, 541);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDDangBai";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			bunifuCards1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			ResumeLayout(false);
		}
	}
}
