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
	public class fHDFollowTheoLink : Form
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

		private Label lblStatus;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label7;

		private Label label6;

		private Label label5;

		private RichTextBox txtUid;

		private ToolTip toolTip1;

		private Label label8;

		public fHDFollowTheoLink(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Follow theo link";
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
				txtUid.Text = setting.GetValue("txtUid");
			}
			catch
			{
			}
			CheckedChangeFull();
		}

		private void CheckedChangeFull()
		{
			ckbTuongTac_CheckedChanged(null, null);
			ckbTuongTacLike_CheckedChanged(null, null);
			ckbTuongTacComment_CheckedChanged(null, null);
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
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sách uid cần kết bạn!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("txtUid", txtUid.Text.Trim());
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
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch User câ\u0300n Follow ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbTuongTac_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbTuongTacComment_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbTuongTacLike_CheckedChanged(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDFollowTheoLink));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			txtUid = new System.Windows.Forms.RichTextBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			lblStatus = new System.Windows.Forms.Label();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(346, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Follow theo user";
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
			pnlHeader.Size = new System.Drawing.Size(346, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(315, 1);
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
			panel1.Controls.Add(label8);
			panel1.Controls.Add(txtUid);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(lblStatus);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(349, 355);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(21, 274);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(208, 16);
			label8.TabIndex = 136;
			label8.Text = "(Vui lo\u0300ng nhâ\u0323p user hoă\u0323c link user)";
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(24, 127);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(295, 143);
			txtUid.TabIndex = 114;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtComment_TextChanged);
			nudDelayTo.Location = new System.Drawing.Point(222, 78);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 4;
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(20, 107);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(188, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch User câ\u0300n Follow (0):";
			nudDelayFrom.Location = new System.Drawing.Point(125, 78);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 3;
			label7.Location = new System.Drawing.Point(187, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 46;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(280, 80);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 45;
			label6.Text = "giây";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(20, 80);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 44;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			txtTenHanhDong.Location = new System.Drawing.Point(125, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 52);
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
			btnCancel.Location = new System.Drawing.Point(184, 311);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 7;
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
			btnAdd.Location = new System.Drawing.Point(77, 311);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 6;
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
			bunifuCards1.Size = new System.Drawing.Size(346, 37);
			bunifuCards1.TabIndex = 28;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 0;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 0;
			toolTip1.ShowAlways = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(349, 355);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDFollowTheoLink";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
