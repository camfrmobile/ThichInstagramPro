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
	public class fHDTuongTacNewsfeed : Form
	{
		private JSON_Settings setting = null;

		private string id_KichBan;

		private string id_TuongTac;

		private string Id_HanhDong;

		private int type;

		public static bool isSave;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel panel1;

		private NumericUpDown nudTimeTo;

		private NumericUpDown nudTimeFrom;

		private TextBox txtTenHanhDong;

		private Label label3;

		private Label label4;

		private Label label2;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private Panel plCountComment;

		private NumericUpDown nudCountCommentFrom;

		private Label label13;

		private Label label14;

		private NumericUpDown nudCountCommentTo;

		private Panel plCountLike;

		private NumericUpDown nudCountLikeFrom;

		private Label label9;

		private Label label10;

		private NumericUpDown nudCountLikeTo;

		private Panel plComment;

		private RichTextBox txtComment;

		private Label lblStatus;

		private Label label8;

		public fHDTuongTacNewsfeed(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Tương tác Newsfeed";
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
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label10);
			Language.GetValue(label9);
			Language.GetValue(label14);
			Language.GetValue(label13);
			Language.GetValue(lblStatus);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 10);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 30);
				nudCountLikeFrom.Value = setting.GetValueInt("nudCountLikeFrom", 1);
				nudCountLikeTo.Value = setting.GetValueInt("nudCountLikeTo", 3);
				nudCountCommentFrom.Value = setting.GetValueInt("nudCountCommentFrom", 1);
				nudCountCommentTo.Value = setting.GetValueInt("nudCountCommentTo", 3);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
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
			if (ckbComment.Checked)
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!"), 3);
					return;
				}
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudTimeFrom", nudTimeFrom.Value);
			jSON_Settings.Update("nudTimeTo", nudTimeTo.Value);
			jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
			jSON_Settings.Update("ckbComment", ckbComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("nudCountLikeFrom", nudCountLikeFrom.Value);
			jSON_Settings.Update("nudCountLikeTo", nudCountLikeTo.Value);
			jSON_Settings.Update("nudCountCommentFrom", nudCountCommentFrom.Value);
			jSON_Settings.Update("nudCountCommentTo", nudCountCommentTo.Value);
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
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbShareWall_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plCountLike.Enabled = ckbInteract.Checked;
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plCountComment.Enabled = ckbComment.Checked;
			plComment.Enabled = ckbComment.Checked;
		}

		private void ckbShareWall_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDTuongTacNewsfeed));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plComment = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.RichTextBox();
			lblStatus = new System.Windows.Forms.Label();
			plCountComment = new System.Windows.Forms.Panel();
			nudCountCommentFrom = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			nudCountCommentTo = new System.Windows.Forms.NumericUpDown();
			plCountLike = new System.Windows.Forms.Panel();
			nudCountLikeFrom = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			nudCountLikeTo = new System.Windows.Forms.NumericUpDown();
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plComment.SuspendLayout();
			plCountComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).BeginInit();
			plCountLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
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
			bunifuCustomLabel1.Text = "Cấu hình Tương tác Newsfeed";
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
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(plCountComment);
			panel1.Controls.Add(plCountLike);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(nudTimeTo);
			panel1.Controls.Add(nudTimeFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(362, 384);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(label8);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(50, 165);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 167);
			plComment.TabIndex = 42;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 146);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(260, 16);
			label8.TabIndex = 193;
			label8.Text = "(Mỗi từ khóa 1 dòng, spin nội dung {a|b|c})";
			txtComment.Location = new System.Drawing.Point(7, 22);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(266, 122);
			txtComment.TabIndex = 106;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 3);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
			plCountComment.Controls.Add(nudCountCommentFrom);
			plCountComment.Controls.Add(label13);
			plCountComment.Controls.Add(label14);
			plCountComment.Controls.Add(nudCountCommentTo);
			plCountComment.Location = new System.Drawing.Point(136, 136);
			plCountComment.Name = "plCountComment";
			plCountComment.Size = new System.Drawing.Size(195, 25);
			plCountComment.TabIndex = 41;
			nudCountCommentFrom.Location = new System.Drawing.Point(1, 1);
			nudCountCommentFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentFrom.Name = "nudCountCommentFrom";
			nudCountCommentFrom.Size = new System.Drawing.Size(56, 23);
			nudCountCommentFrom.TabIndex = 1;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(157, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(25, 16);
			label13.TabIndex = 35;
			label13.Text = "lần";
			label14.Location = new System.Drawing.Point(63, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(29, 16);
			label14.TabIndex = 37;
			label14.Text = "đê\u0301n";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountCommentTo.Location = new System.Drawing.Point(98, 1);
			nudCountCommentTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentTo.Name = "nudCountCommentTo";
			nudCountCommentTo.Size = new System.Drawing.Size(56, 23);
			nudCountCommentTo.TabIndex = 2;
			plCountLike.Controls.Add(nudCountLikeFrom);
			plCountLike.Controls.Add(label9);
			plCountLike.Controls.Add(label10);
			plCountLike.Controls.Add(nudCountLikeTo);
			plCountLike.Location = new System.Drawing.Point(136, 105);
			plCountLike.Name = "plCountLike";
			plCountLike.Size = new System.Drawing.Size(195, 25);
			plCountLike.TabIndex = 39;
			nudCountLikeFrom.Location = new System.Drawing.Point(1, 1);
			nudCountLikeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeFrom.Name = "nudCountLikeFrom";
			nudCountLikeFrom.Size = new System.Drawing.Size(56, 23);
			nudCountLikeFrom.TabIndex = 1;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(157, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 16);
			label9.TabIndex = 35;
			label9.Text = "lần";
			label10.Location = new System.Drawing.Point(63, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 37;
			label10.Text = "đê\u0301n";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountLikeTo.Location = new System.Drawing.Point(98, 1);
			nudCountLikeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeTo.Name = "nudCountLikeTo";
			nudCountLikeTo.Size = new System.Drawing.Size(56, 23);
			nudCountLikeTo.TabIndex = 2;
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(30, 139);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(82, 20);
			ckbComment.TabIndex = 7;
			ckbComment.Text = "Comment";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(30, 107);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(100, 20);
			ckbInteract.TabIndex = 5;
			ckbInteract.Text = "Tha\u0309 cảm xúc";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			nudTimeTo.Location = new System.Drawing.Point(234, 77);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(56, 23);
			nudTimeTo.TabIndex = 2;
			nudTimeFrom.Location = new System.Drawing.Point(137, 77);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(56, 23);
			nudTimeFrom.TabIndex = 1;
			txtTenHanhDong.Location = new System.Drawing.Point(137, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label3.Location = new System.Drawing.Point(199, 79);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(292, 79);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 16);
			label4.TabIndex = 35;
			label4.Text = "giây";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 79);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(92, 16);
			label2.TabIndex = 32;
			label2.Text = "Thơ\u0300i gian lươ\u0301t:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(189, 341);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 10;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(82, 341);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 9;
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
			base.ClientSize = new System.Drawing.Size(362, 384);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTuongTacNewsfeed";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			plCountComment.ResumeLayout(false);
			plCountComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).EndInit();
			plCountLike.ResumeLayout(false);
			plCountLike.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
