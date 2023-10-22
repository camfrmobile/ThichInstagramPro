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
	public class fHDNhanTinTheoLink : Form
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

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Label label2;

		private Label lblStatusUid;

		private RichTextBox txtUid;

		private ToolTip toolTip1;

		private ToolTip toolTip2;

		private Panel plSendImage;

		private TextBox txtFolderAnh;

		private Label label9;

		private NumericUpDown nudCountPicTo;

		private Label label3;

		private NumericUpDown nudCountPicFrom;

		private Label label10;

		private Label label4;

		private CheckBox ckbAnh;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private Label label49;

		private NumericUpDown nudSoLuongUidFrom;

		private Label label68;

		private NumericUpDown nudSoLuongUidTo;

		private Label label66;

		public fHDNhanTinTheoLink(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Nhă\u0301n tin theo link";
			if (InteractSQL.GetTuongTac("", text).Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('" + text + "', '" + text2 + "');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", text);
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
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(lblStatusUid);
			Language.GetValue(label2);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				nudCountPicFrom.Value = setting.GetValueInt("nudCountPicFrom", 1);
				nudCountPicTo.Value = setting.GetValueInt("nudCountPicTo", 1);
				txtUid.Text = setting.GetValue("txtUid");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				ckbAnh.Checked = setting.GetValueBool("ckbAnh");
				txtFolderAnh.Text = setting.GetValue("txtFolderAnh");
			}
			catch
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
			List<string> lst = txtUid.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch Uid!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("nudCountPicFrom", nudCountPicFrom.Value);
			jSON_Settings.Update("nudCountPicTo", nudCountPicTo.Value);
			jSON_Settings.Update("txtUid", txtUid.Text.Trim());
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			jSON_Settings.Update("ckbAnh", ckbAnh.Checked);
			jSON_Settings.Update("txtFolderAnh", txtFolderAnh.Text);
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

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbTuongTacTruocKhiNhanTin_CheckedChanged(null, null);
			ckbTuongTacTruocKhiNhanTinComment_CheckedChanged(null, null);
			ckbAnh_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void txtUid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatusUid.Text = string.Format(Language.GetValue("Danh sa\u0301ch User cần nhắn tin ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbTuongTacTruocKhiNhanTin_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbTuongTacTruocKhiNhanTinComment_CheckedChanged(object sender, EventArgs e)
		{
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
				list = txtNoiDung.Lines.ToList();
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung tin nhă\u0301n ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbAnh_CheckedChanged(object sender, EventArgs e)
		{
			plSendImage.Enabled = ckbAnh.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDNhanTinTheoLink));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			plSendImage = new System.Windows.Forms.Panel();
			txtFolderAnh = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			nudCountPicTo = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			nudCountPicFrom = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			ckbAnh = new System.Windows.Forms.CheckBox();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			txtUid = new System.Windows.Forms.RichTextBox();
			label2 = new System.Windows.Forms.Label();
			lblStatusUid = new System.Windows.Forms.Label();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			toolTip2 = new System.Windows.Forms.ToolTip(components);
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
			plSendImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountPicTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountPicFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			bunifuCards1.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(778, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Nhă\u0301n tin theo link User";
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
			pnlHeader.Size = new System.Drawing.Size(778, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(747, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 77;
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
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongUidFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(nudSoLuongUidTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(plSendImage);
			panel1.Controls.Add(ckbAnh);
			panel1.Controls.Add(txtNoiDung);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(lblStatus);
			panel1.Controls.Add(txtUid);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(lblStatusUid);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(781, 436);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(27, 80);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(64, 16);
			label49.TabIndex = 132;
			label49.Text = "Sô\u0301 lươ\u0323ng:";
			nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidFrom.Location = new System.Drawing.Point(135, 78);
			nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
			nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidFrom.TabIndex = 130;
			nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(290, 80);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(33, 16);
			label68.TabIndex = 133;
			label68.Text = "user";
			nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidTo.Location = new System.Drawing.Point(232, 78);
			nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidTo.Name = "nudSoLuongUidTo";
			nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidTo.TabIndex = 131;
			nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(197, 80);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 134;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plSendImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plSendImage.Controls.Add(txtFolderAnh);
			plSendImage.Controls.Add(label9);
			plSendImage.Controls.Add(nudCountPicTo);
			plSendImage.Controls.Add(label3);
			plSendImage.Controls.Add(nudCountPicFrom);
			plSendImage.Controls.Add(label10);
			plSendImage.Controls.Add(label4);
			plSendImage.Location = new System.Drawing.Point(390, 310);
			plSendImage.Name = "plSendImage";
			plSendImage.Size = new System.Drawing.Size(354, 65);
			plSendImage.TabIndex = 129;
			txtFolderAnh.Location = new System.Drawing.Point(151, 6);
			txtFolderAnh.Name = "txtFolderAnh";
			txtFolderAnh.Size = new System.Drawing.Size(195, 23);
			txtFolderAnh.TabIndex = 54;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(7, 9);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(138, 16);
			label9.TabIndex = 2;
			label9.Text = "Đường dẫn folder a\u0309nh:";
			nudCountPicTo.Location = new System.Drawing.Point(248, 35);
			nudCountPicTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudCountPicTo.Name = "nudCountPicTo";
			nudCountPicTo.Size = new System.Drawing.Size(56, 23);
			nudCountPicTo.TabIndex = 40;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(7, 37);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(89, 16);
			label3.TabIndex = 35;
			label3.Text = "Số lượng ảnh:";
			nudCountPicFrom.Location = new System.Drawing.Point(151, 35);
			nudCountPicFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudCountPicFrom.Name = "nudCountPicFrom";
			nudCountPicFrom.Size = new System.Drawing.Size(56, 23);
			nudCountPicFrom.TabIndex = 39;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(310, 37);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 41;
			label10.Text = "ảnh";
			label4.Location = new System.Drawing.Point(213, 37);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 42;
			label4.Text = "đê\u0301n";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbAnh.AutoSize = true;
			ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAnh.Location = new System.Drawing.Point(371, 288);
			ckbAnh.Name = "ckbAnh";
			ckbAnh.Size = new System.Drawing.Size(227, 20);
			ckbAnh.TabIndex = 128;
			ckbAnh.Text = "Gư\u0309i a\u0309nh (Chi\u0309 sư\u0309 du\u0323ng trên chrome)";
			ckbAnh.UseVisualStyleBackColor = true;
			ckbAnh.CheckedChanged += new System.EventHandler(ckbAnh_CheckedChanged);
			txtNoiDung.Location = new System.Drawing.Point(370, 104);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(374, 160);
			txtNoiDung.TabIndex = 127;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(367, 267);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(273, 16);
			label8.TabIndex = 125;
			label8.Text = "(Mô\u0303i do\u0300ng 1 nô\u0323i dung - Spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(366, 83);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(134, 16);
			lblStatus.TabIndex = 126;
			lblStatus.Text = "Nội dung tin nhắn (0):";
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(31, 154);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(299, 202);
			txtUid.TabIndex = 117;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(28, 359);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(208, 16);
			label2.TabIndex = 115;
			label2.Text = "(Vui lo\u0300ng nhâ\u0323p user hoă\u0323c link user)";
			lblStatusUid.AutoSize = true;
			lblStatusUid.Location = new System.Drawing.Point(27, 135);
			lblStatusUid.Name = "lblStatusUid";
			lblStatusUid.Size = new System.Drawing.Size(197, 16);
			lblStatusUid.TabIndex = 116;
			lblStatusUid.Text = "Danh sa\u0301ch User cần nhắn tin (0):";
			nudDelayTo.Location = new System.Drawing.Point(232, 107);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 6;
			nudDelayFrom.Location = new System.Drawing.Point(135, 107);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 5;
			txtTenHanhDong.Location = new System.Drawing.Point(135, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(195, 23);
			txtTenHanhDong.TabIndex = 0;
			label7.Location = new System.Drawing.Point(197, 109);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(292, 109);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 109);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(397, 391);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(290, 391);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 11;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
			bunifuCards1.Size = new System.Drawing.Size(778, 37);
			bunifuCards1.TabIndex = 28;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 20000;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 0;
			toolTip1.ToolTipTitle = "Chú ý";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(781, 436);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDNhanTinTheoLink";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
			plSendImage.ResumeLayout(false);
			plSendImage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountPicTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountPicFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
