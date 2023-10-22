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
	public class fHDTuongTacBaiVietChiDinh : Form
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

		private NumericUpDown nudTimeTo;

		private NumericUpDown nudTimeFrom;

		private Label label9;

		private Label label4;

		private Label label3;

		private Panel plComment;

		private RichTextBox txtComment;

		private Label lblStatus;

		private CheckBox ckbComment;

		private TextBox txtIdPost;

		private CheckBox ckbInteract;

		private Label label8;

		public fHDTuongTacBaiVietChiDinh(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Tương ta\u0301c ba\u0300i viê\u0301t chi\u0309 đi\u0323nh";
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
			Language.GetValue(label9);
			Language.GetValue(label4);
			Language.GetValue(ckbInteract);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 3);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 5);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				setting.GetValue("typeReaction");
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
				txtIdPost.Text = setting.GetValue("txtIdPost");
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
			List<string> lst = txtIdPost.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch Id ba\u0300i viê\u0301t câ\u0300n buff like, comment!"), 3);
				return;
			}
			if (ckbComment.Checked)
			{
				List<string> lst2 = txtComment.Lines.ToList();
				lst2 = MCommon.Common.RemoveEmptyItems(lst2);
				if (lst2.Count == 0)
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
			jSON_Settings.Update("txtIdPost", txtIdPost.Text.Trim());
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
			ckbInteract_CheckedChanged(null, null);
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void txtIdPost_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtIdPost.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label2.Text = string.Format(Language.GetValue("Danh sa\u0301ch ID bài viết ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void panel1_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void txtComment_TextChanged_1(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = txtComment.Lines.ToList();
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDTuongTacBaiVietChiDinh));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			ckbInteract = new System.Windows.Forms.CheckBox();
			plComment = new System.Windows.Forms.Panel();
			txtComment = new System.Windows.Forms.RichTextBox();
			lblStatus = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			txtIdPost = new System.Windows.Forms.TextBox();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			label8 = new System.Windows.Forms.Label();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plComment.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(323, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh Tương ta\u0301c ba\u0300i viê\u0301t";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(323, 31);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(332, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 77;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(nudTimeTo);
			panel1.Controls.Add(nudTimeFrom);
			panel1.Controls.Add(txtIdPost);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(367, 406);
			panel1.TabIndex = 0;
			panel1.Click += new System.EventHandler(panel1_Click);
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(30, 140);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(100, 20);
			ckbInteract.TabIndex = 167;
			ckbInteract.Text = "Tha\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(label8);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(48, 189);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 151);
			plComment.TabIndex = 164;
			txtComment.Location = new System.Drawing.Point(7, 25);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(263, 102);
			txtComment.TabIndex = 1;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged_1);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(30, 166);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(82, 20);
			ckbComment.TabIndex = 163;
			ckbComment.Text = "Comment";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 82);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(80, 16);
			label2.TabIndex = 40;
			label2.Text = "Link ba\u0300i viê\u0301t:";
			nudTimeTo.Location = new System.Drawing.Point(246, 108);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(51, 23);
			nudTimeTo.TabIndex = 4;
			nudTimeFrom.Location = new System.Drawing.Point(168, 108);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(51, 23);
			nudTimeFrom.TabIndex = 3;
			txtIdPost.Location = new System.Drawing.Point(136, 79);
			txtIdPost.Name = "txtIdPost";
			txtIdPost.Size = new System.Drawing.Size(194, 23);
			txtIdPost.TabIndex = 0;
			txtTenHanhDong.Location = new System.Drawing.Point(136, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label9.Location = new System.Drawing.Point(219, 110);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(29, 16);
			label9.TabIndex = 38;
			label9.Text = "đê\u0301n";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(299, 110);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 16);
			label4.TabIndex = 36;
			label4.Text = "giây";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(27, 110);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(139, 16);
			label3.TabIndex = 34;
			label3.Text = "Thơ\u0300i gian xem bài viết:";
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
			btnCancel.Location = new System.Drawing.Point(191, 361);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 10;
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
			btnAdd.Location = new System.Drawing.Point(84, 361);
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
			bunifuCards1.Controls.Add(button1);
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(365, 37);
			bunifuCards1.TabIndex = 28;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 130);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(266, 16);
			label8.TabIndex = 2;
			label8.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(367, 406);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTuongTacBaiVietChiDinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
