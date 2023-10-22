using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;
using Newtonsoft.Json.Linq;

namespace maxcare
{
	public class fCauHinhChung : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Label label3;

		private NumericUpDown nudInteractThread;

		private Label label4;

		private Label label5;

		private NumericUpDown nudHideThread;

		private Label label6;

		private Panel panel1;

		private GroupBox groupBox2;

		private GroupBox groupBox3;

		private ComboBox cbbHostpot;

		private Button button5;

		private Panel plNordVPN;

		private Label label14;

		private TextBox txtNordVPN;

		private Panel plDcom;

		private TextBox txtProfileNameDcom;

		private Button btnSSH;

		private Label label26;

		private Label label27;

		private RadioButton rbSSH;

		private RadioButton rbExpressVPN;

		private NumericUpDown nudChangeIpCount;

		private RadioButton rbNordVPN;

		private RadioButton rbHotspot;

		private RadioButton rbDcom;

		private RadioButton rbHma;

		private BunifuDragControl bunifuDragControl1;

		private ToolTip toolTip1;

		private Button btnCancel;

		private Button btnSave;

		private BunifuCards bunifuCards2;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button2;

		private Panel plTinsoft;

		private ComboBox cbbLocationTinsoft;

		private Label label7;

		private Label label1;

		private TextBox txtApiUser;

		private Label label8;

		private NumericUpDown nudLuongPerIPTinsoft;

		private RadioButton rbTinsoft;

		private Button button3;

		private Panel panel2;

		private Label label12;

		private TextBox textBox1;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private Panel plXproxy;

		private RadioButton rbSock5Proxy;

		private RadioButton rbHttpProxy;

		private Label label16;

		private Label label17;

		private Label label13;

		private TextBox txtServiceURLXProxy;

		private RadioButton rbXproxy;

		private RichTextBox txtListProxy;

		private Label label18;

		private NumericUpDown nudLuongPerIPXProxy;

		private Panel plCheckDoiIP;

		private RadioButton rbProxy;

		private Button button4;

		private NumericUpDown nudDelayOpenDeviceTo;

		private Label label21;

		private Panel plTMProxy;

		private RichTextBox txtApiKeyTMProxy;

		private Label label24;

		private Label label25;

		private NumericUpDown nudLuongPerIPTMProxy;

		private RadioButton rbTMProxy;

		private LinkLabel linkLabel1;

		private GroupBox groupBox1;

		private RadioButton rbPhanBietMauChu;

		private RadioButton rbPhanBietMauNen;

		private Label label23;

		private LinkLabel linkLabel3;

		private Panel plApiProxy;

		private Label lblCountApiProxy;

		private Label label28;

		private TextBox txtApiProxy;

		private Button button7;

		private Panel plApiUser;

		private RadioButton rbApiProxy;

		private RadioButton rbApiUser;

		private CheckBox ckbWaitDoneAllXproxy;

		private NumericUpDown nudDelayOpenDeviceFrom;

		private Label label29;

		private CheckBox ckbWaitDoneAllTinsoft;

		private CheckBox ckbWaitDoneAllTMProxy;

		private NumericUpDown nudDelayCloseDeviceFrom;

		private NumericUpDown nudDelayCloseDeviceTo;

		private Label label32;

		private Label label31;

		private Label label2;

		private Button button8;

		private Panel panel4;

		private CheckBox ckbKhongCheckIP;

		private RadioButton rbNone;

		private Panel plDelayMoChrome;

		private RadioButton rbMoCachNhau;

		private RadioButton rbMoLanLuot;

		private Label label9;

		private CheckBox ckbKhongAddVaoFormView;

		private Panel panel3;

		private LinkLabel linkLabel2;

		private Panel plLDPlayerThuong;

		private Label label11;

		private TextBox txtLDPathThuong;

		private Panel plLDPlayerSwap;

		private Label label36;

		private TextBox txtLDPathSwap;

		private RadioButton rbLDThuong;

		private RadioButton rbLDSwap;

		private Label label10;

		private TabControl tcCauHinhNenTang;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Panel plSapXepCuaSoChrome;

		private Label label15;

		private Label label19;

		private ComboBox cbbColumnChrome;

		private ComboBox cbbRowChrome;

		private Panel plAddChromeVaoFormView;

		private NumericUpDown nudWidthChrome;

		private Label label35;

		private Label label33;

		private NumericUpDown nudHeighChrome;

		private NumericUpDown nudDelayCloseChromeFrom;

		private NumericUpDown nudDelayCloseChromeTo;

		private NumericUpDown nudDelayOpenChromeFrom;

		private NumericUpDown nudDelayOpenChromeTo;

		private CheckBox ckbShowImageInteract;

		private CheckBox ckbAddChromeIntoForm;

		private Label label20;

		private Label label22;

		private Label label30;

		private Label label34;

		private Label label37;

		private Label label38;

		private Label label39;

		private TextBox txbPathProfile;

		private Label label40;

		private RadioButton rbLoginCookie;

		private RadioButton rbLoginUserPass;

		private CheckBox ckbCreateProfile;

		public fCauHinhChung()
		{
			InitializeComponent();
			settings = new JSON_Settings("configGeneral");
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox2);
			Language.GetValue(label3);
			Language.GetValue(label6);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label29);
			Language.GetValue(label21);
			Language.GetValue(label2);
			Language.GetValue(label32);
			Language.GetValue(label31);
			Language.GetValue(groupBox1);
			Language.GetValue(label23);
			Language.GetValue(rbPhanBietMauNen);
			Language.GetValue(rbPhanBietMauChu);
			Language.GetValue(groupBox3);
			Language.GetValue(ckbKhongCheckIP);
			Language.GetValue(label26);
			Language.GetValue(label27);
			Language.GetValue(button5);
			Language.GetValue(rbNone);
			Language.GetValue(rbProxy);
			Language.GetValue(rbHma);
			Language.GetValue(rbDcom);
			Language.GetValue(button4);
			Language.GetValue(rbTinsoft);
			Language.GetValue(linkLabel3);
			Language.GetValue(rbApiUser);
			Language.GetValue(ckbWaitDoneAllTinsoft);
			Language.GetValue(rbApiProxy);
			Language.GetValue(label7);
			Language.GetValue(label8);
			Language.GetValue(label16);
			Language.GetValue(label17);
			Language.GetValue(ckbWaitDoneAllXproxy);
			Language.GetValue(label18);
			Language.GetValue(linkLabel1);
			Language.GetValue(label24);
			Language.GetValue(ckbWaitDoneAllTMProxy);
			Language.GetValue(label25);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
		}

		private void LoadCbbLocation()
		{
			Dictionary<string, string> dataSource = TinsoftGetListLocation();
			cbbLocationTinsoft.DataSource = new BindingSource(dataSource, null);
			cbbLocationTinsoft.ValueMember = "Key";
			cbbLocationTinsoft.DisplayMember = "Value";
		}

		public Dictionary<string, string> TinsoftGetListLocation()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			List<string> listCountryTinsoft = SetupFolder.GetListCountryTinsoft();
			for (int i = 0; i < listCountryTinsoft.Count; i++)
			{
				string[] array = listCountryTinsoft[i].Split('|');
				dictionary.Add(array[0], array[1]);
			}
			return dictionary;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FConfigGenneral_Load(object sender, EventArgs e)
		{
			LoadCbbLocation();
			LoadCbbColumnChrome();
			nudInteractThread.Value = Convert.ToInt32((settings.GetValue("nudInteractThread") == "") ? "3" : settings.GetValue("nudInteractThread"));
			nudHideThread.Value = Convert.ToInt32((settings.GetValue("nudHideThread") == "") ? "5" : settings.GetValue("nudHideThread"));
			ckbKhongAddVaoFormView.Checked = settings.GetValueBool("ckbKhongAddVaoFormView");
			txtLDPathThuong.Text = settings.GetValue("txtLDPathThuong");
			if (settings.GetValueInt("typeOpenDevice") == 0)
			{
				rbMoLanLuot.Checked = true;
			}
			else
			{
				rbMoCachNhau.Checked = true;
			}
			nudDelayOpenDeviceFrom.Value = settings.GetValueInt("nudDelayOpenDeviceFrom", 1);
			nudDelayOpenDeviceTo.Value = settings.GetValueInt("nudDelayOpenDeviceTo", 1);
			nudDelayCloseDeviceFrom.Value = settings.GetValueInt("nudDelayCloseDeviceFrom");
			nudDelayCloseDeviceTo.Value = settings.GetValueInt("nudDelayCloseDeviceTo");
			txbPathProfile.Text = ((settings.GetValue("txbPathProfile") == "") ? (Application.StartupPath + "\\profiles") : settings.GetValue("txbPathProfile"));
			if (!Directory.Exists(txbPathProfile.Text) || txbPathProfile.Text.Trim() == "profiles")
			{
				txbPathProfile.Text = Application.StartupPath + "\\profiles";
			}
			if (settings.GetValueInt("typeLogin") == 0)
			{
				rbLoginUserPass.Checked = true;
			}
			else
			{
				rbLoginCookie.Checked = true;
			}
			ckbCreateProfile.Checked = settings.GetValueBool("ckbCreateProfile");
			ckbShowImageInteract.Checked = settings.GetValueBool("ckbShowImageInteract");
			ckbAddChromeIntoForm.Checked = settings.GetValueBool("ckbAddChromeIntoForm");
			nudWidthChrome.Value = settings.GetValueInt("nudWidthChrome", 320);
			nudHeighChrome.Value = settings.GetValueInt("nudHeighChrome", 480);
			nudDelayOpenChromeFrom.Value = settings.GetValueInt("nudDelayOpenChromeFrom", 1);
			nudDelayOpenChromeTo.Value = settings.GetValueInt("nudDelayOpenChromeTo", 1);
			nudDelayCloseChromeFrom.Value = settings.GetValueInt("nudDelayCloseChromeFrom");
			nudDelayCloseChromeTo.Value = settings.GetValueInt("nudDelayCloseChromeTo");
			cbbColumnChrome.Text = ((settings.GetValue("cbbColumnChrome") == "") ? "3" : settings.GetValue("cbbColumnChrome"));
			cbbRowChrome.Text = ((settings.GetValue("cbbRowChrome") == "") ? "2" : settings.GetValue("cbbRowChrome"));
			ckbKhongCheckIP.Checked = settings.GetValueBool("ckbKhongCheckIP");
			nudChangeIpCount.Value = Convert.ToInt32((settings.GetValue("ip_nudChangeIpCount") == "") ? "1" : settings.GetValue("ip_nudChangeIpCount"));
			switch (Convert.ToInt32((settings.GetValue("ip_iTypeChangeIp") == "") ? "0" : settings.GetValue("ip_iTypeChangeIp")))
			{
			case 0:
				rbNone.Checked = true;
				break;
			case 1:
				rbHma.Checked = true;
				break;
			case 2:
				rbDcom.Checked = true;
				break;
			case 3:
				rbSSH.Checked = true;
				break;
			case 4:
				rbExpressVPN.Checked = true;
				break;
			case 5:
				rbHotspot.Checked = true;
				break;
			case 6:
				rbNordVPN.Checked = true;
				break;
			case 7:
				rbTinsoft.Checked = true;
				break;
			case 8:
				rbXproxy.Checked = true;
				break;
			case 9:
				rbProxy.Checked = true;
				break;
			case 10:
				rbTMProxy.Checked = true;
				break;
			}
			txtProfileNameDcom.Text = settings.GetValue("ip_txtProfileNameDcom");
			txtNordVPN.Text = settings.GetValue("ip_txtNordVPN");
			cbbHostpot.SelectedIndex = Convert.ToInt32((settings.GetValue("ip_cbbHostpot") == "") ? "0" : settings.GetValue("ip_cbbHostpot"));
			if (settings.GetValueInt("typeApiTinsoft") == 0)
			{
				rbApiUser.Checked = true;
			}
			else
			{
				rbApiProxy.Checked = true;
			}
			txtApiUser.Text = settings.GetValue("txtApiUser");
			txtApiProxy.Text = settings.GetValue("txtApiProxy");
			cbbLocationTinsoft.SelectedValue = ((settings.GetValue("cbbLocationTinsoft") == "") ? "0" : settings.GetValue("cbbLocationTinsoft"));
			nudLuongPerIPTinsoft.Value = settings.GetValueInt("nudLuongPerIPTinsoft");
			ckbWaitDoneAllTinsoft.Checked = settings.GetValueBool("ckbWaitDoneAllTinsoft");
			txtServiceURLXProxy.Text = settings.GetValue("txtServiceURLXProxy");
			if (settings.GetValueInt("typeProxy") == 0)
			{
				rbHttpProxy.Checked = true;
			}
			else
			{
				rbSock5Proxy.Checked = true;
			}
			txtListProxy.Text = settings.GetValue("txtListProxy");
			nudLuongPerIPXProxy.Value = settings.GetValueInt("nudLuongPerIPXProxy");
			ckbWaitDoneAllXproxy.Checked = settings.GetValueBool("ckbWaitDoneAllXproxy");
			txtApiKeyTMProxy.Text = settings.GetValue("txtApiKeyTMProxy");
			nudLuongPerIPTMProxy.Value = settings.GetValueInt("nudLuongPerIPTMProxy", 1);
			ckbWaitDoneAllTMProxy.Checked = settings.GetValueBool("ckbWaitDoneAllTMProxy");
			if (settings.GetValueInt("typePhanBietMau") == 0)
			{
				rbPhanBietMauNen.Checked = true;
			}
			else
			{
				rbPhanBietMauChu.Checked = true;
			}
			CheckedChangedFull();
		}

		private void LoadCbbColumnChrome()
		{
			try
			{
				int num = Screen.PrimaryScreen.WorkingArea.Width;
				double num2 = Math.Floor((double)num * 1.0 / 300.0);
				double num3 = Math.Ceiling((double)num * 1.0 / 420.0);
				for (double num4 = num3; num4 <= num2; num4 += 1.0)
				{
					cbbColumnChrome.Items.Add(num4);
				}
			}
			catch
			{
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				settings.Update("nudInteractThread", nudInteractThread.Value);
				settings.Update("nudHideThread", nudHideThread.Value);
				settings.Update("ckbKhongAddVaoFormView", ckbKhongAddVaoFormView.Checked);
				bool flag = false;
				string text = "";
				if (rbLDSwap.Checked)
				{
					flag = true;
					text = txtLDPathSwap.Text.Trim();
				}
				else
				{
					text = txtLDPathThuong.Text.Trim();
				}
				if (text.Contains(" "))
				{
					MessageBoxHelper.ShowMessageBox("Đường dẫn LDPlayer không đươ\u0323c chư\u0301a dâ\u0301u ca\u0301ch (space)!", 3);
					return;
				}
				settings.Update("isRunSwap", flag);
				settings.Update("txtLDPathSwap", txtLDPathSwap.Text.Trim());
				settings.Update("txtLDPathThuong", txtLDPathThuong.Text.Trim());
				if (rbMoCachNhau.Checked)
				{
					settings.Update("typeOpenDevice", 1);
				}
				else
				{
					settings.Update("typeOpenDevice", 0);
				}
				settings.Update("nudDelayOpenDeviceFrom", nudDelayOpenDeviceFrom.Value);
				settings.Update("nudDelayOpenDeviceTo", nudDelayOpenDeviceTo.Value);
				settings.Update("nudDelayCloseDeviceFrom", nudDelayCloseDeviceFrom.Value);
				settings.Update("nudDelayCloseDeviceTo", nudDelayCloseDeviceTo.Value);
				if (rbLoginUserPass.Checked)
				{
					settings.Update("typeLogin", 0);
				}
				else
				{
					settings.Update("typeLogin", 1);
				}
				settings.Update("txbPathProfile", txbPathProfile.Text);
				settings.Update("ckbCreateProfile", ckbCreateProfile.Checked);
				settings.Update("ckbShowImageInteract", ckbShowImageInteract.Checked);
				settings.Update("ckbAddChromeIntoForm", ckbAddChromeIntoForm.Checked);
				settings.Update("nudWidthChrome", nudWidthChrome.Value);
				settings.Update("nudHeighChrome", nudHeighChrome.Value);
				settings.Update("nudDelayOpenChromeFrom", nudDelayOpenChromeFrom.Value);
				settings.Update("nudDelayOpenChromeTo", nudDelayOpenChromeTo.Value);
				settings.Update("nudDelayCloseChromeFrom", nudDelayCloseChromeFrom.Value);
				settings.Update("nudDelayCloseChromeTo", nudDelayCloseChromeTo.Value);
				settings.Update("cbbColumnChrome", cbbColumnChrome.Text);
				settings.Update("cbbRowChrome", cbbRowChrome.Text);
				settings.Update("ckbKhongCheckIP", ckbKhongCheckIP.Checked);
				settings.Update("ip_nudChangeIpCount", nudChangeIpCount.Value);
				int num = 0;
				if (rbNone.Checked)
				{
					num = 0;
				}
				else if (rbHma.Checked)
				{
					num = 1;
				}
				else if (rbDcom.Checked)
				{
					num = 2;
				}
				else if (rbSSH.Checked)
				{
					num = 3;
				}
				else if (rbExpressVPN.Checked)
				{
					num = 4;
				}
				else if (rbHotspot.Checked)
				{
					num = 5;
				}
				else if (rbNordVPN.Checked)
				{
					num = 6;
				}
				else if (rbTinsoft.Checked)
				{
					num = 7;
				}
				else if (rbXproxy.Checked)
				{
					num = 8;
				}
				else if (rbProxy.Checked)
				{
					num = 9;
				}
				else if (rbTMProxy.Checked)
				{
					num = 10;
				}
				settings.Update("ip_iTypeChangeIp", num);
				settings.Update("ip_txtProfileNameDcom", txtProfileNameDcom.Text);
				settings.Update("ip_txtNordVPN", txtNordVPN.Text);
				settings.Update("ip_cbbHostpot", cbbHostpot.SelectedIndex);
				if (rbApiUser.Checked)
				{
					settings.Update("typeApiTinsoft", 0);
				}
				else
				{
					settings.Update("typeApiTinsoft", 1);
				}
				settings.Update("txtApiUser", txtApiUser.Text);
				settings.Update("txtApiProxy", txtApiProxy.Text);
				settings.Update("cbbLocationTinsoft", cbbLocationTinsoft.SelectedValue);
				settings.Update("nudLuongPerIPTinsoft", nudLuongPerIPTinsoft.Value);
				settings.Update("ckbWaitDoneAllTinsoft", ckbWaitDoneAllTinsoft.Checked);
				settings.Update("txtServiceURLXProxy", txtServiceURLXProxy.Text);
				int num2 = 0;
				if (rbSock5Proxy.Checked)
				{
					num2 = 1;
				}
				settings.Update("typeProxy", num2);
				settings.Update("txtListProxy", txtListProxy.Text);
				settings.Update("nudLuongPerIPXProxy", nudLuongPerIPXProxy.Value);
				settings.Update("ckbWaitDoneAllXproxy", ckbWaitDoneAllXproxy.Checked);
				settings.Update("txtApiKeyTMProxy", txtApiKeyTMProxy.Text);
				settings.Update("nudLuongPerIPTMProxy", nudLuongPerIPTMProxy.Value);
				settings.Update("ckbWaitDoneAllTMProxy", ckbWaitDoneAllTMProxy.Checked);
				if (rbPhanBietMauNen.Checked)
				{
					settings.Update("typePhanBietMau", 0);
				}
				else
				{
					settings.Update("typePhanBietMau", 1);
				}
				settings.Save();
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
				{
					Close();
				}
				string path = text + "\\vms\\config\\leidians.config";
				if (File.Exists(path))
				{
					string json = File.ReadAllText(path);
					JObject jObject = JObject.Parse(json);
					jObject["languageId"] = (JToken)"en_US";
					File.WriteAllText(path, jObject.ToString());
				}
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Lỗi!"));
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32((settings.GetValue("ip_iTypeChangeIp") == "") ? "0" : settings.GetValue("ip_iTypeChangeIp")) == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn loại đổi IP"), 3);
			}
			else if (MCommon.Common.ChangeIP(Convert.ToInt32((settings.GetValue("ip_iTypeChangeIp") == "") ? "0" : settings.GetValue("ip_iTypeChangeIp")), settings.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((settings.GetValue("ip_cbbHostpot") == "") ? "0" : settings.GetValue("ip_cbbHostpot")), settings.GetValue("ip_txtNordVPN")))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đổi IP thành công!"));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đổi IP thất bại!"), 2);
			}
		}

		private void btnSSH_Click(object sender, EventArgs e)
		{
			Process.Start("changeip\\ssh.txt");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!CommonChrome.CheckInvalidChrome())
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cập nhật chromedriver!"), 3);
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Phiên bản chromedriver khả dụng!"));
			}
		}

		private void rbTinsoft_CheckedChanged(object sender, EventArgs e)
		{
			plTinsoft.Enabled = rbTinsoft.Checked;
		}

		private void rbNordVPN_CheckedChanged(object sender, EventArgs e)
		{
			panel2.Enabled = rbNordVPN.Checked;
		}

		private void CheckedChangedFull()
		{
			radioButton1_CheckedChanged(null, null);
			radioButton1_CheckedChanged_1(null, null);
			rbLDThuong_CheckedChanged(null, null);
			rbTinsoft_CheckedChanged(null, null);
			rbNordVPN_CheckedChanged(null, null);
			rbDcom_CheckedChanged(null, null);
			rbXproxy_CheckedChanged(null, null);
			rbHma_CheckedChanged(null, null);
			rbTMProxy_CheckedChanged(null, null);
			rbApiUser_CheckedChanged(null, null);
			rbApiProxy_CheckedChanged(null, null);
			ckbDongBoMaxCare_CheckedChanged(null, null);
			ckbAddChromeIntoForm_CheckedChanged(null, null);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string api_user = txtApiUser.Text.Trim();
			List<string> listKey = TinsoftProxy.GetListKey(api_user);
			if (listKey.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), listKey.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void rbDcom_CheckedChanged(object sender, EventArgs e)
		{
			plDcom.Enabled = rbDcom.Checked;
			CheckDoiIPEnable();
		}

		private void rbXproxy_CheckedChanged(object sender, EventArgs e)
		{
			plXproxy.Enabled = rbXproxy.Checked;
		}

		private void CheckDoiIPEnable()
		{
			plCheckDoiIP.Enabled = rbDcom.Checked || rbHma.Checked;
		}

		private void rbHma_CheckedChanged(object sender, EventArgs e)
		{
			CheckDoiIPEnable();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				if (text.Split('\n').Length <= 3)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kết nối Dcom trước!"), 2);
					return;
				}
				txtProfileNameDcom.Text = text.Split('\n').ToList()[1];
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Lấy tên cấu hình Dcom thành công!"));
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "change ip dcom");
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void rbTMProxy_CheckedChanged(object sender, EventArgs e)
		{
			plTMProxy.Enabled = rbTMProxy.Checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("https://youtu.be/eexEDCyPbR8");
			}
			catch
			{
			}
		}

		private void txtApiProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtApiProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblCountApiProxy.Text = "(" + lst.Count + ")";
			}
			catch
			{
			}
		}

		private void rbApiUser_CheckedChanged(object sender, EventArgs e)
		{
			plApiUser.Enabled = rbApiUser.Checked;
		}

		private void rbApiProxy_CheckedChanged(object sender, EventArgs e)
		{
			plApiProxy.Enabled = rbApiProxy.Checked;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> lst = txtApiProxy.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			foreach (string item in lst)
			{
				if (TinsoftProxy.CheckApiProxy(item))
				{
					list.Add(item);
				}
			}
			txtApiProxy.Lines = list.ToArray();
			if (list.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), list.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("https://www.youtube.com/watch?v=XZTveKk-utY");
			}
			catch
			{
			}
		}

		private void plXproxy_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllXproxy.Visible = true;
			}
		}

		private void plTinsoft_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllTinsoft.Visible = true;
			}
		}

		private void plTMProxy_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllTMProxy.Visible = true;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> lst = txtApiKeyTMProxy.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			foreach (string item in lst)
			{
				if (TMProxy.CheckApiProxy(item))
				{
					list.Add(item);
				}
			}
			txtApiKeyTMProxy.Lines = list.ToArray();
			if (list.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), list.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void txtApiKeyTMProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtApiKeyTMProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label24.Text = string.Format(Language.GetValue("Nhập API KEY ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void txtListProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtListProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label17.Text = string.Format(Language.GetValue("Nhập Proxy ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			plDelayMoChrome.Enabled = rbMoCachNhau.Checked;
		}

		private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
		{
		}

		private void rbLDThuong_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://download.minsoftware.vn/dnplayer4/dnplayer.rar");
		}

		private void ckbDongBoMaxCare_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbAddChromeIntoForm_CheckedChanged(object sender, EventArgs e)
		{
			plAddChromeVaoFormView.Enabled = ckbAddChromeIntoForm.Checked;
			plSapXepCuaSoChrome.Enabled = !ckbAddChromeIntoForm.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhChung));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			label3 = new System.Windows.Forms.Label();
			nudInteractThread = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			nudHideThread = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			tcCauHinhNenTang = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			panel3 = new System.Windows.Forms.Panel();
			rbMoLanLuot = new System.Windows.Forms.RadioButton();
			rbMoCachNhau = new System.Windows.Forms.RadioButton();
			plDelayMoChrome = new System.Windows.Forms.Panel();
			nudDelayOpenDeviceFrom = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			nudDelayOpenDeviceTo = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			plLDPlayerThuong = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			txtLDPathThuong = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			plLDPlayerSwap = new System.Windows.Forms.Panel();
			label36 = new System.Windows.Forms.Label();
			txtLDPathSwap = new System.Windows.Forms.TextBox();
			label31 = new System.Windows.Forms.Label();
			rbLDThuong = new System.Windows.Forms.RadioButton();
			label32 = new System.Windows.Forms.Label();
			rbLDSwap = new System.Windows.Forms.RadioButton();
			nudDelayCloseDeviceTo = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			ckbKhongAddVaoFormView = new System.Windows.Forms.CheckBox();
			nudDelayCloseDeviceFrom = new System.Windows.Forms.NumericUpDown();
			tabPage2 = new System.Windows.Forms.TabPage();
			label40 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			txbPathProfile = new System.Windows.Forms.TextBox();
			plSapXepCuaSoChrome = new System.Windows.Forms.Panel();
			label15 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			cbbColumnChrome = new System.Windows.Forms.ComboBox();
			cbbRowChrome = new System.Windows.Forms.ComboBox();
			plAddChromeVaoFormView = new System.Windows.Forms.Panel();
			nudWidthChrome = new System.Windows.Forms.NumericUpDown();
			label35 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			nudHeighChrome = new System.Windows.Forms.NumericUpDown();
			nudDelayCloseChromeFrom = new System.Windows.Forms.NumericUpDown();
			nudDelayCloseChromeTo = new System.Windows.Forms.NumericUpDown();
			rbLoginUserPass = new System.Windows.Forms.RadioButton();
			nudDelayOpenChromeFrom = new System.Windows.Forms.NumericUpDown();
			rbLoginCookie = new System.Windows.Forms.RadioButton();
			nudDelayOpenChromeTo = new System.Windows.Forms.NumericUpDown();
			ckbShowImageInteract = new System.Windows.Forms.CheckBox();
			ckbAddChromeIntoForm = new System.Windows.Forms.CheckBox();
			label20 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			cbbHostpot = new System.Windows.Forms.ComboBox();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			btnSave = new System.Windows.Forms.Button();
			plNordVPN = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			txtNordVPN = new System.Windows.Forms.TextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			panel4 = new System.Windows.Forms.Panel();
			rbPhanBietMauNen = new System.Windows.Forms.RadioButton();
			rbPhanBietMauChu = new System.Windows.Forms.RadioButton();
			label23 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			btnSSH = new System.Windows.Forms.Button();
			radioButton4 = new System.Windows.Forms.RadioButton();
			rbHotspot = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			rbNordVPN = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			rbSSH = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			rbExpressVPN = new System.Windows.Forms.RadioButton();
			groupBox3 = new System.Windows.Forms.GroupBox();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			plTMProxy = new System.Windows.Forms.Panel();
			ckbWaitDoneAllTMProxy = new System.Windows.Forms.CheckBox();
			txtApiKeyTMProxy = new System.Windows.Forms.RichTextBox();
			label24 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			label25 = new System.Windows.Forms.Label();
			nudLuongPerIPTMProxy = new System.Windows.Forms.NumericUpDown();
			plCheckDoiIP = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			label26 = new System.Windows.Forms.Label();
			nudChangeIpCount = new System.Windows.Forms.NumericUpDown();
			label27 = new System.Windows.Forms.Label();
			plXproxy = new System.Windows.Forms.Panel();
			ckbWaitDoneAllXproxy = new System.Windows.Forms.CheckBox();
			txtListProxy = new System.Windows.Forms.RichTextBox();
			rbSock5Proxy = new System.Windows.Forms.RadioButton();
			rbHttpProxy = new System.Windows.Forms.RadioButton();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			nudLuongPerIPXProxy = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			txtServiceURLXProxy = new System.Windows.Forms.TextBox();
			plTinsoft = new System.Windows.Forms.Panel();
			ckbWaitDoneAllTinsoft = new System.Windows.Forms.CheckBox();
			plApiProxy = new System.Windows.Forms.Panel();
			lblCountApiProxy = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			txtApiProxy = new System.Windows.Forms.TextBox();
			button7 = new System.Windows.Forms.Button();
			plApiUser = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			txtApiUser = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			cbbLocationTinsoft = new System.Windows.Forms.ComboBox();
			rbApiProxy = new System.Windows.Forms.RadioButton();
			rbApiUser = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			nudLuongPerIPTinsoft = new System.Windows.Forms.NumericUpDown();
			rbTMProxy = new System.Windows.Forms.RadioButton();
			plDcom = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			txtProfileNameDcom = new System.Windows.Forms.TextBox();
			rbDcom = new System.Windows.Forms.RadioButton();
			rbTinsoft = new System.Windows.Forms.RadioButton();
			rbProxy = new System.Windows.Forms.RadioButton();
			rbNone = new System.Windows.Forms.RadioButton();
			rbXproxy = new System.Windows.Forms.RadioButton();
			rbHma = new System.Windows.Forms.RadioButton();
			ckbKhongCheckIP = new System.Windows.Forms.CheckBox();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			ckbCreateProfile = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)nudInteractThread).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHideThread).BeginInit();
			panel1.SuspendLayout();
			tcCauHinhNenTang.SuspendLayout();
			tabPage1.SuspendLayout();
			panel3.SuspendLayout();
			plDelayMoChrome.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceTo).BeginInit();
			plLDPlayerThuong.SuspendLayout();
			plLDPlayerSwap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceFrom).BeginInit();
			tabPage2.SuspendLayout();
			plSapXepCuaSoChrome.SuspendLayout();
			plAddChromeVaoFormView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudWidthChrome).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHeighChrome).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeTo).BeginInit();
			bunifuCards2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel2.SuspendLayout();
			plNordVPN.SuspendLayout();
			groupBox1.SuspendLayout();
			panel4.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			plTMProxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).BeginInit();
			plCheckDoiIP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudChangeIpCount).BeginInit();
			plXproxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).BeginInit();
			plTinsoft.SuspendLayout();
			plApiProxy.SuspendLayout();
			plApiUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).BeginInit();
			plDcom.SuspendLayout();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 5;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(575, 38);
			bunifuCards1.TabIndex = 12;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(19, 22);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(97, 16);
			label3.TabIndex = 23;
			label3.Text = "Số luồng chạy :";
			nudInteractThread.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudInteractThread.Location = new System.Drawing.Point(171, 20);
			nudInteractThread.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			nudInteractThread.Name = "nudInteractThread";
			nudInteractThread.Size = new System.Drawing.Size(89, 23);
			nudInteractThread.TabIndex = 24;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(263, 22);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 16);
			label4.TabIndex = 25;
			label4.Text = "Luồng";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(263, 51);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(42, 16);
			label5.TabIndex = 28;
			label5.Text = "Luồng";
			nudHideThread.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudHideThread.Location = new System.Drawing.Point(171, 49);
			nudHideThread.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			nudHideThread.Name = "nudHideThread";
			nudHideThread.Size = new System.Drawing.Size(89, 23);
			nudHideThread.TabIndex = 27;
			label6.AutoSize = true;
			label6.Cursor = System.Windows.Forms.Cursors.Help;
			label6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(19, 51);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(131, 16);
			label6.TabIndex = 26;
			label6.Text = "Số luồng chạy ẩn (?):";
			toolTip1.SetToolTip(label6, "La\u0300 sô\u0301 luô\u0300ng khi cha\u0323y ca\u0301c chư\u0301c năng không liên quan gi\u0300 đê\u0301n tri\u0300nh duyê\u0323t.\r\nVi\u0301 du\u0323 như: Check wall, Check Avatar,...\r\n(Khuyê\u0301n ca\u0301o nên đê\u0309 10 luô\u0300ng)");
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(tcCauHinhNenTang);
			panel1.Controls.Add(cbbHostpot);
			panel1.Controls.Add(bunifuCards2);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(plNordVPN);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(btnSSH);
			panel1.Controls.Add(radioButton4);
			panel1.Controls.Add(rbHotspot);
			panel1.Controls.Add(radioButton5);
			panel1.Controls.Add(rbNordVPN);
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(rbSSH);
			panel1.Controls.Add(radioButton3);
			panel1.Controls.Add(rbExpressVPN);
			panel1.Controls.Add(groupBox3);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1158, 534);
			panel1.TabIndex = 37;
			tcCauHinhNenTang.Controls.Add(tabPage1);
			tcCauHinhNenTang.Controls.Add(tabPage2);
			tcCauHinhNenTang.Cursor = System.Windows.Forms.Cursors.Hand;
			tcCauHinhNenTang.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tcCauHinhNenTang.Location = new System.Drawing.Point(7, 124);
			tcCauHinhNenTang.Name = "tcCauHinhNenTang";
			tcCauHinhNenTang.SelectedIndex = 0;
			tcCauHinhNenTang.Size = new System.Drawing.Size(567, 244);
			tcCauHinhNenTang.TabIndex = 145;
			tabPage1.BackColor = System.Drawing.SystemColors.Control;
			tabPage1.Controls.Add(linkLabel2);
			tabPage1.Controls.Add(panel3);
			tabPage1.Controls.Add(label10);
			tabPage1.Controls.Add(plLDPlayerThuong);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(plLDPlayerSwap);
			tabPage1.Controls.Add(label31);
			tabPage1.Controls.Add(rbLDThuong);
			tabPage1.Controls.Add(label32);
			tabPage1.Controls.Add(rbLDSwap);
			tabPage1.Controls.Add(nudDelayCloseDeviceTo);
			tabPage1.Controls.Add(label9);
			tabPage1.Controls.Add(ckbKhongAddVaoFormView);
			tabPage1.Controls.Add(nudDelayCloseDeviceFrom);
			tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
			tabPage1.Location = new System.Drawing.Point(4, 25);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(559, 215);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Cấu hình LDplayer";
			linkLabel2.AutoSize = true;
			linkLabel2.Location = new System.Drawing.Point(15, 26);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(117, 16);
			linkLabel2.TabIndex = 165;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Download LDPlayer";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			panel3.Controls.Add(rbMoLanLuot);
			panel3.Controls.Add(rbMoCachNhau);
			panel3.Controls.Add(plDelayMoChrome);
			panel3.Location = new System.Drawing.Point(164, 105);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(298, 52);
			panel3.TabIndex = 164;
			rbMoLanLuot.AutoSize = true;
			rbMoLanLuot.Checked = true;
			rbMoLanLuot.Cursor = System.Windows.Forms.Cursors.Hand;
			rbMoLanLuot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbMoLanLuot.Location = new System.Drawing.Point(3, 3);
			rbMoLanLuot.Name = "rbMoLanLuot";
			rbMoLanLuot.Size = new System.Drawing.Size(72, 20);
			rbMoLanLuot.TabIndex = 161;
			rbMoLanLuot.TabStop = true;
			rbMoLanLuot.Text = "Lần lượt";
			rbMoLanLuot.UseVisualStyleBackColor = true;
			rbMoCachNhau.AutoSize = true;
			rbMoCachNhau.Cursor = System.Windows.Forms.Cursors.Hand;
			rbMoCachNhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbMoCachNhau.Location = new System.Drawing.Point(3, 26);
			rbMoCachNhau.Name = "rbMoCachNhau";
			rbMoCachNhau.Size = new System.Drawing.Size(137, 20);
			rbMoCachNhau.TabIndex = 161;
			rbMoCachNhau.Text = "Delay mơ\u0309 LDPlayer:";
			rbMoCachNhau.UseVisualStyleBackColor = true;
			rbMoCachNhau.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			plDelayMoChrome.Controls.Add(nudDelayOpenDeviceFrom);
			plDelayMoChrome.Controls.Add(label21);
			plDelayMoChrome.Controls.Add(label29);
			plDelayMoChrome.Controls.Add(nudDelayOpenDeviceTo);
			plDelayMoChrome.Location = new System.Drawing.Point(142, 24);
			plDelayMoChrome.Name = "plDelayMoChrome";
			plDelayMoChrome.Size = new System.Drawing.Size(153, 26);
			plDelayMoChrome.TabIndex = 162;
			nudDelayOpenDeviceFrom.Location = new System.Drawing.Point(2, 1);
			nudDelayOpenDeviceFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenDeviceFrom.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenDeviceFrom.Name = "nudDelayOpenDeviceFrom";
			nudDelayOpenDeviceFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenDeviceFrom.TabIndex = 151;
			nudDelayOpenDeviceFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(117, 3);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(31, 16);
			label21.TabIndex = 33;
			label21.Text = "giây";
			label29.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(45, 3);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(29, 16);
			label29.TabIndex = 33;
			label29.Text = "đê\u0301n";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudDelayOpenDeviceTo.Location = new System.Drawing.Point(74, 1);
			nudDelayOpenDeviceTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenDeviceTo.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenDeviceTo.Name = "nudDelayOpenDeviceTo";
			nudDelayOpenDeviceTo.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenDeviceTo.TabIndex = 151;
			nudDelayOpenDeviceTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(15, 6);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(137, 16);
			label10.TabIndex = 158;
			label10.Text = "Tùy chọn chế độ chạy:";
			plLDPlayerThuong.Controls.Add(label11);
			plLDPlayerThuong.Controls.Add(txtLDPathThuong);
			plLDPlayerThuong.Location = new System.Drawing.Point(180, 25);
			plLDPlayerThuong.Name = "plLDPlayerThuong";
			plLDPlayerThuong.Size = new System.Drawing.Size(368, 29);
			plLDPlayerThuong.TabIndex = 163;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(4, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(129, 16);
			label11.TabIndex = 158;
			label11.Text = "Đường dẫn LDPlayer:";
			txtLDPathThuong.Location = new System.Drawing.Point(138, 3);
			txtLDPathThuong.Name = "txtLDPathThuong";
			txtLDPathThuong.Size = new System.Drawing.Size(227, 23);
			txtLDPathThuong.TabIndex = 159;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(15, 161);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(129, 16);
			label2.TabIndex = 33;
			label2.Text = "Delay đóng LDPlayer:";
			plLDPlayerSwap.Controls.Add(label36);
			plLDPlayerSwap.Controls.Add(txtLDPathSwap);
			plLDPlayerSwap.Enabled = false;
			plLDPlayerSwap.Location = new System.Drawing.Point(180, 73);
			plLDPlayerSwap.Name = "plLDPlayerSwap";
			plLDPlayerSwap.Size = new System.Drawing.Size(368, 29);
			plLDPlayerSwap.TabIndex = 163;
			label36.AutoSize = true;
			label36.Location = new System.Drawing.Point(3, 6);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(129, 16);
			label36.TabIndex = 158;
			label36.Text = "Đường dẫn LDPlayer:";
			txtLDPathSwap.Location = new System.Drawing.Point(138, 3);
			txtLDPathSwap.Name = "txtLDPathSwap";
			txtLDPathSwap.Size = new System.Drawing.Size(227, 23);
			txtLDPathSwap.TabIndex = 159;
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label31.Location = new System.Drawing.Point(282, 161);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(31, 16);
			label31.TabIndex = 33;
			label31.Text = "giây";
			rbLDThuong.AutoSize = true;
			rbLDThuong.Checked = true;
			rbLDThuong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLDThuong.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbLDThuong.Location = new System.Drawing.Point(166, 4);
			rbLDThuong.Name = "rbLDThuong";
			rbLDThuong.Size = new System.Drawing.Size(154, 20);
			rbLDThuong.TabIndex = 161;
			rbLDThuong.TabStop = true;
			rbLDThuong.Text = "1 tài khoản/1 LDPlayer";
			rbLDThuong.UseVisualStyleBackColor = true;
			rbLDThuong.CheckedChanged += new System.EventHandler(rbLDThuong_CheckedChanged);
			label32.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label32.Location = new System.Drawing.Point(210, 161);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(29, 16);
			label32.TabIndex = 33;
			label32.Text = "đê\u0301n";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			rbLDSwap.AutoSize = true;
			rbLDSwap.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLDSwap.Enabled = false;
			rbLDSwap.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbLDSwap.Location = new System.Drawing.Point(166, 55);
			rbLDSwap.Name = "rbLDSwap";
			rbLDSwap.Size = new System.Drawing.Size(300, 20);
			rbLDSwap.TabIndex = 161;
			rbLDSwap.Text = "Không giới hạn tài khoản/1 LDPlayer (Să\u0301p ra co\u0301)";
			rbLDSwap.UseVisualStyleBackColor = true;
			rbLDSwap.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged_1);
			nudDelayCloseDeviceTo.Location = new System.Drawing.Point(239, 159);
			nudDelayCloseDeviceTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseDeviceTo.Name = "nudDelayCloseDeviceTo";
			nudDelayCloseDeviceTo.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseDeviceTo.TabIndex = 151;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(15, 108);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(140, 16);
			label9.TabIndex = 160;
			label9.Text = "Tu\u0300y cho\u0323n mơ\u0309 LDPlayer:";
			ckbKhongAddVaoFormView.AutoSize = true;
			ckbKhongAddVaoFormView.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongAddVaoFormView.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongAddVaoFormView.Location = new System.Drawing.Point(18, 190);
			ckbKhongAddVaoFormView.Name = "ckbKhongAddVaoFormView";
			ckbKhongAddVaoFormView.Size = new System.Drawing.Size(196, 20);
			ckbKhongAddVaoFormView.TabIndex = 112;
			ckbKhongAddVaoFormView.Text = "Không Add LD vào Form View";
			ckbKhongAddVaoFormView.UseVisualStyleBackColor = true;
			nudDelayCloseDeviceFrom.Location = new System.Drawing.Point(167, 159);
			nudDelayCloseDeviceFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseDeviceFrom.Name = "nudDelayCloseDeviceFrom";
			nudDelayCloseDeviceFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseDeviceFrom.TabIndex = 151;
			tabPage2.BackColor = System.Drawing.SystemColors.Control;
			tabPage2.Controls.Add(ckbCreateProfile);
			tabPage2.Controls.Add(label40);
			tabPage2.Controls.Add(label39);
			tabPage2.Controls.Add(txbPathProfile);
			tabPage2.Controls.Add(plSapXepCuaSoChrome);
			tabPage2.Controls.Add(plAddChromeVaoFormView);
			tabPage2.Controls.Add(nudDelayCloseChromeFrom);
			tabPage2.Controls.Add(nudDelayCloseChromeTo);
			tabPage2.Controls.Add(rbLoginUserPass);
			tabPage2.Controls.Add(nudDelayOpenChromeFrom);
			tabPage2.Controls.Add(rbLoginCookie);
			tabPage2.Controls.Add(nudDelayOpenChromeTo);
			tabPage2.Controls.Add(ckbShowImageInteract);
			tabPage2.Controls.Add(ckbAddChromeIntoForm);
			tabPage2.Controls.Add(label20);
			tabPage2.Controls.Add(label22);
			tabPage2.Controls.Add(label30);
			tabPage2.Controls.Add(label34);
			tabPage2.Controls.Add(label37);
			tabPage2.Controls.Add(label38);
			tabPage2.Location = new System.Drawing.Point(4, 25);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(559, 215);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Cấu hình Chrome";
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label40.Location = new System.Drawing.Point(16, 7);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(96, 16);
			label40.TabIndex = 173;
			label40.Text = "Tu\u0300y cho\u0323n login:";
			label39.AutoSize = true;
			label39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label39.Location = new System.Drawing.Point(15, 32);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(153, 16);
			label39.TabIndex = 173;
			label39.Text = "Đường dẫn folder profile:";
			txbPathProfile.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txbPathProfile.Location = new System.Drawing.Point(212, 29);
			txbPathProfile.Name = "txbPathProfile";
			txbPathProfile.Size = new System.Drawing.Size(328, 23);
			txbPathProfile.TabIndex = 172;
			plSapXepCuaSoChrome.Controls.Add(label15);
			plSapXepCuaSoChrome.Controls.Add(label19);
			plSapXepCuaSoChrome.Controls.Add(cbbColumnChrome);
			plSapXepCuaSoChrome.Controls.Add(cbbRowChrome);
			plSapXepCuaSoChrome.Location = new System.Drawing.Point(12, 128);
			plSapXepCuaSoChrome.Name = "plSapXepCuaSoChrome";
			plSapXepCuaSoChrome.Size = new System.Drawing.Size(358, 29);
			plSapXepCuaSoChrome.TabIndex = 171;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(3, 5);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(148, 16);
			label15.TabIndex = 33;
			label15.Text = "Sắp xếp cửa sổ chrome:";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(245, 2);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(23, 23);
			label19.TabIndex = 33;
			label19.Text = "X";
			cbbColumnChrome.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbColumnChrome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbColumnChrome.FormattingEnabled = true;
			cbbColumnChrome.Location = new System.Drawing.Point(200, 2);
			cbbColumnChrome.Name = "cbbColumnChrome";
			cbbColumnChrome.Size = new System.Drawing.Size(41, 24);
			cbbColumnChrome.TabIndex = 145;
			cbbRowChrome.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbRowChrome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbRowChrome.FormattingEnabled = true;
			cbbRowChrome.Items.AddRange(new object[5] { "1", "2", "3", "4", "5" });
			cbbRowChrome.Location = new System.Drawing.Point(272, 2);
			cbbRowChrome.Name = "cbbRowChrome";
			cbbRowChrome.Size = new System.Drawing.Size(41, 24);
			cbbRowChrome.TabIndex = 145;
			plAddChromeVaoFormView.Controls.Add(nudWidthChrome);
			plAddChromeVaoFormView.Controls.Add(label35);
			plAddChromeVaoFormView.Controls.Add(label33);
			plAddChromeVaoFormView.Controls.Add(nudHeighChrome);
			plAddChromeVaoFormView.Location = new System.Drawing.Point(205, 100);
			plAddChromeVaoFormView.Name = "plAddChromeVaoFormView";
			plAddChromeVaoFormView.Size = new System.Drawing.Size(175, 27);
			plAddChromeVaoFormView.TabIndex = 170;
			nudWidthChrome.Location = new System.Drawing.Point(41, 2);
			nudWidthChrome.Maximum = new decimal(new int[4] { 385, 0, 0, 0 });
			nudWidthChrome.Minimum = new decimal(new int[4] { 270, 0, 0, 0 });
			nudWidthChrome.Name = "nudWidthChrome";
			nudWidthChrome.Size = new System.Drawing.Size(53, 23);
			nudWidthChrome.TabIndex = 151;
			nudWidthChrome.Value = new decimal(new int[4] { 285, 0, 0, 0 });
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label35.Location = new System.Drawing.Point(95, 2);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(23, 23);
			label35.TabIndex = 33;
			label35.Text = "X";
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label33.Location = new System.Drawing.Point(3, 4);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(37, 16);
			label33.TabIndex = 33;
			label33.Text = "Size:";
			nudHeighChrome.Location = new System.Drawing.Point(118, 2);
			nudHeighChrome.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudHeighChrome.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudHeighChrome.Name = "nudHeighChrome";
			nudHeighChrome.Size = new System.Drawing.Size(53, 23);
			nudHeighChrome.TabIndex = 151;
			nudHeighChrome.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayCloseChromeFrom.Location = new System.Drawing.Point(212, 187);
			nudDelayCloseChromeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseChromeFrom.Name = "nudDelayCloseChromeFrom";
			nudDelayCloseChromeFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseChromeFrom.TabIndex = 166;
			nudDelayCloseChromeTo.Location = new System.Drawing.Point(284, 187);
			nudDelayCloseChromeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseChromeTo.Name = "nudDelayCloseChromeTo";
			nudDelayCloseChromeTo.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseChromeTo.TabIndex = 167;
			rbLoginUserPass.AutoSize = true;
			rbLoginUserPass.Checked = true;
			rbLoginUserPass.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginUserPass.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbLoginUserPass.Location = new System.Drawing.Point(212, 5);
			rbLoginUserPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbLoginUserPass.Name = "rbLoginUserPass";
			rbLoginUserPass.Size = new System.Drawing.Size(84, 20);
			rbLoginUserPass.TabIndex = 136;
			rbLoginUserPass.TabStop = true;
			rbLoginUserPass.Text = "User|Pass";
			rbLoginUserPass.UseVisualStyleBackColor = true;
			nudDelayOpenChromeFrom.Location = new System.Drawing.Point(212, 159);
			nudDelayOpenChromeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenChromeFrom.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenChromeFrom.Name = "nudDelayOpenChromeFrom";
			nudDelayOpenChromeFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenChromeFrom.TabIndex = 168;
			nudDelayOpenChromeFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbLoginCookie.AutoSize = true;
			rbLoginCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbLoginCookie.Location = new System.Drawing.Point(316, 5);
			rbLoginCookie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbLoginCookie.Name = "rbLoginCookie";
			rbLoginCookie.Size = new System.Drawing.Size(64, 20);
			rbLoginCookie.TabIndex = 136;
			rbLoginCookie.Text = "Cookie";
			rbLoginCookie.UseVisualStyleBackColor = true;
			nudDelayOpenChromeTo.Location = new System.Drawing.Point(284, 159);
			nudDelayOpenChromeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenChromeTo.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenChromeTo.Name = "nudDelayOpenChromeTo";
			nudDelayOpenChromeTo.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenChromeTo.TabIndex = 169;
			nudDelayOpenChromeTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			ckbShowImageInteract.AutoSize = true;
			ckbShowImageInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShowImageInteract.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbShowImageInteract.Location = new System.Drawing.Point(18, 79);
			ckbShowImageInteract.Name = "ckbShowImageInteract";
			ckbShowImageInteract.Size = new System.Drawing.Size(184, 20);
			ckbShowImageInteract.TabIndex = 164;
			ckbShowImageInteract.Text = "Hiê\u0323n a\u0309nh khi mơ\u0309 tri\u0300nh duyê\u0323t";
			ckbShowImageInteract.UseVisualStyleBackColor = true;
			ckbAddChromeIntoForm.AutoSize = true;
			ckbAddChromeIntoForm.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAddChromeIntoForm.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbAddChromeIntoForm.Location = new System.Drawing.Point(18, 102);
			ckbAddChromeIntoForm.Name = "ckbAddChromeIntoForm";
			ckbAddChromeIntoForm.Size = new System.Drawing.Size(188, 20);
			ckbAddChromeIntoForm.TabIndex = 165;
			ckbAddChromeIntoForm.Text = "Add Chrome vào Form View";
			ckbAddChromeIntoForm.UseVisualStyleBackColor = true;
			ckbAddChromeIntoForm.CheckedChanged += new System.EventHandler(ckbAddChromeIntoForm_CheckedChanged);
			label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(255, 189);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 158;
			label20.Text = "đê\u0301n";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label22.Location = new System.Drawing.Point(327, 189);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(31, 16);
			label22.TabIndex = 159;
			label22.Text = "giây";
			label30.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label30.Location = new System.Drawing.Point(255, 161);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(29, 16);
			label30.TabIndex = 160;
			label30.Text = "đê\u0301n";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label34.Location = new System.Drawing.Point(15, 189);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(123, 16);
			label34.TabIndex = 161;
			label34.Text = "Delay đóng chrome:";
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label37.Location = new System.Drawing.Point(327, 161);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(31, 16);
			label37.TabIndex = 162;
			label37.Text = "giây";
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label38.Location = new System.Drawing.Point(15, 161);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(113, 16);
			label38.TabIndex = 163;
			label38.Text = "Delay mơ\u0309 chrome:";
			cbbHostpot.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbHostpot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbHostpot.Enabled = false;
			cbbHostpot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			cbbHostpot.ForeColor = System.Drawing.Color.Black;
			cbbHostpot.FormattingEnabled = true;
			cbbHostpot.Items.AddRange(new object[2] { "Chi\u0309 trong quô\u0301c gia đang cho\u0323n", "Toa\u0300n bô\u0323 quô\u0301c gia" });
			cbbHostpot.Location = new System.Drawing.Point(1177, 563);
			cbbHostpot.Name = "cbbHostpot";
			cbbHostpot.Size = new System.Drawing.Size(229, 24);
			cbbHostpot.TabIndex = 144;
			bunifuCards2.BackColor = System.Drawing.Color.White;
			bunifuCards2.BorderRadius = 0;
			bunifuCards2.BottomSahddow = true;
			bunifuCards2.color = System.Drawing.Color.SaddleBrown;
			bunifuCards2.Controls.Add(pnlHeader);
			bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards2.LeftSahddow = false;
			bunifuCards2.Location = new System.Drawing.Point(0, 0);
			bunifuCards2.Name = "bunifuCards2";
			bunifuCards2.RightSahddow = true;
			bunifuCards2.ShadowDepth = 20;
			bunifuCards2.Size = new System.Drawing.Size(1156, 37);
			bunifuCards2.TabIndex = 40;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1156, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.Location = new System.Drawing.Point(1125, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(30, 30);
			button2.TabIndex = 77;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(BtnCancel_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(1156, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh chung";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(583, 492);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 20;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label12);
			panel2.Controls.Add(textBox1);
			panel2.Enabled = false;
			panel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			panel2.Location = new System.Drawing.Point(1176, 475);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(232, 30);
			panel2.TabIndex = 142;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label12.Location = new System.Drawing.Point(3, 5);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(76, 16);
			label12.TabIndex = 82;
			label12.Text = "Đường dẫn:";
			textBox1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			textBox1.ForeColor = System.Drawing.Color.Black;
			textBox1.Location = new System.Drawing.Point(87, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(142, 23);
			textBox1.TabIndex = 83;
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(483, 492);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 19;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(BtnSave_Click);
			plNordVPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plNordVPN.Controls.Add(label14);
			plNordVPN.Controls.Add(txtNordVPN);
			plNordVPN.Enabled = false;
			plNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plNordVPN.Location = new System.Drawing.Point(1176, 475);
			plNordVPN.Name = "plNordVPN";
			plNordVPN.Size = new System.Drawing.Size(232, 30);
			plNordVPN.TabIndex = 142;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label14.Location = new System.Drawing.Point(3, 5);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(76, 16);
			label14.TabIndex = 82;
			label14.Text = "Đường dẫn:";
			txtNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtNordVPN.ForeColor = System.Drawing.Color.Black;
			txtNordVPN.Location = new System.Drawing.Point(87, 2);
			txtNordVPN.Name = "txtNordVPN";
			txtNordVPN.Size = new System.Drawing.Size(142, 23);
			txtNordVPN.TabIndex = 83;
			groupBox1.Controls.Add(panel4);
			groupBox1.Controls.Add(label23);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox1.Location = new System.Drawing.Point(7, 373);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(568, 44);
			groupBox1.TabIndex = 38;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình khác";
			panel4.Controls.Add(rbPhanBietMauNen);
			panel4.Controls.Add(rbPhanBietMauChu);
			panel4.Location = new System.Drawing.Point(241, 16);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(309, 25);
			panel4.TabIndex = 156;
			rbPhanBietMauNen.AutoSize = true;
			rbPhanBietMauNen.Checked = true;
			rbPhanBietMauNen.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPhanBietMauNen.Location = new System.Drawing.Point(3, 3);
			rbPhanBietMauNen.Name = "rbPhanBietMauNen";
			rbPhanBietMauNen.Size = new System.Drawing.Size(131, 20);
			rbPhanBietMauNen.TabIndex = 34;
			rbPhanBietMauNen.TabStop = true;
			rbPhanBietMauNen.Text = "Đổi màu nền dòng";
			rbPhanBietMauNen.UseVisualStyleBackColor = true;
			rbPhanBietMauChu.AutoSize = true;
			rbPhanBietMauChu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPhanBietMauChu.Location = new System.Drawing.Point(189, 1);
			rbPhanBietMauChu.Name = "rbPhanBietMauChu";
			rbPhanBietMauChu.Size = new System.Drawing.Size(99, 20);
			rbPhanBietMauChu.TabIndex = 34;
			rbPhanBietMauChu.Text = "Đổi màu chữ";
			rbPhanBietMauChu.UseVisualStyleBackColor = true;
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(20, 19);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(224, 16);
			label23.TabIndex = 33;
			label23.Text = "Phân biệt màu [Tình trạng tài khoản]:";
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(nudHideThread);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(nudInteractThread);
			groupBox2.Controls.Add(label3);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox2.Location = new System.Drawing.Point(7, 39);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(567, 80);
			groupBox2.TabIndex = 38;
			groupBox2.TabStop = false;
			groupBox2.Text = "Cấu hình chung";
			btnSSH.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSSH.Enabled = false;
			btnSSH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnSSH.ForeColor = System.Drawing.Color.Black;
			btnSSH.Location = new System.Drawing.Point(1263, 508);
			btnSSH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnSSH.Name = "btnSSH";
			btnSSH.Size = new System.Drawing.Size(106, 26);
			btnSSH.TabIndex = 130;
			btnSSH.Text = "Nhập IP SSH";
			btnSSH.UseVisualStyleBackColor = true;
			btnSSH.Click += new System.EventHandler(btnSSH_Click);
			radioButton4.AutoSize = true;
			radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton4.Enabled = false;
			radioButton4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton4.Location = new System.Drawing.Point(1162, 426);
			radioButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(131, 20);
			radioButton4.TabIndex = 133;
			radioButton4.Text = "Đổi IP ExpressVPN";
			radioButton4.UseVisualStyleBackColor = true;
			rbHotspot.AutoSize = true;
			rbHotspot.Enabled = false;
			rbHotspot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbHotspot.Location = new System.Drawing.Point(1162, 539);
			rbHotspot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbHotspot.Name = "rbHotspot";
			rbHotspot.Size = new System.Drawing.Size(146, 20);
			rbHotspot.TabIndex = 135;
			rbHotspot.Text = "Đổi IP Hotspot Shield";
			rbHotspot.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton5.Enabled = false;
			radioButton5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton5.Location = new System.Drawing.Point(1162, 511);
			radioButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(88, 20);
			radioButton5.TabIndex = 132;
			radioButton5.Text = "Đổi IP SSH";
			radioButton5.UseVisualStyleBackColor = true;
			rbNordVPN.AutoSize = true;
			rbNordVPN.Enabled = false;
			rbNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbNordVPN.Location = new System.Drawing.Point(1162, 451);
			rbNordVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbNordVPN.Name = "rbNordVPN";
			rbNordVPN.Size = new System.Drawing.Size(114, 20);
			rbNordVPN.TabIndex = 134;
			rbNordVPN.Text = "Đổi IP NordVPN";
			rbNordVPN.UseVisualStyleBackColor = true;
			rbNordVPN.CheckedChanged += new System.EventHandler(rbNordVPN_CheckedChanged);
			radioButton2.AutoSize = true;
			radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton2.Enabled = false;
			radioButton2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton2.Location = new System.Drawing.Point(1162, 539);
			radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(146, 20);
			radioButton2.TabIndex = 135;
			radioButton2.Text = "Đổi IP Hotspot Shield";
			radioButton2.UseVisualStyleBackColor = true;
			rbSSH.AutoSize = true;
			rbSSH.Enabled = false;
			rbSSH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbSSH.Location = new System.Drawing.Point(1162, 511);
			rbSSH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbSSH.Name = "rbSSH";
			rbSSH.Size = new System.Drawing.Size(88, 20);
			rbSSH.TabIndex = 132;
			rbSSH.Text = "Đổi IP SSH";
			rbSSH.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton3.Enabled = false;
			radioButton3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton3.Location = new System.Drawing.Point(1162, 451);
			radioButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(114, 20);
			radioButton3.TabIndex = 134;
			radioButton3.Text = "Đổi IP NordVPN";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += new System.EventHandler(rbNordVPN_CheckedChanged);
			rbExpressVPN.AutoSize = true;
			rbExpressVPN.Enabled = false;
			rbExpressVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbExpressVPN.Location = new System.Drawing.Point(1162, 426);
			rbExpressVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbExpressVPN.Name = "rbExpressVPN";
			rbExpressVPN.Size = new System.Drawing.Size(131, 20);
			rbExpressVPN.TabIndex = 133;
			rbExpressVPN.Text = "Đổi IP ExpressVPN";
			rbExpressVPN.UseVisualStyleBackColor = true;
			groupBox3.Controls.Add(linkLabel3);
			groupBox3.Controls.Add(linkLabel1);
			groupBox3.Controls.Add(plTMProxy);
			groupBox3.Controls.Add(plCheckDoiIP);
			groupBox3.Controls.Add(plXproxy);
			groupBox3.Controls.Add(plTinsoft);
			groupBox3.Controls.Add(rbTMProxy);
			groupBox3.Controls.Add(plDcom);
			groupBox3.Controls.Add(rbDcom);
			groupBox3.Controls.Add(rbTinsoft);
			groupBox3.Controls.Add(rbProxy);
			groupBox3.Controls.Add(rbNone);
			groupBox3.Controls.Add(rbXproxy);
			groupBox3.Controls.Add(rbHma);
			groupBox3.Controls.Add(ckbKhongCheckIP);
			groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox3.Location = new System.Drawing.Point(581, 39);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(568, 443);
			groupBox3.TabIndex = 39;
			groupBox3.TabStop = false;
			groupBox3.Text = "Cấu hình đổi IP";
			linkLabel3.AutoSize = true;
			linkLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel3.Location = new System.Drawing.Point(205, 208);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(86, 16);
			linkLabel3.TabIndex = 147;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "Hươ\u0301ng dâ\u0303n(?)";
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(462, 283);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(86, 16);
			linkLabel1.TabIndex = 147;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Hươ\u0301ng dâ\u0303n(?)";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			plTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTMProxy.Controls.Add(ckbWaitDoneAllTMProxy);
			plTMProxy.Controls.Add(txtApiKeyTMProxy);
			plTMProxy.Controls.Add(label24);
			plTMProxy.Controls.Add(button8);
			plTMProxy.Controls.Add(label25);
			plTMProxy.Controls.Add(nudLuongPerIPTMProxy);
			plTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTMProxy.Location = new System.Drawing.Point(312, 308);
			plTMProxy.Name = "plTMProxy";
			plTMProxy.Size = new System.Drawing.Size(240, 123);
			plTMProxy.TabIndex = 146;
			plTMProxy.Click += new System.EventHandler(plTMProxy_Click);
			ckbWaitDoneAllTMProxy.AutoSize = true;
			ckbWaitDoneAllTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllTMProxy.Location = new System.Drawing.Point(115, 1);
			ckbWaitDoneAllTMProxy.Name = "ckbWaitDoneAllTMProxy";
			ckbWaitDoneAllTMProxy.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllTMProxy.TabIndex = 145;
			ckbWaitDoneAllTMProxy.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllTMProxy.UseVisualStyleBackColor = true;
			ckbWaitDoneAllTMProxy.Visible = false;
			txtApiKeyTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtApiKeyTMProxy.Location = new System.Drawing.Point(6, 23);
			txtApiKeyTMProxy.Name = "txtApiKeyTMProxy";
			txtApiKeyTMProxy.Size = new System.Drawing.Size(175, 68);
			txtApiKeyTMProxy.TabIndex = 144;
			txtApiKeyTMProxy.Text = "";
			txtApiKeyTMProxy.WordWrap = false;
			txtApiKeyTMProxy.TextChanged += new System.EventHandler(txtApiKeyTMProxy_TextChanged);
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label24.Location = new System.Drawing.Point(3, 2);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(111, 16);
			label24.TabIndex = 79;
			label24.Text = "Nhập API KEY (0):";
			button8.Cursor = System.Windows.Forms.Cursors.Hand;
			button8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button8.ForeColor = System.Drawing.Color.Black;
			button8.Location = new System.Drawing.Point(183, 22);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(52, 27);
			button8.TabIndex = 143;
			button8.Text = "Check";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label25.Location = new System.Drawing.Point(5, 95);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(79, 16);
			label25.TabIndex = 139;
			label25.Text = "Số luồng/IP:";
			nudLuongPerIPTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPTMProxy.Location = new System.Drawing.Point(90, 94);
			nudLuongPerIPTMProxy.Name = "nudLuongPerIPTMProxy";
			nudLuongPerIPTMProxy.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPTMProxy.TabIndex = 140;
			nudLuongPerIPTMProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			plCheckDoiIP.Controls.Add(button5);
			plCheckDoiIP.Controls.Add(label26);
			plCheckDoiIP.Controls.Add(nudChangeIpCount);
			plCheckDoiIP.Controls.Add(label27);
			plCheckDoiIP.Location = new System.Drawing.Point(15, 45);
			plCheckDoiIP.Name = "plCheckDoiIP";
			plCheckDoiIP.Size = new System.Drawing.Size(270, 27);
			plCheckDoiIP.TabIndex = 146;
			button5.Cursor = System.Windows.Forms.Cursors.Hand;
			button5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button5.ForeColor = System.Drawing.Color.Black;
			button5.Location = new System.Drawing.Point(193, 0);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(77, 27);
			button5.TabIndex = 143;
			button5.Text = "Test";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label26.Location = new System.Drawing.Point(3, 5);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(101, 16);
			label26.TabIndex = 139;
			label26.Text = "Thay đổi IP sau:";
			nudChangeIpCount.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudChangeIpCount.Location = new System.Drawing.Point(106, 3);
			nudChangeIpCount.Name = "nudChangeIpCount";
			nudChangeIpCount.Size = new System.Drawing.Size(46, 23);
			nudChangeIpCount.TabIndex = 140;
			nudChangeIpCount.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label27.Location = new System.Drawing.Point(154, 5);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(30, 16);
			label27.TabIndex = 141;
			label27.Text = "lượt";
			plXproxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plXproxy.Controls.Add(ckbWaitDoneAllXproxy);
			plXproxy.Controls.Add(txtListProxy);
			plXproxy.Controls.Add(rbSock5Proxy);
			plXproxy.Controls.Add(rbHttpProxy);
			plXproxy.Controls.Add(label16);
			plXproxy.Controls.Add(label17);
			plXproxy.Controls.Add(label18);
			plXproxy.Controls.Add(nudLuongPerIPXProxy);
			plXproxy.Controls.Add(label13);
			plXproxy.Controls.Add(txtServiceURLXProxy);
			plXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plXproxy.Location = new System.Drawing.Point(312, 78);
			plXproxy.Name = "plXproxy";
			plXproxy.Size = new System.Drawing.Size(240, 196);
			plXproxy.TabIndex = 142;
			plXproxy.Click += new System.EventHandler(plXproxy_Click);
			ckbWaitDoneAllXproxy.AutoSize = true;
			ckbWaitDoneAllXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllXproxy.Location = new System.Drawing.Point(108, 49);
			ckbWaitDoneAllXproxy.Name = "ckbWaitDoneAllXproxy";
			ckbWaitDoneAllXproxy.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllXproxy.TabIndex = 145;
			ckbWaitDoneAllXproxy.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllXproxy.UseVisualStyleBackColor = true;
			ckbWaitDoneAllXproxy.Visible = false;
			txtListProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtListProxy.Location = new System.Drawing.Point(6, 71);
			txtListProxy.Name = "txtListProxy";
			txtListProxy.Size = new System.Drawing.Size(229, 90);
			txtListProxy.TabIndex = 144;
			txtListProxy.Text = "";
			txtListProxy.WordWrap = false;
			txtListProxy.TextChanged += new System.EventHandler(txtListProxy_TextChanged);
			rbSock5Proxy.AutoSize = true;
			rbSock5Proxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbSock5Proxy.Enabled = false;
			rbSock5Proxy.Location = new System.Drawing.Point(153, 28);
			rbSock5Proxy.Name = "rbSock5Proxy";
			rbSock5Proxy.Size = new System.Drawing.Size(60, 20);
			rbSock5Proxy.TabIndex = 82;
			rbSock5Proxy.Text = "Sock5";
			rbSock5Proxy.UseVisualStyleBackColor = true;
			rbHttpProxy.AutoSize = true;
			rbHttpProxy.Checked = true;
			rbHttpProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHttpProxy.Location = new System.Drawing.Point(90, 28);
			rbHttpProxy.Name = "rbHttpProxy";
			rbHttpProxy.Size = new System.Drawing.Size(49, 20);
			rbHttpProxy.TabIndex = 82;
			rbHttpProxy.TabStop = true;
			rbHttpProxy.Text = "Http";
			rbHttpProxy.UseVisualStyleBackColor = true;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label16.Location = new System.Drawing.Point(3, 28);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(71, 16);
			label16.TabIndex = 79;
			label16.Text = "Loại Proxy:";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label17.Location = new System.Drawing.Point(3, 50);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(98, 16);
			label17.TabIndex = 79;
			label17.Text = "Nhập Proxy (0):";
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label18.Location = new System.Drawing.Point(5, 168);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(79, 16);
			label18.TabIndex = 139;
			label18.Text = "Số luồng/IP:";
			nudLuongPerIPXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPXProxy.Location = new System.Drawing.Point(90, 167);
			nudLuongPerIPXProxy.Name = "nudLuongPerIPXProxy";
			nudLuongPerIPXProxy.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPXProxy.TabIndex = 140;
			nudLuongPerIPXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label13.Location = new System.Drawing.Point(3, 5);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(81, 16);
			label13.TabIndex = 79;
			label13.Text = "Service URL:";
			txtServiceURLXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtServiceURLXProxy.ForeColor = System.Drawing.Color.Black;
			txtServiceURLXProxy.Location = new System.Drawing.Point(90, 2);
			txtServiceURLXProxy.Name = "txtServiceURLXProxy";
			txtServiceURLXProxy.Size = new System.Drawing.Size(145, 23);
			txtServiceURLXProxy.TabIndex = 81;
			plTinsoft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTinsoft.Controls.Add(ckbWaitDoneAllTinsoft);
			plTinsoft.Controls.Add(plApiProxy);
			plTinsoft.Controls.Add(plApiUser);
			plTinsoft.Controls.Add(cbbLocationTinsoft);
			plTinsoft.Controls.Add(rbApiProxy);
			plTinsoft.Controls.Add(rbApiUser);
			plTinsoft.Controls.Add(label7);
			plTinsoft.Controls.Add(label8);
			plTinsoft.Controls.Add(nudLuongPerIPTinsoft);
			plTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTinsoft.Location = new System.Drawing.Point(21, 233);
			plTinsoft.Name = "plTinsoft";
			plTinsoft.Size = new System.Drawing.Size(266, 196);
			plTinsoft.TabIndex = 142;
			plTinsoft.Click += new System.EventHandler(plTinsoft_Click);
			ckbWaitDoneAllTinsoft.AutoSize = true;
			ckbWaitDoneAllTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllTinsoft.Location = new System.Drawing.Point(132, 3);
			ckbWaitDoneAllTinsoft.Name = "ckbWaitDoneAllTinsoft";
			ckbWaitDoneAllTinsoft.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllTinsoft.TabIndex = 145;
			ckbWaitDoneAllTinsoft.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllTinsoft.UseVisualStyleBackColor = true;
			ckbWaitDoneAllTinsoft.Visible = false;
			plApiProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plApiProxy.Controls.Add(lblCountApiProxy);
			plApiProxy.Controls.Add(label28);
			plApiProxy.Controls.Add(txtApiProxy);
			plApiProxy.Controls.Add(button7);
			plApiProxy.Location = new System.Drawing.Point(6, 77);
			plApiProxy.Name = "plApiProxy";
			plApiProxy.Size = new System.Drawing.Size(257, 87);
			plApiProxy.TabIndex = 35;
			lblCountApiProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblCountApiProxy.Location = new System.Drawing.Point(1, 24);
			lblCountApiProxy.Name = "lblCountApiProxy";
			lblCountApiProxy.Size = new System.Drawing.Size(32, 16);
			lblCountApiProxy.TabIndex = 82;
			lblCountApiProxy.Text = "(0)";
			lblCountApiProxy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label28.Location = new System.Drawing.Point(1, 5);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(32, 16);
			label28.TabIndex = 82;
			label28.Text = "API:";
			txtApiProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtApiProxy.ForeColor = System.Drawing.Color.Black;
			txtApiProxy.Location = new System.Drawing.Point(35, 2);
			txtApiProxy.Multiline = true;
			txtApiProxy.Name = "txtApiProxy";
			txtApiProxy.Size = new System.Drawing.Size(165, 79);
			txtApiProxy.TabIndex = 83;
			txtApiProxy.WordWrap = false;
			txtApiProxy.TextChanged += new System.EventHandler(txtApiProxy_TextChanged);
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button7.ForeColor = System.Drawing.Color.Black;
			button7.Location = new System.Drawing.Point(203, 1);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(52, 27);
			button7.TabIndex = 143;
			button7.Text = "Check";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			plApiUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plApiUser.Controls.Add(label1);
			plApiUser.Controls.Add(txtApiUser);
			plApiUser.Controls.Add(button3);
			plApiUser.Location = new System.Drawing.Point(6, 24);
			plApiUser.Name = "plApiUser";
			plApiUser.Size = new System.Drawing.Size(257, 29);
			plApiUser.TabIndex = 35;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(1, 5);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 16);
			label1.TabIndex = 82;
			label1.Text = "API:";
			txtApiUser.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtApiUser.ForeColor = System.Drawing.Color.Black;
			txtApiUser.Location = new System.Drawing.Point(35, 2);
			txtApiUser.Name = "txtApiUser";
			txtApiUser.Size = new System.Drawing.Size(165, 23);
			txtApiUser.TabIndex = 83;
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button3.ForeColor = System.Drawing.Color.Black;
			button3.Location = new System.Drawing.Point(203, 0);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(52, 27);
			button3.TabIndex = 143;
			button3.Text = "Check";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			cbbLocationTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbLocationTinsoft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbLocationTinsoft.DropDownWidth = 120;
			cbbLocationTinsoft.FormattingEnabled = true;
			cbbLocationTinsoft.Location = new System.Drawing.Point(67, 165);
			cbbLocationTinsoft.Name = "cbbLocationTinsoft";
			cbbLocationTinsoft.Size = new System.Drawing.Size(67, 24);
			cbbLocationTinsoft.TabIndex = 84;
			rbApiProxy.AutoSize = true;
			rbApiProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbApiProxy.Location = new System.Drawing.Point(3, 56);
			rbApiProxy.Name = "rbApiProxy";
			rbApiProxy.Size = new System.Drawing.Size(136, 20);
			rbApiProxy.TabIndex = 34;
			rbApiProxy.Text = "Sử dụng Api Proxy:";
			rbApiProxy.UseVisualStyleBackColor = true;
			rbApiProxy.CheckedChanged += new System.EventHandler(rbApiProxy_CheckedChanged);
			rbApiUser.AutoSize = true;
			rbApiUser.Checked = true;
			rbApiUser.Cursor = System.Windows.Forms.Cursors.Hand;
			rbApiUser.Location = new System.Drawing.Point(3, 3);
			rbApiUser.Name = "rbApiUser";
			rbApiUser.Size = new System.Drawing.Size(131, 20);
			rbApiUser.TabIndex = 34;
			rbApiUser.TabStop = true;
			rbApiUser.Text = "Sử dụng Api User:";
			rbApiUser.UseVisualStyleBackColor = true;
			rbApiUser.CheckedChanged += new System.EventHandler(rbApiUser_CheckedChanged);
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(9, 168);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(60, 16);
			label7.TabIndex = 82;
			label7.Text = "Location:";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label8.Location = new System.Drawing.Point(140, 168);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(79, 16);
			label8.TabIndex = 139;
			label8.Text = "Số luồng/IP:";
			toolTip1.SetToolTip(label8, "Là số tài khoản cùng chạy trên 1 Proxy (hay 1 IP)");
			nudLuongPerIPTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPTinsoft.Location = new System.Drawing.Point(222, 166);
			nudLuongPerIPTinsoft.Name = "nudLuongPerIPTinsoft";
			nudLuongPerIPTinsoft.Size = new System.Drawing.Size(46, 23);
			nudLuongPerIPTinsoft.TabIndex = 140;
			nudLuongPerIPTinsoft.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbTMProxy.AutoSize = true;
			rbTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbTMProxy.Location = new System.Drawing.Point(312, 281);
			rbTMProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbTMProxy.Name = "rbTMProxy";
			rbTMProxy.Size = new System.Drawing.Size(148, 20);
			rbTMProxy.TabIndex = 145;
			rbTMProxy.Text = "https://tmproxy.com/";
			rbTMProxy.UseVisualStyleBackColor = true;
			rbTMProxy.CheckedChanged += new System.EventHandler(rbTMProxy_CheckedChanged);
			plDcom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDcom.Controls.Add(button4);
			plDcom.Controls.Add(txtProfileNameDcom);
			plDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plDcom.Location = new System.Drawing.Point(22, 174);
			plDcom.Name = "plDcom";
			plDcom.Size = new System.Drawing.Size(265, 30);
			plDcom.TabIndex = 131;
			button4.Cursor = System.Windows.Forms.Cursors.Hand;
			button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button4.ForeColor = System.Drawing.Color.Black;
			button4.Location = new System.Drawing.Point(4, 1);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(100, 25);
			button4.TabIndex = 143;
			button4.Text = "Lấy tên Dcom";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			txtProfileNameDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtProfileNameDcom.ForeColor = System.Drawing.Color.Black;
			txtProfileNameDcom.Location = new System.Drawing.Point(110, 2);
			txtProfileNameDcom.Name = "txtProfileNameDcom";
			txtProfileNameDcom.Size = new System.Drawing.Size(151, 23);
			txtProfileNameDcom.TabIndex = 81;
			rbDcom.AutoSize = true;
			rbDcom.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbDcom.Location = new System.Drawing.Point(21, 151);
			rbDcom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbDcom.Name = "rbDcom";
			rbDcom.Size = new System.Drawing.Size(96, 20);
			rbDcom.TabIndex = 137;
			rbDcom.Text = "Đổi IP Dcom";
			rbDcom.UseVisualStyleBackColor = true;
			rbDcom.CheckedChanged += new System.EventHandler(rbDcom_CheckedChanged);
			rbTinsoft.AutoSize = true;
			rbTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbTinsoft.Location = new System.Drawing.Point(21, 206);
			rbTinsoft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbTinsoft.Name = "rbTinsoft";
			rbTinsoft.Size = new System.Drawing.Size(168, 20);
			rbTinsoft.TabIndex = 134;
			rbTinsoft.Text = "https://tinsoftproxy.com/";
			rbTinsoft.UseVisualStyleBackColor = true;
			rbTinsoft.CheckedChanged += new System.EventHandler(rbTinsoft_CheckedChanged);
			rbProxy.AutoSize = true;
			rbProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbProxy.Location = new System.Drawing.Point(21, 103);
			rbProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbProxy.Name = "rbProxy";
			rbProxy.Size = new System.Drawing.Size(267, 20);
			rbProxy.TabIndex = 136;
			rbProxy.Text = "Sử dụng Proxy (đã gán cho mỗi tài khoản)";
			rbProxy.UseVisualStyleBackColor = true;
			rbNone.AutoSize = true;
			rbNone.Checked = true;
			rbNone.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNone.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbNone.Location = new System.Drawing.Point(21, 79);
			rbNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbNone.Name = "rbNone";
			rbNone.Size = new System.Drawing.Size(97, 20);
			rbNone.TabIndex = 136;
			rbNone.TabStop = true;
			rbNone.Text = "Không đổi IP";
			rbNone.UseVisualStyleBackColor = true;
			rbXproxy.AutoSize = true;
			rbXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbXproxy.Location = new System.Drawing.Point(312, 48);
			rbXproxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbXproxy.Name = "rbXproxy";
			rbXproxy.Size = new System.Drawing.Size(208, 20);
			rbXproxy.TabIndex = 138;
			rbXproxy.Text = "Xproxy, Mobi, OBC, Eager Proxy";
			rbXproxy.UseVisualStyleBackColor = true;
			rbXproxy.CheckedChanged += new System.EventHandler(rbXproxy_CheckedChanged);
			rbHma.AutoSize = true;
			rbHma.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHma.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbHma.Location = new System.Drawing.Point(21, 127);
			rbHma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbHma.Name = "rbHma";
			rbHma.Size = new System.Drawing.Size(90, 20);
			rbHma.TabIndex = 138;
			rbHma.Text = "Đổi IP HMA";
			rbHma.UseVisualStyleBackColor = true;
			rbHma.CheckedChanged += new System.EventHandler(rbHma_CheckedChanged);
			ckbKhongCheckIP.AutoSize = true;
			ckbKhongCheckIP.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongCheckIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongCheckIP.Location = new System.Drawing.Point(21, 21);
			ckbKhongCheckIP.Name = "ckbKhongCheckIP";
			ckbKhongCheckIP.Size = new System.Drawing.Size(199, 20);
			ckbKhongCheckIP.TabIndex = 112;
			ckbKhongCheckIP.Text = "Không Check IP trước khi chạy";
			ckbKhongCheckIP.UseVisualStyleBackColor = true;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			ckbCreateProfile.AutoSize = true;
			ckbCreateProfile.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbCreateProfile.Location = new System.Drawing.Point(18, 56);
			ckbCreateProfile.Name = "ckbCreateProfile";
			ckbCreateProfile.Size = new System.Drawing.Size(187, 20);
			ckbCreateProfile.TabIndex = 174;
			ckbCreateProfile.Text = "Tự động tạo Profile khi chạy";
			ckbCreateProfile.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1158, 534);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhChung";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(FConfigGenneral_Load);
			((System.ComponentModel.ISupportInitialize)nudInteractThread).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHideThread).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			tcCauHinhNenTang.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			plDelayMoChrome.ResumeLayout(false);
			plDelayMoChrome.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceTo).EndInit();
			plLDPlayerThuong.ResumeLayout(false);
			plLDPlayerThuong.PerformLayout();
			plLDPlayerSwap.ResumeLayout(false);
			plLDPlayerSwap.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceFrom).EndInit();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			plSapXepCuaSoChrome.ResumeLayout(false);
			plSapXepCuaSoChrome.PerformLayout();
			plAddChromeVaoFormView.ResumeLayout(false);
			plAddChromeVaoFormView.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudWidthChrome).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHeighChrome).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeTo).EndInit();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			plNordVPN.ResumeLayout(false);
			plNordVPN.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			plTMProxy.ResumeLayout(false);
			plTMProxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).EndInit();
			plCheckDoiIP.ResumeLayout(false);
			plCheckDoiIP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudChangeIpCount).EndInit();
			plXproxy.ResumeLayout(false);
			plXproxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).EndInit();
			plTinsoft.ResumeLayout(false);
			plTinsoft.PerformLayout();
			plApiProxy.ResumeLayout(false);
			plApiProxy.PerformLayout();
			plApiUser.ResumeLayout(false);
			plApiUser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).EndInit();
			plDcom.ResumeLayout(false);
			plDcom.PerformLayout();
			ResumeLayout(false);
		}
	}
}
