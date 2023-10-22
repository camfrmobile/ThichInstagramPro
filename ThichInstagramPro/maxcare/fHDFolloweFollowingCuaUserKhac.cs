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
	public class fHDFolloweFollowingCuaUserKhac : Form
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

		private Label label49;

		private NumericUpDown nudSoLuongBanBeFrom;

		private Label label68;

		private NumericUpDown nudSoLuongBanBeTo;

		private Label label66;

		private Panel plComment;

		private RichTextBox txtLstUser;

		private Label lblStatus;

		private Label label21;

		private Label label18;

		private Label label16;

		private NumericUpDown nudTimeTo;

		private NumericUpDown nudTimeFrom;

		public fHDFolloweFollowingCuaUserKhac(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Follow Following của user khác";
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
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label68);
			Language.GetValue(label21);
			Language.GetValue(label16);
			Language.GetValue(label18);
			Language.GetValue(lblStatus);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongBanBeFrom.Value = setting.GetValueInt("nudSoLuongBanBeFrom", 1);
				nudSoLuongBanBeTo.Value = setting.GetValueInt("nudSoLuongBanBeTo", 3);
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 10);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 30);
				txtLstUser.Text = setting.GetValue("txtLstUser");
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
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudSoLuongBanBeFrom", nudSoLuongBanBeFrom.Value);
			jSON_Settings.Update("nudSoLuongBanBeTo", nudSoLuongBanBeTo.Value);
			jSON_Settings.Update("nudTimeFrom", nudTimeFrom.Value);
			jSON_Settings.Update("nudTimeTo", nudTimeTo.Value);
			jSON_Settings.Update("txtLstUser", txtLstUser.Text.Trim());
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
				List<string> list = new List<string>();
				list = txtLstUser.Lines.ToList();
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Danh sách user ({0}):"), list.Count.ToString());
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

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbShareWall_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void txtLstUser_TextChanged(object sender, EventArgs e)
		{
			MCommon.Common.UpdateCountLine(txtLstUser, lblStatus);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDFolloweFollowingCuaUserKhac));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plComment = new System.Windows.Forms.Panel();
			txtLstUser = new System.Windows.Forms.RichTextBox();
			lblStatus = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongBanBeFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudSoLuongBanBeTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(412, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Follow Following của user khác";
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
			pnlHeader.Size = new System.Drawing.Size(412, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(381, 1);
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
			panel1.Controls.Add(label21);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(nudTimeTo);
			panel1.Controls.Add(nudTimeFrom);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongBanBeFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(nudSoLuongBanBeTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(415, 416);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(txtLstUser);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(21, 136);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(381, 223);
			plComment.TabIndex = 130;
			txtLstUser.Location = new System.Drawing.Point(7, 27);
			txtLstUser.Name = "txtLstUser";
			txtLstUser.Size = new System.Drawing.Size(369, 191);
			txtLstUser.TabIndex = 106;
			txtLstUser.Text = "";
			txtLstUser.WordWrap = false;
			txtLstUser.TextChanged += new System.EventHandler(txtLstUser_TextChanged);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(122, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sách user (0):";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(18, 109);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(100, 16);
			label21.TabIndex = 127;
			label21.Text = "Thơ\u0300i gian delay:";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(312, 109);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(31, 16);
			label18.TabIndex = 128;
			label18.Text = "giây";
			label16.Location = new System.Drawing.Point(218, 109);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(29, 16);
			label16.TabIndex = 129;
			label16.Text = "đê\u0301n";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudTimeTo.Location = new System.Drawing.Point(253, 107);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(56, 23);
			nudTimeTo.TabIndex = 126;
			nudTimeFrom.Location = new System.Drawing.Point(156, 107);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(56, 23);
			nudTimeFrom.TabIndex = 125;
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(18, 80);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(132, 16);
			label49.TabIndex = 121;
			label49.Text = "Sô\u0301 lươ\u0323ng follow/user:";
			nudSoLuongBanBeFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongBanBeFrom.Location = new System.Drawing.Point(156, 78);
			nudSoLuongBanBeFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBanBeFrom.Name = "nudSoLuongBanBeFrom";
			nudSoLuongBanBeFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBanBeFrom.TabIndex = 119;
			nudSoLuongBanBeFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(314, 80);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(42, 16);
			label68.TabIndex = 122;
			label68.Text = "follow";
			nudSoLuongBanBeTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongBanBeTo.Location = new System.Drawing.Point(253, 78);
			nudSoLuongBanBeTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBanBeTo.Name = "nudSoLuongBanBeTo";
			nudSoLuongBanBeTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBanBeTo.TabIndex = 120;
			nudSoLuongBanBeTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.AutoSize = true;
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(218, 80);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 123;
			label66.Text = "đê\u0301n";
			txtTenHanhDong.Location = new System.Drawing.Point(156, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(213, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(18, 52);
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
			btnCancel.Location = new System.Drawing.Point(214, 374);
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
			btnAdd.Location = new System.Drawing.Point(107, 374);
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
			bunifuCards1.Size = new System.Drawing.Size(412, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(415, 416);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDFolloweFollowingCuaUserKhac";
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
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
