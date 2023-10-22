using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fImportAccount : Form
	{
		public static bool isAddAccount = false;

		public static int idFileAdded = -1;

		public static bool isAddFile = false;

		private int indexOld = 0;

		private List<string> lstAccount = new List<string>();

		private List<Thread> lstThread = null;

		private List<ComboBox> lstCbbDinhDang;

		private object objLock = new object();

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnAdd;

		private Button btnCancel;

		private Label lblSuccess;

		private Label lblError;

		private Label lblTotal;

		private Label label3;

		private Label label4;

		private Label label7;

		private Label lblStatus;

		private Label label8;

		private ComboBox cbbDinhDangNhap;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private PictureBox pictureBox1;

		private Label label16;

		private ComboBox cbbThuMuc;

		private Button button1;

		private RichTextBox txbAccount;

		private Button btnMinimize;

		private Panel plDinhDangNhap;

		private ComboBox cbbDinhDang1;

		private ComboBox cbbDinhDang2;

		private ComboBox cbbDinhDang3;

		private ComboBox cbbDinhDang4;

		private Label label11;

		private Label label9;

		private Label label10;

		public fImportAccount(string idFile)
		{
			InitializeComponent();
			ChangeLanguage();
			Load_cbbThuMuc();
			if (idFile != "" && idFile != "-1" && idFile != "999999")
			{
				cbbThuMuc.SelectedValue = idFile;
			}
			cbbDinhDangNhap.SelectedIndex = 0;
			lstCbbDinhDang = new List<ComboBox> { cbbDinhDang1, cbbDinhDang2, cbbDinhDang3, cbbDinhDang4 };
			isAddFile = false;
			isAddAccount = false;
			idFileAdded = -1;
		}

		private void Load_cbbThuMuc()
		{
			indexOld = cbbThuMuc.SelectedIndex;
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase();
			if (allFilesFromDatabase.Rows.Count > 0)
			{
				cbbThuMuc.DataSource = allFilesFromDatabase;
				cbbThuMuc.ValueMember = "id";
				cbbThuMuc.DisplayMember = "name";
				if (indexOld == -1)
				{
					indexOld = 0;
				}
				cbbThuMuc.SelectedIndex = indexOld;
			}
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label7);
			Language.GetValue(label16);
			Language.GetValue(button1);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txbAccount.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhâ\u0323p thông tin ta\u0300i khoa\u0309n!"), 3);
					txbAccount.Focus();
					return;
				}
				if (cbbThuMuc.SelectedValue == null)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cho\u0323n thư mu\u0323c!"), 3);
					return;
				}
				string idFile = cbbThuMuc.SelectedValue.ToString();
				int selectedIndex = cbbDinhDangNhap.SelectedIndex;
				lblSuccess.Text = "0";
				lblError.Text = "0";
				lstAccount = new List<string>();
				int num = 0;
				switch (selectedIndex)
				{
				case 0:
				{
					num = 2;
					for (int k = 0; k < lst.Count; k++)
					{
						string[] array = lst[k].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add("|" + array[1] + "|||" + array[0] + "||||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 1:
				{
					num = 2;
					for (int m = 0; m < lst.Count; m++)
					{
						string[] array = lst[m].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add("|" + array[1] + "|||" + array[0] + "||" + array[2] + "||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 2:
				{
					num = 1;
					for (int n = 0; n < lst.Count; n++)
					{
						string[] array = lst[n].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add("|||" + array[0] + "|||||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 3:
				{
					num = 3;
					for (int l = 0; l < lst.Count; l++)
					{
						string[] array = lst[l].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add("|" + array[1] + "||" + array[2] + "|" + array[0] + "||||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 4:
				{
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					for (int i = 0; i < lst.Count; i++)
					{
						string[] array = lst[i].Split('|');
						text = "";
						text2 = "";
						text3 = "";
						text4 = "";
						try
						{
							for (int j = 0; j < lstCbbDinhDang.Count; j++)
							{
								switch (lstCbbDinhDang[j].SelectedIndex)
								{
								case 0:
									text2 = array[j];
									break;
								case 1:
									text = array[j];
									break;
								case 2:
									text4 = array[j];
									break;
								case 3:
									text3 = array[j];
									break;
								}
							}
							lstAccount.Add("|" + text + "||" + text3 + "|" + text2 + "||" + text4 + "||||");
						}
						catch
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				}
				string[] lstQuery = new string[lstAccount.Count];
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						btnAdd.Invoke((MethodInvoker)delegate
						{
							btnAdd.Enabled = false;
						});
						UpdateStatus(Language.GetValue("Check Info tài khoản..."), lblStatus);
						try
						{
							int dem = 0;
							int total = lstAccount.Count;
							int iThread = 0;
							int num2 = ((total < 100) ? total : 100);
							int num3 = 0;
							while (num3 < total)
							{
								if (iThread < num2)
								{
									Interlocked.Increment(ref iThread);
									int row = num3++;
									new Thread((ThreadStart)delegate
									{
										try
										{
											string text5 = lstAccount[row];
											if (text5.Trim() == "")
											{
												return;
											}
											string[] array2 = text5.Split('|');
											string text6 = "";
											string text7 = "";
											string text8 = "";
											string text9 = "";
											string text10 = "";
											string text11 = "";
											string text12 = "";
											string text13 = "";
											string text14 = "";
											string text15 = "";
											string text16 = "";
											text6 = array2[0];
											text7 = array2[1];
											text8 = array2[2];
											text9 = array2[3];
											text10 = array2[4];
											text11 = array2[5];
											text12 = array2[6];
											text13 = array2[7];
											text14 = array2[8];
											text15 = array2[9];
											text16 = array2[10];
											string name = "";
											string friends = "";
											string groups = "";
											string gender = "";
											string info = "unknow";
											if (text10 != "")
											{
												string uidIg = CommonRequest.GetUidIg(text10);
												if (uidIg.Trim() != "|")
												{
													text6 = uidIg.Split('|')[0];
													name = uidIg.Split('|')[1];
													info = "Live";
												}
												else if (!MCommon.Common.IsNumber(text10) && !MCommon.Common.IsValidMail(text10))
												{
													info = "Die";
												}
											}
											if (text6 == "")
											{
												text6 = Regex.Match(text9 + ";", "ds_user_id=(.*?);").Groups[1].Value;
											}
											lstQuery[row] = CommonSQL.ConvertToSqlInsertAccount(text6, text7, text8, text9, text10, name, friends, groups, text15, gender, info, text12, idFile, text11, text13, text14, text16);
										}
										catch
										{
										}
										Interlocked.Decrement(ref iThread);
										Interlocked.Increment(ref dem);
										UpdateStatus(Language.GetValue($"Check Info tài khoản {dem}/{total}..."), lblStatus);
									}).Start();
								}
								else
								{
									Application.DoEvents();
									Thread.Sleep(200);
								}
							}
							while (iThread > 0)
							{
								Application.DoEvents();
								Thread.Sleep(1000);
							}
						}
						catch
						{
						}
						UpdateStatus(Language.GetValue("Đang thêm tài khoản..."), lblStatus);
						if (lstQuery.Length >= 0)
						{
							List<string> list = CommonSQL.ConvertToSqlInsertAccount(lstQuery.ToList());
							for (int num4 = 0; num4 < list.Count; num4++)
							{
								IncrementLabel(lblSuccess, Connector.Instance.ExecuteNonQuery(list[num4]));
							}
						}
						UpdateStatus((Convert.ToInt32(lblTotal.Text) - Convert.ToInt32(lblSuccess.Text)).ToString() ?? "", lblError);
						btnAdd.Invoke((MethodInvoker)delegate
						{
							btnAdd.Enabled = true;
						});
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Thêm tài khoản thành công!"));
						UpdateStatus(Language.GetValue("Thêm tài khoản thành công!"), lblStatus);
						isAddAccount = true;
						idFileAdded = Convert.ToInt32(idFile);
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2, "AddAccount");
					}
				}).Start();
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đa\u0303 co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				MCommon.Common.ExportError(null, ex, "AddAccount");
			}
		}

		private void UpdateStatus(string content, Label lbl)
		{
			lbl.Invoke((MethodInvoker)delegate
			{
				Application.DoEvents();
				lbl.Text = content;
			});
		}

		private void TxbAccount_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txbAccount.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblTotal.Text = lst.Count.ToString();
			}
			catch
			{
			}
		}

		private void IncrementLabel(Label lbl, int count = -1)
		{
			if (count == -1)
			{
				lbl.Invoke((MethodInvoker)delegate
				{
					Application.DoEvents();
					lbl.Text = (Convert.ToInt32(lbl.Text) + ((count == -1) ? 1 : count)).ToString();
				});
			}
			else
			{
				lbl.Invoke((MethodInvoker)delegate
				{
					Application.DoEvents();
					lbl.Text = (Convert.ToInt32(lbl.Text) + count).ToString();
				});
			}
		}

		private void cbbDinhDangNhap_SelectedIndexChanged(object sender, EventArgs e)
		{
			plDinhDangNhap.Visible = cbbDinhDangNhap.SelectedIndex == cbbDinhDangNhap.Items.Count - 1;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fAddFile f = new fAddFile();
			MCommon.Common.ShowForm(f);
			if (fAddFile.isAdd)
			{
				Load_cbbThuMuc();
				cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 1;
				isAddFile = true;
			}
		}

		private void cbbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fImportAccount));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnAdd = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			lblSuccess = new System.Windows.Forms.Label();
			lblError = new System.Windows.Forms.Label();
			lblTotal = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			cbbDinhDangNhap = new System.Windows.Forms.ComboBox();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			label16 = new System.Windows.Forms.Label();
			cbbThuMuc = new System.Windows.Forms.ComboBox();
			button1 = new System.Windows.Forms.Button();
			txbAccount = new System.Windows.Forms.RichTextBox();
			plDinhDangNhap = new System.Windows.Forms.Panel();
			cbbDinhDang1 = new System.Windows.Forms.ComboBox();
			cbbDinhDang2 = new System.Windows.Forms.ComboBox();
			cbbDinhDang3 = new System.Windows.Forms.ComboBox();
			cbbDinhDang4 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			plDinhDangNhap.SuspendLayout();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(676, 37);
			bunifuCards1.TabIndex = 11;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(676, 31);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(645, 1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(30, 30);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnCancel_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(676, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Nhập Tài Khoản";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(226, 465);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(107, 31);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(340, 465);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(107, 31);
			btnCancel.TabIndex = 14;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			lblSuccess.AutoSize = true;
			lblSuccess.BackColor = System.Drawing.SystemColors.Control;
			lblSuccess.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblSuccess.ForeColor = System.Drawing.Color.FromArgb(53, 120, 229);
			lblSuccess.Location = new System.Drawing.Point(106, 51);
			lblSuccess.Name = "lblSuccess";
			lblSuccess.Size = new System.Drawing.Size(19, 19);
			lblSuccess.TabIndex = 23;
			lblSuccess.Text = "0";
			lblError.AutoSize = true;
			lblError.BackColor = System.Drawing.SystemColors.Control;
			lblError.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblError.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			lblError.Location = new System.Drawing.Point(298, 52);
			lblError.Name = "lblError";
			lblError.Size = new System.Drawing.Size(19, 19);
			lblError.TabIndex = 24;
			lblError.Text = "0";
			lblTotal.AutoSize = true;
			lblTotal.BackColor = System.Drawing.SystemColors.Control;
			lblTotal.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTotal.ForeColor = System.Drawing.Color.Teal;
			lblTotal.Location = new System.Drawing.Point(509, 51);
			lblTotal.Name = "lblTotal";
			lblTotal.Size = new System.Drawing.Size(19, 19);
			lblTotal.TabIndex = 26;
			lblTotal.Text = "0";
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label3.Location = new System.Drawing.Point(22, 53);
			label3.Name = "label3";
			label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label3.Size = new System.Drawing.Size(87, 16);
			label3.TabIndex = 34;
			label3.Text = "Tha\u0300nh công:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label4.Location = new System.Drawing.Point(250, 54);
			label4.Name = "label4";
			label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label4.Size = new System.Drawing.Size(52, 16);
			label4.TabIndex = 35;
			label4.Text = "Lỗi:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(450, 53);
			label7.Name = "label7";
			label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label7.Size = new System.Drawing.Size(63, 16);
			label7.TabIndex = 38;
			label7.Text = "Tô\u0309ng sô\u0301:";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.Location = new System.Drawing.Point(14, 80);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(646, 28);
			lblStatus.TabIndex = 27;
			lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(14, 397);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(97, 14);
			label8.TabIndex = 39;
			label8.Text = "Định dạng nhập:";
			cbbDinhDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDangNhap.FormattingEnabled = true;
			cbbDinhDangNhap.Items.AddRange(new object[5] { "User|Pass", "User|Pass|2FA", "Cookie", "User|Pass|Cookie", "Other..." });
			cbbDinhDangNhap.Location = new System.Drawing.Point(117, 394);
			cbbDinhDangNhap.Name = "cbbDinhDangNhap";
			cbbDinhDangNhap.Size = new System.Drawing.Size(269, 22);
			cbbDinhDangNhap.TabIndex = 40;
			cbbDinhDangNhap.SelectedIndexChanged += new System.EventHandler(cbbDinhDangNhap_SelectedIndexChanged);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(14, 368);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(90, 14);
			label16.TabIndex = 39;
			label16.Text = "Cho\u0323n thư mu\u0323c:";
			cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbThuMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbThuMuc.DropDownWidth = 269;
			cbbThuMuc.FormattingEnabled = true;
			cbbThuMuc.Location = new System.Drawing.Point(117, 365);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(201, 22);
			cbbThuMuc.TabIndex = 40;
			cbbThuMuc.SelectedIndexChanged += new System.EventHandler(cbbThuMuc_SelectedIndexChanged);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Location = new System.Drawing.Point(324, 364);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(62, 25);
			button1.TabIndex = 45;
			button1.Text = "Thêm";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			txbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txbAccount.Location = new System.Drawing.Point(15, 120);
			txbAccount.Name = "txbAccount";
			txbAccount.Size = new System.Drawing.Size(645, 238);
			txbAccount.TabIndex = 48;
			txbAccount.Text = "";
			txbAccount.WordWrap = false;
			txbAccount.TextChanged += new System.EventHandler(TxbAccount_TextChanged);
			plDinhDangNhap.Controls.Add(cbbDinhDang1);
			plDinhDangNhap.Controls.Add(cbbDinhDang2);
			plDinhDangNhap.Controls.Add(cbbDinhDang3);
			plDinhDangNhap.Controls.Add(cbbDinhDang4);
			plDinhDangNhap.Controls.Add(label11);
			plDinhDangNhap.Controls.Add(label9);
			plDinhDangNhap.Controls.Add(label10);
			plDinhDangNhap.Location = new System.Drawing.Point(114, 421);
			plDinhDangNhap.Name = "plDinhDangNhap";
			plDinhDangNhap.Size = new System.Drawing.Size(367, 28);
			plDinhDangNhap.TabIndex = 49;
			cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang1.FormattingEnabled = true;
			cbbDinhDang1.Items.AddRange(new object[4] { "User", "Pass", "2FA", "Cookie" });
			cbbDinhDang1.Location = new System.Drawing.Point(3, 3);
			cbbDinhDang1.Name = "cbbDinhDang1";
			cbbDinhDang1.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang1.TabIndex = 40;
			cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang2.FormattingEnabled = true;
			cbbDinhDang2.Items.AddRange(new object[4] { "User", "Pass", "2FA", "Cookie" });
			cbbDinhDang2.Location = new System.Drawing.Point(96, 3);
			cbbDinhDang2.Name = "cbbDinhDang2";
			cbbDinhDang2.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang2.TabIndex = 40;
			cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang3.FormattingEnabled = true;
			cbbDinhDang3.Items.AddRange(new object[4] { "User", "Pass", "2FA", "Cookie" });
			cbbDinhDang3.Location = new System.Drawing.Point(189, 3);
			cbbDinhDang3.Name = "cbbDinhDang3";
			cbbDinhDang3.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang3.TabIndex = 40;
			cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang4.FormattingEnabled = true;
			cbbDinhDang4.Items.AddRange(new object[4] { "User", "Pass", "2FA", "Cookie" });
			cbbDinhDang4.Location = new System.Drawing.Point(282, 3);
			cbbDinhDang4.Name = "cbbDinhDang4";
			cbbDinhDang4.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang4.TabIndex = 40;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 12f);
			label11.Location = new System.Drawing.Point(267, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(15, 19);
			label11.TabIndex = 41;
			label11.Text = "|";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 12f);
			label9.Location = new System.Drawing.Point(81, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(15, 19);
			label9.TabIndex = 41;
			label9.Text = "|";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 12f);
			label10.Location = new System.Drawing.Point(174, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(15, 19);
			label10.TabIndex = 41;
			label10.Text = "|";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(676, 509);
			base.Controls.Add(plDinhDangNhap);
			base.Controls.Add(txbAccount);
			base.Controls.Add(button1);
			base.Controls.Add(cbbThuMuc);
			base.Controls.Add(cbbDinhDangNhap);
			base.Controls.Add(label16);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(lblStatus);
			base.Controls.Add(lblTotal);
			base.Controls.Add(lblError);
			base.Controls.Add(lblSuccess);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fImportAccount";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Nhập tài khoản";
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			plDinhDangNhap.ResumeLayout(false);
			plDinhDangNhap.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
