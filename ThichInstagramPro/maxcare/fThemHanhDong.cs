using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fThemHanhDong : Form
	{
		private string id_KichBan;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button1;

		private GroupBox groupBox2;

		private PictureBox pictureBox2;

		private Panel panel1;

		private GroupBox groupBox3;

		private PictureBox pictureBox6;

		private ToolTip toolTip1;

		private MetroButton metroButton29;

		private MetroButton metroButton35;

		private GroupBox groupBox7;

		private PictureBox pictureBox8;

		private MetroButton metroButton16;

		private MetroButton metroButton19;

		private MetroButton metroButton1;

		private MetroButton metroButton6;

		private MetroButton metroButton5;

		private MetroButton metroButton4;

		private MetroButton metroButton3;

		private MetroButton btnLuotStory;

		private MetroButton btnUpAvatar;

		private MetroButton metroButton12;

		private MetroButton metroButton14;

		private MetroButton metroButton15;

		private GroupBox groupBox1;

		private MetroButton metroButton17;

		private MetroButton metroButton20;

		private MetroButton metroButton21;

		private PictureBox pictureBox3;

		private MetroButton metroButton22;

		private MetroButton metroButton23;

		private MetroButton metroButton25;

		private MetroButton metroButton26;

		private MetroButton metroButton27;

		public fThemHanhDong(string id_KichBan)
		{
			InitializeComponent();
			ChangeLanguage();
			this.id_KichBan = id_KichBan;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox2);
			Language.GetValue(metroButton29);
			Language.GetValue(groupBox3);
			Language.GetValue(metroButton35);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void metroButton13_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowGoiY(id_KichBan));
			if (fHDFollowGoiY.isSave)
			{
				Close();
			}
		}

		private void groupBox5_Enter(object sender, EventArgs e)
		{
		}

		private void metroButton18_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDUnFollow(id_KichBan));
			if (fHDUnFollow.isSave)
			{
				Close();
			}
		}

		private void metroButton9_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowTheoLink(id_KichBan));
			if (fHDFollowTheoLink.isSave)
			{
				Close();
			}
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

		private void metroButton1_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacNewsfeed(id_KichBan));
			if (fHDTuongTacNewsfeed.isSave)
			{
				Close();
			}
		}

		private void metroButton35_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNghiGiaiLao(id_KichBan));
			if (fHDNghiGiaiLao.isSave)
			{
				Close();
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				base.Height = 508;
			}
		}

		private void metroButton16_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacBaiVietChiDinh(id_KichBan));
			if (fHDTuongTacBaiVietChiDinh.isSave)
			{
				Close();
			}
		}

		private void metroButton19_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDSpamBaiViet(id_KichBan));
			if (fHDSpamBaiViet.isSave)
			{
				Close();
			}
		}

		private void metroButton1_Click_3(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNhanTinTheoLink(id_KichBan));
			if (fHDNhanTinTheoLink.isSave)
			{
				Close();
			}
		}

		private void metroButton13_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowTheoTuKhoa(id_KichBan));
			if (fHDFollowTheoTuKhoa.isSave)
			{
				Close();
			}
		}

		private void metroButton3_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacFollowers(id_KichBan));
			if (fHDTuongTacFollowers.isSave)
			{
				Close();
			}
		}

		private void metroButton4_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacFollowing(id_KichBan));
			if (fHDTuongTacFollowing.isSave)
			{
				Close();
			}
		}

		private void metroButton5_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNhanTinFollowers(id_KichBan));
			if (fHDNhanTinFollowers.isSave)
			{
				Close();
			}
		}

		private void metroButton6_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNhanTinFollowing(id_KichBan));
			if (fHDNhanTinFollowing.isSave)
			{
				Close();
			}
		}

		private void metroButton7_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowBackFollower(id_KichBan));
			if (fHDFollowBackFollower.isSave)
			{
				Close();
			}
		}

		private void btnLuotStory_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDLuotStory(id_KichBan));
			if (fHDLuotStory.isSave)
			{
				Close();
			}
		}

		private void btnUpAvatar_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDUpAvatar(id_KichBan));
			if (fHDUpAvatar.isSave)
			{
				Close();
			}
		}

		private void metroButton8_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDangBai(id_KichBan));
			if (fHDDangBai.isSave)
			{
				Close();
			}
		}

		private void metroButton8_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowLikedPost(id_KichBan));
			if (fHDFollowLikedPost.isSave)
			{
				Close();
			}
		}

		private void metroButton10_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFolloweFollowerCuaUserKhac(id_KichBan));
			if (fHDFolloweFollowerCuaUserKhac.isSave)
			{
				Close();
			}
		}

		private void metroButton11_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFolloweFollowingCuaUserKhac(id_KichBan));
			if (fHDFolloweFollowingCuaUserKhac.isSave)
			{
				Close();
			}
		}

		private void metroButton12_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDFollowTheoDiaDiem(id_KichBan));
			if (fHDFollowTheoDiaDiem.isSave)
			{
				Close();
			}
		}

		private void metroButton14_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDViewDiscover(id_KichBan));
			if (fHDViewDiscover.isSave)
			{
				Close();
			}
		}

		private void metroButton15_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDShareBaiViet(id_KichBan));
			if (fHDShareBaiViet.isSave)
			{
				Close();
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fThemHanhDong));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			groupBox2 = new System.Windows.Forms.GroupBox();
			metroButton15 = new MetroFramework.Controls.MetroButton();
			btnLuotStory = new MetroFramework.Controls.MetroButton();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			metroButton6 = new MetroFramework.Controls.MetroButton();
			metroButton5 = new MetroFramework.Controls.MetroButton();
			metroButton1 = new MetroFramework.Controls.MetroButton();
			metroButton4 = new MetroFramework.Controls.MetroButton();
			metroButton3 = new MetroFramework.Controls.MetroButton();
			metroButton29 = new MetroFramework.Controls.MetroButton();
			metroButton16 = new MetroFramework.Controls.MetroButton();
			panel1 = new System.Windows.Forms.Panel();
			groupBox7 = new System.Windows.Forms.GroupBox();
			metroButton14 = new MetroFramework.Controls.MetroButton();
			btnUpAvatar = new MetroFramework.Controls.MetroButton();
			pictureBox8 = new System.Windows.Forms.PictureBox();
			metroButton35 = new MetroFramework.Controls.MetroButton();
			groupBox3 = new System.Windows.Forms.GroupBox();
			metroButton12 = new MetroFramework.Controls.MetroButton();
			pictureBox6 = new System.Windows.Forms.PictureBox();
			metroButton19 = new MetroFramework.Controls.MetroButton();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			groupBox1 = new System.Windows.Forms.GroupBox();
			metroButton17 = new MetroFramework.Controls.MetroButton();
			metroButton20 = new MetroFramework.Controls.MetroButton();
			metroButton21 = new MetroFramework.Controls.MetroButton();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			metroButton22 = new MetroFramework.Controls.MetroButton();
			metroButton23 = new MetroFramework.Controls.MetroButton();
			metroButton25 = new MetroFramework.Controls.MetroButton();
			metroButton26 = new MetroFramework.Controls.MetroButton();
			metroButton27 = new MetroFramework.Controls.MetroButton();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel1.SuspendLayout();
			groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(848, 31);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Danh sách hành động";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(848, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(816, 1);
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
			bunifuCards1.Size = new System.Drawing.Size(848, 37);
			bunifuCards1.TabIndex = 0;
			groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox2.Controls.Add(metroButton14);
			groupBox2.Controls.Add(btnLuotStory);
			groupBox2.Controls.Add(pictureBox2);
			groupBox2.Controls.Add(metroButton6);
			groupBox2.Controls.Add(metroButton5);
			groupBox2.Controls.Add(metroButton1);
			groupBox2.Controls.Add(metroButton4);
			groupBox2.Controls.Add(metroButton3);
			groupBox2.Controls.Add(metroButton29);
			groupBox2.Location = new System.Drawing.Point(9, 43);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(200, 400);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tương tác - Nhă\u0301n tin";
			metroButton15.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton15.Location = new System.Drawing.Point(14, 194);
			metroButton15.Name = "metroButton15";
			metroButton15.Size = new System.Drawing.Size(171, 23);
			metroButton15.TabIndex = 6;
			metroButton15.Text = "Share bài viết";
			metroButton15.UseSelectable = true;
			metroButton15.Click += new System.EventHandler(metroButton15_Click);
			btnLuotStory.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLuotStory.Location = new System.Drawing.Point(14, 310);
			btnLuotStory.Name = "btnLuotStory";
			btnLuotStory.Size = new System.Drawing.Size(171, 23);
			btnLuotStory.TabIndex = 3;
			btnLuotStory.Text = "Lướt story";
			btnLuotStory.UseSelectable = true;
			btnLuotStory.Click += new System.EventHandler(btnLuotStory_Click);
			pictureBox2.Image = maxcare.Properties.Resources.Cach_check_follow_ao_Instagram;
			pictureBox2.Location = new System.Drawing.Point(14, 34);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(171, 83);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			metroButton6.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton6.Location = new System.Drawing.Point(14, 281);
			metroButton6.Name = "metroButton6";
			metroButton6.Size = new System.Drawing.Size(171, 23);
			metroButton6.TabIndex = 5;
			metroButton6.Text = "Nhă\u0301n tin vơ\u0301i Following";
			metroButton6.UseSelectable = true;
			metroButton6.Click += new System.EventHandler(metroButton6_Click);
			metroButton5.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton5.Location = new System.Drawing.Point(14, 252);
			metroButton5.Name = "metroButton5";
			metroButton5.Size = new System.Drawing.Size(171, 23);
			metroButton5.TabIndex = 4;
			metroButton5.Text = "Nhă\u0301n tin vơ\u0301i Followers";
			metroButton5.UseSelectable = true;
			metroButton5.Click += new System.EventHandler(metroButton5_Click);
			metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton1.Location = new System.Drawing.Point(14, 223);
			metroButton1.Name = "metroButton1";
			metroButton1.Size = new System.Drawing.Size(171, 23);
			metroButton1.TabIndex = 3;
			metroButton1.Text = "Nhă\u0301n tin theo User";
			metroButton1.UseSelectable = true;
			metroButton1.Click += new System.EventHandler(metroButton1_Click_3);
			metroButton4.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton4.Location = new System.Drawing.Point(14, 194);
			metroButton4.Name = "metroButton4";
			metroButton4.Size = new System.Drawing.Size(171, 23);
			metroButton4.TabIndex = 2;
			metroButton4.Text = "Tương tác vơ\u0301i Following";
			metroButton4.UseSelectable = true;
			metroButton4.Click += new System.EventHandler(metroButton4_Click);
			metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton3.Location = new System.Drawing.Point(14, 165);
			metroButton3.Name = "metroButton3";
			metroButton3.Size = new System.Drawing.Size(171, 23);
			metroButton3.TabIndex = 1;
			metroButton3.Text = "Tương tác vơ\u0301i Followers";
			metroButton3.UseSelectable = true;
			metroButton3.Click += new System.EventHandler(metroButton3_Click_1);
			metroButton29.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton29.Location = new System.Drawing.Point(14, 136);
			metroButton29.Name = "metroButton29";
			metroButton29.Size = new System.Drawing.Size(171, 23);
			metroButton29.TabIndex = 0;
			metroButton29.Text = "Tương tác Newsfeed";
			metroButton29.UseSelectable = true;
			metroButton29.Click += new System.EventHandler(metroButton1_Click_1);
			metroButton16.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton16.Location = new System.Drawing.Point(14, 165);
			metroButton16.Name = "metroButton16";
			metroButton16.Size = new System.Drawing.Size(171, 23);
			metroButton16.TabIndex = 1;
			metroButton16.Text = "Tương ta\u0301c Ba\u0300i viê\u0301t chi\u0309 đi\u0323nh";
			metroButton16.UseSelectable = true;
			metroButton16.Click += new System.EventHandler(metroButton16_Click_1);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox7);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox3);
			panel1.Controls.Add(bunifuCards1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(851, 452);
			panel1.TabIndex = 25;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox7.Controls.Add(btnUpAvatar);
			groupBox7.Controls.Add(pictureBox8);
			groupBox7.Controls.Add(metroButton35);
			groupBox7.Location = new System.Drawing.Point(641, 43);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(200, 399);
			groupBox7.TabIndex = 4;
			groupBox7.TabStop = false;
			groupBox7.Text = "Chư\u0301c năng kha\u0301c";
			groupBox7.Enter += new System.EventHandler(groupBox5_Enter);
			metroButton14.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton14.Location = new System.Drawing.Point(14, 339);
			metroButton14.Name = "metroButton14";
			metroButton14.Size = new System.Drawing.Size(171, 23);
			metroButton14.TabIndex = 3;
			metroButton14.Text = "View Discover";
			metroButton14.UseSelectable = true;
			metroButton14.Click += new System.EventHandler(metroButton14_Click);
			btnUpAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUpAvatar.Location = new System.Drawing.Point(14, 164);
			btnUpAvatar.Name = "btnUpAvatar";
			btnUpAvatar.Size = new System.Drawing.Size(171, 23);
			btnUpAvatar.TabIndex = 2;
			btnUpAvatar.Text = "Up Avatar";
			btnUpAvatar.UseSelectable = true;
			btnUpAvatar.Click += new System.EventHandler(btnUpAvatar_Click);
			pictureBox8.Image = maxcare.Properties.Resources._2_B_Facebook;
			pictureBox8.Location = new System.Drawing.Point(14, 34);
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new System.Drawing.Size(171, 83);
			pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox8.TabIndex = 1;
			pictureBox8.TabStop = false;
			metroButton35.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton35.Location = new System.Drawing.Point(14, 135);
			metroButton35.Name = "metroButton35";
			metroButton35.Size = new System.Drawing.Size(171, 23);
			metroButton35.TabIndex = 0;
			metroButton35.Text = "Nghỉ giải lao";
			metroButton35.UseSelectable = true;
			metroButton35.Click += new System.EventHandler(metroButton35_Click);
			groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox3.Controls.Add(metroButton15);
			groupBox3.Controls.Add(pictureBox6);
			groupBox3.Controls.Add(metroButton16);
			groupBox3.Controls.Add(metroButton19);
			groupBox3.Location = new System.Drawing.Point(214, 42);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(200, 400);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Spam - Seeding";
			groupBox3.Enter += new System.EventHandler(groupBox5_Enter);
			metroButton12.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton12.Location = new System.Drawing.Point(14, 194);
			metroButton12.Name = "metroButton12";
			metroButton12.Size = new System.Drawing.Size(171, 23);
			metroButton12.TabIndex = 9;
			metroButton12.Text = "Follow theo địa điểm";
			metroButton12.UseSelectable = true;
			metroButton12.Click += new System.EventHandler(metroButton12_Click);
			pictureBox6.Image = maxcare.Properties.Resources._5480_p3kd5t8zvhepwnxbpyugpea1nmd56562ivikdcjgw0;
			pictureBox6.Location = new System.Drawing.Point(14, 34);
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new System.Drawing.Size(171, 83);
			pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox6.TabIndex = 1;
			pictureBox6.TabStop = false;
			metroButton19.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton19.Location = new System.Drawing.Point(14, 136);
			metroButton19.Name = "metroButton19";
			metroButton19.Size = new System.Drawing.Size(171, 23);
			metroButton19.TabIndex = 1;
			metroButton19.Text = "Spam ba\u0300i viê\u0301t";
			metroButton19.UseSelectable = true;
			metroButton19.Click += new System.EventHandler(metroButton19_Click);
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 0;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 0;
			groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox1.Controls.Add(metroButton12);
			groupBox1.Controls.Add(metroButton17);
			groupBox1.Controls.Add(metroButton20);
			groupBox1.Controls.Add(metroButton21);
			groupBox1.Controls.Add(pictureBox3);
			groupBox1.Controls.Add(metroButton22);
			groupBox1.Controls.Add(metroButton23);
			groupBox1.Controls.Add(metroButton25);
			groupBox1.Controls.Add(metroButton26);
			groupBox1.Controls.Add(metroButton27);
			groupBox1.Location = new System.Drawing.Point(420, 42);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(200, 400);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Follow";
			groupBox1.Enter += new System.EventHandler(groupBox5_Enter);
			metroButton17.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton17.Location = new System.Drawing.Point(14, 281);
			metroButton17.Name = "metroButton17";
			metroButton17.Size = new System.Drawing.Size(171, 23);
			metroButton17.TabIndex = 6;
			metroButton17.Text = "Follow user liked post";
			metroButton17.UseSelectable = true;
			metroButton17.Click += new System.EventHandler(metroButton8_Click_1);
			metroButton20.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton20.Location = new System.Drawing.Point(14, 339);
			metroButton20.Name = "metroButton20";
			metroButton20.Size = new System.Drawing.Size(171, 23);
			metroButton20.TabIndex = 8;
			metroButton20.Text = "Follow following của user";
			metroButton20.UseSelectable = true;
			metroButton20.Click += new System.EventHandler(metroButton11_Click);
			metroButton21.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton21.Location = new System.Drawing.Point(14, 252);
			metroButton21.Name = "metroButton21";
			metroButton21.Size = new System.Drawing.Size(171, 23);
			metroButton21.TabIndex = 5;
			metroButton21.Text = "Follow lại followers";
			metroButton21.UseSelectable = true;
			metroButton21.Click += new System.EventHandler(metroButton7_Click);
			pictureBox3.Image = maxcare.Properties.Resources.follow_unfollow;
			pictureBox3.Location = new System.Drawing.Point(14, 34);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(171, 83);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 1;
			pictureBox3.TabStop = false;
			metroButton22.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton22.Location = new System.Drawing.Point(14, 310);
			metroButton22.Name = "metroButton22";
			metroButton22.Size = new System.Drawing.Size(171, 23);
			metroButton22.TabIndex = 7;
			metroButton22.Text = "Follow follower của user";
			metroButton22.UseSelectable = true;
			metroButton22.Click += new System.EventHandler(metroButton10_Click);
			metroButton23.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton23.Location = new System.Drawing.Point(14, 364);
			metroButton23.Name = "metroButton23";
			metroButton23.Size = new System.Drawing.Size(171, 23);
			metroButton23.TabIndex = 2;
			metroButton23.Text = "UnFollow";
			metroButton23.UseSelectable = true;
			metroButton23.Click += new System.EventHandler(metroButton18_Click);
			metroButton25.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton25.Location = new System.Drawing.Point(14, 223);
			metroButton25.Name = "metroButton25";
			metroButton25.Size = new System.Drawing.Size(171, 23);
			metroButton25.TabIndex = 4;
			metroButton25.Text = "Follow theo user";
			metroButton25.UseSelectable = true;
			metroButton25.Click += new System.EventHandler(metroButton9_Click);
			metroButton26.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton26.Location = new System.Drawing.Point(14, 136);
			metroButton26.Name = "metroButton26";
			metroButton26.Size = new System.Drawing.Size(171, 23);
			metroButton26.TabIndex = 1;
			metroButton26.Text = "Follow theo gợi ý";
			metroButton26.UseSelectable = true;
			metroButton26.Click += new System.EventHandler(metroButton13_Click);
			metroButton27.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton27.Location = new System.Drawing.Point(14, 165);
			metroButton27.Name = "metroButton27";
			metroButton27.Size = new System.Drawing.Size(171, 23);
			metroButton27.TabIndex = 1;
			metroButton27.Text = "Follow theo tư\u0300 kho\u0301a";
			metroButton27.UseSelectable = true;
			metroButton27.Click += new System.EventHandler(metroButton13_Click_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(851, 452);
			base.Controls.Add(groupBox2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fThemHanhDong";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			bunifuCards1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel1.ResumeLayout(false);
			groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			ResumeLayout(false);
		}
	}
}
