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
	public class fHDLuotStory : Form
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

		private Panel plStoryNewfeed;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudSoLuongStoryTo;

		private NumericUpDown nudDelayFrom;

		private NumericUpDown nudSoLuongStoryFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label3;

		private Label label6;

		private Label label4;

		private Label label5;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Label label19;

		private Panel panel2;

		private Panel plStoryChiDinh;

		private Label lblUser;

		private Label label2;

		private NumericUpDown nudDelayChiDinhTo;

		private Label label8;

		private NumericUpDown nudDelayChiDinhFrom;

		private Label label9;

		private RichTextBox txtListUser;

		private RadioButton rbStoryUser;

		private RadioButton rbStoryNewfeed;

		private Label label10;

		public fHDLuotStory(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Lướt story";
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
			Language.GetValue(label19);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongStoryFrom.Value = setting.GetValueInt("nudSoLuongStoryFrom", 1);
				nudSoLuongStoryTo.Value = setting.GetValueInt("nudSoLuongStoryTo", 1);
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				nudDelayChiDinhFrom.Value = setting.GetValueInt("nudDelayChiDinhFrom", 3);
				nudDelayChiDinhTo.Value = setting.GetValueInt("nudDelayChiDinhTo", 5);
				if (setting.GetValueInt("typeStory") == 0)
				{
					rbStoryNewfeed.Checked = true;
				}
				else
				{
					rbStoryUser.Checked = true;
				}
				txtListUser.Text = setting.GetValue("txtListUser");
			}
			catch
			{
			}
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
			jSON_Settings.Update("nudSoLuongStoryFrom", nudSoLuongStoryFrom.Value);
			jSON_Settings.Update("nudSoLuongStoryTo", nudSoLuongStoryTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("nudDelayChiDinhFrom", nudDelayChiDinhFrom.Value);
			jSON_Settings.Update("nudDelayChiDinhTo", nudDelayChiDinhTo.Value);
			int num = 0;
			if (rbStoryUser.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeStory", num);
			jSON_Settings.Update("txtListUser", txtListUser.Text);
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
			if (plStoryNewfeed.BorderStyle == BorderStyle.FixedSingle)
			{
				int num = 1;
				int num2 = 0;
				using Pen pen = new Pen(Color.DarkViolet, 1f);
				e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, plStoryNewfeed.ClientSize.Width - num, plStoryNewfeed.ClientSize.Height - num));
			}
		}

		private void txtListUser_TextChanged_1(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtListUser.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblUser.Text = string.Format(Language.GetValue("Nhập danh sách User ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbStoryNewfeed_CheckedChanged(object sender, EventArgs e)
		{
			panel2.Enabled = rbStoryNewfeed.Checked;
		}

		private void rbStoryUser_CheckedChanged(object sender, EventArgs e)
		{
			plStoryChiDinh.Enabled = rbStoryUser.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDLuotStory));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			plStoryNewfeed = new System.Windows.Forms.Panel();
			label10 = new System.Windows.Forms.Label();
			rbStoryUser = new System.Windows.Forms.RadioButton();
			rbStoryNewfeed = new System.Windows.Forms.RadioButton();
			plStoryChiDinh = new System.Windows.Forms.Panel();
			txtListUser = new System.Windows.Forms.RichTextBox();
			lblUser = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			nudDelayChiDinhTo = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			nudDelayChiDinhFrom = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label19 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			nudSoLuongStoryTo = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			nudSoLuongStoryFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			plStoryNewfeed.SuspendLayout();
			plStoryChiDinh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayChiDinhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayChiDinhFrom).BeginInit();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongStoryTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongStoryFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Lướt story";
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
			pnlHeader.Size = new System.Drawing.Size(359, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(328, 1);
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
			plStoryNewfeed.BackColor = System.Drawing.Color.White;
			plStoryNewfeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plStoryNewfeed.Controls.Add(label10);
			plStoryNewfeed.Controls.Add(rbStoryUser);
			plStoryNewfeed.Controls.Add(rbStoryNewfeed);
			plStoryNewfeed.Controls.Add(plStoryChiDinh);
			plStoryNewfeed.Controls.Add(panel2);
			plStoryNewfeed.Controls.Add(txtTenHanhDong);
			plStoryNewfeed.Controls.Add(label1);
			plStoryNewfeed.Controls.Add(btnCancel);
			plStoryNewfeed.Controls.Add(btnAdd);
			plStoryNewfeed.Controls.Add(bunifuCards1);
			plStoryNewfeed.Cursor = System.Windows.Forms.Cursors.Arrow;
			plStoryNewfeed.Dock = System.Windows.Forms.DockStyle.Fill;
			plStoryNewfeed.Location = new System.Drawing.Point(0, 0);
			plStoryNewfeed.Name = "plStoryNewfeed";
			plStoryNewfeed.Size = new System.Drawing.Size(362, 488);
			plStoryNewfeed.TabIndex = 0;
			plStoryNewfeed.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.Red;
			label10.Location = new System.Drawing.Point(46, 462);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(268, 16);
			label10.TabIndex = 107;
			label10.Text = "Chú ý: Chức năng na\u0300y chỉ chạy trên LDplayer!";
			label10.Visible = false;
			rbStoryUser.AutoSize = true;
			rbStoryUser.Cursor = System.Windows.Forms.Cursors.Hand;
			rbStoryUser.Location = new System.Drawing.Point(30, 170);
			rbStoryUser.Name = "rbStoryUser";
			rbStoryUser.Size = new System.Drawing.Size(157, 20);
			rbStoryUser.TabIndex = 106;
			rbStoryUser.TabStop = true;
			rbStoryUser.Text = "Story của user chỉ định";
			rbStoryUser.UseVisualStyleBackColor = true;
			rbStoryUser.CheckedChanged += new System.EventHandler(rbStoryUser_CheckedChanged);
			rbStoryNewfeed.AutoSize = true;
			rbStoryNewfeed.Cursor = System.Windows.Forms.Cursors.Hand;
			rbStoryNewfeed.Location = new System.Drawing.Point(29, 78);
			rbStoryNewfeed.Name = "rbStoryNewfeed";
			rbStoryNewfeed.Size = new System.Drawing.Size(123, 20);
			rbStoryNewfeed.TabIndex = 106;
			rbStoryNewfeed.TabStop = true;
			rbStoryNewfeed.Text = "Story ngâ\u0303u nhiên";
			rbStoryNewfeed.UseVisualStyleBackColor = true;
			rbStoryNewfeed.CheckedChanged += new System.EventHandler(rbStoryNewfeed_CheckedChanged);
			plStoryChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plStoryChiDinh.Controls.Add(txtListUser);
			plStoryChiDinh.Controls.Add(lblUser);
			plStoryChiDinh.Controls.Add(label2);
			plStoryChiDinh.Controls.Add(nudDelayChiDinhTo);
			plStoryChiDinh.Controls.Add(label8);
			plStoryChiDinh.Controls.Add(nudDelayChiDinhFrom);
			plStoryChiDinh.Controls.Add(label9);
			plStoryChiDinh.Enabled = false;
			plStoryChiDinh.Location = new System.Drawing.Point(29, 194);
			plStoryChiDinh.Name = "plStoryChiDinh";
			plStoryChiDinh.Size = new System.Drawing.Size(303, 214);
			plStoryChiDinh.TabIndex = 103;
			txtListUser.Location = new System.Drawing.Point(6, 24);
			txtListUser.Name = "txtListUser";
			txtListUser.Size = new System.Drawing.Size(291, 153);
			txtListUser.TabIndex = 45;
			txtListUser.Text = "";
			txtListUser.WordWrap = false;
			txtListUser.TextChanged += new System.EventHandler(txtListUser_TextChanged_1);
			lblUser.AutoSize = true;
			lblUser.Location = new System.Drawing.Point(3, 5);
			lblUser.Name = "lblUser";
			lblUser.Size = new System.Drawing.Size(155, 16);
			lblUser.TabIndex = 44;
			lblUser.Text = "Nhập danh sách User (0):";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1, 185);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(90, 16);
			label2.TabIndex = 41;
			label2.Text = "Thơ\u0300i gian chơ\u0300:";
			nudDelayChiDinhTo.Location = new System.Drawing.Point(210, 183);
			nudDelayChiDinhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayChiDinhTo.Name = "nudDelayChiDinhTo";
			nudDelayChiDinhTo.Size = new System.Drawing.Size(56, 23);
			nudDelayChiDinhTo.TabIndex = 40;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(268, 185);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(31, 16);
			label8.TabIndex = 42;
			label8.Text = "giây";
			nudDelayChiDinhFrom.Location = new System.Drawing.Point(113, 183);
			nudDelayChiDinhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayChiDinhFrom.Name = "nudDelayChiDinhFrom";
			nudDelayChiDinhFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayChiDinhFrom.TabIndex = 39;
			label9.Location = new System.Drawing.Point(175, 185);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(29, 16);
			label9.TabIndex = 43;
			label9.Text = "đê\u0301n";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label19);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(nudDelayTo);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(nudSoLuongStoryTo);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(nudDelayFrom);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(nudSoLuongStoryFrom);
			panel2.Controls.Add(label7);
			panel2.Enabled = false;
			panel2.Location = new System.Drawing.Point(29, 101);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(303, 65);
			panel2.TabIndex = 102;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(3, 7);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(98, 16);
			label19.TabIndex = 101;
			label19.Text = "Sô\u0301 lượng Story:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 36);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			nudDelayTo.Location = new System.Drawing.Point(208, 34);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 6;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(266, 7);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(36, 16);
			label4.TabIndex = 35;
			label4.Text = "story";
			nudSoLuongStoryTo.Location = new System.Drawing.Point(208, 5);
			nudSoLuongStoryTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongStoryTo.Name = "nudSoLuongStoryTo";
			nudSoLuongStoryTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongStoryTo.TabIndex = 4;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(266, 36);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			nudDelayFrom.Location = new System.Drawing.Point(111, 34);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 5;
			label3.Location = new System.Drawing.Point(173, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongStoryFrom.Location = new System.Drawing.Point(111, 5);
			nudSoLuongStoryFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongStoryFrom.Name = "nudSoLuongStoryFrom";
			nudSoLuongStoryFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongStoryFrom.TabIndex = 3;
			label7.Location = new System.Drawing.Point(173, 36);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			txtTenHanhDong.Location = new System.Drawing.Point(135, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(195, 23);
			txtTenHanhDong.TabIndex = 0;
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
			btnCancel.Location = new System.Drawing.Point(188, 425);
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
			btnAdd.Location = new System.Drawing.Point(81, 425);
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
			bunifuCards1.Size = new System.Drawing.Size(359, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(362, 488);
			base.Controls.Add(plStoryNewfeed);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDLuotStory";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			plStoryNewfeed.ResumeLayout(false);
			plStoryNewfeed.PerformLayout();
			plStoryChiDinh.ResumeLayout(false);
			plStoryChiDinh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayChiDinhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayChiDinhFrom).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongStoryTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongStoryFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
