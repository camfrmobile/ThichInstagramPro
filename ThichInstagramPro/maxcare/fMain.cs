using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SystemCarePro;
using SystemCarePro.Helper;
using Bunifu.Framework.UI;
using Common;
using DeviceId;
using maxcare.Enum;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;
using WindowsFormsControlLibrary1;

namespace maxcare
{
	public class fMain : Form
	{
		private Random rd;

		private bool isStop;

		public const int softIndex = 62;

		public const string nameSoft = "maxinstagrampro";

		public string deviceId;

		public static fMain remote;

		public bool isResetAdb;

		private JSON_Settings setting_general;

		private JSON_Settings setting_Interact;

		private JSON_Settings setting_InteractGeneral;

		private JSON_Settings setting_ShowDtgv;

		private JSON_Settings setting_MoTrinhDuyet;

		private int icheck1;

		private List<Thread> lstThread;

		private List<string> lstIdGroup;

		private List<string> lstIdFr;

		private List<TinsoftProxy> listTinsoft;

		private List<XproxyProxy> listxProxy;

		private List<TMProxy> listTMProxy;

		private List<string> listApiTinsoft;

		private List<string> listProxyXproxy;

		private List<string> listProxyTMProxy;

		private Dictionary<string, List<string>> dicUidNhom;

		private Dictionary<string, List<string>> dicUidCaNhan;

		private Dictionary<string, List<string>> dicUidTinNhanProfile;

		private Dictionary<string, List<string>> dicHDDangBaiTuong_NoiDung;

		private Dictionary<string, List<string>> dicHDDangBaiNhom_NoiDung;

		private Dictionary<string, List<string>> dicUidTuongTacPage;

		private Dictionary<string, List<string>> dicSdt;

		private Dictionary<string, List<string>> dicNoiDungReview;

		private Dictionary<string, List<string>> dicHDTuongTacBaiVietChiDinhComment;

		private Dictionary<string, List<string>> dicHDSpamBaiVietID;

		private int checkDelayLD;

		private object lock_checkDelayLD;

		private bool isOpeningDevice;

		private object lock_checkDelayCreateDevice;

		private int checkDelayLD_MoLDPLayer;

		private object lock_checkDelayLD_MoLDPLayer;

		private bool isOpeningDevice_MoLDPLayer;

		private object lock_checkDelayCreateDevice_MoLDPLayer;

		private bool isReloginIfLogout;

		private List<Device> lstDevice;

		private object lock_StartProxy;

		private object lock_FinishProxy;

		private int checkDelayChrome;

		private object lock_checkDelayChrome;

		private object lock_restoreDevice;

		private object lock_useImage;

		private object lock_fileig;

		private object _lockbackup;

		private object lock_db2;

		private object lockStatus;

		private bool kiukiu;

		private int indexCbbThuMucOld;

		private bool isExcute_CbbThuMuc_SelectedIndexChanged;

		private object objLock;

		private object _lock;

		private object _lock2;

		private object _lock3;

		private object _lock4;

		private int indexCbbTinhTrangOld;

		private bool isExcute_CbbTinhTrang_SelectedIndexChanged;

		private int tung1;

		private bool isCountCheckAccountWhenChayTuongTac;

		private object lock_CreateDevice;

		private string ipx;

		private IContainer components;

		public DataGridView dtgvAcc;

		private BunifuDragControl bunifuDragControl1;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private Button button2;

		private Button button1;

		private Button btnMinimize;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem hệThốngToolStripMenuItem;

		private ToolStripMenuItem càiĐặtToolStripMenuItem;

		private GroupBox grQuanLyThuMuc;

		private Label label1;

		private MetroComboBox cbbThuMuc;

		private MetroContextMenu ctmsAcc;

		private ToolStripMenuItem chọnLiveToolStripMenuItem;

		private ToolStripMenuItem liveToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem cookieToolStripMenuItem;

		private ToolStripMenuItem uidPassToolStripMenuItem;

		private ToolStripMenuItem xóaTàiKhoảnToolStripMenuItem;

		private ToolStripMenuItem chuyểnThưMụcToolStripMenuItem;

		private ToolStripMenuItem tấtCảToolStripMenuItem;

		private ToolStripMenuItem bỏChọnTấtCảToolStripMenuItem;

		private ToolStripMenuItem passToolStripMenuItem;

		private Button btnInteract;

		private ToolStripMenuItem tảiLạiDanhSáchToolStripMenuItem;

		private ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem;

		private ToolStripMenuItem mậtKhẩuToolStripMenuItem1;

		private ToolStripMenuItem cookieToolStripMenuItem3;

		private Button btnPause;

		private ToolStripMenuItem chứcNăngToolStripMenuItem1;

		private ToolStripMenuItem trạngTháiToolStripMenuItem;

		private BunifuCustomTextbox txbSearch;

		private ToolStripMenuItem mailToolStripMenuItem;

		private ToolStripMenuItem mailKhôiPhụcToolStripMenuItem;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel lblStatus;

		private ToolStripStatusLabel toolStripStatusLabel3;

		private ToolStripStatusLabel lblKey;

		private ToolStripStatusLabel toolStripStatusLabel7;

		private ToolStripStatusLabel lblCountTotal;

		private ToolStripStatusLabel toolStripStatusLabel8;

		private ToolStripStatusLabel txbUid;

		private ToolStripStatusLabel lblUser;

		private ToolStripStatusLabel toolStripStatusLabel9;

		private ToolStripStatusLabel toolStripStatusLabel10;

		private ToolStripStatusLabel toolStripStatusLabel5;

		private ToolStripStatusLabel lblCountSelect;

		private ToolStripMenuItem tinhTrangToolStripMenuItem;

		private ToolStripMenuItem locTrungToolStripMenuItem;

		private ToolStripMenuItem uidPass2FaToolStripMenuItem;

		private BunifuDragControl bunifuDragControl2;

		private ToolTip toolTip1;

		private ToolStripMenuItem thoátToolStripMenuItem;

		private ToolStripMenuItem useragentToolStripMenuItem;

		private ToolStripMenuItem proxyToolStripMenuItem;

		private ToolStripMenuItem proxyToolStripMenuItem1;

		private ComboBox cbbSearch;

		private ToolStripMenuItem ghiChuToolStripMenuItem;

		private MetroButton AddFileAccount;

		private MetroButton btnDeleteFile;

		private MetroButton btnLoadAcc;

		private MetroComboBox cbbTinhTrang;

		private Label label2;

		private Button button9;

		private MetroButton BtnSearch;

		private Panel plTrangThai;

		private Label lblTrangThai;

		private ToolStripMenuItem uidToolStripMenuItem;

		private ToolStripMenuItem taiKhoanĐaXoaToolStripMenuItem;

		private ToolStripMenuItem tiệnÍchToolStripMenuItem;

		private ToolStripMenuItem lọcTrùngDữLiệuToolStripMenuItem;

		private ToolStripMenuItem xửLýChuỗiOnlineToolStripMenuItem;

		private MetroButton btnEditFile;

		private ToolStripMenuItem checkProxyToolStripMenuItem1;

		private ToolStripMenuItem lToolStripMenuItem;

		private Panel panel1;

		private ToolStripMenuItem liênHệToolStripMenuItem;

		public ToolStripStatusLabel lblDateExpried;

		private System.Windows.Forms.Timer timer1;

		public BunifuCustomLabel bunifuCustomLabel1;

		private MetroButton btnRandomIndexRow;

		private Button button7;

		private Panel plChucNang;

		private Button button5;

		private Button button3;

		private Button btnPost;

		private DataGridViewCheckBoxColumn cChose;

		private DataGridViewTextBoxColumn cStt;

		private DataGridViewTextBoxColumn cId;

		private DataGridViewTextBoxColumn cUid;

		private DataGridViewTextBoxColumn cToken;

		private DataGridViewTextBoxColumn cCookies;

		private DataGridViewTextBoxColumn cEmail;

		private DataGridViewTextBoxColumn cPhone;

		private DataGridViewTextBoxColumn cName;

		private DataGridViewTextBoxColumn cFollow;

		private DataGridViewTextBoxColumn cFriend;

		private DataGridViewTextBoxColumn cGroup;

		private DataGridViewTextBoxColumn cBirthday;

		private DataGridViewTextBoxColumn cGender;

		private DataGridViewTextBoxColumn cPassword;

		private DataGridViewTextBoxColumn cMailRecovery;

		private DataGridViewTextBoxColumn cPassMail;

		private DataGridViewTextBoxColumn cBackup;

		private DataGridViewTextBoxColumn cFa2;

		private DataGridViewTextBoxColumn cUseragent;

		private DataGridViewTextBoxColumn cProxy;

		private DataGridViewTextBoxColumn cDateCreateAcc;

		private DataGridViewTextBoxColumn cAvatar;

		private DataGridViewTextBoxColumn cProfile;

		private DataGridViewTextBoxColumn cThuMuc;

		private DataGridViewTextBoxColumn cInteractEnd;

		private DataGridViewTextBoxColumn cDevice;

		private DataGridViewTextBoxColumn cInfo;

		private DataGridViewTextBoxColumn cGhiChu;

		private DataGridViewTextBoxColumn cStatus;

		private GroupBox grTimKiem;

		private ToolStripMenuItem mã2FAToolStripMenuItem;

		private ToolStripMenuItem fAToolStripMenuItem;

		private ToolStripMenuItem maBaoMât6SôToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem checkCookieToolStripMenuItem;

		private ToolStripMenuItem checkInfoUIDToolStripMenuItem;

		private ToolStripMenuItem checkProxyToolStripMenuItem;

		public fMain(string log)
		{
			rd = new Random();
			deviceId = "";
			isResetAdb = false;
			icheck1 = 0;
			lstThread = null;
			lstIdGroup = new List<string>();
			lstIdFr = new List<string>();
			listTinsoft = null;
			listxProxy = null;
			listTMProxy = null;
			listApiTinsoft = null;
			listProxyXproxy = null;
			listProxyTMProxy = null;
			dicUidNhom = null;
			dicUidCaNhan = null;
			dicUidTinNhanProfile = null;
			dicHDDangBaiTuong_NoiDung = null;
			dicHDDangBaiNhom_NoiDung = null;
			dicUidTuongTacPage = null;
			dicSdt = null;
			dicNoiDungReview = null;
			dicHDTuongTacBaiVietChiDinhComment = null;
			dicHDSpamBaiVietID = null;
			checkDelayLD = 0;
			lock_checkDelayLD = new object();
			isOpeningDevice = false;
			lock_checkDelayCreateDevice = new object();
			checkDelayLD_MoLDPLayer = 0;
			lock_checkDelayLD_MoLDPLayer = new object();
			isOpeningDevice_MoLDPLayer = false;
			lock_checkDelayCreateDevice_MoLDPLayer = new object();
			isReloginIfLogout = false;
			lstDevice = null;
			lock_StartProxy = new object();
			lock_FinishProxy = new object();
			checkDelayChrome = 0;
			lock_checkDelayChrome = new object();
			lock_restoreDevice = new object();
			lock_useImage = new object();
			lock_fileig = new object();
			_lockbackup = new object();
			lock_db2 = new object();
			lockStatus = new object();
			kiukiu = false;
			indexCbbThuMucOld = -1;
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
			objLock = new object();
			_lock = new object();
			_lock2 = new object();
			_lock3 = new object();
			_lock4 = new object();
			indexCbbTinhTrangOld = -1;
			isExcute_CbbTinhTrang_SelectedIndexChanged = true;
			tung1 = 1;
			isCountCheckAccountWhenChayTuongTac = false;
			lock_CreateDevice = new object();
			ipx = "";
			components = null;
			CheckKey.CheckVersion("maxinstagrampro");
			InitializeComponent();
			ChangeLanguage();
			log.Split('|');
			lblDateExpried.Text = "Vĩnh Viễn";
			lblKey.Text = "H5637UYT****";
			lblUser.Text = "Uyennguyen";
			remote = this;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(hệThốngToolStripMenuItem);
			Language.GetValue(càiĐặtToolStripMenuItem);
			Language.GetValue(thoátToolStripMenuItem);
			Language.GetValue(taiKhoanĐaXoaToolStripMenuItem);
			Language.GetValue(tiệnÍchToolStripMenuItem);
			Language.GetValue(checkProxyToolStripMenuItem1);
			Language.GetValue(lọcTrùngDữLiệuToolStripMenuItem);
			Language.GetValue(xửLýChuỗiOnlineToolStripMenuItem);
			Language.GetValue(liênHệToolStripMenuItem);
			Language.GetValue(btnInteract);
			Language.GetValue(btnPause);
			Language.GetValue(grTimKiem);
			Language.GetValue(grQuanLyThuMuc);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(button9);
			Language.GetValue(toolStripStatusLabel1);
			Language.GetValue(lblStatus);
			Language.GetValue(toolStripStatusLabel3);
			Language.GetValue(toolStripStatusLabel9);
			Language.GetValue(toolStripStatusLabel10);
			Language.GetValue(toolStripStatusLabel5);
			Language.GetValue(toolStripStatusLabel7);
			foreach (DataGridViewColumn column in dtgvAcc.Columns)
			{
				Language.GetValue(column);
			}
			Language.GetValue(chọnLiveToolStripMenuItem);
			Language.GetValue(tấtCảToolStripMenuItem);
			Language.GetValue(liveToolStripMenuItem);
			Language.GetValue(tinhTrangToolStripMenuItem);
			Language.GetValue(trạngTháiToolStripMenuItem);
			Language.GetValue(bỏChọnTấtCảToolStripMenuItem);
			Language.GetValue(xóaTàiKhoảnToolStripMenuItem);
			Language.GetValue(cậpNhậtDữLiệuToolStripMenuItem);
			Language.GetValue(ghiChuToolStripMenuItem);
			Language.GetValue(chuyểnThưMụcToolStripMenuItem);
			Language.GetValue(chứcNăngToolStripMenuItem1);
			Language.GetValue(locTrungToolStripMenuItem);
			Language.GetValue(lToolStripMenuItem);
			Language.GetValue(tảiLạiDanhSáchToolStripMenuItem);
		}

		protected override void OnLoad(EventArgs args)
		{
			Application.Idle += OnLoaded;
		}

		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= OnLoaded;
			LoadCheckTool();
			Base.useragentDefault = CommonChrome.GetUserAgentDefault();
			SetupFolder.StartApplication();
			LoadcbbSearch();
			LoadSetting();
			LoadConfigManHinh();
			LoadCbbThuMuc();
			LoadCbbTinhTrang();
			Base.width = base.Width;
			Base.heigh = base.Height;
			menuStrip1.Cursor = Cursors.Hand;
			new Thread((ThreadStart)delegate
			{
				while (true)
				{
					try
					{
						string text = ADBHelper.RunCMD("adb devices");
						if (!text.Contains("List of devices attached"))
						{
							MCommon.Common.KillProcess("adb");
							isResetAdb = true;
						}
					}
					catch
					{
					}
					MCommon.Common.DelayTime(30.0);
				}
			}).Start();
		}

		private void LoadcbbSearch()
		{
			Dictionary<string, string> dataSource = new Dictionary<string, string>
			{
				{ "cUid", "UID" },
				{
					"cPassword",
					Language.GetValue("Mật khẩu")
				},
				{
					"cName",
					Language.GetValue("Tên")
				},
				{
					"cBirthday",
					Language.GetValue("Ngày sinh")
				},
				{
					"cGender",
					Language.GetValue("Giới tính")
				},
				{ "cToken", "Token" },
				{ "cCookies", "Cookie" },
				{ "cEmail", "Email" },
				{ "cPassMail", "Pass email" },
				{ "cFa2", "2FA" },
				{
					"cGhiChu",
					Language.GetValue("Ghi chu\u0301")
				},
				{
					"cInteractEnd",
					Language.GetValue("Tương ta\u0301c cuô\u0301i")
				}
			};
			cbbSearch.DataSource = new BindingSource(dataSource, null);
			cbbSearch.ValueMember = "Key";
			cbbSearch.DisplayMember = "Value";
		}

		private void LoadCbbThuMuc()
		{
			isExcute_CbbThuMuc_SelectedIndexChanged = false;
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase(isShowAll: true);
			cbbThuMuc.DataSource = allFilesFromDatabase;
			cbbThuMuc.ValueMember = "id";
			cbbThuMuc.DisplayMember = "name";
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
		}

		private void LoadCbbTinhTrang(List<string> lstIdFile = null)
		{
			try
			{
				DataTable allInfoFromAccount = CommonSQL.GetAllInfoFromAccount(lstIdFile);
				cbbTinhTrang.DataSource = allInfoFromAccount;
				cbbTinhTrang.ValueMember = "id";
				cbbTinhTrang.DisplayMember = "name";
			}
			catch
			{
			}
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			try
			{
				try
				{
					File.Delete("settings\\language.txt");
				}
				catch
				{
				}
				Environment.Exit(0);
			}
			catch
			{
				Close();
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (base.Width == Screen.PrimaryScreen.WorkingArea.Width && base.Height == Screen.PrimaryScreen.WorkingArea.Height)
			{
				base.Width = Base.width;
				base.Height = Base.heigh;
				base.Top = Base.top;
				base.Left = Base.left;
			}
			else
			{
				Base.top = base.Top;
				Base.left = base.Left;
				base.Top = 0;
				base.Left = 0;
				base.Width = Screen.PrimaryScreen.WorkingArea.Width;
				base.Height = Screen.PrimaryScreen.WorkingArea.Height;
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void BtnLoadAcc_Click(object sender, EventArgs e)
		{
			string text = "";
			if (cbbThuMuc.SelectedValue != null)
			{
				text = cbbThuMuc.SelectedValue.ToString();
			}
			LoadCbbThuMuc();
			if (text != "999999" && text != "-1")
			{
				indexCbbThuMucOld = -1;
				cbbThuMuc.SelectedValue = text;
				return;
			}
			isExcute_CbbThuMuc_SelectedIndexChanged = false;
			cbbThuMuc.SelectedValue = text;
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
			LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFiles);
		}

		private List<string> GetIdFile()
		{
			List<string> result = null;
			try
			{
				string text = cbbThuMuc.SelectedValue.ToString();
				string text2 = text;
				if (!(text2 == "-1"))
				{
					result = ((text2 == "999999") ? CollectionHelper.CloneList(fChonThuMuc.lstChooseIdFiles) : new List<string> { cbbThuMuc.SelectedValue.ToString() });
				}
			}
			catch
			{
			}
			return result;
		}

		private void LoadAccountFromFile(List<string> lstIdFile = null, string info = "")
		{
			try
			{
				dtgvAcc.Rows.Clear();
				if (info == "[Tất cả tình trạng]" || info == Language.GetValue("[Tất cả tình trạng]"))
				{
					info = "";
				}
				DataTable accFromFile = CommonSQL.GetAccFromFile(lstIdFile, info);
				LoadDtgvAccFromDatatable(accFromFile);
			}
			catch (Exception)
			{
			}
		}

		private void LoadDtgvAccFromDatatable(DataTable tableAccount)
		{
			for (int i = 0; i < tableAccount.Rows.Count; i++)
			{
				DataRow dataRow = tableAccount.Rows[i];
				dtgvAcc.Rows.Add(false, dtgvAcc.RowCount + 1, dataRow["id"], dataRow["uid"], dataRow["token"], dataRow["cookie1"], dataRow["email"], dataRow["phone"], dataRow["name"], dataRow["follow"], dataRow["friends"], dataRow["groups"], dataRow["birthday"], dataRow["gender"], dataRow["pass"], "", dataRow["passmail"], dataRow["backup"], dataRow["fa2"], dataRow["useragent"], dataRow["proxy"], dataRow["dateCreateAcc"], dataRow["avatar"], dataRow["profile"], dataRow["nameFile"], dataRow["interactEnd"], dataRow["device"], dataRow["info"], dataRow["ghiChu"], "");
			}
			CountCheckedAccount(0);
			SetRowColor();
			CountTotalAccount();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "";
				if (cbbThuMuc.SelectedValue != null)
				{
					text = cbbThuMuc.SelectedValue.ToString();
				}
				MCommon.Common.ShowForm(new fImportAccount(text));
				if (fImportAccount.isAddAccount || fImportAccount.isAddFile)
				{
					LoadCbbThuMuc();
					indexCbbThuMucOld = -1;
					if (fImportAccount.isAddAccount)
					{
						cbbThuMuc.SelectedValue = fImportAccount.idFileAdded;
					}
					else
					{
						cbbThuMuc.SelectedValue = text;
					}
				}
			}
			catch
			{
			}
		}

		private int GetIndexRowFromCondition(string id)
		{
			int result = -1;
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (dtgvAcc.Rows[i].Cells["cId"].Value.ToString().Equals(id))
				{
					result = i;
					break;
				}
			}
			return result;
		}

		private void ChoseRowInDatagrid(string modeChose)
		{
			switch (modeChose)
			{
			case "ToggleCheck":
			{
				for (int k = 0; k < dtgvAcc.SelectedRows.Count; k++)
				{
					int index = dtgvAcc.SelectedRows[k].Index;
					SetCellAccount(index, "cChose", !Convert.ToBoolean(GetCellAccount(index, "cChose")));
				}
				CountCheckedAccount();
				break;
			}
			case "SelectHighline":
			{
				DataGridViewSelectedRowCollection selectedRows = dtgvAcc.SelectedRows;
				for (int j = 0; j < selectedRows.Count; j++)
				{
					SetCellAccount(selectedRows[j].Index, "cChose", true);
				}
				CountCheckedAccount();
				break;
			}
			case "UnAll":
			{
				for (int l = 0; l < dtgvAcc.RowCount; l++)
				{
					SetCellAccount(l, "cChose", false);
				}
				CountCheckedAccount(0);
				break;
			}
			case "All":
			{
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					SetCellAccount(i, "cChose", true);
				}
				CountCheckedAccount(dtgvAcc.RowCount);
				break;
			}
			}
		}

		private void CopyRowDatagrid(string modeCopy)
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						list.Add(GetCellAccount(i, "cId"));
						break;
					}
				}
				if (list.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox("Vui lòng chọn danh sách tài khoản muốn copy thông tin!", 3);
					return;
				}
				switch (modeCopy)
				{
				case "mail|pass|cookie":
				{
					for (int num = 0; num < dtgvAcc.RowCount; num++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num, "cEmail") + "|" + GetCellAccount(num, "cPassword") + "|" + GetCellAccount(num, "cCookies") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass":
				{
					for (int num9 = 0; num9 < dtgvAcc.RowCount; num9++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num9].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num9, "cUid") + "|" + GetCellAccount(num9, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case "mail|passmail":
				{
					for (int num13 = 0; num13 < dtgvAcc.RowCount; num13++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num13].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num13, "cEmail") + "|" + GetCellAccount(num13, "cPassMail") + "\r\n";
						}
					}
					break;
				}
				case "ma2fa":
				{
					for (int num5 = 0; num5 < dtgvAcc.RowCount; num5++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							text = text + MCommon.Common.GetTotp(GetCellAccount(num5, "cFa2")) + "\r\n";
						}
					}
					break;
				}
				case "2fa":
				{
					for (int k = 0; k < dtgvAcc.RowCount; k++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[k].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(k, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case "uid":
				{
					for (int num11 = 0; num11 < dtgvAcc.RowCount; num11++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num11].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num11, "cUid") + "\r\n";
						}
					}
					break;
				}
				case "proxy":
				{
					for (int num7 = 0; num7 < dtgvAcc.RowCount; num7++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num7].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num7, "cProxy").Split('*')[0] + "\r\n";
						}
					}
					break;
				}
				case "pass":
				{
					for (int num3 = 0; num3 < dtgvAcc.RowCount; num3++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num3, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case "cookie":
				{
					for (int m = 0; m < dtgvAcc.RowCount; m++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[m].Cells["cChose"].Value))
						{
							string cellAccount = GetCellAccount(m, "cCookies");
							text = text + cellAccount + "\r\n";
						}
					}
					break;
				}
				case "useragent":
				{
					for (int num14 = 0; num14 < dtgvAcc.RowCount; num14++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num14].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num14, "cUseragent") + "\r\n";
						}
					}
					break;
				}
				case "mail|pass":
				{
					for (int num12 = 0; num12 < dtgvAcc.RowCount; num12++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num12].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num12, "cEmail") + "|" + GetCellAccount(num12, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|token|cookie|mail|passmail":
				{
					for (int num10 = 0; num10 < dtgvAcc.RowCount; num10++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num10].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num10, "cUid") + "|" + GetCellAccount(num10, "cPassword") + "|" + GetCellAccount(num10, "cToken") + "|" + GetCellAccount(num10, "cCookies") + "|" + GetCellAccount(num10, "cEmail") + "|" + GetCellAccount(num10, "cPassMail") + "\r\n";
						}
					}
					break;
				}
				case "token":
				{
					for (int num8 = 0; num8 < dtgvAcc.RowCount; num8++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num8].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num8, "cToken") + "\r\n";
						}
					}
					break;
				}
				case "name":
				{
					for (int num6 = 0; num6 < dtgvAcc.RowCount; num6++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num6, "cName") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|2fa":
				{
					for (int num4 = 0; num4 < dtgvAcc.RowCount; num4++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num4, "cUid") + "|" + GetCellAccount(num4, "cPassword") + "|" + GetCellAccount(num4, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case "mail|pass|2fa":
				{
					for (int num2 = 0; num2 < dtgvAcc.RowCount; num2++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num2, "cEmail") + "|" + GetCellAccount(num2, "cPassword") + "|" + GetCellAccount(num2, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case "birthday":
				{
					for (int n = 0; n < dtgvAcc.RowCount; n++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[n].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(n, "cBirthday") + "\r\n";
						}
					}
					break;
				}
				case "mail":
				{
					for (int l = 0; l < dtgvAcc.RowCount; l++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[l].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(l, "cEmail") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|token|cookie|mail|passmail|fa2":
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(j, "cUid") + "|" + GetCellAccount(j, "cPassword") + "|" + GetCellAccount(j, "cToken") + "|" + GetCellAccount(j, "cCookies") + "|" + GetCellAccount(j, "cEmail") + "|" + GetCellAccount(j, "cPassMail") + "|" + GetCellAccount(j, "cFa2") + "\r\n";
						}
					}
					break;
				}
				}
				Clipboard.SetText(text.TrimEnd('\r', '\n'));
			}
			catch
			{
			}
		}

		private string ConvertCookie(string cookie)
		{
			string text = "";
			string value = Regex.Match(cookie + ";", "sb=(.*?);").Groups[1].Value;
			if (value != "")
			{
				text = text + "sb=" + value + ";";
			}
			string value2 = Regex.Match(cookie + ";", "wd=(.*?);").Groups[1].Value;
			if (value2 != "")
			{
				text = text + "wd=" + value2 + ";";
			}
			string value3 = Regex.Match(cookie + ";", "datr=(.*?);").Groups[1].Value;
			if (value3 != "")
			{
				text = text + "datr=" + value3 + ";";
			}
			string value4 = Regex.Match(cookie + ";", "locale=(.*?);").Groups[1].Value;
			if (value4 != "")
			{
				text = text + "locale=" + value4 + ";";
			}
			string value5 = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
			if (value5 != "")
			{
				text = text + "c_user=" + value5 + ";";
			}
			string value6 = Regex.Match(cookie + ";", "xs=(.*?);").Groups[1].Value;
			if (value6 != "")
			{
				text = text + "xs=" + value6 + ";";
			}
			string value7 = Regex.Match(cookie + ";", "fr=(.*?);").Groups[1].Value;
			if (value7 != "")
			{
				text = text + "fr=" + value7 + ";";
			}
			string value8 = Regex.Match(cookie + ";", "spin=(.*?);").Groups[1].Value;
			if (value8 != "")
			{
				text = text + "spin=" + value8 + ";";
			}
			return text;
		}

		private void TấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("All");
		}

		private void LiveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("SelectHighline");
		}

		private void BỏChọnTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("UnAll");
		}

		private void TokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("token");
		}

		private void CookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("cookie");
		}

		private void UidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid");
		}

		private void PassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("pass");
		}

		private void UidPassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|pass");
		}

		private void UidPassTokenCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie");
		}

		private void AddFileAccount_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fAddFile());
			if (fAddFile.isAdd)
			{
				LoadCbbThuMuc();
				cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 2;
			}
		}

		private void DeleteAccountDatagridFromId()
		{
			for (int i = 0; i < dtgvAcc.SelectedRows.Count; i++)
			{
				dtgvAcc.Rows.RemoveAt(dtgvAcc.SelectedRows[i].Index);
			}
		}

		private void FMain_Load(object sender, EventArgs e)
		{
		}

		private void CtmsAcc_Opening(object sender, CancelEventArgs e)
		{
			chuyểnThưMụcToolStripMenuItem.DropDownItems.Clear();
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase();
			int num = 0;
			for (int i = 0; i < allFilesFromDatabase.Rows.Count; i++)
			{
				DataRow dataRow = allFilesFromDatabase.Rows[i];
				if (dataRow["id"].ToString() != ((cbbThuMuc.SelectedValue == null) ? "" : cbbThuMuc.SelectedValue.ToString()))
				{
					chuyểnThưMụcToolStripMenuItem.DropDownItems.Add(dataRow["name"].ToString());
					chuyểnThưMụcToolStripMenuItem.DropDownItems[i - num].Tag = dataRow["id"];
					chuyểnThưMụcToolStripMenuItem.DropDownItems[i - num].Click += TransfomerAccount;
				}
				else
				{
					num++;
				}
			}
			trạngTháiToolStripMenuItem.DropDownItems.Clear();
			List<string> list = new List<string>();
			string text = "";
			string text2 = "";
			for (int j = 0; j < dtgvAcc.RowCount; j++)
			{
				text = GetCellAccount(j, "cStatus");
				if (text != "")
				{
					text2 = Regex.Match(text, "\\(IP: (.*?)\\)").Value;
					if (text2 != "")
					{
						text = text.Replace(text2, "").Trim();
					}
					text2 = Regex.Match(text, "\\[(.*?)\\]").Value;
					if (text2 != "")
					{
						text = text.Replace(text2, "").Trim();
					}
					if (text != "" && !list.Contains(text))
					{
						list.Add(text);
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				trạngTháiToolStripMenuItem.DropDownItems.Add(list[k]);
				trạngTháiToolStripMenuItem.DropDownItems[k].Click += SelectGridByStatus;
			}
			tinhTrangToolStripMenuItem.DropDownItems.Clear();
			list = new List<string>();
			string text3 = "";
			for (int l = 0; l < dtgvAcc.RowCount; l++)
			{
				text3 = GetCellAccount(l, "cInfo");
				if (!text3.Equals("") && !list.Contains(text3))
				{
					list.Add(text3);
				}
			}
			for (int m = 0; m < list.Count; m++)
			{
				tinhTrangToolStripMenuItem.DropDownItems.Add(list[m]);
				tinhTrangToolStripMenuItem.DropDownItems[m].Click += SelectGridByInfo;
			}
		}

		private void SelectGridByInfo(object sender, EventArgs e)
		{
			ChooseAccountByValue("cInfo", (sender as ToolStripMenuItem).Text);
		}

		private void SelectGridByStatus(object sender, EventArgs e)
		{
			ChooseAccountByValue("cStatus", (sender as ToolStripMenuItem).Text);
		}

		private void ChooseAccountByValue(string column, string value)
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				dtgvAcc.Rows[i].Cells["cChose"].Value = GetCellAccount(i, column).Contains(value);
			}
			CountCheckedAccount();
		}

		private void TransfomerAccount(object sender, EventArgs e)
		{
			if (Convert.ToInt32(lblCountSelect.Text) == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chuyển!"), 3);
				return;
			}
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có thực sự muốn chuyển {0} tài khoản sang thư mục [{1}]?"), lblCountSelect.Text, toolStripMenuItem.Text)) == DialogResult.Yes)
			{
				TransfomAccountToOrtherFile(toolStripMenuItem.Tag.ToString());
			}
		}

		private void TransfomAccountToOrtherFile(string idFileTo)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
					}
				}
				if (CommonSQL.UpdateFieldToAccount(list, "idfile", idFileTo))
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							dtgvAcc.Rows.RemoveAt(j--);
						}
					}
					SetRowColor();
					UpdateSttOnDatatable();
					CountCheckedAccount(0);
					CountTotalAccount();
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Chuyển thành công {0} tài khoản!"), list.Count));
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Chuyển thất bại, vui lòng thử lại sau!"), 2);
				}
			}
			catch
			{
			}
		}

		private void DeleteAccount(bool isDeleteProfile)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
				}
			}
			if (list.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản cần xóa!"));
			}
			else
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có muốn xóa {0} tài khoản đã chọn?"), CountChooseRowInDatagridview()) + "\r\n" + Language.GetValue("(Đồng thời xóa luôn LDPlayer của tài khoản)") + "\r\n" + Language.GetValue("(Ta\u0300i khoa\u0309n sau khi xo\u0301a se\u0303 đươ\u0323c lưu ta\u0323i mu\u0323c [Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a])")) != DialogResult.Yes)
				{
					return;
				}
				if (isDeleteProfile)
				{
					int iThread = 0;
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < 10)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang xo\u0301a profile..."));
									DeleteProfile(row);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					while (iThread > 0)
					{
						MCommon.Common.DelayTime(1.0);
					}
				}
				if (CommonSQL.DeleteAccountToDatabase(list))
				{
					CommonSQL.UpdateMultiFieldToAccount(list, "device", "");
					LoadSetting();
					bool valueBool = setting_general.GetValueBool("isRunSwap");
					string pathLDPlayer = ConfigHelper.GetPathLDPlayer();
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							continue;
						}
						if (!valueBool)
						{
							string cellAccount = GetCellAccount(j, "cDevice");
							if (cellAccount != "" && Directory.Exists(pathLDPlayer + "\\vms\\leidian" + cellAccount))
							{
								try
								{
									Directory.Delete(pathLDPlayer + "\\vms\\leidian" + cellAccount, recursive: true);
								}
								catch
								{
								}
							}
						}
						dtgvAcc.Rows.RemoveAt(j--);
					}
					UpdateSttOnDatatable();
					CountTotalAccount();
					CountCheckedAccount(0);
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Xóa thất bại, vui lòng thử lại sau!"), 2);
				}
			}
		}

		public List<string> GetListKeyTinsoft()
		{
			List<string> list = new List<string>();
			try
			{
				if (setting_general.GetValueInt("typeApiTinsoft") == 0)
				{
					RequestXNet requestXNet = new RequestXNet("", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)", "", 0);
					string json = requestXNet.RequestGet("http://proxy.tinsoftsv.com/api/getUserKeys.php?key=" + setting_general.GetValue("txtApiUser"));
					JObject jObject = JObject.Parse(json);
					foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
					{
						if (Convert.ToBoolean(item["success"]!.ToString()))
						{
							list.Add(item["key"]!.ToString());
						}
					}
				}
				else
				{
					List<string> valueList = setting_general.GetValueList("txtApiProxy");
					foreach (string item2 in valueList)
					{
						if (TinsoftProxy.CheckApiProxy(item2))
						{
							list.Add(item2);
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}

		private bool CheckIsUidFacebook(string uid)
		{
			return MCommon.Common.IsNumber(uid) && !uid.StartsWith("0");
		}

		private Dictionary<string, List<string>> GetDictionaryIntoHanhDong(string idKichBan, string tenTuongTac, string field = "txtUid")
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			try
			{
				List<string> idHanhDongByIdKichBanAndTenTuongTac = InteractSQL.GetIdHanhDongByIdKichBanAndTenTuongTac(idKichBan, tenTuongTac);
				if (idHanhDongByIdKichBanAndTenTuongTac.Count > 0)
				{
					for (int i = 0; i < idHanhDongByIdKichBanAndTenTuongTac.Count; i++)
					{
						string text = idHanhDongByIdKichBanAndTenTuongTac[i];
						JSON_Settings jSON_Settings = new JSON_Settings(InteractSQL.GetCauHinhFromHanhDong(text), isJsonString: true);
						List<string> list = new List<string>();
						list = ((!(field == "txtUid")) ? jSON_Settings.GetValueList(field, jSON_Settings.GetValueInt("typeNganCach")) : jSON_Settings.GetValueList(field));
						dictionary.Add(text, list);
					}
				}
			}
			catch
			{
			}
			return dictionary;
		}

		private void SaveDictionaryIntoHanhDong(Dictionary<string, List<string>> dic, string field = "txtUid")
		{
			if (dic.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, List<string>> item in dic)
			{
				string key = item.Key;
				List<string> value = item.Value;
				JSON_Settings jSON_Settings = new JSON_Settings(InteractSQL.GetCauHinhFromHanhDong(key), isJsonString: true);
				jSON_Settings.Update(field, value);
				InteractSQL.UpdateHanhDong(key, "", jSON_Settings.GetFullString());
			}
		}

		private bool ComparePortXproxy(string proxy1, string proxy2)
		{
			try
			{
				string text = proxy1.Split(':')[1];
				string text2 = proxy2.Split(':')[1];
				if (text.Substring(1) == text2.Substring(1))
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void OpenFormViewLD(bool isRunSwap)
		{
			if (!MCommon.Common.CheckFormIsOpenning("fViewLD"))
			{
				fViewLD obj = new fViewLD();
				obj.isRunSwap = false;
				obj.Show();
			}
		}

		private void CloseFormViewLD()
		{
			MCommon.Common.CloseForm("fViewLD");
		}

		private bool BackupAccountFacebook(Device device, string uid, string pass, string fa2)
		{
			try
			{
				device.BackupAccountFacebook(uid);
				File.WriteAllText("profile\\" + uid + "\\account.txt", uid + "|" + pass + "|" + fa2);
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		private bool ConnectProxy(Device device, string text)
		{
			bool result = false;
			device.OpenApp("com.cell47.College_Proxy");
			for (int i = 0; i < 5; i++)
			{
				if (device.GetActivity() == "com.cell47.College_Proxy/com.cell47.College_Proxy.ui.MainActivity")
				{
					break;
				}
				device.DelayTime(1.0);
			}
			if (device.WaitForTextDisappear(30.0, "please wait"))
			{
				string html = device.GetHtml();
				if (device.CheckExistText("stop proxy service", html))
				{
					device.TapByText("stop proxy service", html);
					device.DelayTime(1.0);
					html = device.GetHtml();
				}
				string text2 = device.CheckIP();
				List<string> list = new List<string> { "125,90", "125,125", "125,160", "125,195" };
				for (int j = 0; j < 4; j++)
				{
					device.DoubleTap(Convert.ToInt32(list[j].Split(',')[0]), Convert.ToInt32(list[j].Split(',')[1]));
					device.DelayTime(1.0);
					device.InputText(text.Split(':')[j].ToString());
					device.DelayTime(1.0);
				}
				device.TapByText("start proxy service", html);
				for (int k = 0; k < 10; k++)
				{
					html = device.GetHtml();
					switch (device.CheckExistTexts(html, 0.0, "connection request", "stop proxy service"))
					{
					case 0:
						continue;
					case 1:
						device.TapByText("ok", html);
						device.DelayTime(1.0);
						break;
					}
					break;
				}
				string text3 = "127.0.0.1:" + (device.IndexDevice * 2 + 5555);
				ADBHelper.ConnectDevice(text3);
				string text4 = "";
				for (int l = 0; l < 10; l++)
				{
					text4 = device.CheckIP();
					if (text4 != "" && !text4.Contains("error"))
					{
						break;
					}
					Thread.Sleep(1000);
				}
				result = text2 != text4 && !text4.Contains("error") && text4 != "";
			}
			return result;
		}

		private void RunByChrome()
		{
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				string profilePath = ConfigHelper.GetPathProfile();
				if (!Directory.Exists(profilePath))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn profile không hợp lệ!"), 3);
					return;
				}
				if (Base.useragentDefault == "")
				{
					Base.useragentDefault = CommonChrome.GetUserAgentDefault();
					if (Base.useragentDefault == "")
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Phiên bản Chromedriver hiện tại không khả dụng, vui lòng cập nhật!"), 3);
						return;
					}
				}
				int maxThread = setting_general.GetValueInt("nudInteractThread", 3);
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
				{
					listApiTinsoft = GetListKeyTinsoft();
					if (listApiTinsoft.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy Tinsoft không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTinsoft = new List<TinsoftProxy>();
					for (int j = 0; j < listApiTinsoft.Count; j++)
					{
						TinsoftProxy item2 = new TinsoftProxy(listApiTinsoft[j], setting_general.GetValueInt("nudLuongPerIPTinsoft"), setting_general.GetValueInt("cbbLocationTinsoft"));
						listTinsoft.Add(item2);
					}
					if (listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft") < maxThread)
					{
						maxThread = listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft");
					}
					break;
				}
				case 8:
				{
					listProxyXproxy = setting_general.GetValueList("txtListProxy");
					if (listProxyXproxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng cấu hình lại!"), 2);
						return;
					}
					listxProxy = new List<XproxyProxy>();
					for (int k = 0; k < listProxyXproxy.Count; k++)
					{
						XproxyProxy item3 = new XproxyProxy(setting_general.GetValue("txtServiceURLXProxy"), listProxyXproxy[k], setting_general.GetValueInt("typeProxy"), setting_general.GetValueInt("nudLuongPerIPXProxy"));
						listxProxy.Add(item3);
					}
					if (listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy") < maxThread)
					{
						maxThread = listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy");
					}
					break;
				}
				case 10:
				{
					listProxyTMProxy = setting_general.GetValueList("txtApiKeyTMProxy");
					if (listProxyTMProxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("TMProxy không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTMProxy = new List<TMProxy>();
					for (int i = 0; i < listProxyTMProxy.Count; i++)
					{
						TMProxy item = new TMProxy(listProxyTMProxy[i], 0, setting_general.GetValueInt("nudLuongPerIPTMProxy"));
						listTMProxy.Add(item);
					}
					if (listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy") < maxThread)
					{
						maxThread = listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy");
					}
					break;
				}
				}
				List<int> lstPossition = new List<int>();
				for (int l = 0; l < maxThread; l++)
				{
					lstPossition.Add(0);
				}
				cControl("start");
				if (setting_general.GetValueBool("ckbAddChromeIntoForm"))
				{
					OpenFormViewChrome();
				}
				isCountCheckAccountWhenChayTuongTac = true;
				isStop = false;
				int curChangeIp = 0;
				bool isChangeIPSuccess = false;
				checkDelayChrome = 0;
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						List<string> list = new List<string>();
						string idKichBan = "";
						string text = "";
						int num = setting_InteractGeneral.GetValueInt("nudSoLuotChay", 1);
						if (num == 0)
						{
							num = 1;
						}
						int num2 = 0;
						while (num2 < num)
						{
							list = new List<string>();
							if (setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
							{
								text = ((num > 1) ? string.Format(Language.GetValue("Lượt {0}/{1}. "), num2 + 1, num) : "");
								if (setting_InteractGeneral.GetValueBool("RepeatAllVIP"))
								{
									list = setting_InteractGeneral.GetValueList("lstIdKichBan");
									if (setting_InteractGeneral.GetValueBool("ckbRandomKichBan"))
									{
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
									}
								}
								else
								{
									list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
								}
							}
							else
							{
								list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
							}
							int num3 = 0;
							while (true)
							{
								if (num3 < list.Count && !isStop)
								{
									idKichBan = list[num3];
									if (text != "")
									{
										ShowTrangThai(text + string.Format(Language.GetValue("Kịch bản") + ": {0}...", InteractSQL.GetTenKichBanById(idKichBan)));
									}
									if (setting_InteractGeneral.GetValueBool("ckbRandomThuTuTaiKhoan"))
									{
										dtgvAcc.Invoke((MethodInvoker)delegate
										{
											RandomThuTuTaiKhoan();
										});
									}
									dicUidNhom = GetDictionaryIntoHanhDong(idKichBan, "HDThamGiaNhomUid");
									dicUidCaNhan = GetDictionaryIntoHanhDong(idKichBan, "HDKetBanTepUid");
									dicHDSpamBaiVietID = GetDictionaryIntoHanhDong(idKichBan, "HDSpamBaiViet");
									dicHDDangBaiTuong_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiTuong", "txtNoiDung");
									dicHDDangBaiNhom_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiNhom", "txtNoiDung");
									dicUidTuongTacPage = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacPage");
									dicSdt = GetDictionaryIntoHanhDong(idKichBan, "HDDongBoDanhBa", "txtSdt");
									dicNoiDungReview = GetDictionaryIntoHanhDong(idKichBan, "HDDanhGiaPage", "txtComment");
									dicHDTuongTacBaiVietChiDinhComment = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacBaiVietChiDinh", "txtComment");
									int num4 = 0;
									while (num4 < dtgvAcc.Rows.Count && !isStop)
									{
										if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
										{
											num4++;
											goto IL_098e;
										}
										if (isStop)
										{
											break;
										}
										if (lstThread.Count < maxThread)
										{
											if (isStop)
											{
												break;
											}
											int row = num4++;
											Thread thread = new Thread((ThreadStart)delegate
											{
												try
												{
													int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
													ExcuteOneThread_Chrome(row, indexOfPossitionApp, idKichBan, profilePath);
													MCommon.Common.FillIndexPossition(ref lstPossition, indexOfPossitionApp);
												}
												catch (Exception ex3)
												{
													MCommon.Common.ExportError(null, ex3);
												}
												if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
												{
													SetCellAccount(row, "cChose", false);
												}
											})
											{
												Name = row.ToString()
											};
											lock (lstThread)
											{
												lstThread.Add(thread);
											}
											MCommon.Common.DelayTime(1.0);
											thread.Start();
											goto IL_098e;
										}
										if (isStop)
										{
											break;
										}
										if ((setting_general.GetValueInt("ip_iTypeChangeIp") == 7 && setting_general.GetValueBool("ckbWaitDoneAllTinsoft")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 8 && setting_general.GetValueBool("ckbWaitDoneAllXproxy")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 10 && setting_general.GetValueBool("ckbWaitDoneAllTMProxy")))
										{
											for (int m = 0; m < lstThread.Count; m++)
											{
												lstThread[m].Join();
												lock (lstThread)
												{
													lstThread.RemoveAt(m--);
												}
											}
											goto IL_098e;
										}
										if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10)
										{
											for (int n = 0; n < lstThread.Count; n++)
											{
												if (!lstThread[n].IsAlive)
												{
													lock (lstThread)
													{
														lstThread.RemoveAt(n--);
													}
												}
											}
											goto IL_098e;
										}
										for (int num5 = 0; num5 < lstThread.Count; num5++)
										{
											lstThread[num5].Join();
											lock (lstThread)
											{
												lstThread.RemoveAt(num5--);
											}
										}
										if (isStop)
										{
											break;
										}
										Interlocked.Increment(ref curChangeIp);
										if (curChangeIp < setting_general.GetValueInt("ip_nudChangeIpCount", 1))
										{
											goto IL_098e;
										}
										for (int num6 = 0; num6 < 3; num6++)
										{
											isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
											if (isChangeIPSuccess)
											{
												break;
											}
										}
										if (isChangeIPSuccess)
										{
											curChangeIp = 0;
											goto IL_098e;
										}
										MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 2);
										goto end_IL_0001;
										IL_098e:
										if (isStop)
										{
											break;
										}
									}
									for (int num7 = 0; num7 < lstThread.Count; num7++)
									{
										lstThread[num7].Join();
									}
									SaveDictionaryIntoHanhDong(dicUidNhom);
									SaveDictionaryIntoHanhDong(dicUidCaNhan);
									SaveDictionaryIntoHanhDong(dicHDSpamBaiVietID);
									SaveDictionaryIntoHanhDong(dicHDDangBaiTuong_NoiDung, "txtNoiDung");
									SaveDictionaryIntoHanhDong(dicHDDangBaiNhom_NoiDung, "txtNoiDung");
									SaveDictionaryIntoHanhDong(dicUidTuongTacPage);
									SaveDictionaryIntoHanhDong(dicSdt, "txtSdt");
									SaveDictionaryIntoHanhDong(dicNoiDungReview, "txtComment");
									SaveDictionaryIntoHanhDong(dicHDTuongTacBaiVietChiDinhComment, "txtComment");
									if (!isStop)
									{
										if (num3 + 1 < list.Count)
										{
											int num8 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayKichBanFrom"), setting_InteractGeneral.GetValueInt("nudDelayKichBanTo") + 1);
											int tickCount = Environment.TickCount;
											while ((Environment.TickCount - tickCount) / 1000 - num8 < 0)
											{
												ShowTrangThai(text + string.Format(Language.GetValue("Chạy kịch bản tiếp theo sau {time} giây...").Replace("{time}", (num8 - (Environment.TickCount - tickCount) / 1000).ToString())));
												MCommon.Common.DelayTime(0.5);
												if (isStop)
												{
													break;
												}
											}
										}
										num3++;
										continue;
									}
								}
								if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll") || isStop)
								{
									break;
								}
								if (num2 + 1 < num)
								{
									int num9 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayTurnFrom"), setting_InteractGeneral.GetValueInt("nudDelayTurnTo") + 1) * 60;
									int tickCount2 = Environment.TickCount;
									while ((Environment.TickCount - tickCount2) / 1000 - num9 < 0)
									{
										ShowTrangThai(text + string.Format(Language.GetValue("Chạy lượt tiếp theo sau {time} giây...").Replace("{time}", (num9 - (Environment.TickCount - tickCount2) / 1000).ToString())));
										MCommon.Common.DelayTime(0.5);
										if (isStop)
										{
											break;
										}
									}
								}
								if (isStop)
								{
									break;
								}
								num2++;
								goto IL_0d94;
							}
							break;
							IL_0d94:;
						}
						end_IL_0001:;
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
					HideTrangThai();
					CloseFormViewChrome();
					cControl("stop");
					isCountCheckAccountWhenChayTuongTac = false;
				}).Start();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				cControl("stop");
				isCountCheckAccountWhenChayTuongTac = false;
			}
			int x = ((File.Exists("settings\\language.txt") && File.ReadAllText("settings\\language.txt").StartsWith("1")) ? 1 : 0);
		}

		private void RunByLDPlayer()
		{
			lstDevice = new List<Device>();
			Thread thread = null;
			try
			{
				thread = new Thread((ThreadStart)delegate
				{
					while (true)
					{
						try
						{
							if (isResetAdb && lstDevice.Count > 0)
							{
								bool flag = false;
								while (!flag)
								{
									flag = true;
									for (int num11 = 0; num11 < lstDevice.Count; num11++)
									{
										string deviceByIndex = ADBHelper.GetDeviceByIndex(lstDevice[num11].IndexDevice);
										if (string.IsNullOrEmpty(deviceByIndex))
										{
											flag = false;
										}
										else
										{
											lstDevice[num11].DeviceId = deviceByIndex;
										}
									}
								}
								isResetAdb = false;
							}
						}
						catch
						{
						}
						MCommon.Common.DelayTime(5.0);
					}
				});
				thread.IsBackground = true;
				thread.Start();
			}
			catch
			{
			}
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				isReloginIfLogout = setting_InteractGeneral.GetValueBool("ckbReloginIfLogout");
				bool isRunSwap = setting_general.GetValueBool("isRunSwap");
				string pathLD = ConfigHelper.GetPathLDPlayer();
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				int maxThread = setting_general.GetValueInt("nudInteractThread", 3);
				maxThread = ((CountChooseRowInDatagridview() < maxThread) ? CountChooseRowInDatagridview() : maxThread);
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
				{
					listApiTinsoft = GetListKeyTinsoft();
					if (listApiTinsoft.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy Tinsoft không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTinsoft = new List<TinsoftProxy>();
					for (int j = 0; j < listApiTinsoft.Count; j++)
					{
						TinsoftProxy item2 = new TinsoftProxy(listApiTinsoft[j], setting_general.GetValueInt("nudLuongPerIPTinsoft"), setting_general.GetValueInt("cbbLocationTinsoft"));
						listTinsoft.Add(item2);
					}
					if (listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft") < maxThread)
					{
						maxThread = listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft");
					}
					break;
				}
				case 8:
				{
					listProxyXproxy = setting_general.GetValueList("txtListProxy");
					if (listProxyXproxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng cấu hình lại!"), 2);
						return;
					}
					listxProxy = new List<XproxyProxy>();
					for (int k = 0; k < listProxyXproxy.Count; k++)
					{
						XproxyProxy item3 = new XproxyProxy(setting_general.GetValue("txtServiceURLXProxy"), listProxyXproxy[k], setting_general.GetValueInt("typeProxy"), setting_general.GetValueInt("nudLuongPerIPXProxy"));
						listxProxy.Add(item3);
					}
					if (listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy") < maxThread)
					{
						maxThread = listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy");
					}
					break;
				}
				case 10:
				{
					listProxyTMProxy = setting_general.GetValueList("txtApiKeyTMProxy");
					if (listProxyTMProxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("TMProxy không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTMProxy = new List<TMProxy>();
					for (int i = 0; i < listProxyTMProxy.Count; i++)
					{
						TMProxy item = new TMProxy(listProxyTMProxy[i], 0, setting_general.GetValueInt("nudLuongPerIPTMProxy"));
						listTMProxy.Add(item);
					}
					if (listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy") < maxThread)
					{
						maxThread = listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy");
					}
					break;
				}
				}
				List<int> lstPossition = new List<int>();
				for (int l = 0; l < maxThread; l++)
				{
					lstPossition.Add(0);
				}
				isOpeningDevice = false;
				checkDelayLD = 0;
				cControl("start");
				if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
				{
					OpenFormViewLD(isRunSwap);
					for (int m = 0; m < maxThread; m++)
					{
						fViewLD.remote.AddPanelDevice(m + 1);
					}
				}
				isCountCheckAccountWhenChayTuongTac = true;
				isStop = false;
				int curChangeIp = 0;
				bool isChangeIPSuccess = false;
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						List<string> list = new List<string>();
						string idKichBan = "";
						string text = "";
						int num = setting_InteractGeneral.GetValueInt("nudSoLuotChay", 1);
						if (num == 0)
						{
							num = 1;
						}
						int num2 = 0;
						while (num2 < num)
						{
							list = new List<string>();
							if (setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
							{
								text = ((num > 1) ? string.Format(Language.GetValue("Lượt {0}/{1}. "), num2 + 1, num) : "");
								if (setting_InteractGeneral.GetValueBool("RepeatAllVIP"))
								{
									list = setting_InteractGeneral.GetValueList("lstIdKichBan");
									if (setting_InteractGeneral.GetValueBool("ckbRandomKichBan"))
									{
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
									}
								}
								else
								{
									list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
								}
							}
							else
							{
								list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
							}
							int num3 = 0;
							while (true)
							{
								if (num3 < list.Count && !isStop)
								{
									idKichBan = list[num3];
									if (text != "")
									{
										ShowTrangThai(text + string.Format(Language.GetValue("Kịch bản") + ": {0}...", InteractSQL.GetTenKichBanById(idKichBan)));
									}
									if (setting_InteractGeneral.GetValueBool("ckbRandomThuTuTaiKhoan"))
									{
										dtgvAcc.Invoke((MethodInvoker)delegate
										{
											RandomThuTuTaiKhoan();
										});
									}
									dicUidNhom = GetDictionaryIntoHanhDong(idKichBan, "HDThamGiaNhomUid");
									dicUidCaNhan = GetDictionaryIntoHanhDong(idKichBan, "HDKetBanTepUid");
									dicHDSpamBaiVietID = GetDictionaryIntoHanhDong(idKichBan, "HDSpamBaiViet");
									dicHDDangBaiTuong_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiTuong", "txtNoiDung");
									dicHDDangBaiNhom_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiNhom", "txtNoiDung");
									dicUidTuongTacPage = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacPage");
									dicSdt = GetDictionaryIntoHanhDong(idKichBan, "HDDongBoDanhBa", "txtSdt");
									dicNoiDungReview = GetDictionaryIntoHanhDong(idKichBan, "HDDanhGiaPage", "txtComment");
									dicHDTuongTacBaiVietChiDinhComment = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacBaiVietChiDinh", "txtComment");
									int num4 = 0;
									while (num4 < dtgvAcc.Rows.Count && !isStop)
									{
										if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
										{
											num4++;
											goto IL_098e;
										}
										if (isStop)
										{
											break;
										}
										if (lstThread.Count < maxThread)
										{
											if (isStop)
											{
												break;
											}
											int row = num4++;
											Thread thread2 = new Thread((ThreadStart)delegate
											{
												try
												{
													int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
													ExcuteOneThread(row, indexOfPossitionApp + 1, idKichBan, isRunSwap, pathLD);
													MCommon.Common.FillIndexPossition(ref lstPossition, indexOfPossitionApp);
												}
												catch (Exception ex3)
												{
													MCommon.Common.ExportError(null, ex3);
												}
												if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
												{
													SetCellAccount(row, "cChose", false);
												}
											})
											{
												Name = row.ToString()
											};
											lock (lstThread)
											{
												lstThread.Add(thread2);
											}
											MCommon.Common.DelayTime(1.0);
											thread2.Start();
											goto IL_098e;
										}
										if (isStop)
										{
											break;
										}
										if ((setting_general.GetValueInt("ip_iTypeChangeIp") == 7 && setting_general.GetValueBool("ckbWaitDoneAllTinsoft")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 8 && setting_general.GetValueBool("ckbWaitDoneAllXproxy")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 10 && setting_general.GetValueBool("ckbWaitDoneAllTMProxy")))
										{
											for (int n = 0; n < lstThread.Count; n++)
											{
												lstThread[n].Join();
												lock (lstThread)
												{
													lstThread.RemoveAt(n--);
												}
											}
											goto IL_098e;
										}
										if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10)
										{
											for (int num5 = 0; num5 < lstThread.Count; num5++)
											{
												if (!lstThread[num5].IsAlive)
												{
													lock (lstThread)
													{
														lstThread.RemoveAt(num5--);
													}
												}
											}
											goto IL_098e;
										}
										for (int num6 = 0; num6 < lstThread.Count; num6++)
										{
											lstThread[num6].Join();
											lock (lstThread)
											{
												lstThread.RemoveAt(num6--);
											}
										}
										if (isStop)
										{
											break;
										}
										Interlocked.Increment(ref curChangeIp);
										if (curChangeIp < setting_general.GetValueInt("ip_nudChangeIpCount", 1))
										{
											goto IL_098e;
										}
										for (int num7 = 0; num7 < 3; num7++)
										{
											isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
											if (isChangeIPSuccess)
											{
												break;
											}
										}
										if (isChangeIPSuccess)
										{
											curChangeIp = 0;
											goto IL_098e;
										}
										MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 2);
										goto end_IL_0001;
										IL_098e:
										if (isStop)
										{
											break;
										}
									}
									for (int num8 = 0; num8 < lstThread.Count; num8++)
									{
										lstThread[num8].Join();
									}
									SaveDictionaryIntoHanhDong(dicUidNhom);
									SaveDictionaryIntoHanhDong(dicUidCaNhan);
									SaveDictionaryIntoHanhDong(dicHDSpamBaiVietID);
									SaveDictionaryIntoHanhDong(dicHDDangBaiTuong_NoiDung, "txtNoiDung");
									SaveDictionaryIntoHanhDong(dicHDDangBaiNhom_NoiDung, "txtNoiDung");
									SaveDictionaryIntoHanhDong(dicUidTuongTacPage);
									SaveDictionaryIntoHanhDong(dicSdt, "txtSdt");
									SaveDictionaryIntoHanhDong(dicNoiDungReview, "txtComment");
									SaveDictionaryIntoHanhDong(dicHDTuongTacBaiVietChiDinhComment, "txtComment");
									if (!isStop)
									{
										if (num3 + 1 < list.Count)
										{
											int num9 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayKichBanFrom"), setting_InteractGeneral.GetValueInt("nudDelayKichBanTo") + 1);
											int tickCount = Environment.TickCount;
											while ((Environment.TickCount - tickCount) / 1000 - num9 < 0)
											{
												ShowTrangThai(text + string.Format(Language.GetValue("Chạy kịch bản tiếp theo sau {time} giây...").Replace("{time}", (num9 - (Environment.TickCount - tickCount) / 1000).ToString())));
												MCommon.Common.DelayTime(0.5);
												if (isStop)
												{
													break;
												}
											}
										}
										num3++;
										continue;
									}
								}
								if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll") || isStop)
								{
									break;
								}
								if (num2 + 1 < num)
								{
									int num10 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayTurnFrom"), setting_InteractGeneral.GetValueInt("nudDelayTurnTo") + 1) * 60;
									int tickCount2 = Environment.TickCount;
									while ((Environment.TickCount - tickCount2) / 1000 - num10 < 0)
									{
										ShowTrangThai(text + string.Format(Language.GetValue("Chạy lượt tiếp theo sau {time} giây...").Replace("{time}", (num10 - (Environment.TickCount - tickCount2) / 1000).ToString())));
										MCommon.Common.DelayTime(0.5);
										if (isStop)
										{
											break;
										}
									}
								}
								if (isStop)
								{
									break;
								}
								num2++;
								goto IL_0d94;
							}
							break;
							IL_0d94:;
						}
						end_IL_0001:;
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
					HideTrangThai();
					if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
					{
						CloseFormViewLD();
					}
					cControl("stop");
					isCountCheckAccountWhenChayTuongTac = false;
				}).Start();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				cControl("stop");
				isCountCheckAccountWhenChayTuongTac = false;
			}
			int x = ((File.Exists("settings\\language.txt") && File.ReadAllText("settings\\language.txt").StartsWith("1")) ? 1 : 0);
		}

		private void BtnInteract_Click(object sender, EventArgs e)
		{
			LoadSetting();
			string pathPictureLDPlayer = ConfigHelper.GetPathPictureLDPlayer();
			if (Directory.Exists(pathPictureLDPlayer))
			{
				MCommon.Common.DeleteFolder(pathPictureLDPlayer + "\\Instagram");
			}
			if (setting_InteractGeneral.GetValueInt("typeRun") == 0)
			{
				RunByChrome();
			}
			else
			{
				RunByLDPlayer();
			}
		}

		private int HDTimKiemGoogle(int indexRow, string statusProxy, Chrome chrome, List<string> lstTuKhoa, int countTurnFrom, int countTurnTo, int countPageFrom, int countPageTo, int countLinkClickFrom, int countLinkClickTo, int countTimeScrollFrom, int countTimeScrollTo, string tenHanhDong)
		{
			int result = 0;
			try
			{
				int num = Base.rd.Next(countTurnFrom, countTurnTo + 1);
				for (int i = 0; i < num; i++)
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({i}/{num})...");
					if (lstTuKhoa.Count == 0)
					{
						break;
					}
					string text = lstTuKhoa[Base.rd.Next(0, lstTuKhoa.Count)];
					lstTuKhoa.Remove(text);
					string content = text.Split('|')[0];
					string text2 = text.Split('|')[1];
					if (!chrome.CheckChromeClosed())
					{
						chrome.GotoURL("https://www.google.com.vn/");
						chrome.DelayRandom(2, 3);
						if (chrome.CheckExistElement("input[role =\"combobox\"]", 3.0) != 1)
						{
							continue;
						}
						chrome.DelayRandom(1, 2);
						if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('input[role =\"combobox\"]')") == 1)
						{
							chrome.DelayRandom(1, 2);
						}
						switch (setting_general.GetValueInt("tocDoGoVanBan"))
						{
						case 0:
							chrome.SendKeys(rd, 4, "input[role=\"combobox\"]", content, 0.08);
							break;
						case 1:
							chrome.SendKeys(4, "input[role=\"combobox\"]", content, 0.08);
							break;
						case 2:
							chrome.SendKeys(4, "input[role=\"combobox\"]", content);
							break;
						}
						chrome.DelayRandom(2, 3);
						chrome.SendEnter(4, "input[role=\"combobox\"]");
						chrome.DelayRandom(2, 3);
						string cssSelector = chrome.GetCssSelector("a", "href", text2);
						if (cssSelector == "")
						{
							int num2 = Base.rd.Next(countPageFrom, countPageTo + 1);
							for (int j = 0; j < num2 - 1 && chrome.CheckExistElement("[aria-label=\"Page " + (j + 2) + "\"]") == 1; j++)
							{
								chrome.ScrollSmooth("document.querySelector('[aria-label=\"Page " + (j + 2) + "\"]')");
								chrome.DelayRandom(2, 3);
								chrome.Click(4, "[aria-label=\"Page " + (j + 2) + "\"]");
								chrome.DelayRandom(2, 3);
								cssSelector = chrome.GetCssSelector("a", "href", text2);
								if (cssSelector != "")
								{
									break;
								}
							}
						}
						if (cssSelector != "")
						{
							for (int k = 0; k < 10; k++)
							{
								if (Base.rd.Next(0, 100) % 5 == 1)
								{
									chrome.ScrollSmooth(-Base.rd.Next(100, 300));
								}
								else
								{
									chrome.ScrollSmooth(Base.rd.Next(100, 300));
								}
								chrome.DelayRandom(1, 2);
							}
							if (chrome.CheckExistElementOnScreen("document.querySelector('" + cssSelector + "')") != 0)
							{
								chrome.ScrollSmooth("document.querySelector('" + cssSelector + "')");
							}
							chrome.DelayRandom(2, 3);
							chrome.Click(4, cssSelector);
						}
						else
						{
							chrome.GotoURL(text2);
						}
						int num3 = Base.rd.Next(countLinkClickFrom, countLinkClickTo + 1);
						int num4 = Convert.ToInt32(chrome.ExecuteScript("var count=0; document.querySelectorAll('a').forEach(e=>{if(e.getAttribute('href')!=null && e.getAttribute('href')!='') count++}); return count+''").ToString());
						for (int l = 0; l < num3; l++)
						{
							if (num4 == 0)
							{
								break;
							}
							int index = Base.rd.Next(1, num4 + 1);
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('a')[" + index + "]");
							chrome.DelayRandom(2, 3);
							chrome.Click(4, "a", index);
							chrome.DelayTime(3.0);
							int num5 = rd.Next(1, 3);
							for (int m = 0; m < num5; m++)
							{
								chrome.ScrollSmooth(rd.Next(100, 300));
								chrome.DelayRandom(2, 3);
							}
							if (chrome.GetURL() != text2)
							{
								chrome.GotoBackPage();
								chrome.DelayRandom(2, 3);
							}
						}
						int num6 = Base.rd.Next(countTimeScrollFrom, countTimeScrollTo + 1);
						int tickCount = Environment.TickCount;
						int num7 = 1;
						do
						{
							num7 = ((Base.rd.Next(1, 1000) % 5 != 0) ? 1 : (-1));
							chrome.ScrollSmooth(num7 * Base.rd.Next(100, 300));
							chrome.DelayRandom(2, 3);
						}
						while (Environment.TickCount - tickCount < num6 * 1000);
						continue;
					}
					return -2;
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(chrome, ex, "HDSearchGoogle");
				result = -1;
			}
			return result;
		}

		private int HDTruyCapWebsite(int indexRow, string statusProxy, Chrome chrome, List<string> lstLinkWeb, int countTurnFrom, int countTurnTo, int countLinkClickFrom, int countLinkClickTo, int countTimeScrollFrom, int countTimeScrollTo, bool ckbLuot, string tenHanhDong)
		{
			int result = 0;
			try
			{
				int num = Base.rd.Next(countTurnFrom, countTurnTo + 1);
				for (int i = 0; i < num; i++)
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({i}/{num})...");
					if (lstLinkWeb.Count == 0)
					{
						break;
					}
					string text = lstLinkWeb[Base.rd.Next(0, lstLinkWeb.Count)];
					lstLinkWeb.Remove(text);
					if (!chrome.CheckChromeClosed())
					{
						chrome.GotoURL(text);
						int num2 = Base.rd.Next(countLinkClickFrom, countLinkClickTo + 1);
						int num3 = Convert.ToInt32(chrome.ExecuteScript("var count=0; document.querySelectorAll('a').forEach(e=>{if(e.getAttribute('href')!=null && e.getAttribute('href')!='') count++}); return count+''").ToString());
						for (int j = 0; j < num2; j++)
						{
							if (num3 == 0)
							{
								break;
							}
							int index = Base.rd.Next(1, num3 + 1);
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('a')[" + index + "]");
							chrome.DelayRandom(2, 3);
							chrome.Click(4, "a", index);
							chrome.DelayTime(3.0);
							int num4 = rd.Next(1, 3);
							for (int k = 0; k < num4; k++)
							{
								chrome.ScrollSmooth(rd.Next(100, 300));
								chrome.DelayRandom(2, 3);
							}
							if (chrome.GetURL() != text)
							{
								chrome.GotoBackPage();
								chrome.DelayRandom(2, 3);
							}
						}
						int num5 = Base.rd.Next(countTimeScrollFrom, countTimeScrollTo + 1);
						if (ckbLuot)
						{
							int tickCount = Environment.TickCount;
							int num6 = 1;
							do
							{
								num6 = ((Base.rd.Next(1, 1000) % 6 != 0) ? 1 : (-1));
								chrome.ScrollSmooth(num6 * Base.rd.Next(100, 300));
								chrome.DelayRandom(2, 3);
							}
							while (Environment.TickCount - tickCount < num5 * 1000);
						}
						else
						{
							chrome.DelayTime(num5);
						}
						continue;
					}
					return -2;
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(chrome, ex, "HDSearchGoogle");
				result = -1;
			}
			return result;
		}

		private List<string> GetListBountsAvailability(List<string> lstBounds)
		{
			List<string> list = new List<string>();
			lstBounds = lstBounds.Distinct().ToList();
			for (int i = 0; i < lstBounds.Count; i++)
			{
				if (lstBounds[i] != "[0,0][0,0]")
				{
					list.Add(lstBounds[i]);
				}
			}
			return list;
		}

		private int LoginInstagram(Device device, int indexRow, string statusProxy)
		{
			int result = -1;
			string cellAccount = GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			if (cellAccount.Trim() == "" || cellAccount2.Trim() == "")
			{
				if (cellAccount.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y User!"));
				}
				else if (cellAccount2.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
				}
			}
			else
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng User|Pass..."), device);
				result = device.LoginInstagram(cellAccount, cellAccount2, cellAccount3);
			}
			return result;
		}

		private string LoginInstagram(Chrome chrome, int indexRow, int typeLogin, string statusProxy)
		{
			string result = "0";
			string cellAccount = GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			string cellAccount4 = GetCellAccount(indexRow, "cCookies");
			if (typeLogin == 0)
			{
				if (cellAccount.Trim() == "" || cellAccount2.Trim() == "")
				{
					if (cellAccount.Trim() == "")
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y User!"));
					}
					else if (cellAccount2.Trim() == "")
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
					}
				}
				else
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng User|Pass..."));
					result = CommonChrome.LoginInstagram(chrome, cellAccount, cellAccount2, cellAccount3);
				}
			}
			else if (cellAccount4.Trim() == "")
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Cookie!"));
			}
			else
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng Cookie..."));
				result = CommonChrome.LoginInstagram(chrome, cellAccount4);
			}
			return result;
		}

		private int CheckStatusDevice(Device device, int indexRow, string statusProxy)
		{
			device.LoadStatusLD("Check status...");
			string html = "";
			int num = device.CheckStatusDevice(ref html);
			device.LoadStatusLD($"Check status: {num}...");
			if ((num.ToString() ?? "").StartsWith("-1"))
			{
				if (device.CheckExistText("\"ok\"", html))
				{
					device.TapByText("\"ok\"", html);
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			if (num3 != -1)
			{
				return num;
			}
			if (isReloginIfLogout)
			{
				device.CloseAppInstagram();
				string text = "";
				for (int i = 0; i < 10; i++)
				{
					text = device.OpenInstagramAndCheckStatusLogin(0).Split('|')[1];
					if (text == "0")
					{
						break;
					}
				}
				if (text != "1" && LoginInstagram(device, indexRow, statusProxy) == 1)
				{
					return 1;
				}
			}
			return -1;
		}

		private void ExcuteOneThread(int indexRow, int indexPos, string idKichBan, bool isRunSwap, string pathLD)
		{
			int num = 0;
			string text = "";
			int num2 = 0;
			string text2 = "";
			int typeProxy = 0;
			string text3 = "";
			TinsoftProxy tinsoftProxy = null;
			XproxyProxy xproxyProxy = null;
			TMProxy tMProxy = null;
			Device device = null;
			int num3 = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int sttTaiKhoan = Convert.ToInt32(GetCellAccount(indexRow, "cStt"));
			string text4 = GetCellAccount(indexRow, "cUid");
			string cellAccount = GetCellAccount(indexRow, "cId");
			GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cFa2");
			string cellAccount3 = GetCellAccount(indexRow, "cPassword");
			string cellAccount4 = GetCellAccount(indexRow, "cCookies");
			GetCellAccount(indexRow, "cToken");
			if (text4 == "")
			{
				text4 = CommonIG.GetUidFromCookie(cellAccount4);
			}
			try
			{
				if (isStop)
				{
					SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
					num3 = 1;
				}
				else
				{
					while (true)
					{
						switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
						{
						case 10:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tMProxy = null;
									while (!isStop)
									{
										foreach (TMProxy item in listTMProxy)
										{
											if (tMProxy == null || item.daSuDung < tMProxy.daSuDung)
											{
												tMProxy = item;
											}
										}
										if (tMProxy.daSuDung != tMProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tMProxy.daSuDung > 0 || tMProxy.ChangeProxy())
									{
										text = tMProxy.proxy;
										if (text == "")
										{
											text = tMProxy.GetProxy();
										}
										tMProxy.dangSuDung++;
										tMProxy.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag5 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag5 = false;
										}
									}
									if (!flag5)
									{
										tMProxy.dangSuDung--;
										tMProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0109;
						case 8:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Xproxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									xproxyProxy = null;
									while (!isStop)
									{
										foreach (XproxyProxy item2 in listxProxy)
										{
											if (xproxyProxy == null || item2.daSuDung < xproxyProxy.daSuDung)
											{
												xproxyProxy = item2;
											}
										}
										if (xproxyProxy.daSuDung != xproxyProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (xproxyProxy.daSuDung > 0 || xproxyProxy.ChangeProxy())
									{
										text = xproxyProxy.proxy;
										typeProxy = xproxyProxy.typeProxy;
										xproxyProxy.dangSuDung++;
										xproxyProxy.daSuDung++;
										break;
									}
								}
								bool flag4;
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
								}
								else
								{
									flag4 = true;
									if (setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										goto IL_05d9;
									}
									text2 = "(IP: " + text.Split(':')[0] + ") ";
									SetStatusAccount(indexRow, text2 + "Check IP...");
									int num4 = 0;
									while (true)
									{
										if (num4 < 30)
										{
											MCommon.Common.DelayTime(1.0);
											text3 = MCommon.Common.CheckProxy(text, typeProxy);
											if (!(text3 != ""))
											{
												if (!isStop)
												{
													num4++;
													continue;
												}
												SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
												num3 = 1;
												break;
											}
										}
										if (text3 == "")
										{
											flag4 = false;
										}
										goto IL_05d9;
									}
								}
								goto end_IL_03a8;
								IL_05d9:
								if (!flag4)
								{
									xproxyProxy.dangSuDung--;
									xproxyProxy.daSuDung--;
									continue;
								}
								break;
								end_IL_03a8:;
							}
							goto end_IL_0109;
						case 7:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tinsoftProxy = null;
									while (!isStop)
									{
										foreach (TinsoftProxy item3 in listTinsoft)
										{
											if (tinsoftProxy == null || item3.daSuDung < tinsoftProxy.daSuDung)
											{
												tinsoftProxy = item3;
											}
										}
										if (tinsoftProxy.daSuDung != tinsoftProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tinsoftProxy.daSuDung > 0 || tinsoftProxy.ChangeProxy())
									{
										text = tinsoftProxy.proxy;
										if (text == "")
										{
											text = tinsoftProxy.GetProxy();
										}
										tinsoftProxy.dangSuDung++;
										tinsoftProxy.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag6 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag6 = false;
										}
									}
									if (!flag6)
									{
										tinsoftProxy.dangSuDung--;
										tinsoftProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0109;
						case 9:
							text = GetCellAccount(indexRow, "cProxy");
							typeProxy = ((text.Split('*').Length > 1) ? Convert.ToInt32(text.Split('*')[1]) : 0);
							text = text.Split('*')[0];
							break;
						}
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						if (!setting_general.GetValueBool("ckbKhongCheckIP"))
						{
							if (setting_general.GetValueInt("ip_iTypeChangeIp") != 7 && setting_general.GetValueInt("ip_iTypeChangeIp") != 8 && setting_general.GetValueInt("ip_iTypeChangeIp") != 10)
							{
								if (text != "")
								{
									text2 = "(IP: " + text.Split(':')[0] + ") ";
								}
								SetStatusAccount(indexRow, text2 + "Check IP...");
								bool flag7 = false;
								int num5 = 0;
								while (true)
								{
									if (num5 < 30)
									{
										MCommon.Common.DelayTime(1.0);
										text3 = MCommon.Common.CheckProxy(text, typeProxy);
										if (!(text3 != ""))
										{
											if (!isStop)
											{
												num5++;
												continue;
											}
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
											num3 = 1;
											break;
										}
										flag7 = true;
									}
									if (!flag7)
									{
										if (text != "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thể kết nối proxy!"));
										}
										else
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có kết nối Internet!"));
										}
										num3 = 1;
										break;
									}
									goto IL_0b2e;
								}
								break;
							}
							goto IL_0b2e;
						}
						goto IL_0b40;
						IL_0b40:
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						num = Environment.TickCount;
						if (isRunSwap)
						{
							device = new Device(pathLD, indexPos.ToString() ?? "");
							if (!Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
								for (int i = 0; i < 2; i++)
								{
									ADBHelper.AddDevice(pathLD);
									if (Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
									{
										break;
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
								lock (lock_restoreDevice)
								{
									device.Restore();
								}
								device.ChangeHardwareLDPlayer2();
								device.ChangeFileConfig();
							}
						}
						else
						{
							string text5 = GetCellAccount(indexRow, "cDevice");
							if (text5 == "" || !Directory.Exists(pathLD + "\\vms\\leidian" + text5))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị, chờ đến lượt..."));
								lock (lock_checkDelayCreateDevice)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
									List<string> listIndexLDPlayer = ADBHelper.GetListIndexLDPlayer(pathLD);
									ADBHelper.AddDevice(pathLD);
									for (int j = 0; j < 30; j++)
									{
										text5 = ADBHelper.GetListIndexLDPlayer(pathLD).Except(listIndexLDPlayer).First();
										if (text5 != "")
										{
											break;
										}
									}
									if (text5 == "")
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị thất bại!"));
										num3 = 1;
										goto IL_22b4;
									}
								}
								device = new Device(pathLD, text5);
								SetCellAccount(indexRow, "cDevice", text5);
								CommonSQL.UpdateFieldToAccount(cellAccount, "device", text5);
								SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
								lock (lock_restoreDevice)
								{
									device.Restore();
								}
								device.ChangeHardwareLDPlayer2();
								device.ChangeFileConfig();
							}
							else
							{
								device = new Device(pathLD, text5 ?? "");
							}
						}
						string text6 = FileHelper.GetPathToCurrentFolder() + "\\device\\" + cellAccount + "\\config";
						string text7 = FileHelper.GetPathToCurrentFolder() + "\\device\\" + text4 + "\\config";
						if (File.Exists(text6) && text4 != "" && !File.Exists(text7))
						{
							try
							{
								MCommon.Common.CreateFolder(FileHelper.GetPathToCurrentFolder() + "\\device\\" + text4);
								File.Move(text6, text7);
								Directory.Delete(FileHelper.GetPathToCurrentFolder() + "\\device\\" + cellAccount);
							}
							catch
							{
							}
						}
						if (text4 != "" && File.Exists(text7))
						{
							device.RestoreConfigDevice(text4);
							device.ChangeFileConfig();
						}
						else if (File.Exists(text6))
						{
							device.RestoreConfigDevice(cellAccount);
							device.ChangeFileConfig();
						}
						else
						{
							device.ChangeHardwareLDPlayer2();
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Chờ đến lượt..."));
						lock (lock_checkDelayLD)
						{
							if (setting_general.GetValueInt("typeOpenDevice") == 0)
							{
								while (true)
								{
									if (isOpeningDevice)
									{
										MCommon.Common.DelayTime(0.5);
										if (!isStop)
										{
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										goto IL_22b4;
									}
									isOpeningDevice = true;
									break;
								}
							}
							else if (checkDelayLD > 0)
							{
								int num6 = rd.Next(setting_general.GetValueInt("nudDelayOpenDeviceFrom", 1), setting_general.GetValueInt("nudDelayOpenDeviceTo", 1) + 1);
								if (num6 > 0)
								{
									int tickCount = Environment.TickCount;
									while ((Environment.TickCount - tickCount) / 1000 - num6 < 0)
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiê\u0301t bi\u0323 sau {time}s...".Replace("{time}", (num6 - (Environment.TickCount - tickCount) / 1000).ToString())));
										device.LoadStatusLD("Open device after {time}s...".Replace("{time}", (num6 - (Environment.TickCount - tickCount) / 1000).ToString()));
										MCommon.Common.DelayTime(0.5);
										if (!isStop)
										{
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										goto IL_22b4;
									}
								}
							}
							else
							{
								checkDelayLD++;
							}
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị..."));
						device.LoadStatusLD("Open device...");
						device.Open();
						if (device.process == null)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
							isOpeningDevice = false;
							num3 = 1;
							break;
						}
						if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
						{
							fViewLD.remote.AddLDIntoPanel(device.process.MainWindowHandle, device.IndexDevice, sttTaiKhoan);
						}
						if (!device.CheckOpenedDevice())
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
							isOpeningDevice = false;
							num3 = 1;
							break;
						}
						isOpeningDevice = false;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị thành công!"));
						if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
						{
							fViewLD.remote.ShowPicTurnOffDevice(device.IndexDevice);
						}
						device.LoadStatusLD("Open device success...");
						lstDevice.Add(device);
						for (int k = 0; k < 5; k++)
						{
							device.lstPackages = device.GetListPackages();
							if (device.lstPackages.Contains("com.instagram.android") && device.lstPackages.Contains("com.android.adbkeyboard"))
							{
								break;
							}
							if (!device.lstPackages.Contains("com.instagram.android"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Instagram..."), device);
								device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\instagram.apk");
							}
							if (!device.lstPackages.Contains("com.android.adbkeyboard"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Keyboard..."), device);
								device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\ADBKeyboard.apk");
							}
						}
						if (!device.lstPackages.Contains("com.instagram.android") || !device.lstPackages.Contains("com.android.adbkeyboard"))
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Install App!"));
							num3 = 1;
							break;
						}
						device.ExecuteCMD("shell settings put secure location_providers_allowed -gps");
						device.RemoveProxy();
						if (text != "")
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Connect proxy..."), device);
							if (text.Split(':').Length != 2)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Chưa hô\u0303 trơ\u0323 proxy da\u0323ng user pass!"));
								num3 = 1;
								break;
							}
							device.ConnectProxy(text);
						}
						if (isRunSwap)
						{
							device.ClearDataAppFacebook();
							if (File.Exists(FileHelper.GetPathToCurrentFolder() + "\\profile\\" + text4 + "\\data.tar.gz"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Restore dữ liệu Fb..."), device);
								device.RestoreAccountFacebook(text4);
							}
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở app Instagram..."), device);
						string text8 = device.OpenInstagramAndCheckStatusLogin();
						if (text8.Split('|')[0] == "0")
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở app Instagram!"));
							num3 = 1;
							break;
						}
						if (text8.Split('|')[0] == "2")
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi đăng nhập swap!"));
							num3 = 1;
							break;
						}
						if (text8.Split('|')[1] == "0")
						{
							num2 = LoginInstagram(device, indexRow, text2);
						}
						else if (text8.Split('|')[1] == "11")
						{
							device.ClearDataAppFacebook();
							num2 = LoginInstagram(device, indexRow, text2);
						}
						else
						{
							num2 = Convert.ToInt32(text8.Split('|')[1]);
						}
						switch (num2)
						{
						case 0:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thất bại!"));
							break;
						case 1:
							SetInfoAccount(cellAccount, indexRow, "Live");
							break;
						case 2:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Checkpoint!"));
							SetInfoAccount(cellAccount, indexRow, "Checkpoint!");
							break;
						case 3:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Không có 2fa!"));
							break;
						case 4:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Tài khoản không đúng!"));
							break;
						case 5:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Mật khẩu không đúng!"));
							SetInfoAccount(cellAccount, indexRow, "Changed pass!");
							break;
						case 6:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Mã 2FA không đúng!"));
							break;
						case 7:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi kết nối Internet!"));
							break;
						case 8:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Tài khoản chưa xác minh!"));
							break;
						case 9:
							SetInfoAccount(cellAccount, indexRow, "Checkpoint: Confirm phone");
							SetStatusAccount(indexRow, text2 + Language.GetValue("Checkpoint: Confirm phone"));
							break;
						case 10:
							SetStatusAccount(indexRow, text2 + Language.GetValue("Không thê\u0309 login!"));
							break;
						}
						if (num2 != 1)
						{
							num3 = 1;
							device.CheckDevice("", "", "log\\loginfail" + num2);
							break;
						}
						flag3 = true;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thành công..."), device);
						DataTable dataTable = InteractSQL.GetAllHanhDongByKichBan(idKichBan);
						if (setting_InteractGeneral.GetValueBool("ckbRandomHanhDong"))
						{
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
						}
						string text9 = "";
						string text10 = "";
						DataTable dataTable2 = new DataTable();
						string cauHinhFromKichBan = InteractSQL.GetCauHinhFromKichBan(idKichBan);
						JSON_Settings jSON_Settings = new JSON_Settings(cauHinhFromKichBan, isJsonString: true);
						int valueInt = jSON_Settings.GetValueInt("typeSoLuongHanhDong");
						int valueInt2 = jSON_Settings.GetValueInt("nudHanhDongFrom");
						int valueInt3 = jSON_Settings.GetValueInt("nudHanhDongTo");
						int num7 = dataTable.Rows.Count;
						if (valueInt == 1 && valueInt2 <= valueInt3)
						{
							num7 = Base.rd.Next(valueInt2, valueInt3 + 1);
							if (num7 > dataTable.Rows.Count)
							{
								num7 = dataTable.Rows.Count;
							}
						}
						for (int l = 0; l < num7; l++)
						{
							if (!isStop)
							{
								if (device.GetActivity() == "com.android.launcher3/com.android.launcher3.Launcher")
								{
									device.OpenAppInstagram();
								}
								try
								{
									text10 = dataTable.Rows[l]["TenHanhDong"].ToString();
									text9 = dataTable.Rows[l]["Id_HanhDong"].ToString();
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đang") + " " + text10 + "...", device);
									dataTable2 = InteractSQL.GetHanhDongById(text9);
									JSON_Settings jSON_Settings2 = new JSON_Settings(dataTable2.Rows[0]["CauHinh"].ToString(), isJsonString: true);
									switch (dataTable2.Rows[0]["TenTuongTac"].ToString())
									{
									case "HDFollowGoiY":
										try
										{
											num2 = HDFollowGoiY(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex21)
										{
											MCommon.Common.ExportError(ex21, "HDFollowGoiY");
										}
										break;
									case "HDNhanTinFollowing":
										try
										{
											num2 = HDNhanTinFollowing(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex20)
										{
											MCommon.Common.ExportError(ex20, "HDNhanTinFollowing");
										}
										break;
									case "HDNghiGiaiLao":
										try
										{
											num2 = HDNghiGiaiLao(indexRow, text2, jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text10);
										}
										catch (Exception ex19)
										{
											MCommon.Common.ExportError(ex19, "HDNghiGiaiLao");
										}
										break;
									case "HDFollowBackFollower":
										try
										{
											num2 = HDFollowBackFollower(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex18)
										{
											MCommon.Common.ExportError(ex18, "fHDFollowBackFollower");
										}
										break;
									case "HDNhanTinFollowers":
										try
										{
											num2 = HDNhanTinFollowers(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex17)
										{
											MCommon.Common.ExportError(ex17, "HDNhanTinFollowers");
										}
										break;
									case "HDTuongTacFollowing":
										try
										{
											num2 = HDTuongTacFollowing(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex16)
										{
											MCommon.Common.ExportError(ex16, "HDTuongTacFollowing");
										}
										break;
									case "HDFolloweFollowerCuaUserKhac":
										try
										{
											num2 = HDFollowFollowerCuaUser(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex15)
										{
											MCommon.Common.ExportError(ex15, "HDFolloweFollowerCuaUserKhac");
										}
										break;
									case "HDTuongTacNewsfeed":
										try
										{
											num2 = HDTuongTacNewsfeed(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex14)
										{
											MCommon.Common.ExportError(ex14, "HDTuongTacNewsfeed");
										}
										break;
									case "HDLuotStory":
										try
										{
											num2 = HDLuotStory(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex13)
										{
											MCommon.Common.ExportError(ex13, "HDLuotStory");
										}
										break;
									case "HDShareBaiViet":
										try
										{
											num2 = HDSharebaiviet(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex12)
										{
											MCommon.Common.ExportError(ex12, "HDShareBaiViet");
										}
										break;
									case "HDFollowLikedPost":
										try
										{
											num2 = HDFolloweLikedPost(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex11)
										{
											MCommon.Common.ExportError(ex11, "HDFollowLikedPost");
										}
										break;
									case "HDNhanTinTheoLink":
										try
										{
											num2 = HDNhanTinTheoLink(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex10)
										{
											MCommon.Common.ExportError(ex10, "HDNhanTinTheoLink");
										}
										break;
									case "HDfollowTheoDiaDiem":
										try
										{
											num2 = HDFollowTheoDiaDiem(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex9)
										{
											MCommon.Common.ExportError(ex9, "HDfollowTheoDiaDiem");
										}
										break;
									case "HDTuongTacFollowers":
										try
										{
											num2 = HDTuongTacFollowers(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex8)
										{
											MCommon.Common.ExportError(ex8, "HDTuongTacFollowers");
										}
										break;
									case "HDTuongTacBaiVietChiDinh":
										try
										{
											num2 = HDTuongTacBaiVietChiDinh(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex7)
										{
											MCommon.Common.ExportError(ex7, "HDTuongTacBaiVietChiDinh");
										}
										break;
									case "HDFollowTheoTuKhoa":
										try
										{
											num2 = HDFollowTheoTuKhoa(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex6)
										{
											MCommon.Common.ExportError(ex6, "HDFollowTheoTuKhoa");
										}
										break;
									case "HDViewDiscover":
										try
										{
											num2 = HDViewDiscover(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex5)
										{
											MCommon.Common.ExportError(ex5, "HDViewDiscover");
										}
										break;
									case "HDFolloweFollowingCuaUserKhac":
										try
										{
											num2 = HDFollowFollowingCuaUser(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex4)
										{
											MCommon.Common.ExportError(ex4, "HDFolloweFollowingCuaUserKhac");
										}
										break;
									case "HDSpamBaiViet":
										try
										{
											num2 = HDSpamBaiViet(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex3)
										{
											MCommon.Common.ExportError(ex3, "HDSpamBaiViet");
										}
										break;
									case "HDFollowTheoLink":
										try
										{
											num2 = HDFollowTheoLink(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex2)
										{
											MCommon.Common.ExportError(ex2, "HDFollowTheoLink");
										}
										break;
									case "HDUnFollow":
										try
										{
											num2 = HDUnFollow(indexRow, text2, device, jSON_Settings2);
										}
										catch (Exception ex)
										{
											MCommon.Common.ExportError(ex, "HDUnFollow");
										}
										break;
									}
								}
								catch (Exception ex22)
								{
									MCommon.Common.ExportError(ex22, "Tuong tac theo kich ban");
								}
								switch (num2)
								{
								case -2:
									SetStatusAccount(indexRow, text2 + "Thiết bị đã bị đóng!");
									num3 = 1;
									goto end_IL_0109;
								case -5:
									flag2 = true;
									goto end_IL_0109;
								case -4:
									flag = true;
									goto end_IL_0109;
								}
								continue;
							}
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						break;
						IL_0b2e:
						text2 = "(IP: " + text3 + ") ";
						goto IL_0b40;
					}
				}
				end_IL_0109:;
			}
			catch (Exception ex23)
			{
				device.ExportError(ex23, "Lô\u0303i không xa\u0301c đi\u0323nh!");
				SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				num3 = 1;
				MCommon.Common.ExportError(null, ex23, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
			}
			goto IL_22b4;
			IL_22b4:
			string text11 = "";
			if (num3 == 1)
			{
				text11 = GetStatusAccount(indexRow);
			}
			try
			{
				int num8 = rd.Next(setting_general.GetValueInt("nudDelayCloseDeviceFrom"), setting_general.GetValueInt("nudDelayCloseDeviceTo") + 1);
				if (num8 > 0)
				{
					int tickCount2 = Environment.TickCount;
					while ((Environment.TickCount - tickCount2) / 1000 - num8 < 0)
					{
						if (!isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đóng LD sau {time}s...").Replace("{time}", (num8 - (Environment.TickCount - tickCount2) / 1000).ToString()));
							MCommon.Common.DelayTime(0.5);
							continue;
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
						break;
					}
				}
				if (flag3)
				{
					if (text4 != "")
					{
						device.BackupConfigDevice(text4);
					}
					else
					{
						device.BackupConfigDevice(cellAccount);
					}
					if (isRunSwap && device.CheckIsLive())
					{
						SetStatusAccount(indexRow, text2 + Language.GetValue("Backup dữ liệu Ig..."));
						BackupAccountFacebook(device, text4, cellAccount3, cellAccount2);
						CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
						SetCellAccount(indexRow, "cProfile", "Yes");
					}
				}
				device.CloseAppInstagram();
				if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
				{
					fViewLD.remote.RemovePanelDevice(device.IndexDevice);
				}
				else
				{
					device.Close();
				}
			}
			catch
			{
			}
			lstDevice.Remove(device);
			string text12 = text11;
			string text13 = text12;
			if (!(text13 == ""))
			{
				SetStatusAccount(indexRow, text2 + text11 + (flag2 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag ? "- Facebook blocked" : ""));
			}
			else
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã tương tác xong!") + (flag2 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag ? "- Facebook blocked" : "") + " [" + MCommon.Common.ConvertSecondsToTime((Environment.TickCount - num) / 1000) + "(s)]");
				SetCellAccount(indexRow, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				CommonSQL.UpdateFieldToAccount(cellAccount, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				SetInfoAccount(cellAccount, indexRow, "Live");
			}
			lock (lock_FinishProxy)
			{
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
					tinsoftProxy?.DecrementDangSuDung();
					break;
				case 8:
					xproxyProxy?.DecrementDangSuDung();
					break;
				case 10:
					tMProxy?.DecrementDangSuDung();
					break;
				case 9:
					break;
				}
			}
		}

		private void ExcuteOneThread_Chrome(int indexRow, int indexPos, string idKichBan, string profilePath)
		{
			int num = 0;
			string text = "";
			Chrome chrome = null;
			int num2 = 0;
			string text2 = "";
			int typeProxy = 0;
			string text3 = "";
			TinsoftProxy tinsoftProxy = null;
			XproxyProxy xproxyProxy = null;
			TMProxy tMProxy = null;
			int num3 = 0;
			bool flag = false;
			string text4 = GetCellAccount(indexRow, "cUid");
			string cellAccount = GetCellAccount(indexRow, "cId");
			string text5 = GetCellAccount(indexRow, "cEmail");
			GetCellAccount(indexRow, "cFa2");
			GetCellAccount(indexRow, "cPassword");
			string cellAccount2 = GetCellAccount(indexRow, "cCookies");
			GetCellAccount(indexRow, "cToken");
			if (text4 == "")
			{
				text4 = CommonIG.GetUidFromCookie(cellAccount2);
			}
			try
			{
				if (isStop)
				{
					SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
					num3 = 1;
				}
				else
				{
					while (true)
					{
						switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
						{
						case 10:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tMProxy = null;
									while (!isStop)
									{
										foreach (TMProxy item in listTMProxy)
										{
											if (tMProxy == null || item.daSuDung < tMProxy.daSuDung)
											{
												tMProxy = item;
											}
										}
										if (tMProxy.daSuDung != tMProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tMProxy.daSuDung > 0 || tMProxy.ChangeProxy())
									{
										text = tMProxy.proxy;
										if (text == "")
										{
											text = tMProxy.GetProxy();
										}
										tMProxy.dangSuDung++;
										tMProxy.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag3 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag3 = false;
										}
									}
									if (!flag3)
									{
										tMProxy.dangSuDung--;
										tMProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_00e1;
						case 8:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Xproxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									xproxyProxy = null;
									while (!isStop)
									{
										foreach (XproxyProxy item2 in listxProxy)
										{
											if (xproxyProxy == null || item2.daSuDung < xproxyProxy.daSuDung)
											{
												xproxyProxy = item2;
											}
										}
										if (xproxyProxy.daSuDung != xproxyProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (xproxyProxy.daSuDung > 0 || xproxyProxy.ChangeProxy())
									{
										text = xproxyProxy.proxy;
										typeProxy = xproxyProxy.typeProxy;
										xproxyProxy.dangSuDung++;
										xproxyProxy.daSuDung++;
										break;
									}
								}
								bool flag2;
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
								}
								else
								{
									flag2 = true;
									if (setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										goto IL_05b9;
									}
									text2 = "(IP: " + text.Split(':')[0] + ") ";
									SetStatusAccount(indexRow, text2 + "Check IP...");
									int num4 = 0;
									while (true)
									{
										if (num4 < 30)
										{
											MCommon.Common.DelayTime(1.0);
											text3 = MCommon.Common.CheckProxy(text, typeProxy);
											if (!(text3 != ""))
											{
												if (!isStop)
												{
													num4++;
													continue;
												}
												SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
												num3 = 1;
												break;
											}
										}
										if (text3 == "")
										{
											flag2 = false;
										}
										goto IL_05b9;
									}
								}
								goto end_IL_0384;
								IL_05b9:
								if (!flag2)
								{
									xproxyProxy.dangSuDung--;
									xproxyProxy.daSuDung--;
									continue;
								}
								break;
								end_IL_0384:;
							}
							goto end_IL_00e1;
						case 7:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tinsoftProxy = null;
									while (!isStop)
									{
										foreach (TinsoftProxy item3 in listTinsoft)
										{
											if (tinsoftProxy == null || item3.daSuDung < tinsoftProxy.daSuDung)
											{
												tinsoftProxy = item3;
											}
										}
										if (tinsoftProxy.daSuDung != tinsoftProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tinsoftProxy.daSuDung > 0 || tinsoftProxy.ChangeProxy())
									{
										text = tinsoftProxy.proxy;
										if (text == "")
										{
											text = tinsoftProxy.GetProxy();
										}
										tinsoftProxy.dangSuDung++;
										tinsoftProxy.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag4 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag4 = false;
										}
									}
									if (!flag4)
									{
										tinsoftProxy.dangSuDung--;
										tinsoftProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_00e1;
						case 9:
							text = GetCellAccount(indexRow, "cProxy");
							typeProxy = ((text.Split('*').Length > 1) ? Convert.ToInt32(text.Split('*')[1]) : 0);
							text = text.Split('*')[0];
							break;
						}
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						if (!setting_general.GetValueBool("ckbKhongCheckIP"))
						{
							if (setting_general.GetValueInt("ip_iTypeChangeIp") != 7 && setting_general.GetValueInt("ip_iTypeChangeIp") != 8 && setting_general.GetValueInt("ip_iTypeChangeIp") != 10)
							{
								if (text != "")
								{
									text2 = "(IP: " + text.Split(':')[0] + ") ";
								}
								SetStatusAccount(indexRow, text2 + "Check IP...");
								bool flag5 = false;
								int num5 = 0;
								while (true)
								{
									if (num5 < 30)
									{
										MCommon.Common.DelayTime(1.0);
										text3 = MCommon.Common.CheckProxy(text, typeProxy);
										if (!(text3 != ""))
										{
											if (!isStop)
											{
												num5++;
												continue;
											}
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
											num3 = 1;
											break;
										}
										flag5 = true;
									}
									if (!flag5)
									{
										if (text != "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thể kết nối proxy!"));
										}
										else
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có kết nối Internet!"));
										}
										num3 = 1;
										break;
									}
									goto IL_0b17;
								}
								break;
							}
							goto IL_0b17;
						}
						goto IL_0b2a;
						IL_0b2a:
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						num = Environment.TickCount;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Chờ đến lượt..."));
						lock (lock_checkDelayChrome)
						{
							if (checkDelayChrome > 0)
							{
								int num6 = rd.Next(setting_general.GetValueInt("nudDelayOpenChromeFrom", 1), setting_general.GetValueInt("nudDelayOpenChromeTo", 1) + 1);
								if (num6 > 0)
								{
									int tickCount = Environment.TickCount;
									while ((Environment.TickCount - tickCount) / 1000 - num6 < 0)
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mở tri\u0300nh duyê\u0323t sau") + " {time}s...".Replace("{time}", (num6 - (Environment.TickCount - tickCount) / 1000).ToString()));
										MCommon.Common.DelayTime(0.5);
										if (!isStop)
										{
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										goto IL_20c4;
									}
								}
							}
							else
							{
								checkDelayChrome++;
							}
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
						string text6 = "data:,";
						Point position;
						Point size;
						if (setting_general.GetValueBool("ckbAddChromeIntoForm"))
						{
							if (text6 == "")
							{
								position = new Point(-1000, 0);
								size = new Point(setting_general.GetValueInt("nudWidthChrome") + 16, setting_general.GetValueInt("nudHeighChrome") + 132);
							}
							else
							{
								position = new Point(-1000, 0);
								size = new Point(setting_general.GetValueInt("nudWidthChrome") + 33, setting_general.GetValueInt("nudHeighChrome") + 39);
							}
						}
						else
						{
							position = MCommon.Common.GetPointFromIndexPosition(indexPos, setting_general.GetValueInt("cbbColumnChrome", 3), setting_general.GetValueInt("cbbRowChrome", 2));
							size = MCommon.Common.GetSizeChrome(setting_general.GetValueInt("cbbColumnChrome", 3), setting_general.GetValueInt("cbbRowChrome", 2));
						}
						if (Directory.Exists(profilePath + "\\" + cellAccount) && text4 != "" && !Directory.Exists(profilePath + "\\" + text4))
						{
							string text7 = profilePath + "\\" + cellAccount;
							string pathTo = profilePath + "\\" + text4;
							if (!MCommon.Common.MoveFolder(text7, pathTo) && MCommon.Common.CopyFolder(text7, pathTo))
							{
								MCommon.Common.DeleteFolder(text7);
							}
						}
						string text8 = "";
						text8 = ((!(text4 != "")) ? (profilePath + "\\" + cellAccount) : (profilePath + "\\" + text4));
						if (!setting_general.GetValueBool("ckbCreateProfile") && !Directory.Exists(text8))
						{
							text8 = "";
						}
						chrome = new Chrome
						{
							IndexChrome = indexRow,
							DisableImage = !Convert.ToBoolean((setting_general.GetValue("ckbShowImageInteract") == "") ? "false" : setting_general.GetValue("ckbShowImageInteract")),
							ProfilePath = text8,
							Size = size,
							Position = position,
							TimeWaitForSearchingElement = 3,
							TimeWaitForLoadingPage = 120,
							Proxy = text,
							TypeProxy = typeProxy,
							DisableSound = true,
							App = text6,
							IsUsePortable = setting_general.GetValueBool("ckbUsePortable"),
							PathToPortableZip = setting_general.GetValue("txtPathToPortableZip")
						};
						chrome.IsSwitchUseragent = true;
						if (setting_general.GetValue("sizeChrome").Contains("x"))
						{
							chrome.IsUseEmulator = true;
							string text9 = setting_general.GetValue("sizeChrome").Substring(0, setting_general.GetValue("sizeChrome").LastIndexOf('x'));
							int pixelRatio = Convert.ToInt32(setting_general.GetValue("sizeChrome").Split('x')[2]);
							chrome.Size_Emulator = new Point(Convert.ToInt32(text9.Split('x')[0]), Convert.ToInt32(text9.Split('x')[1]));
							chrome.UserAgent = Base.useragentDefault;
							chrome.PixelRatio = pixelRatio;
						}
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						if (setting_general.GetValueInt("typeBrowser") != 0)
						{
							chrome.LinkToOtherBrowser = setting_general.GetValue("txtLinkToOtherBrowser");
						}
						int num7 = 0;
						while (true)
						{
							if (chrome.Open())
							{
								chrome.ExecuteScript("document.title=\"proxyauth=" + text + "\"");
								chrome.DelayTime(2.0);
								if (!setting_general.GetValueBool("ckbKhongCheckIP") && text.Split(':').Length > 1)
								{
									chrome.GotoURL("http://v4v6.ipv6-test.com/api/myip.php?json");
									chrome.DelayTime(1.0);
									string pageSource = chrome.GetPageSource();
									if (!pageSource.Contains("address"))
									{
										chrome.Close();
										num7++;
										if (num7 >= 3)
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi kết nối proxy!"));
											num3 = 1;
											break;
										}
										continue;
									}
								}
								if (!chrome.GetProcess())
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Không check đươ\u0323c chrome!"));
									num3 = 1;
									break;
								}
								if (setting_general.GetValueBool("ckbAddChromeIntoForm"))
								{
									if (text6 != "")
									{
										fViewChrome.remote.AddPanelDevice(chrome.IndexChrome, chrome.Size.X - 33, chrome.Size.Y - 39);
										fViewChrome.remote.AddChromeIntoPanel(chrome.process.MainWindowHandle, chrome.IndexChrome, chrome.Size.X, chrome.Size.Y);
									}
									else
									{
										fViewChrome.remote.AddPanelDevice(chrome.IndexChrome, chrome.Size.X - 16, chrome.Size.Y - 132);
										fViewChrome.remote.AddChromeIntoPanel(chrome.process.MainWindowHandle, chrome.IndexChrome, chrome.Size.X + 17, chrome.Size.Y, -10, -125);
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đang đăng nhâ\u0323p..."));
								bool flag6;
								if (!(flag6 = CommonChrome.CheckLoginSuccess(chrome)))
								{
									string text10 = LoginInstagram(chrome, indexRow, setting_general.GetValueInt("typeLogin"), text2);
									switch (text10)
									{
									default:
										SetStatusAccount(indexRow, text2 + text10);
										break;
									case "6":
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mã 2fa không đúng!"));
										break;
									case "3":
										SetStatusAccount(indexRow, text2 + Language.GetValue("Không có 2fa!"));
										break;
									case "2":
										chrome.Status = StatusChromeAccount.Checkpoint;
										SetInfoAccount(cellAccount, indexRow, Language.GetValue("Checkpoint"));
										SetStatusAccount(indexRow, text2 + "Checkpoint!");
										break;
									case "1":
										flag6 = true;
										break;
									case "0":
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thất bại!"));
										break;
									}
									if (!flag6)
									{
										SetRowColor(indexRow, 1);
										num3 = 1;
										break;
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p tha\u0300nh công!"));
								SetRowColor(indexRow, 2);
								cellAccount2 = chrome.GetCookieFromChrome("instagram").Trim();
								if (cellAccount2 != "" && cellAccount2 != "-2")
								{
									SetCellAccount(indexRow, "cCookies", cellAccount2);
									CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", cellAccount2);
								}
								if (text4.Trim() == "" && cellAccount2 != "")
								{
									text4 = CommonIG.GetUidFromCookie(cellAccount2);
									SetCellAccount(indexRow, "cUid", text4);
									CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text4);
								}
								if (MCommon.Common.IsValidMail(text5) || MCommon.Common.IsNumber(text5))
								{
									string value = Regex.Match(chrome.GetPageSource(), "\"username\":\"(.*?)\"").Groups[1].Value;
									if (value.Trim() != "")
									{
										SetCellAccount(indexRow, "cEmail", value);
										CommonSQL.UpdateFieldToAccount(cellAccount, "email", value);
										CommonSQL.UpdateFieldToAccount(cellAccount, "phone", text5);
										text5 = value;
									}
								}
								DataTable dataTable = InteractSQL.GetAllHanhDongByKichBan(idKichBan);
								if (setting_InteractGeneral.GetValueBool("ckbRandomHanhDong"))
								{
									dataTable = MCommon.Common.ShuffleDataTable(dataTable);
									dataTable = MCommon.Common.ShuffleDataTable(dataTable);
									dataTable = MCommon.Common.ShuffleDataTable(dataTable);
								}
								string text11 = "";
								string text12 = "";
								DataTable dataTable2 = new DataTable();
								string cauHinhFromKichBan = InteractSQL.GetCauHinhFromKichBan(idKichBan);
								JSON_Settings jSON_Settings = new JSON_Settings(cauHinhFromKichBan, isJsonString: true);
								int valueInt = jSON_Settings.GetValueInt("typeSoLuongHanhDong");
								int valueInt2 = jSON_Settings.GetValueInt("nudHanhDongFrom");
								int valueInt3 = jSON_Settings.GetValueInt("nudHanhDongTo");
								int num8 = dataTable.Rows.Count;
								if (valueInt == 1 && valueInt2 <= valueInt3)
								{
									num8 = Base.rd.Next(valueInt2, valueInt3 + 1);
									if (num8 > dataTable.Rows.Count)
									{
										num8 = dataTable.Rows.Count;
									}
								}
								for (int i = 0; i < num8; i++)
								{
									if (!isStop)
									{
										try
										{
											text12 = dataTable.Rows[i]["TenHanhDong"].ToString();
											text11 = dataTable.Rows[i]["Id_HanhDong"].ToString();
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đang") + " " + text12 + "...");
											dataTable2 = InteractSQL.GetHanhDongById(text11);
											JSON_Settings jSON_Settings2 = new JSON_Settings(dataTable2.Rows[0]["CauHinh"].ToString(), isJsonString: true);
											switch (dataTable2.Rows[0]["TenTuongTac"].ToString())
											{
											case "HDFollowGoiY":
												try
												{
													num2 = Chrome_FolloweTheoGoiY(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex20)
												{
													MCommon.Common.ExportError(ex20, "HDFollowGoiY");
												}
												break;
											case "HDNhanTinFollowing":
												try
												{
													num2 = Chrome_NhanTinVoiFollowing(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex19)
												{
													MCommon.Common.ExportError(ex19, "HDNhanTinFollowing");
												}
												break;
											case "HDNghiGiaiLao":
												try
												{
													num2 = HDNghiGiaiLao(indexRow, text2, jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text12);
												}
												catch (Exception ex18)
												{
													MCommon.Common.ExportError(ex18, "HDNghiGiaiLao");
												}
												break;
											case "HDFollowBackFollower":
												try
												{
													num2 = Chrome_FollowBackFollower(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex17)
												{
													MCommon.Common.ExportError(ex17, "HDFollowBackFollower");
												}
												break;
											case "HDNhanTinFollowers":
												try
												{
													num2 = Chrome_NhanTinVoiFollower(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex16)
												{
													MCommon.Common.ExportError(ex16, "HDNhanTinFollowers");
												}
												break;
											case "HDFolloweFollowerCuaUserKhac":
												try
												{
													num2 = Chrome_FollowFollowerCuaUser(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex15)
												{
													MCommon.Common.ExportError(ex15, "HDFolloweFollowerCuaUserKhac");
												}
												break;
											case "HDUpAvatar":
												try
												{
													num2 = Chrome_UpAvatar(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex14)
												{
													MCommon.Common.ExportError(ex14, "HDUpAvatar");
												}
												break;
											case "HDLuotStory":
												try
												{
													num2 = Chrome_LuotStory(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex13)
												{
													MCommon.Common.ExportError(ex13, "HDTuongTacFollowers");
												}
												break;
											case "HDShareBaiViet":
												try
												{
													num2 = Chrome_Sharebaiviet(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex12)
												{
													MCommon.Common.ExportError(ex12, "HDShareBaiViet");
												}
												break;
											case "HDTuongTacFollowing":
												try
												{
													num2 = Chrome_TuongTacFollowing(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex11)
												{
													MCommon.Common.ExportError(ex11, "HDTuongTacFollowing");
												}
												break;
											case "HDNhanTinTheoLink":
												try
												{
													num2 = Chrome_NhanTinTheoUser(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex10)
												{
													MCommon.Common.ExportError(ex10, "HDNhanTinTheoLink");
												}
												break;
											case "HDTuongTacNewsfeed":
												try
												{
													num2 = Chrome_TuongTacNewsfeed(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex9)
												{
													MCommon.Common.ExportError(ex9, "HDTuongTacNewsfeed");
												}
												break;
											case "HDTuongTacFollowers":
												try
												{
													num2 = Chrome_TuongTacFollower(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex8)
												{
													MCommon.Common.ExportError(ex8, "HDTuongTacFollowers");
												}
												break;
											case "HDTuongTacBaiVietChiDinh":
												try
												{
													num2 = Chrome_TuongTacBaiVietChiDinh(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex7)
												{
													MCommon.Common.ExportError(ex7, "HDTuongTacBaiVietChiDinh");
												}
												break;
											case "HDFollowLikedPost":
												try
												{
													num2 = Chrome_FollowLikedPost(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex6)
												{
													MCommon.Common.ExportError(ex6, "HDFollowLikedPost");
												}
												break;
											case "HDDangBai":
												try
												{
													num2 = Chrome_DangBai(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex5)
												{
													MCommon.Common.ExportError(ex5, "HDDangBai");
												}
												break;
											case "HDFolloweFollowingCuaUserKhac":
												try
												{
													num2 = Chrome_FollowFolloweingCuaUser(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex4)
												{
													MCommon.Common.ExportError(ex4, "HDFolloweFollowingCuaUserKhac");
												}
												break;
											case "HDSpamBaiViet":
												try
												{
													num2 = Chrome_SpamBaiViet(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex3)
												{
													MCommon.Common.ExportError(ex3, "HDSpamBaiViet");
												}
												break;
											case "HDFollowTheoLink":
												try
												{
													num2 = Chrome_FolloweTheoUser(indexRow, chrome, jSON_Settings2);
												}
												catch (Exception ex2)
												{
													MCommon.Common.ExportError(ex2, "HDFollowTheoLink");
												}
												break;
											case "HDUnFollow":
												try
												{
													num2 = Chrome_Unfollowe(indexRow, chrome, jSON_Settings2, text5);
												}
												catch (Exception ex)
												{
													MCommon.Common.ExportError(ex, "HDUnFollow");
												}
												break;
											}
										}
										catch (Exception ex21)
										{
											MCommon.Common.ExportError(ex21, "Tuong tac theo kich ban");
										}
										_ = chrome.chrome.Manage().Window.Size.Width;
										_ = chrome.chrome.Manage().Window.Size.Height;
										switch (num2)
										{
										case -2:
											SetStatusAccount(indexRow, text2 + "Chrome đã bị đóng!");
											num3 = 1;
											goto end_IL_00e1;
										case -4:
											flag = true;
											goto end_IL_00e1;
										}
										continue;
									}
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
									break;
								}
							}
							else
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở trình duyệt!"));
								num3 = 1;
							}
							break;
						}
						break;
						IL_0b17:
						text2 = "(IP: " + text3 + ") ";
						goto IL_0b2a;
					}
				}
				end_IL_00e1:;
			}
			catch (Exception ex22)
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				num3 = 1;
				MCommon.Common.ExportError(null, ex22, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
			}
			goto IL_20c4;
			IL_20c4:
			string text13 = "";
			if (num3 == 1)
			{
				text13 = GetStatusAccount(indexRow);
			}
			try
			{
				if (chrome?.CheckIsLive() ?? false)
				{
					int num9 = rd.Next(setting_general.GetValueInt("nudDelayCloseChromeFrom"), setting_general.GetValueInt("nudDelayCloseChromeTo") + 1);
					if (num9 > 0)
					{
						int tickCount2 = Environment.TickCount;
						while ((Environment.TickCount - tickCount2) / 1000 - num9 < 0)
						{
							if (!isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đóng tri\u0300nh duyê\u0323t sau {time}s...").Replace("{time}", (num9 - (Environment.TickCount - tickCount2) / 1000).ToString()));
								MCommon.Common.DelayTime(0.5);
								continue;
							}
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							break;
						}
					}
					try
					{
						fViewChrome.remote.RemovePanelDevice(chrome.IndexChrome);
					}
					catch
					{
					}
					try
					{
						chrome.Close();
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			string text14 = text13;
			string text15 = text14;
			if (!(text15 == ""))
			{
				SetStatusAccount(indexRow, text2 + text13 + (flag ? "- Facebook blocked" : ""));
			}
			else
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã tương tác xong!") + (flag ? "- Facebook blocked" : "") + " [" + MCommon.Common.ConvertSecondsToTime((Environment.TickCount - num) / 1000) + "(s)]");
				SetCellAccount(indexRow, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				CommonSQL.UpdateFieldToAccount(cellAccount, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				SetInfoAccount(cellAccount, indexRow, "Live");
			}
			lock (lock_FinishProxy)
			{
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
					tinsoftProxy?.DecrementDangSuDung();
					break;
				case 8:
					xproxyProxy?.DecrementDangSuDung();
					break;
				case 10:
					tMProxy?.DecrementDangSuDung();
					break;
				case 9:
					break;
				}
			}
		}

		private int Chrome_Sharebaiviet(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			setting.GetValueInt("nudSoLuongBaiVietFrom", 1);
			int num = rd.Next(setting.GetValueInt("nudSoLuongBaiVietFrom"), setting.GetValueInt("nudSoLuongBaiVietTo", 1) + 1);
			string value = setting.GetValue("txtLinkBaiViet");
			string text = "qwertyuiopasdfghjklzxcvbnm";
			string text2 = "";
			try
			{
				if (value.Contains("instagram"))
				{
					chrome.GotoURL(value);
				}
				else
				{
					chrome.GotoURL("https://www.instagram.com/p/" + value);
				}
				if (chrome.CheckExistElement("section>span:nth-child(3)>button", 10.0) == 1 && chrome.Click(4, "section>span:nth-child(3)>button") == 1)
				{
					DelayThaoTacNho();
					if (chrome.CheckExistElement("[name=\"queryBox\"]", 10.0) == 1)
					{
						int num2 = 0;
						for (int i = 0; i < num; i++)
						{
							text2 = text[rd.Next(0, text.Length)].ToString();
							chrome.SendKeys(4, "[name=\"queryBox\"]", text2);
							DelayThaoTacNho();
							if (chrome.Click(4, "button .glyphsSpriteCircle__outline__24__grey_2") != 1)
							{
								num2++;
								if (num2 > 3)
								{
									break;
								}
							}
							else
							{
								num2 = 0;
								DelayThaoTacNho();
							}
						}
						if (chrome.Click(4, "[role=\"dialog\"]>div>div:nth-child(2)>div:nth-child(5)>button") == 1)
						{
							DelayThaoTacNho();
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_FolloweTheoGoiY(int indexRow, Chrome chrome, JSON_Settings settings)
		{
			int result = 1;
			int num = rd.Next(settings.GetValueInt("nudSoLuongFrom"), settings.GetValueInt("nudSoLuongTo") + 1);
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			try
			{
				chrome.GotoURL("https://www.instagram.com/explore/people/suggested/");
				DelayThaoTacNho();
				if (chrome.CheckExistElement("[role=\"main\"]", 10.0) == 1)
				{
					for (int i = 0; i < num; i++)
					{
						if (chrome.CheckExistElement("document.querySelectorAll('[type=\"button\"]')[" + i + "]", 5.0) != 1)
						{
							break;
						}
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[type=\"button\"]')[" + i + "]");
						chrome.DelayTime(1.0);
						if (chrome.Click(4, "[type=\"button\"]", i) == 1)
						{
							chrome.DelayRandom(valueInt, valueInt2);
							SetStatusAccount(indexRow, "Đang follow theo gợi ý: " + (i + 1) + "/" + num);
							continue;
						}
						break;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_FollowBackFollower(int indexRow, Chrome chrome, JSON_Settings settings, string username)
		{
			int result = 1;
			int num = rd.Next(settings.GetValueInt("nudSoLuongFrom"), settings.GetValueInt("nudSoLuongTo") + 1);
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			try
			{
				string url = "https://www.instagram.com/" + username;
				chrome.GotoURL(url);
				DelayThaoTacNho();
				if (chrome.CheckExistElement("[href=\"/" + username + "/followers/\"]", 10.0) == 1)
				{
					chrome.Click(4, "[href=\"/" + username + "/followers/\"]");
					DelayThaoTacNho(2);
					if (chrome.CheckExistElement("[role=\"main\"]", 10.0) == 1)
					{
						int num2 = 0;
						while (num2 < num && chrome.CheckExistElement(".PZuss li>div>div:nth-child(2) button", 2.0) == 1)
						{
							chrome.ScrollSmooth("document.querySelectorAll('.PZuss li>div>div:nth-child(2) button')[0]");
							DelayThaoTacNho();
							if (chrome.Click(4, ".PZuss li>div>div:nth-child(2) button") == 1)
							{
								num2++;
								chrome.DelayRandom(valueInt, valueInt2);
								SetStatusAccount(indexRow, "Đang follow: " + (num2 + 1) + "/" + num);
								continue;
							}
							break;
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_FolloweTheoUser(int indexRow, Chrome chrome, JSON_Settings settings)
		{
			int result = 1;
			List<string> valueList = settings.GetValueList("txtUid");
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			int num = 0;
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					SetStatusAccount(indexRow, "Đang follow user" + valueList[i]);
					string url = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					chrome.GotoURL(url);
					num++;
					if (chrome.CheckExistElement("[role=\"main\"]", 10.0) == 1)
					{
						num++;
						if (Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('section')[1].querySelectorAll('button').length")) == 3)
						{
							num++;
							_ = chrome.Click(4, "section", 0, 4, "button", 1) == 0;
							SetStatusAccount(indexRow, "Đang follow user: " + valueList[i] + "...");
							chrome.DelayRandom(valueInt, valueInt2 + 1);
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_TuongTacBaiVietChiDinh(int indexRow, Chrome chrome, JSON_Settings settings)
		{
			int result = 1;
			int valueInt = settings.GetValueInt("nudTimeFrom");
			int valueInt2 = settings.GetValueInt("nudTimeTo");
			bool valueBool = settings.GetValueBool("ckbInteract");
			bool valueBool2 = settings.GetValueBool("ckbComment");
			List<string> valueList = settings.GetValueList("txtComment");
			string text = "";
			string value = settings.GetValue("txtIdPost");
			try
			{
				string url = (value.Trim().StartsWith("https://www.instagram.com/p/") ? value.Trim() : ("https://www.instagram.com/p/" + value.Trim()));
				chrome.GotoURL(url);
				if (chrome.CheckExistElement("article[role=\"presentation\"]", 10.0) == 1)
				{
					chrome.DelayRandom(valueInt, valueInt2);
					if (valueBool && chrome.CheckExistElement("article>div:nth-child(4)>section:nth-child(1) [type=\"button\"] span>[fill=\"#262626\"]", 10.0) == 1)
					{
						chrome.ScrollSmooth("document.querySelector('article section:nth-child(1)>span:nth-child(1) [type=\"button\"]')");
						DelayThaoTacNho();
						chrome.Click(4, "article section:nth-child(1)>span:nth-child(1) [type=\"button\"]");
						DelayThaoTacNho();
					}
					if (valueBool2 && chrome.Click(4, "article section:nth-child(1)>span:nth-child(2) [type=\"button\"]") == 1)
					{
						chrome.ScrollSmooth("document.querySelector('article section:nth-child(1)>span:nth-child(2) [type=\"button\"]')");
						DelayThaoTacNho();
						text = valueList[rd.Next(0, valueList.Count())];
						text = MCommon.Common.SpinText(text, rd);
						chrome.SendKeys(4, "article textarea", text);
						DelayThaoTacNho();
						chrome.Click(4, "[type=\"submit\"]");
						DelayThaoTacNho();
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_SpamBaiViet(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			int valueInt = setting.GetValueInt("nudSoLuongBaiVietFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBaiVietTo");
			int valueInt3 = setting.GetValueInt("nudDelayFrom");
			int valueInt4 = setting.GetValueInt("nudDelayTo");
			List<string> valueList = setting.GetValueList("txtUid");
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			string text = "";
			int num = 0;
			List<string> valueList2 = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList2);
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			string text2 = "";
			int num2 = 0;
			bool flag = false;
			try
			{
				for (int i = 0; i < valueList.Count(); i++)
				{
					SetStatusAccount(indexRow, "Đang spam bài viết của: " + valueList[i]);
					num = rd.Next(valueInt, valueInt2 + 1);
					string url = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					chrome.GotoURL(url);
					DelayThaoTacNho();
					list2.Clear();
					list3.Clear();
					if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 10.0) == 1 && !(flag = chrome.CheckExistElement("[aria-label=\"Camera\"]") == 1 || chrome.CheckExistElement("article [role=\"button\"] a") == 1))
					{
						num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
						for (int j = 0; j < num2; j++)
						{
							list2.Add(chrome.ExecuteScript("return document.querySelectorAll('article a')[" + j + "].getAttribute('href')").ToString());
						}
						list3 = CloneList(list2);
						if (list2.Count() == 0)
						{
							chrome.GotoBackPage();
						}
						for (int k = 0; k < num; k++)
						{
							text2 = list3.First();
							list3.Remove(text2);
							flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[href=\"" + text2 + "\"]')") == 1;
							DelayThaoTacNho();
							if (!flag)
							{
								break;
							}
							chrome.Click(4, "[href=\"" + text2 + "\"]");
							DelayThaoTacNho();
							if (valueBool && chrome.CheckExistElement("article>div:nth-child(4)>section:nth-child(1) [type=\"button\"] span>[fill=\"#262626\"]", 2.0) == 1)
							{
								chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(1)>button");
								DelayThaoTacNho();
							}
							if (valueBool2 && (flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(2)>button") == 1))
							{
								text = list[rd.Next(0, list.Count())];
								list.Remove(text);
								if (list.Count() == 0)
								{
									list = CloneList(valueList2);
								}
								text = MCommon.Common.SpinText(text, rd);
								chrome.SendKeys(4, "section textarea", text);
								DelayThaoTacNho();
								chrome.SendEnter(4, "section textarea");
								DelayThaoTacNho(3);
							}
							chrome.GotoBackPage();
							if (list3.Count() != 0)
							{
								continue;
							}
							chrome.Scroll(20, 300);
							num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
							for (int l = 0; l < num2; l++)
							{
								text2 = chrome.ExecuteScript("return document.querySelectorAll('article a')[" + l + "].getAttribute('href')").ToString();
								if (list2.Contains(text2))
								{
									list2.Remove(text2);
								}
								else
								{
									list2.Add(text2);
								}
							}
							if (list2.Count != 0)
							{
								list3 = CloneList(list2);
								continue;
							}
							goto end_IL_00e9;
						}
					}
					chrome.DelayRandom(valueInt3, valueInt4 + 1);
				}
				end_IL_00e9:;
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_Unfollowe(int indexRow, Chrome chrome, JSON_Settings setting, string username)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongFrom"), setting.GetValueInt("nudSoLuongTo"));
			setting.GetValueInt("nudDelayFrom");
			setting.GetValueInt("nudDelayTo");
			bool flag = false;
			List<string> valueList = setting.GetValueList("txtLstNgoaiTru");
			bool valueBool = setting.GetValueBool("ckbNgoaiTru");
			string text = "";
			if (setting.GetValueInt("typeUnFollow") == 0)
			{
				flag = true;
			}
			try
			{
				chrome.GotoURL("https://www.instagram.com/" + username);
				DelayThaoTacNho();
				if (flag)
				{
					if (chrome.Click(4, "[href=\"/" + username + "/following/\"]") == 1)
					{
						DelayThaoTacNho();
						if (chrome.CheckExistElement("[role=\"main\"] li [type=\"button\"]", 5.0) == 1)
						{
							for (int i = 0; i < num; i++)
							{
								SetStatusAccount(indexRow, "Đang unfollow người mình theo dõi: " + (i + 1) + "/" + num);
								if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[role=\"main\"] li [type=\"button\"]')[" + i + "]") != 1)
								{
									break;
								}
								DelayThaoTacNho();
								if (valueBool)
								{
									text = chrome.ExecuteScript("return document.querySelectorAll('[role=\"main\"] li a')[" + i + "].getAttribute('href')").ToString().Split('/')[1].ToString();
									if (valueList.Contains(text))
									{
										continue;
									}
								}
								if (chrome.Click(4, "[role=\"main\"] li [type=\"button\"]", i) == 1)
								{
									DelayThaoTacNho();
									if (chrome.Click(4, "[role=\"dialog\"]", 1, 4, "button:nth-child(1)") == 1)
									{
										DelayThaoTacNho();
										continue;
									}
									break;
								}
								break;
							}
						}
					}
				}
				else if (chrome.Click(4, "[href=\"/" + username + "/followers/\"]") == 1)
				{
					DelayThaoTacNho();
					for (int j = 0; j < num; j++)
					{
						SetStatusAccount(indexRow, "Đang xóa người theo dõi mình: " + (j + 1) + "/" + num);
						if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[role=\"main\"] li [type=\"button\"]')[" + j + "]") != 1)
						{
							break;
						}
						DelayThaoTacNho();
						if (valueBool)
						{
							text = chrome.ExecuteScript("return document.querySelectorAll('[role=\"main\"] li a')[" + j + "].getAttribute('href')").ToString().Split('/')[1].ToString();
							if (valueList.Contains(text))
							{
								continue;
							}
						}
						if (chrome.Click(4, "[role=\"main\"] li [type=\"button\"]:nth-child(1)", j) == 1)
						{
							DelayThaoTacNho();
							if (chrome.Click(4, "[role=\"dialog\"]", 1, 4, "button:nth-child(1)") == 1)
							{
								DelayThaoTacNho();
								continue;
							}
							break;
						}
						break;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_NhanTinTheoUser(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			setting.GetValueInt("nudDelayFrom", 3);
			setting.GetValueInt("nudDelayTo", 5);
			int valueInt = setting.GetValueInt("nudCountPicFrom");
			int valueInt2 = setting.GetValueInt("nudCountPicTo");
			int num = 0;
			bool valueBool = setting.GetValueBool("ckbAnh");
			string value = setting.GetValue("txtFolderAnh");
			List<string> valueList = setting.GetValueList("txtUid");
			List<string> valueList2 = setting.GetValueList("txtNoiDung");
			CloneList(valueList2);
			List<string> list = new List<string>();
			if (valueBool)
			{
				list = Directory.GetFiles(value, "*.*", SearchOption.AllDirectories).ToList();
			}
			List<string> list2 = CloneList(list);
			string text = "";
			string text2 = "";
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					SetStatusAccount(indexRow, "Đang nhắn tin: " + valueList[i]);
					string url = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					chrome.GotoURL(url);
					DelayThaoTacNho();
					if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) != 1)
					{
						continue;
					}
					if (Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('section')[1].querySelectorAll('button').length")) == 3)
					{
						chrome.Click(4, "section", 0, 4, "button", 1);
						DelayThaoTacNho();
					}
					if (chrome.CheckExistElementv2("document.querySelectorAll('section')[1].querySelectorAll('button')[2]", 10.0) != 1)
					{
						continue;
					}
					chrome.Click(4, "section", 1, 4, "button", 1);
					if (chrome.CheckExistElement("section textarea", 10.0) != 1)
					{
						continue;
					}
					text2 = valueList2[rd.Next(0, valueList2.Count())];
					text2 = MCommon.Common.SpinText(text2, rd);
					chrome.SendKeys(4, "section textarea", text2);
					DelayThaoTacNho();
					chrome.SendEnter(4, "section textarea");
					DelayThaoTacNho();
					if (!valueBool)
					{
						continue;
					}
					num = rd.Next(valueInt, valueInt2 + 1);
					for (int j = 0; j < num; j++)
					{
						text = list2[rd.Next(0, list.Count())];
						list2.Remove(text);
						if (list2.Count == 0)
						{
							list2 = CloneList(list);
						}
						chrome.SendKeys(4, "[method=\"POST\"] input", text);
						DelayThaoTacNho(3);
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int Chrome_NhanTinVoiFollowing(int indexRow, Chrome chrome, JSON_Settings setting, string username)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongUidFrom"), setting.GetValueInt("nudSoLuongUidTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom", 3);
			int valueInt2 = setting.GetValueInt("nudDelayTo", 5);
			int valueInt3 = setting.GetValueInt("nudCountPicFrom");
			int valueInt4 = setting.GetValueInt("nudCountPicTo");
			int num2 = 0;
			bool valueBool = setting.GetValueBool("ckbAnh");
			string value = setting.GetValue("txtFolderAnh");
			List<string> valueList = setting.GetValueList("txtNoiDung");
			CloneList(valueList);
			List<string> list = new List<string>();
			if (valueBool)
			{
				list = Directory.GetFiles(value, "*.*", SearchOption.AllDirectories).ToList();
			}
			List<string> list2 = CloneList(list);
			string text = "";
			string text2 = "";
			try
			{
				chrome.GotoURL("https://www.instagram.com/" + username);
				DelayThaoTacNho();
				if (chrome.CheckExistElement("[href=\"/" + username + "/following/\"]", 10.0) == 1)
				{
					chrome.Click(4, "[href=\"/" + username + "/following/\"]");
					DelayThaoTacNho();
					for (int i = 0; i < num; i++)
					{
						SetStatusAccount(indexRow, "Đang nhắn tin following: " + (i + 1) + "/" + num);
						if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + i + "]") != 1 || chrome.Click(4, "li span>a", i) != 1)
						{
							break;
						}
						if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) != 1)
						{
							continue;
						}
						chrome.Click(4, "section", 1, 4, "button", 1);
						if (chrome.CheckExistElement("section textarea", 10.0) != 1)
						{
							continue;
						}
						text2 = valueList[rd.Next(0, valueList.Count())];
						text2 = MCommon.Common.SpinText(text2, rd);
						chrome.SendKeys(4, "section textarea", text2);
						DelayThaoTacNho();
						chrome.SendEnter(4, "section textarea");
						DelayThaoTacNho();
						if (valueBool)
						{
							num2 = rd.Next(valueInt3, valueInt4 + 1);
							for (int j = 0; j < num2; j++)
							{
								text = list2[rd.Next(0, list.Count())];
								list2.Remove(text);
								if (list2.Count == 0)
								{
									list2 = CloneList(list);
								}
								chrome.SendKeys(4, "[method=\"POST\"] input", text);
							}
						}
						DelayThaoTacNho(3);
						chrome.GotoBackPage();
						DelayThaoTacNho();
						chrome.GotoBackPage();
						chrome.DelayRandom(valueInt, valueInt2);
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_NhanTinVoiFollower(int indexRow, Chrome chrome, JSON_Settings setting, string username)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongUidFrom"), setting.GetValueInt("nudSoLuongUidTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom", 3);
			int valueInt2 = setting.GetValueInt("nudDelayTo", 5);
			int valueInt3 = setting.GetValueInt("nudCountPicFrom");
			int valueInt4 = setting.GetValueInt("nudCountPicTo");
			int num2 = 0;
			bool valueBool = setting.GetValueBool("ckbAnh");
			string value = setting.GetValue("txtFolderAnh");
			List<string> valueList = setting.GetValueList("txtNoiDung");
			CloneList(valueList);
			List<string> list = new List<string>();
			if (valueBool)
			{
				list = Directory.GetFiles(value, "*.*", SearchOption.AllDirectories).ToList();
			}
			List<string> list2 = CloneList(list);
			string text = "";
			string text2 = "";
			try
			{
				string url = "https://www.instagram.com/" + username;
				chrome.GotoURL(url);
				DelayThaoTacNho();
				if (chrome.CheckExistElement("[href=\"/" + username + "/followers/\"]", 10.0) == 1)
				{
					chrome.Click(4, "[href=\"/" + username + "/followers/\"]");
					DelayThaoTacNho();
					for (int i = 0; i < num; i++)
					{
						SetStatusAccount(indexRow, "Đang nhắn tin followers: " + (i + 1) + "/" + num);
						if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + i + "]") != 1 || chrome.Click(4, "li span>a", i) != 1)
						{
							break;
						}
						if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) != 1)
						{
							continue;
						}
						if (Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('section')[1].querySelectorAll('button').length")) == 3)
						{
							chrome.Click(4, "section", 0, 4, "button", 1);
							DelayThaoTacNho();
						}
						chrome.Click(4, "section", 1, 4, "button", 1);
						if (chrome.CheckExistElement("section textarea", 10.0) != 1)
						{
							continue;
						}
						text2 = valueList[rd.Next(0, valueList.Count())];
						text2 = MCommon.Common.SpinText(text2, rd);
						chrome.SendKeys(4, "section textarea", text2);
						DelayThaoTacNho();
						chrome.SendEnter(4, "section textarea");
						DelayThaoTacNho();
						if (valueBool)
						{
							num2 = rd.Next(valueInt3, valueInt4 + 1);
							for (int j = 0; j < num2; j++)
							{
								text = list2[rd.Next(0, list.Count())];
								list2.Remove(text);
								if (list2.Count() == 0)
								{
									list2 = CloneList(list);
								}
								chrome.SendKeys(4, "[method=\"POST\"] input", text);
							}
						}
						DelayThaoTacNho(3);
						chrome.GotoBackPage();
						DelayThaoTacNho();
						chrome.GotoBackPage();
						chrome.DelayRandom(valueInt, valueInt2);
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int Chrome_TuongTacFollower(int indexRow, Chrome chrome, JSON_Settings setting, string username)
		{
			int result = 1;
			bool flag = false;
			int num = rd.Next(setting.GetValueInt("nudSoLuongBanBeFrom"), setting.GetValueInt("nudSoLuongBanBeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num4 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num5 = 0;
			int num6 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			string text2 = "";
			int num7 = 0;
			int num8 = 0;
			try
			{
				chrome.GotoURL("https://www.instagram.com/" + username);
				DelayThaoTacNho();
				if (flag = chrome.CheckExistElement("[href=\"/" + username + "/followers/\"]", 10.0) == 1)
				{
					chrome.Click(4, "[href=\"/" + username + "/followers/\"]");
					DelayThaoTacNho();
					for (int i = 0; i < num; i++)
					{
						num5 = 0;
						num6 = 0;
						flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + i + "]") == 1;
						DelayThaoTacNho();
						if (!flag || !(flag = chrome.Click(4, "li span>a", i) == 1))
						{
							break;
						}
						if (!(flag = chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) == 1))
						{
							continue;
						}
						if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 10.0) != 1)
						{
							break;
						}
						if (!(flag = chrome.CheckExistElement("[aria-label=\"Camera\"]", 2.0) == 1 || chrome.CheckExistElement("article [role=\"button\"] a", 2.0) == 1))
						{
							list2.Clear();
							list3.Clear();
							num8 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
							for (int j = 0; j < num8; j++)
							{
								list2.Add(chrome.ExecuteScript("return document.querySelectorAll('article a')[" + j + "].getAttribute('href')").ToString());
							}
							list3 = CloneList(list2);
							if (list2.Count() == 0)
							{
								chrome.GotoBackPage();
							}
							num7 = Environment.TickCount;
							while (Environment.TickCount - num7 < num2 * 1000)
							{
								text2 = list3.First();
								list3.Remove(text2);
								flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[href=\"" + text2 + "\"]')") == 1;
								DelayThaoTacNho();
								if (flag)
								{
									chrome.Click(4, "[href=\"" + text2 + "\"]");
									DelayThaoTacNho();
									flag = false;
									for (int k = 0; k < 10; k++)
									{
										if (flag = chrome.GetURL() == "https://www.instagram.com" + text2)
										{
											break;
										}
										chrome.DelayTime(2.0);
									}
									if (flag)
									{
										if (valueBool && num5 < num3 && chrome.CheckExistElement("article>div:nth-child(4)>section:nth-child(1) [type=\"button\"] span>[fill=\"#262626\"]", 2.0) == 1)
										{
											if (!(flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(1)>button") == 1))
											{
												num5++;
											}
											DelayThaoTacNho();
										}
										if (valueBool2 && num6 < num4 && (flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(2)>button") == 1))
										{
											text = list[rd.Next(0, list.Count())];
											list.Remove(text);
											if (list.Count() == 0)
											{
												list = CloneList(valueList);
											}
											text = MCommon.Common.SpinText(text, rd);
											chrome.SendKeys(4, "section textarea", text);
											DelayThaoTacNho();
											chrome.SendEnter(4, "section textarea");
											num6++;
										}
										DelayThaoTacNho();
										chrome.GotoBackPage();
										DelayThaoTacNho();
									}
									if (list3.Count() != 0)
									{
										continue;
									}
									num8 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
									for (int l = 0; l < num8; l++)
									{
										text2 = chrome.ExecuteScript("return document.querySelectorAll('article a')[" + l + "].getAttribute('href')").ToString();
										if (list2.Contains(text2))
										{
											list2.Remove(text2);
										}
										else
										{
											list2.Add(text2);
										}
									}
									if (list2.Count == 0)
									{
										break;
									}
									list3 = CloneList(list2);
									continue;
								}
								goto end_IL_0184;
							}
						}
						chrome.GotoBackPage();
					}
				}
				end_IL_0184:;
			}
			catch
			{
			}
			_ = chrome.chrome.Manage().Window.Size.Width;
			return result;
		}

		private int Chrome_TuongTacFollowing(int indexRow, Chrome chrome, JSON_Settings setting, string username)
		{
			int result = 1;
			bool flag = false;
			int num = rd.Next(setting.GetValueInt("nudSoLuongBanBeFrom"), setting.GetValueInt("nudSoLuongBanBeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num4 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num5 = 0;
			int num6 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			string text2 = "";
			int num7 = 0;
			int num8 = 0;
			try
			{
				chrome.GotoURL("https://www.instagram.com/" + username);
				DelayThaoTacNho();
				if (flag = chrome.CheckExistElement("[href=\"/" + username + "/following/\"]", 10.0) == 1)
				{
					chrome.Click(4, "[href=\"/" + username + "/following/\"]");
					DelayThaoTacNho();
					for (int i = 0; i < num; i++)
					{
						num5 = 0;
						num6 = 0;
						flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + i + "]") == 1;
						DelayThaoTacNho();
						if (!flag || !(flag = chrome.Click(4, "li span>a", i) == 1))
						{
							break;
						}
						if (!(flag = chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) == 1))
						{
							continue;
						}
						list2.Clear();
						list3.Clear();
						if (chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 10.0) != 1)
						{
							break;
						}
						if (!(flag = chrome.CheckExistElement("[aria-label=\"Camera\"]", 3.0) == 1 || chrome.CheckExistElement("article [role=\"button\"] a", 3.0) == 1))
						{
							num8 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
							for (int j = 0; j < num8; j++)
							{
								list2.Add(chrome.ExecuteScript("return document.querySelectorAll('article a')[" + j + "].getAttribute('href')").ToString());
							}
							list3 = CloneList(list2);
							if (list2.Count() == 0)
							{
								chrome.GotoBackPage();
							}
							num7 = Environment.TickCount;
							while (Environment.TickCount - num7 < num2 * 1000)
							{
								text2 = list3.First();
								list3.Remove(text2);
								flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[href=\"" + text2 + "\"]')") == 1;
								DelayThaoTacNho();
								if (flag)
								{
									chrome.Click(4, "[href=\"" + text2 + "\"]");
									DelayThaoTacNho();
									flag = false;
									for (int k = 0; k < 10; k++)
									{
										if (flag = chrome.GetURL() == "https://www.instagram.com" + text2)
										{
											break;
										}
										chrome.DelayTime(2.0);
									}
									if (flag)
									{
										if (valueBool && num5 < num3 && chrome.CheckExistElement("article>div:nth-child(4)>section:nth-child(1) [type=\"button\"] span>[fill=\"#262626\"]", 2.0) == 1)
										{
											if (!(flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(1)>button") == 1))
											{
												num5++;
											}
											DelayThaoTacNho();
										}
										if (valueBool2 && num6 < num4 && (flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(2)>button") == 1))
										{
											text = list[rd.Next(0, list.Count())];
											list.Remove(text);
											if (list.Count() == 0)
											{
												list = CloneList(valueList);
											}
											text = MCommon.Common.SpinText(text, rd);
											chrome.SendKeys(4, "section textarea", text);
											DelayThaoTacNho();
											chrome.SendEnter(4, "section textarea");
											num6++;
										}
										DelayThaoTacNho();
										chrome.GotoBackPage();
										DelayThaoTacNho();
									}
									if (list3.Count() != 0)
									{
										continue;
									}
									num8 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article a').length"));
									for (int l = 0; l < num8; l++)
									{
										text2 = chrome.ExecuteScript("return document.querySelectorAll('article a')[" + l + "].getAttribute('href')").ToString();
										if (list2.Contains(text2))
										{
											list2.Remove(text2);
										}
										else
										{
											list2.Add(text2);
										}
									}
									if (list2.Count == 0)
									{
										break;
									}
									list3 = CloneList(list2);
									continue;
								}
								goto end_IL_017e;
							}
						}
						chrome.GotoBackPage();
					}
				}
				end_IL_017e:;
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int Chrome_TuongTacNewsfeed(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num4 = 0;
			int num5 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			bool flag = false;
			string text2 = "";
			int num6 = 0;
			int num7 = 0;
			try
			{
				chrome.GotoURL("https://www.instagram.com/");
				DelayThaoTacNho();
				if (chrome.CheckExistElement("article", 10.0) == 1)
				{
					num7 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article').length"));
					for (int i = 0; i < num7; i++)
					{
						list2.Add(chrome.ExecuteScript("return document.querySelectorAll('article>div:nth-child(4)>div:nth-child(4)>a')[" + i + "].getAttribute('href')").ToString());
					}
					list3 = CloneList(list2);
					if (list3.Count != 0)
					{
						num6 = Environment.TickCount;
						while (Environment.TickCount - num6 < num * 1000)
						{
							text2 = list3.First();
							list3.Remove(text2);
							string jSpath = "document.querySelector('article>div:nth-child(4)>div:nth-child(4)>[href=\"" + text2 + "\"]')";
							for (int j = 0; j < 10; j++)
							{
								if (chrome.CheckExistElementOnScreen(jSpath) == 0)
								{
									break;
								}
								chrome.ScrollSmooth(jSpath);
								chrome.DelayTime(0.5);
							}
							flag = chrome.CheckExistElementOnScreen(jSpath) == 0;
							DelayThaoTacNho();
							if (!flag)
							{
								break;
							}
							chrome.Click(4, "article>div:nth-child(4)>div:nth-child(4)>[href=\"" + text2 + "\"]");
							DelayThaoTacNho();
							if (valueBool && num4 < num2 && chrome.CheckExistElement("article>div:nth-child(4)>section:nth-child(1) [type=\"button\"] span>[fill=\"#262626\"]", 2.0) == 1)
							{
								chrome.ScrollSmooth("document.querySelector('article>div:nth-child(4)>section:nth-child(1)>span:nth-child(1)>button')");
								chrome.DelayTime(1.0);
								if (flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(1)>button") == 1)
								{
									num4++;
								}
								DelayThaoTacNho();
							}
							if (valueBool2 && num5 < num3)
							{
								chrome.ScrollSmooth("article>div:nth-child(4)>section:nth-child(1)>span:nth-child(2)>button')");
								chrome.DelayTime(1.0);
								if (flag = chrome.Click(4, "article>div:nth-child(4)>section:nth-child(1)>span:nth-child(2)>button") == 1)
								{
									text = list[rd.Next(0, list.Count())];
									list.Remove(text);
									if (list.Count() == 0)
									{
										list = CloneList(valueList);
									}
									text = MCommon.Common.SpinText(text, rd);
									chrome.ScrollSmooth("section textarea");
									chrome.DelayTime(1.0);
									chrome.SendKeys(4, "section textarea", text);
									DelayThaoTacNho();
									chrome.SendEnter(4, "section textarea");
									DelayThaoTacNho(2);
									num5++;
								}
							}
							if (chrome.GetURL() != "https://www.instagram.com/")
							{
								chrome.GotoBackPage();
								DelayThaoTacNho();
							}
							if (list3.Count() != 0)
							{
								continue;
							}
							num7 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('article').length"));
							if (num7 == 0)
							{
								break;
							}
							for (int k = 0; k < num7; k++)
							{
								text2 = chrome.ExecuteScript("return document.querySelectorAll('article>div:nth-child(4)>div:nth-child(4) a')[" + k + "].getAttribute('href')").ToString();
								if (list2.Contains(text2))
								{
									list2.Remove(text2);
								}
								else
								{
									list2.Add(text2);
								}
							}
							if (list2.Count != 0)
							{
								list3 = CloneList(list2);
								continue;
							}
							break;
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_LuotStory(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongStoryFrom"), setting.GetValueInt("nudSoLuongStoryTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom");
			int valueInt2 = setting.GetValueInt("nudDelayTo");
			int valueInt3 = setting.GetValueInt("nudDelayChiDinhFrom");
			int valueInt4 = setting.GetValueInt("nudDelayChiDinhTo");
			bool valueBool = setting.GetValueBool("ckbStoryNewfeed");
			bool valueBool2 = setting.GetValueBool("ckbStoryUser");
			List<string> valueList = setting.GetValueList("txtListUser");
			try
			{
				chrome.GotoURL("https://www.instagram.com/");
				chrome.DelayTime(5.0);
				if (valueBool && chrome.CheckExistElement("[role=\"menuitem\"]", 10.0) == 1)
				{
					for (int i = 0; i < 3; i++)
					{
						chrome.Click(4, "[role=\"menuitem\"]");
						if (chrome.GetURL().Contains("stories"))
						{
							break;
						}
					}
					string text = "";
					string text2 = "";
					for (int j = 0; j < num; j++)
					{
						text = chrome.GetURL().Split('/')[4].ToString();
						chrome.DelayRandom(valueInt, valueInt2);
						int num2 = 0;
						while (num2 < 50)
						{
							text2 = chrome.GetURL().Split('/')[4].ToString();
							if (text != text2)
							{
								break;
							}
							chrome.Click(4, "button>.coreSpriteRightChevron");
							chrome.DelayTime(1.0);
							if (chrome.GetURL().Contains("stories"))
							{
								num2++;
								continue;
							}
							goto IL_02a4;
						}
					}
				}
				goto IL_02a4;
				IL_02a4:
				if (valueBool2)
				{
					for (int k = 0; k < valueList.Count; k++)
					{
						chrome.GotoURL("https://www.instagram.com/stories/" + valueList[k]);
						DelayThaoTacNho();
						if (chrome.CheckExistElement("section div:nth-child(4)>button", 10.0) == 1)
						{
							chrome.Click(4, "section div:nth-child(4)>button");
							chrome.DelayRandom(valueInt3, valueInt4);
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int Chrome_UpAvatar(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			string value = setting.GetValue("txtFolderAnh");
			try
			{
				List<string> list = Directory.GetFiles(value, "*.*", SearchOption.AllDirectories).ToList();
				chrome.GotoURL("https://www.instagram.com/accounts/edit/");
				DelayThaoTacNho();
				if (chrome.CheckExistElement("article>div>div:nth-child(1) form input", 10.0) == 1)
				{
					chrome.SendKeys(4, "article>div>div:nth-child(1) form input", list[rd.Next(0, list.Count)]);
					chrome.DelayTime(2.0);
					for (int i = 0; i < 10; i++)
					{
						if (chrome.CheckExistElement("[data-visualcompletion=\"loading-state\"]") == 0)
						{
							break;
						}
						chrome.DelayTime(1.0);
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_DangBai(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			string useragent = chrome.GetUseragent();
			string useragentIPhone = SetupFolder.GetUseragentIPhone(rd);
			chrome.SwitchUseragent(useragentIPhone);
			try
			{
			}
			catch
			{
			}
			chrome.SwitchUseragent(useragent);
			return result;
		}

		private int Chrome_FollowLikedPost(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			int num = 0;
			int valueInt = setting.GetValueInt("nudCountFollowFrom");
			int valueInt2 = setting.GetValueInt("nudCountFollowTo");
			int valueInt3 = setting.GetValueInt("nudDelayFrom");
			int valueInt4 = setting.GetValueInt("nudDelayTo");
			List<string> valueList = setting.GetValueList("txtUid");
			try
			{
				for (int i = 0; i < valueList.Count(); i++)
				{
					chrome.GotoURL("https://www.instagram.com/p/" + valueList[i]);
					DelayThaoTacNho();
					if (chrome.CheckExistElement("[href=\"/p/" + valueList[i] + "/liked_by/\"]", 5.0) == 1 && chrome.Click(4, "[href=\"/p/" + valueList[i] + "/liked_by/\"]") == 1 && chrome.CheckExistElement("[role=\"dialog\"]>div>div:nth-child(2) button", 5.0) == 1)
					{
						num = rd.Next(valueInt, valueInt2 + 1);
						for (int j = 0; j < num; j++)
						{
							if (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[role=\"dialog\"]>div>div:nth-child(2) button')[" + j + "]") != 1)
							{
								break;
							}
							DelayThaoTacNho();
							if (chrome.Click(4, "[role=\"dialog\"]>div>div:nth-child(2) button", j) != 1)
							{
								break;
							}
							DelayThaoTacNho();
						}
					}
					chrome.DelayRandom(valueInt3, valueInt4 + 1);
				}
			}
			catch
			{
			}
			return result;
		}

		private int Chrome_FollowFollowerCuaUser(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			bool flag = false;
			int num = 0;
			int valueInt = setting.GetValueInt("nudSoLuongBanBeFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBanBeTo");
			int valueInt3 = setting.GetValueInt("nudTimeFrom");
			int valueInt4 = setting.GetValueInt("nudTimeTo");
			string text = "";
			int num2 = 0;
			List<string> valueList = setting.GetValueList("txtLstUser");
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					text = valueList[i];
					chrome.GotoURL("https://www.instagram.com/" + text);
					DelayThaoTacNho();
					if (flag = chrome.CheckExistElement("[href=\"/" + text + "/followers/\"]", 10.0) == 1)
					{
						chrome.Click(4, "[href=\"/" + text + "/followers/\"]");
						DelayThaoTacNho();
						num = rd.Next(valueInt, valueInt2 + 1);
						num2 = 0;
						int num3 = 0;
						while (true)
						{
							flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + num3 + "]") == 1;
							DelayThaoTacNho();
							if (!flag || !(flag = chrome.Click(4, "li span>a", num3) == 1) || !(flag = chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) == 1))
							{
								break;
							}
							if (!(flag = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('section')[1].querySelectorAll('button').length")) == 3))
							{
								chrome.GotoBackPage();
							}
							else
							{
								flag = chrome.Click(4, "section", 0, 4, "button", 1) == 1;
								DelayThaoTacNho();
								if (flag)
								{
									num2++;
								}
								chrome.GotoBackPage();
								if (num2 >= num)
								{
									break;
								}
							}
							num3++;
						}
					}
					chrome.DelayRandom(valueInt3, valueInt4);
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int Chrome_FollowFolloweingCuaUser(int indexRow, Chrome chrome, JSON_Settings setting)
		{
			int result = 1;
			bool flag = false;
			int num = 0;
			int valueInt = setting.GetValueInt("nudSoLuongBanBeFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBanBeTo");
			int valueInt3 = setting.GetValueInt("nudTimeFrom");
			int valueInt4 = setting.GetValueInt("nudTimeTo");
			string text = "";
			int num2 = 0;
			List<string> valueList = setting.GetValueList("txtLstUser");
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					text = valueList[i];
					chrome.GotoURL("https://www.instagram.com/" + text);
					DelayThaoTacNho();
					if (flag = chrome.CheckExistElement("[href=\"/" + text + "/following/\"]", 10.0) == 1)
					{
						chrome.Click(4, "[href=\"/" + text + "/following/\"]");
						DelayThaoTacNho();
						num = rd.Next(valueInt, valueInt2 + 1);
						num2 = 0;
						int num3 = 0;
						while (true)
						{
							flag = chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('li span>a')[" + num3 + "]") == 1;
							DelayThaoTacNho();
							if (!flag || !(flag = chrome.Click(4, "li span>a", num3) == 1) || !(flag = chrome.CheckExistElement("[data-testid=\"user-avatar\"]", 20.0) == 1))
							{
								break;
							}
							if (!(flag = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('section')[1].querySelectorAll('button').length")) == 3))
							{
								chrome.GotoBackPage();
							}
							else
							{
								if (flag = chrome.Click(4, "section", 0, 4, "button", 1) == 1)
								{
									num2++;
								}
								chrome.GotoBackPage();
								if (num2 >= num)
								{
									break;
								}
							}
							num3++;
						}
					}
					chrome.DelayRandom(valueInt3, valueInt4);
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDViewDiscover(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num4 = 0;
			int num5 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.TapByText("search and explore", "", 10) && device.TapByText("at row 1, column 1", "", 10))
				{
					int tickCount = Environment.TickCount;
					while (Environment.TickCount - tickCount < num * 1000)
					{
						device.GetHtml();
						if (valueBool && num4 < num2)
						{
							string text2 = device.GetListBoundsByText("\"like\"").LastOrDefault();
							if (!string.IsNullOrEmpty(text2))
							{
								device.TapByBounds(text2);
								num4++;
							}
						}
						device.DelayTime(1.0);
						if (valueBool2 && num5 < num3)
						{
							string text3 = device.GetListBoundsByText("\"comment\"").LastOrDefault();
							if (!string.IsNullOrEmpty(text3))
							{
								device.TapByBounds(text3);
								if (device.TapByText("\"add a comment…\"", "", 3))
								{
									if (list.Count() == 0)
									{
										list = CloneList(valueList);
									}
									text = list[rd.Next(0, list.Count())];
									list.Remove(text);
									text = MCommon.Common.SpinText(text, rd);
									device.InputTextWithUnicode(text);
									if (device.TapByText("\"post\"", "", 10))
									{
										num5++;
									}
									device.DelayTime(1.0);
									device.GotoBack();
									if (!device.CheckExistText("search and explore", "", 2.0))
									{
										device.GotoBack();
									}
									device.DelayTime(2.0);
								}
							}
						}
						if (!device.ScrollAndCheckScreenNotChange(650))
						{
							device.DelayRandom(2.0, 4.0);
							continue;
						}
						break;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDSharebaiviet(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			setting.GetValueInt("nudSoLuongBaiVietFrom", 1);
			int num = rd.Next(setting.GetValueInt("nudSoLuongBaiVietFrom"), setting.GetValueInt("nudSoLuongBaiVietTo", 1) + 1);
			string value = setting.GetValue("txtLinkBaiViet");
			string text = "qwertyuiopasdfghjklzxcvbnm";
			string text2 = "";
			try
			{
				if (value.Contains("instagram"))
				{
					device.OpenLink(value);
				}
				else
				{
					device.OpenLink("https://www.instagram.com/p/" + value);
				}
				if (device.CheckExistText("more actions for this post", "", 10.0))
				{
					device.Scroll();
					device.DelayTime(1.0);
					if (device.TapByText("\"send post\"", "", 10) && device.TapByText("\"search\"", "", 10))
					{
						DelayThaoTacNho();
						text2 = text[rd.Next(0, text.Length)].ToString();
						text.Replace(text2, "");
						device.InputText(text2);
						int num2 = 0;
						while (true)
						{
							if (num2 < num)
							{
								if (device.TapByImage("DataClick\\nut\\nutSendSharePost", null, 2) || device.ScrollAndCheckScreenNotChange(500))
								{
									goto IL_0294;
								}
								if (text.Length != 0)
								{
									if (!device.TapByImage("DataClick\\nut\\nutCloseShareSearch") && !device.TapByText("\"search\"", "", 5))
									{
										DelayThaoTacNho();
										text2 = text[rd.Next(0, text.Length)].ToString();
										text.Replace(text2, "");
										device.InputText(text2);
										num2--;
										goto IL_0294;
									}
									break;
								}
							}
							if (device.TapByText("\"done\"", "", 10))
							{
							}
							break;
							IL_0294:
							num2++;
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDFollowTheoDiaDiem(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int num = rd.Next(setting.GetValueInt("nudSoLuongBaiVietFrom"), setting.GetValueInt("nudSoLuongBaiVietTo", 1) + 1);
			string value = setting.GetValue("txtDiaDiem");
			int result = 1;
			string text = "";
			try
			{
				device.OpenLink("https://www.instagram.com/");
				text = device.GetHtml();
				if (device.CheckExistText("search and explore", text, 10.0) && device.TapByText("search and explore", text, 10) && device.TapByText("\"search\"", "", 5))
				{
					if (device.TapByText("\"allow\"", "", 5))
					{
						device.TapByText("\"search\"", "", 5);
					}
					device.DelayTime(1.0);
					device.InputTextWithUnicode(value);
					device.DelayTime(1.0);
					if (device.TapByText("\"places\"", "", 5))
					{
						device.TapByBounds("[26,107][49,133]");
						DelayThaoTacNho();
						if (device.TapByText("\"recent\"", "", 5) && device.TapByText("at row 1, column 1", "", 5))
						{
							for (int i = 0; i < num; i++)
							{
								if (!device.TapByText("\"follow\"", "", 2) && device.ScrollAndCheckScreenNotChange(800))
								{
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDFollowGoiY(int indexRow, string statusProxy, Device device, JSON_Settings settings)
		{
			int result = 1;
			int num = rd.Next(settings.GetValueInt("nudSoLuongFrom"), settings.GetValueInt("nudSoLuongTo") + 1);
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			bool flag = false;
			string text = "";
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if ((flag = device.CheckExistText("search and explore", "", 10.0)) && (flag = device.TapByText("\"profile\"", "", 10)) && (flag = device.TapByText("followers", "", 10)))
				{
					flag = false;
					for (int i = 0; i < 10; i++)
					{
						if (flag = device.TapByText("see all suggestions"))
						{
							break;
						}
						device.Scroll(100);
						device.DelayTime(1.0);
					}
					if (flag)
					{
						flag = false;
						for (int j = 0; j < 10; j++)
						{
							text = device.GetHtml();
							if (device.CheckExistText("allow instagram to access your contacts?", text))
							{
								device.TapByText("\"allow\"", text);
							}
							else if (device.CheckExistText("allow contacts access", text))
							{
								device.TapByText("allow access", text);
							}
							else if (device.CheckExistText("find people to follow", text))
							{
								device.TapByText("close", text);
							}
							else if (device.CheckExistText("profile photo", text))
							{
								flag = true;
								break;
							}
							device.DelayTime(1.0);
						}
						if (flag)
						{
							if (device.TapByImage("DataClick\\image\\nutXemThemFollowe", null, 5))
							{
								device.DelayTime(2.0);
							}
							for (int k = 0; k < num; k++)
							{
								SetStatusAccount(indexRow, "Đang follow: " + (k + 1) + "/" + num);
								flag = device.TapByImage("DataClick\\image\\nutFollowe");
								device.DelayTime(1.0);
								if (!flag)
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									k--;
								}
								device.DelayRandom(valueInt, valueInt2);
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDFollowBackFollower(int indexRow, string statusProxy, Device device, JSON_Settings settings)
		{
			int result = 1;
			int num = rd.Next(settings.GetValueInt("nudSoLuongFrom"), settings.GetValueInt("nudSoLuongTo") + 1);
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"profile\"", "", 10) && device.TapByText("followers", "", 10))
				{
					for (int i = 0; i < num; i++)
					{
						if (!device.TapByImage("DataClick\\nut\\nutFollowBack"))
						{
							if (device.CheckExistText("suggestions for you") || device.ScrollAndCheckScreenNotChange())
							{
								break;
							}
							i--;
						}
						else
						{
							device.DelayRandom(valueInt, valueInt2);
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDFollowTheoLink(int indexRow, string statusProxy, Device device, JSON_Settings settings)
		{
			int result = 1;
			List<string> valueList = settings.GetValueList("txtUid");
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			string text = "";
			try
			{
				for (int i = 0; i < valueList.Count(); i++)
				{
					SetStatusAccount(indexRow, "Đang follow: " + valueList[i], device);
					string link = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					device.OpenLink(link);
					device.DelayTime(2.0);
					text = device.GetHtml();
					if (device.CheckExistText("profile picture of", text, 10.0))
					{
						device.TapByText("\"follow\"", text);
						device.DelayRandom(valueInt, valueInt2);
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDFollowTheoTuKhoa(int indexRow, string statusProxy, Device device, JSON_Settings settings)
		{
			int result = 1;
			int num = rd.Next(settings.GetValueInt("nudSoLuongFrom"), settings.GetValueInt("nudSoLuongTo") + 1);
			int valueInt = settings.GetValueInt("nudDelayFrom");
			int valueInt2 = settings.GetValueInt("nudDelayTo");
			string text = "";
			List<string> valueList = settings.GetValueList("txtTuKhoa");
			string text2 = "";
			int num2 = 0;
			try
			{
				while (valueList.Count() != 0)
				{
					text = valueList[rd.Next(0, valueList.Count())];
					valueList.Remove(text);
					device.OpenLink("https://www.instagram.com/");
					text2 = device.GetHtml();
					if (!device.CheckExistText("search and explore", text2, 10.0) || !device.TapByText("search and explore", text2, 10) || !device.TapByText("\"search\"", "", 5))
					{
						break;
					}
					if (device.TapByText("\"allow\"", "", 5))
					{
						device.TapByText("\"search\"", "", 5);
					}
					device.DelayTime(1.0);
					device.InputTextWithUnicode(text);
					device.DelayTime(1.0);
					if (!device.TapByText("accounts", "", 10))
					{
						break;
					}
					if (device.CheckExistText("profile picture", text2, 10.0))
					{
						device.DelayTime(5.0);
						List<string> listBoundsByText = device.GetListBoundsByText("profile picture");
						string text3 = "";
						int num3 = 0;
						int num4 = 0;
						while (num4 < num)
						{
							text3 = listBoundsByText.First();
							listBoundsByText.Remove(text3);
							device.TapByBounds(text3);
							text2 = device.GetHtml();
							if (!device.CheckExistText("profile picture of", text2, 10.0))
							{
								device.GotoBack();
								device.DelayTime(1.0);
								num4--;
							}
							else if (!device.TapByText("\"follow\"", text2))
							{
								num4--;
								num3++;
								device.GotoBack();
								if (num3 > 5)
								{
									break;
								}
							}
							else
							{
								num3 = 0;
								num2++;
								device.DelayTime(1.0);
								device.GotoBack();
							}
							if (listBoundsByText.Count() == 0)
							{
								device.SwipeByBounds("[127,438][147,444]", "[158,62][179,73]", 2000);
								device.DelayTime(1.0);
								listBoundsByText = device.GetListBoundsByText("profile picture");
							}
							device.DelayRandom(valueInt, valueInt2);
							if (num2 != num)
							{
								num4++;
								continue;
							}
							goto end_IL_0093;
						}
					}
					if (num2 >= num)
					{
						break;
					}
				}
				end_IL_0093:;
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDTuongTacBaiVietChiDinh(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int valueInt = setting.GetValueInt("nudTimeFrom");
			int valueInt2 = setting.GetValueInt("nudTimeTo");
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			string text = "";
			string value = setting.GetValue("txtIdPost");
			try
			{
				device.OpenLink("https://www.instagram.com/p/" + value);
				device.DelayTime(1.0);
				if (device.CheckExistText("more actions for this post", "", 10.0))
				{
					device.DelayRandom(valueInt, valueInt2);
					device.Scroll();
					device.DelayTime(1.0);
					if (valueBool && device.TapByText("\"like\"", "", 10))
					{
						device.DelayTime(1.0);
					}
					if (valueBool2 && device.TapByText("\"comment\"", "", 10) && device.TapByText("\"add a comment…\"", "", 10))
					{
						text = valueList[rd.Next(0, valueList.Count())];
						text = MCommon.Common.SpinText(text, rd);
						device.InputTextWithUnicode(text);
						if (device.TapByText("\"post\"", "", 10))
						{
							device.GotoBack();
							device.DelayTime(2.0);
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDSpamBaiViet(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int valueInt = setting.GetValueInt("nudSoLuongBaiVietFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBaiVietTo");
			int valueInt3 = setting.GetValueInt("nudDelayFrom");
			int valueInt4 = setting.GetValueInt("nudDelayTo");
			List<string> valueList = setting.GetValueList("txtUid");
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			string text = "";
			int num = 0;
			List<string> valueList2 = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList2);
			string text2 = "";
			int num2 = 1;
			int num3 = 1;
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					string link = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					device.OpenLink(link);
					device.DelayTime(2.0);
					if (!device.TapByText("posts", "", 10) || !device.CheckExistText("at row 1", "", 10.0))
					{
						continue;
					}
					text2 = "";
					text2 = device.GetBoundsByText("\"follow\"");
					if (text2 != "")
					{
						device.TapByBounds(text2);
					}
					num = rd.Next(valueInt, valueInt2 + 1);
					for (int j = 0; j < num; j++)
					{
						while (!device.TapByText("at row " + num2 + ", column " + num3))
						{
							if (device.ScrollAndCheckScreenNotChange())
							{
								goto end_IL_0410;
							}
						}
						device.Swipe(181, 374, 173, 272);
						if (valueBool && device.TapByText("\"like\"", "", 10))
						{
							device.DelayTime(1.0);
						}
						if (valueBool2)
						{
							text = list[rd.Next(0, list.Count())];
							list.Remove(text);
							if (list.Count() == 0)
							{
								list = CloneList(valueList2);
							}
							if (device.TapByText("\"comment\"", "", 10) && device.TapByText("\"add a comment…\"", "", 10))
							{
								text = MCommon.Common.SpinText(text, rd);
								device.InputTextWithUnicode(text);
								device.TapByText("\"post\"", "", 10);
								device.DelayTime(1.0);
								device.GotoBack(2);
								device.DelayTime(2.0);
							}
						}
						device.GotoBack();
						device.DelayRandom(valueInt3, valueInt4);
						num3++;
						if (num3 > 3)
						{
							num3 = 1;
							num2++;
						}
						continue;
						end_IL_0410:
						break;
					}
					device.DelayTime(2.0);
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDUnFollow(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongFrom"), setting.GetValueInt("nudSoLuongTo"));
			int valueInt = setting.GetValueInt("nudDelayFrom");
			int valueInt2 = setting.GetValueInt("nudDelayTo");
			bool flag = false;
			if (setting.GetValueInt("typeUnFollow") == 0)
			{
				flag = true;
			}
			bool flag2 = false;
			try
			{
				device.DelayTime(2.0);
				device.OpenLink("https://www.instagram.com/");
				if ((flag2 = device.CheckExistText("search and explore", "", 10.0)) && (flag2 = device.TapByText("\"profile\"", "", 10)) && (flag2 = device.TapByText("\"profile\"", "", 10)))
				{
					if (flag)
					{
						if (flag2 = device.TapByText("following", "", 10))
						{
							for (int i = 0; i < num; i++)
							{
								flag2 = device.TapByText("\"following\"");
								device.DelayTime(1.0);
								if (!flag2)
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									i--;
								}
								device.TapByText("unfollow", "", 2);
								device.DelayRandom(valueInt, valueInt2);
							}
						}
					}
					else if (flag2 = device.TapByText("followers", "", 10))
					{
						for (int j = 0; j < num; j++)
						{
							flag2 = device.TapByText("remove");
							device.DelayTime(1.0);
							if (!flag2)
							{
								if (device.CheckExistImage("DataClick\\image\\nutFollowe", null, 3))
								{
									break;
								}
								device.Scroll();
								j--;
							}
							if (device.CheckExistText("remove follower?", "", 2.0))
							{
								device.TapByBounds(device.GetListBoundsByText("remove").Last());
							}
							device.DelayRandom(valueInt, valueInt2);
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDNhanTinTheoLink(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int valueInt = setting.GetValueInt("nudDelayFrom", 3);
			int valueInt2 = setting.GetValueInt("nudDelayTo", 5);
			List<string> valueList = setting.GetValueList("txtUid");
			List<string> valueList2 = setting.GetValueList("txtNoiDung");
			new List<string>();
			List<string> list = CloneList(valueList2);
			string text = "";
			string text2 = "";
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					string link = (valueList[i].Trim().StartsWith("https://www.instagram.com/") ? valueList[i].Trim() : ("https://www.instagram.com/" + valueList[i].Trim()));
					device.OpenLink(link);
					device.DelayTime(2.0);
					text2 = device.GetHtml();
					if (device.CheckExistText("profile picture of", text2, 5.0) && device.TapByText("\"message\"", text2, 10) && device.TapByText("message…", text2, 10))
					{
						text = list[rd.Next(0, list.Count)];
						list.Remove(text);
						if (list.Count == 0)
						{
							list = CloneList(valueList2);
						}
						text = MCommon.Common.SpinText(text, rd);
						device.InputTextWithUnicode(text);
						device.TapByText("send", "", 3);
						device.DelayRandom(valueInt, valueInt2);
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDNhanTinFollowers(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongUidFrom"), setting.GetValueInt("nudSoLuongUidTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom", 3);
			int valueInt2 = setting.GetValueInt("nudDelayTo", 5);
			List<string> valueList = setting.GetValueList("txtNoiDung");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			new List<string>();
			string text = "";
			string text2 = "";
			string text3 = "";
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"profile\"", "", 10) && device.TapByText("followers", "", 10))
				{
					list2 = device.GetListBoundsByText("remove");
					if (list2.Count() != 0)
					{
						for (int i = 0; i < num; i++)
						{
							text = list2.Last();
							if (num2 == 0)
							{
								list2.Remove(text);
							}
							else
							{
								list2.Clear();
							}
							num3 = Convert.ToInt32(text.Split('[', ',', ']')[1].ToString());
							num4 = Convert.ToInt32(text.Split('[', ',', ']')[2].ToString()) - 5;
							device.Tap(num3, num4);
							text2 = device.GetHtml();
							if (device.CheckExistText("profile picture of", text2, 5.0) && device.TapByText("\"message\"", text2, 10) && device.TapByText("message…", text2, 10))
							{
								text3 = list[rd.Next(0, list.Count)];
								list.Remove(text3);
								if (list.Count == 0)
								{
									list = CloneList(valueList);
								}
								text3 = MCommon.Common.SpinText(text3, rd);
								device.InputTextWithUnicode(text3);
								device.DelayTime(1.0);
								device.TapByText("send", "", 3);
								device.DelayTime(2.0);
							}
							for (int j = 0; j < 5; j++)
							{
								if (device.CheckExistText("\"profile picture\""))
								{
									break;
								}
								device.GotoBack();
								device.DelayTime(1.0);
							}
							device.DelayRandom(valueInt, valueInt2);
							if (list2.Count() == 0)
							{
								num2++;
								device.Swipe(62, 251, 62, 201, 180);
								list2 = device.GetListBoundsByText("remove");
								if (device.CheckExistText("suggestions for you"))
								{
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDNhanTinFollowing(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongUidFrom"), setting.GetValueInt("nudSoLuongUidTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom", 3);
			int valueInt2 = setting.GetValueInt("nudDelayTo", 5);
			List<string> valueList = setting.GetValueList("txtNoiDung");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			new List<string>();
			string text = "";
			string text2 = "";
			string text3 = "";
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"profile\"", "", 10) && device.TapByText("following", "", 10))
				{
					list2 = device.GetListBoundsByText("\"following\"");
					if (list2.Count() != 0)
					{
						for (int i = 0; i < num; i++)
						{
							text = list2.Last();
							if (num2 == 0)
							{
								list2.Remove(text);
							}
							else
							{
								list2.Clear();
							}
							num3 = Convert.ToInt32(text.Split('[', ',', ']')[1].ToString());
							num4 = Convert.ToInt32(text.Split('[', ',', ']')[2].ToString()) - 5;
							device.Tap(num3, num4);
							text2 = device.GetHtml();
							if (device.CheckExistText("profile picture of", text2, 5.0))
							{
								if (!device.TapByText("\"message\"", text2, 10))
								{
									i--;
								}
								else if (!device.TapByText("message…", text2, 10))
								{
									i--;
								}
								else
								{
									text3 = list[rd.Next(0, list.Count)];
									list.Remove(text3);
									if (list.Count == 0)
									{
										list = CloneList(valueList);
									}
									text3 = MCommon.Common.SpinText(text3, rd);
									device.InputTextWithUnicode(text3);
									device.TapByText("send", "", 3);
									device.DelayTime(2.0);
								}
							}
							for (int j = 0; j < 5; j++)
							{
								if (device.CheckExistText("\"more actions for this post\""))
								{
									break;
								}
								device.GotoBack();
								device.DelayTime(1.0);
							}
							device.DelayRandom(valueInt, valueInt2);
							if (list2.Count() == 0)
							{
								num2++;
								device.Swipe(62, 251, 62, 201, 180);
								list2 = device.GetListBoundsByText("\"following\"");
								if (device.CheckExistText("suggestions for you"))
								{
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDTuongTacFollowing(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongBanBeFrom"), setting.GetValueInt("nudSoLuongBanBeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num4 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num5 = 0;
			int num6 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			string text2 = "";
			string text3 = "";
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"profile\"", "", 10) && device.TapByText("following", "", 10))
				{
					list2 = device.GetListBoundsByText("\"following\"");
					if (list2.Count() != 0)
					{
						for (int i = 0; i < num; i++)
						{
							num5 = 0;
							num6 = 0;
							text2 = list2.Last();
							if (num7 == 0)
							{
								list2.Remove(text2);
							}
							else
							{
								list2.Clear();
							}
							num8 = Convert.ToInt32(text2.Split('[', ',', ']')[1].ToString());
							num9 = Convert.ToInt32(text2.Split('[', ',', ']')[2].ToString()) - 5;
							device.Tap(num8, num9);
							if (device.TapByText("posts", "", 5) && device.TapByText("at row 1, column 1", "", 5))
							{
								num10 = Environment.TickCount;
								while (Environment.TickCount - num10 < num2 * 1000)
								{
									text3 = device.GetHtml();
									if (valueBool && num5 < num3)
									{
										string text4 = device.GetListBoundsByText("\"like\"").LastOrDefault();
										if (!string.IsNullOrEmpty(text4))
										{
											device.TapByBounds(text4);
											num5++;
										}
									}
									device.DelayTime(1.0);
									if (valueBool2 && num6 < num4)
									{
										string text5 = device.GetListBoundsByText("\"comment\"").LastOrDefault();
										if (!string.IsNullOrEmpty(text5))
										{
											device.TapByBounds(text5);
											if (device.TapByText("\"add a comment…\"", "", 3))
											{
												text = list[rd.Next(0, list.Count())];
												list.Remove(text);
												if (list.Count() == 0)
												{
													list = CloneList(valueList);
												}
												text = MCommon.Common.SpinText(text, rd);
												device.InputTextWithUnicode(text);
												if (device.TapByText("\"post\"", "", 10))
												{
													num6++;
												}
												device.DelayTime(1.0);
												device.GotoBack();
												if (!device.CheckExistText("search and explore", "", 2.0))
												{
													device.GotoBack();
												}
												device.DelayTime(2.0);
											}
										}
									}
									if (device.ScrollAndCheckScreenNotChange(150))
									{
										break;
									}
									device.DelayRandom(3.0, 4.0);
								}
							}
							int num11 = 0;
							while (true)
							{
								if (num11 < 5)
								{
									text3 = device.GetHtml();
									if (device.CheckExistText("\"more actions for this post\"", text3) && device.CheckExistText("following", text3))
									{
										break;
									}
									device.GotoBack();
									device.DelayTime(1.0);
									num11++;
									continue;
								}
								device.DelayRandom(3.0, 5.0);
								break;
							}
							if (list2.Count() == 0)
							{
								num7++;
								device.Swipe(62, 251, 62, 201, 180);
								list2 = device.GetListBoundsByText("\"following\"");
								if (device.CheckExistText("suggestions for you"))
								{
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDTuongTacFollowers(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongBanBeFrom"), setting.GetValueInt("nudSoLuongBanBeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num4 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num5 = 0;
			int num6 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			List<string> list2 = new List<string>();
			string text2 = "";
			string text3 = "";
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"profile\"", "", 10) && device.TapByText("\"followers\"", "", 10))
				{
					list2 = device.GetListBoundsByText("\"remove\"");
					if (list2.Count() != 0)
					{
						for (int i = 0; i < num; i++)
						{
							num5 = 0;
							num6 = 0;
							text2 = list2.Last();
							if (num7 == 0)
							{
								list2.Remove(text2);
							}
							else
							{
								list2.Clear();
							}
							num8 = Convert.ToInt32(text2.Split('[', ',', ']')[1].ToString());
							num9 = Convert.ToInt32(text2.Split('[', ',', ']')[2].ToString()) - 5;
							device.Tap(num8, num9);
							if (device.TapByText("posts", "", 5) && device.TapByText("at row 1, column 1", "", 5))
							{
								num10 = Environment.TickCount;
								while (Environment.TickCount - num10 < num2 * 1000)
								{
									text3 = device.GetHtml();
									if (valueBool && num5 < num3)
									{
										string text4 = device.GetListBoundsByText("\"like\"").LastOrDefault();
										if (!string.IsNullOrEmpty(text4))
										{
											device.TapByBounds(text4);
											num5++;
										}
									}
									device.DelayTime(1.0);
									if (valueBool2 && num6 < num4)
									{
										string text5 = device.GetListBoundsByText("\"comment\"").LastOrDefault();
										if (!string.IsNullOrEmpty(text5))
										{
											device.TapByBounds(text5);
											if (device.TapByText("\"add a comment…\"", "", 3))
											{
												text = list[rd.Next(0, list.Count())];
												list.Remove(text);
												if (list.Count() == 0)
												{
													list = CloneList(valueList);
												}
												text = MCommon.Common.SpinText(text, rd);
												device.InputTextWithUnicode(text);
												if (device.TapByText("\"post\"", "", 10))
												{
													num6++;
												}
												device.DelayTime(1.0);
												device.GotoBack();
												if (!device.CheckExistText("search and explore", "", 2.0))
												{
													device.GotoBack();
												}
												device.DelayTime(2.0);
											}
										}
									}
									if (device.ScrollAndCheckScreenNotChange(150))
									{
										break;
									}
									device.DelayRandom(3.0, 4.0);
								}
							}
							int num11 = 0;
							while (true)
							{
								if (num11 < 5)
								{
									text3 = device.GetHtml();
									if (device.CheckExistText("\"remove\"", text3))
									{
										break;
									}
									device.GotoBack();
									device.DelayTime(1.0);
									num11++;
									continue;
								}
								device.DelayRandom(3.0, 5.0);
								break;
							}
							if (list2.Count() == 0)
							{
								num7++;
								device.Swipe(62, 251, 62, 201, 180);
								list2 = device.GetListBoundsByText("\"remove\"");
								if (device.CheckExistText("suggestions for you"))
								{
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDTuongTacNewsfeed(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudTimeFrom"), setting.GetValueInt("nudTimeTo") + 1);
			int num2 = rd.Next(setting.GetValueInt("nudCountLikeFrom"), setting.GetValueInt("nudCountLikeTo") + 1);
			int num3 = rd.Next(setting.GetValueInt("nudCountCommentFrom"), setting.GetValueInt("nudCountCommentTo") + 1);
			int num4 = 0;
			int num5 = 0;
			string text = "";
			bool valueBool = setting.GetValueBool("ckbInteract");
			bool valueBool2 = setting.GetValueBool("ckbComment");
			List<string> valueList = setting.GetValueList("txtComment");
			List<string> list = CloneList(valueList);
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0))
				{
					int tickCount = Environment.TickCount;
					while (Environment.TickCount - tickCount < num * 1000)
					{
						device.GetHtml();
						if (valueBool && num4 < num2)
						{
							string text2 = device.GetListBoundsByText("\"like\"").LastOrDefault();
							if (!string.IsNullOrEmpty(text2))
							{
								device.TapByBounds(text2);
								num4++;
							}
						}
						device.DelayTime(1.0);
						if (valueBool2 && num5 < num3)
						{
							string text3 = device.GetListBoundsByText("\"comment\"").LastOrDefault();
							if (!string.IsNullOrEmpty(text3))
							{
								device.TapByBounds(text3);
								if (device.TapByText("\"add a comment…\"", "", 3))
								{
									if (list.Count() == 0)
									{
										list = CloneList(valueList);
									}
									text = list[rd.Next(0, list.Count())];
									list.Remove(text);
									text = MCommon.Common.SpinText(text, rd);
									device.InputTextWithUnicode(text);
									if (device.TapByText("\"post\"", "", 10))
									{
										num5++;
									}
									device.DelayTime(1.0);
									device.GotoBack();
									if (!device.CheckExistText("search and explore", "", 2.0))
									{
										device.GotoBack();
									}
									device.DelayTime(2.0);
								}
							}
						}
						if (!device.ScrollAndCheckScreenNotChange(150))
						{
							device.DelayRandom(2.0, 4.0);
							continue;
						}
						break;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDLuotStory(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = rd.Next(setting.GetValueInt("nudSoLuongStoryFrom"), setting.GetValueInt("nudSoLuongStoryTo") + 1);
			int valueInt = setting.GetValueInt("nudDelayFrom");
			int valueInt2 = setting.GetValueInt("nudDelayTo");
			int valueInt3 = setting.GetValueInt("nudDelayChiDinhFrom");
			int valueInt4 = setting.GetValueInt("nudDelayChiDinhTo");
			int valueInt5 = setting.GetValueInt("typeStory");
			List<string> valueList = setting.GetValueList("txtListUser");
			string text = "";
			try
			{
				device.OpenLink("https://www.instagram.com/");
				if (device.CheckExistText("search and explore", "", 10.0))
				{
					if (valueInt5 == 0)
					{
						text = device.GetBoundsByText("story at column 1", "", 5);
						if (text != "")
						{
							for (int i = 0; i < num && device.TapByText("story at column " + (i + 1)); i++)
							{
								if (!device.CheckExistText("more", "", 10.0))
								{
									break;
								}
								device.DelayRandom(valueInt, valueInt2);
								for (int j = 0; j < 5; j++)
								{
									if (device.CheckExistText("story at column", "", 2.0))
									{
										break;
									}
									device.GotoBack();
								}
								if (!device.CheckExistText("story at column " + (i + 2), "", 5.0))
								{
									device.SwipeByBounds("[182,79][198,96]", "[88,82][101,93]", 500);
									device.DelayTime(1.0);
								}
							}
						}
					}
					else
					{
						for (int k = 0; k < valueList.Count; k++)
						{
							string link = (valueList[k].Trim().StartsWith("https://www.instagram.com/") ? valueList[k].Trim() : ("https://www.instagram.com/" + valueList[k].Trim()));
							device.OpenLink(link);
							device.DelayRandom(2.0, 3.0);
							device.TapByText("profile picture of ", "", 10);
							if (device.CheckExistText("more", "", 5.0))
							{
								device.DelayRandom(valueInt3, valueInt4);
							}
						}
					}
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDFolloweLikedPost(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = 0;
			int valueInt = setting.GetValueInt("nudCountFollowFrom");
			int valueInt2 = setting.GetValueInt("nudCountFollowTo");
			int valueInt3 = setting.GetValueInt("nudDelayFrom");
			int valueInt4 = setting.GetValueInt("nudDelayTo");
			List<string> valueList = setting.GetValueList("txtUid");
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < valueList.Count(); i++)
				{
					device.OpenLink("https://www.instagram.com/p/" + valueList[i]);
					DelayThaoTacNho();
					device.Scroll();
					list = device.GetListBoundsByText("liked", "", 10);
					if (list.Count() != 0 && device.TapByBounds(list.LastOrDefault()) && device.CheckExistText("follow", "", 10.0))
					{
						num = rd.Next(valueInt, valueInt2 + 1);
						for (int j = 0; j < num; j++)
						{
							if (!device.TapByImage("DataClick\\nut\\nutfollow", null, 5))
							{
								if (device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								j--;
							}
							DelayThaoTacNho();
						}
					}
					device.DelayRandom(valueInt3, valueInt4 + 1);
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDFollowFollowerCuaUser(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = 0;
			int valueInt = setting.GetValueInt("nudSoLuongBanBeFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBanBeTo");
			int valueInt3 = setting.GetValueInt("nudTimeFrom");
			int valueInt4 = setting.GetValueInt("nudTimeTo");
			List<string> valueList = setting.GetValueList("txtLstUser");
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					device.OpenLink("https://www.instagram.com/" + valueList[i]);
					if (device.TapByText("\"followers\"", "", 10) && device.CheckExistText("follow", "", 10.0))
					{
						num = rd.Next(valueInt, valueInt2 + 1);
						for (int j = 0; j < num; j++)
						{
							if (!device.TapByImage("DataClick\\nut\\nutfollow", null, 5))
							{
								if (device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								j--;
							}
							DelayThaoTacNho();
						}
					}
					device.DelayRandom(valueInt3, valueInt4);
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDFollowFollowingCuaUser(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			int num = 0;
			int valueInt = setting.GetValueInt("nudSoLuongBanBeFrom");
			int valueInt2 = setting.GetValueInt("nudSoLuongBanBeTo");
			int valueInt3 = setting.GetValueInt("nudTimeFrom");
			int valueInt4 = setting.GetValueInt("nudTimeTo");
			List<string> valueList = setting.GetValueList("txtLstUser");
			try
			{
				for (int i = 0; i < valueList.Count; i++)
				{
					device.OpenLink("https://www.instagram.com/" + valueList[i]);
					if (device.TapByText("\"following\"", "", 10) && device.CheckExistText("follow", "", 10.0))
					{
						num = rd.Next(valueInt, valueInt2 + 1);
						for (int j = 0; j < num; j++)
						{
							if (!device.TapByImage("DataClick\\nut\\nutfollow", null, 5))
							{
								if (device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								j--;
							}
							DelayThaoTacNho();
						}
					}
					device.DelayRandom(valueInt3, valueInt4);
				}
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HD(int indexRow, string statusProxy, Device device, JSON_Settings setting)
		{
			int result = 1;
			try
			{
			}
			catch
			{
				throw;
			}
			return result;
		}

		private int HDUpCover(int indexRow, string statusProxy, Device device, string pathFolder, bool isXoaAnhDaDung, string tenHanhDong)
		{
			int result = 0;
			try
			{
				if (!device.CheckIsLive())
				{
					return -2;
				}
				bool flag = false;
				int num = 0;
				int num2 = 0;
				string text = "";
				num = 1;
				int num3 = 1;
				int num4 = 1;
				while (true)
				{
					IL_046b:
					device.GotoProfileQuick();
					device.DelayTime(2.0);
					device.GotoPageHead();
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 0:
						text = device.GetHtml();
						if (device.GetListText(text).Count == 1)
						{
							device.TapByText(device.GetListText(text)[0], text);
							device.DelayTime(2.0);
						}
						while (true)
						{
							num2 = device.CheckExistTexts("", 10.0, "profile picture", "\"hủy\"");
							if (num2 != 2)
							{
								break;
							}
							if (device.TapByText("\"hủy\""))
							{
								device.TapByText("\"dừng\"", "", 5);
							}
						}
						flag = num2 > 0;
						while (flag)
						{
							num++;
							switch (num)
							{
							default:
								goto end_IL_0006;
							case 2:
							{
								string boundsByText = device.GetBoundsByText("profile picture", "", 10);
								if (boundsByText != "")
								{
									string[] array = boundsByText.Split('[', ',', ']');
									device.Tap(Convert.ToInt32(array[1]) - 10, Convert.ToInt32(array[2]) - 10);
									flag = true;
								}
								continue;
							}
							case 3:
								lock (lock_useImage)
								{
									string[] files = Directory.GetFiles(pathFolder);
									if (files.Length != 0)
									{
										string text2 = files.OrderBy((string t) => Guid.NewGuid()).First();
										device.PushImageToDevice(text2);
										device.DelayRandom(1.5, 2.0);
										if (isXoaAnhDaDung)
										{
											try
											{
												File.Delete(text2);
											}
											catch
											{
											}
										}
										flag = false;
										if (!device.TapByText("upload photo", "", 5))
										{
											continue;
										}
										for (int i = 0; i < 5; device.DelayTime(1.0), i++)
										{
											text = device.GetHtml();
											switch (device.CheckExistTexts(text, 0.0, "\"allow\"", "\"want to upload your photos", "gallery"))
											{
											case 1:
												device.TapByText("\"allow\"", text);
												continue;
											case 2:
												device.TapByText("\"want to upload your photos", text);
												device.DelayTime(2.0);
												device.GotoBack();
												continue;
											default:
												continue;
											case 3:
												break;
											}
											break;
										}
										string text3 = device.CheckExistTextsV2(text, 0.0, "photo. disabled.", "\"photo");
										if (text3 != "")
										{
											device.TapByText(text3, text);
											flag = device.TapByText("\"save\"", "", 10);
										}
										continue;
									}
								}
								goto end_IL_0006;
							case 4:
								flag = device.WaitForTextDisappear(60.0, "uploading your cover photo.");
								continue;
							case 1:
								break;
							}
							goto IL_046b;
						}
						goto end_IL_0006;
					case 1:
						break;
					default:
						goto end_IL_0006;
					}
				}
				end_IL_0006:;
			}
			catch
			{
			}
			return result;
		}

		private List<string> GetGroupKhongKiemDuyet(List<string> lstGroup, string cookie, string useragent, string proxy, int typeProxy)
		{
			List<string> lstOutput = new List<string>();
			try
			{
				int iThread = 0;
				int num = ((lstGroup.Count < 100) ? lstGroup.Count : 100);
				int num2 = 0;
				while (num2 < lstGroup.Count)
				{
					if (iThread < num)
					{
						Interlocked.Increment(ref iThread);
						int row = num2++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string text = lstGroup[row].Split('|')[0];
								RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
								string text2 = requestXNet.RequestGet("https://m.facebook.com/groups/" + text + "/madminpanel");
								if (!text2.Contains("madminpanel/pending/"))
								{
									lock (lstOutput)
									{
										lstOutput.Add(text);
									}
								}
							}
							catch
							{
							}
							Interlocked.Decrement(ref iThread);
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
			return lstOutput;
		}

		private int HDNghiGiaiLao(int indexRow, string statusProxy, int delayFrom, int delayTo, string tenHanhDong)
		{
			try
			{
				int num = rd.Next(delayTo, delayTo + 1);
				if (num > 0)
				{
					int tickCount = Environment.TickCount;
					while ((Environment.TickCount - tickCount) / 1000 - num < 0 && !isStop)
					{
						SetStatusAccount(indexRow, statusProxy + string.Format(Language.GetValue("Đang {0}, đợi {{time}}s..."), tenHanhDong).Replace("{time}", (num - (Environment.TickCount - tickCount) / 1000).ToString()));
						MCommon.Common.DelayTime(0.5);
					}
				}
				return 1;
			}
			catch
			{
			}
			return 0;
		}

		private void ScreenCaptureError(Chrome chrome, string uid, int type)
		{
			try
			{
				if (chrome != null)
				{
					string text = Application.StartupPath + "\\log_capture";
					switch (type)
					{
					case 0:
						text += "\\checkpoint";
						break;
					case 1:
						text += "\\loginfail";
						break;
					case 2:
						text += "\\disconnect";
						break;
					}
					MCommon.Common.CreateFolder(text);
					chrome.ScreenCapture(text, uid);
					File.WriteAllText(text + "\\" + uid + ".txt", chrome.GetURL());
					File.WriteAllText(text + "\\" + uid + ".html", chrome.GetPageSource());
				}
			}
			catch
			{
			}
		}

		private bool LinkToInstagram(Chrome chrome)
		{
			bool flag = false;
			try
			{
				chrome.GotoURL("https://www.instagram.com/");
				DelayThaoTacNho();
				switch (chrome.CheckExistElements(10.0, "[href=\"/accounts/activity/\"]", "form button"))
				{
				case 2:
					chrome.Click(4, "form button", 1);
					switch (chrome.CheckExistElements(10.0, "[href=\"/accounts/activity/\"]", "[name=\"__CONFIRM__\"]", "[name=\"username\"]"))
					{
					case 2:
					{
						chrome.DelayTime(1.0);
						chrome.Click(2, "__CONFIRM__");
						string text = "minsoft" + MCommon.Common.CreateRandomString(3, rd) + MCommon.Common.CreateRandomString(5, rd);
						chrome.SendKeys(2, "username", text);
						MCommon.Common.DelayTime(1.0);
						string text2 = "Minsoft_" + MCommon.Common.CreateRandomString(6, rd);
						chrome.SendKeys(2, "password", text2);
						DelayThaoTacNho();
						chrome.Click(4, "form button[type=\"submit\"]");
						DelayThaoTacNho();
						if (chrome.CheckExistElement("[href=\"/accounts/activity/\"]", 10.0) == 1)
						{
							flag = true;
						}
						if (!flag && chrome.CheckExistElement("[type=\"button\"]") == 1)
						{
							flag = true;
						}
						if (flag)
						{
							lock (lock_fileig)
							{
								File.AppendAllText("account_ig.txt", text + "|" + text2 + Environment.NewLine);
								return flag;
							}
						}
						return flag;
					}
					default:
						return flag;
					case 1:
					case 3:
						return flag;
					}
				case 1:
					flag = true;
					return flag;
				default:
					return flag;
				}
			}
			catch
			{
				return flag;
			}
		}

		private void Logout(Chrome chrome)
		{
			try
			{
				CommonChrome.GoToHome(chrome);
				if (chrome.CheckExistElement("#bookmarks_jewel a", 3.0) != 1)
				{
					return;
				}
				DelayThaoTacNho();
				chrome.Click(4, "#bookmarks_jewel a");
				DelayThaoTacNho(1);
				if (chrome.CheckExistElementv2("document.querySelector('[data-sigil=\"logout\"]')", 3.0) == 1)
				{
					chrome.ScrollSmooth("document.querySelector('[data-sigil=\"logout\"]')");
					DelayThaoTacNho(1);
					chrome.Click(4, "[data-sigil=\"logout\"]");
					DelayThaoTacNho();
					if (chrome.CheckExistElement("[name=\"m_savepass\"]", 3.0) == 1)
					{
						chrome.Click(2, "m_savepass");
						DelayThaoTacNho();
					}
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(chrome, ex, "Logout error");
			}
		}

		private bool LogoutOldDevice(Chrome chrome)
		{
			bool result = false;
			try
			{
				chrome.GotoURL("https://m.facebook.com/settings/security_login/sessions/log_out_all/confirm/");
				chrome.DelayTime(1.0);
				string text = "";
				for (int i = 0; i < 10; i++)
				{
					text = chrome.ExecuteScript("return document.documentElement.innerHTML.match(new RegExp('/security/settings/sessions/log_out_all/(.*?)\"'))[0].replace('\"','').split('amp;').join('');").ToString();
					if (!(text != ""))
					{
						chrome.DelayTime(1.0);
						continue;
					}
					chrome.GotoURL("https://m.facebook.com" + text);
					result = true;
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		private bool AllowFollow(Chrome chrome)
		{
			bool result = false;
			try
			{
				chrome.GotoURL("https://m.facebook.com/settings/subscribe/");
				chrome.DelayTime(1.0);
				if (chrome.CheckExistElement("[data-sigil=\"audience-options-list\"]>label", 10.0) == 1)
				{
					if (!Convert.ToBoolean(chrome.ExecuteScript("return document.querySelector('[data-sigil=\"audience-options-list\"]>label').getAttribute('data-sigil').includes('selected')+''")))
					{
						if (chrome.Click(4, "[data-sigil=\"audience-options-list\"]>label") == 1)
						{
							result = true;
							return result;
						}
						return result;
					}
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		private bool CheckStringIsExistInList(string s, List<string> lst)
		{
			bool result = false;
			try
			{
				for (int i = 0; i < lst.Count; i++)
				{
					if (MCommon.Common.ConvertToUnSign(s).ToLower().Contains(MCommon.Common.ConvertToUnSign(lst[i]).ToLower()))
					{
						result = true;
						return result;
					}
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		public bool ClosePopup(Device device, ref string html)
		{
			string text = device.CheckExistTextsV2(html, 0.0, Device.GetListTextClosePopup().ToArray());
			if (text != "")
			{
				device.TapByText(text, html);
				device.DelayTime(1.0);
				html = device.GetHtml();
				return true;
			}
			return false;
		}

		public int HDXemStory(int indexRow, string statusProxy, Device device, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, string tenHanhDong)
		{
			string text = "";
			int randomInt = device.GetRandomInt(nudTimeFrom, nudTimeTo);
			try
			{
				while (true)
				{
					device.GotoNewFeedQuick();
					device.DelayRandom(1.0, 2.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0018;
					case 0:
					{
						string boundsByText = device.GetBoundsByText("'s story");
						if (boundsByText != "")
						{
							device.TapByBounds(boundsByText);
							int tickCount = Environment.TickCount;
							while (Environment.TickCount - tickCount < randomInt * 1000)
							{
								device.DelayRandom(4.0, 8.0);
								string boundsByText2 = device.GetBoundsByText("reply to");
								if (!(boundsByText2 == ""))
								{
									if (ckbComment && device.GetRandomInt(1, 9) % 3 == 0)
									{
										text = lstComment[device.GetRandomInt(0, lstComment.Count - 1)];
										text = MCommon.Common.SpinText(text, rd);
										device.TapByBounds(boundsByText2);
										device.DelayTime(1.0);
										device.InputTextWithUnicode(text);
										device.TapByText("\"send\"");
										device.DelayRandom(1.0, 1.5);
									}
									if (ckbInteract && device.GetRandomInt(1, 9) % 3 == 0)
									{
										string bounds = "[165,445][195,470]";
										string bounds2 = "[35,445][65,470]";
										device.SwipeByBounds(bounds, bounds2);
										device.DelayRandom(1.0, 1.5);
										int typeReaction2 = Convert.ToInt32(typeReaction[device.GetRandomInt(0, typeReaction.Length - 1)].ToString());
										device.ClickReactions(typeReaction2);
										device.DelayRandom(1.0, 1.5);
										device.TapByBounds("[260,198][300,268]");
										device.DelayRandom(1.0, 1.5);
									}
									device.TapByBounds("[260,198][300,268]");
									continue;
								}
								break;
							}
						}
						goto end_IL_0018;
					}
					}
				}
				end_IL_0018:;
			}
			catch
			{
			}
			return randomInt;
		}

		public List<string> GetIdFriend(string token, string cookie, string useragent, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				requestXNet.request.AddHeader("Authorization", "OAuth " + token);
				string json = requestXNet.RequestGet("https://graph.facebook.com/?ids=" + value + "&pretty=0&fields=friends.limit(5000){id}");
				JObject jObject = JObject.Parse(json);
				JToken jToken = jObject[value]!["friends"];
				if (jToken["data"].Count() > 0)
				{
					for (int i = 0; i < jToken["data"].Count(); i++)
					{
						string item = jToken["data"]![i]!["id"]!.ToString();
						list.Add(item);
					}
				}
			}
			catch
			{
			}
			return list;
		}

		public List<string> CloneList(List<string> lstFrom)
		{
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < lstFrom.Count; i++)
				{
					list.Add(lstFrom[i]);
				}
			}
			catch
			{
			}
			return list;
		}

		private void DelayThaoTacNho(int timeAdd = 0)
		{
			MCommon.Common.DelayTime(rd.Next(timeAdd + 1, timeAdd + 4));
		}

		public int HDBackupData(string id, int indexRow, string statusProxy, Chrome chrome, string token, bool isNgaySinh, bool isAnh, bool isBackupNangCao, int soLuongAnh, bool isNhanTin, bool isBinhLuan, int numberMonth, bool isCreateHtml, string proxy, int typeProxy, string tenHanhDong = "")
		{
			GetCellAccount(indexRow, "cUid");
			GetCellAccount(indexRow, "cPassword");
			GetCellAccount(indexRow, "cFa2");
			int result = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				string template_backup = Base.template_backup;
				string useragent = chrome.GetUseragent().Split('$')[0];
				string cookie = chrome.GetCookieFromChrome();
				if (token == "" || !CommonRequest.CheckLiveToken(cookie, token, useragent, proxy, typeProxy))
				{
					token = CommonChrome.GetTokenEAAAAZ(chrome);
				}
				string text = chrome.ExecuteScript("return (document.cookie+';').match(new RegExp('c_user=(.*?);'))[1]").ToString();
				MCommon.Common.CreateFolder("backup\\" + text);
				bool flag = false;
				if (token != "")
				{
					string text2 = "";
					string text3 = "";
					if (isNgaySinh)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup ngày sinh..."));
						string birthday = CommonChrome.GetBirthday(chrome, token);
						if (birthday == "")
						{
							CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", "Token die!");
							flag = true;
						}
						else
						{
							text2 = birthday.Split('|')[1];
							text3 = birthday.Split('|')[2];
							lock (_lockbackup)
							{
								File.WriteAllText("backup\\" + text + "\\ngaysinh.txt", birthday);
							}
						}
					}
					if (!flag && isAnh)
					{
						CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup a\u0309nh") + "...");
						List<string> listImageBackup = new List<string>();
						int iThread = 0;
						object _lock_countSuccess = new object();
						int countSuccess = 0;
						List<string> myListUidNameFriend = CommonRequest.GetMyListUidNameFriend(cookie, token, useragent, proxy, typeProxy);
						int totalFriend = myListUidNameFriend.Count;
						List<string> lstQuery = GhepFileList(myListUidNameFriend);
						_ = lstQuery.Count;
						new Thread((ThreadStart)delegate
						{
							while (iThread > 0)
							{
								CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", string.Format(Language.GetValue("Đang backup ảnh: {0}/{1}..."), countSuccess, totalFriend));
								Thread.Sleep(100);
							}
						}).Start();
						if (lstQuery.Count > 0)
						{
							int num = ((lstQuery.Count > 10) ? 10 : lstQuery.Count);
							int num2 = 0;
							while (num2 < lstQuery.Count)
							{
								if (iThread < num)
								{
									Interlocked.Increment(ref iThread);
									int stt = num2++;
									new Thread((ThreadStart)delegate
									{
										string text5 = lstQuery[stt];
										List<string> list = CommonRequest.BackupImageOne(text5, cookie, token, useragent, proxy, typeProxy, soLuongAnh, isBackupNangCao);
										if (list.Count > 0)
										{
											lock (listImageBackup)
											{
												listImageBackup.AddRange(list);
											}
										}
										lock (_lock_countSuccess)
										{
											countSuccess += text5.Split(',').Length;
										}
										Interlocked.Decrement(ref iThread);
									}).Start();
								}
								else
								{
									Thread.Sleep(100);
								}
							}
							while (iThread > 0)
							{
								Thread.Sleep(100);
							}
							if (listImageBackup.Count > 0)
							{
								lock (_lock2)
								{
									Directory.CreateDirectory("backup\\" + text);
									File.WriteAllLines("backup\\" + text + "\\" + text + ".txt", listImageBackup);
								}
							}
							else
							{
								CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
							}
						}
						else
						{
							CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
						}
					}
					if (!flag && isNhanTin)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup nhắn tin..."));
						List<string> myListUidMessage = CommonChrome.GetMyListUidMessage(chrome);
						lock (_lock4)
						{
							File.WriteAllLines("backup\\" + text + "\\banbeinbox.txt", myListUidMessage);
						}
					}
					if (!flag && isBinhLuan)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup bình luận..."));
						List<string> myListComments = CommonChrome.GetMyListComments(chrome, numberMonth);
						lock (_lock3)
						{
							File.WriteAllLines("backup\\" + text + "\\lscomment.txt", myListComments);
						}
					}
					if (!flag && isCreateHtml)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tạo File html..."));
						CreateHTML(text, template_backup);
					}
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đã backup xong!"));
					if (!flag)
					{
						string text4 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
						CommonSQL.UpdateMultiFieldToAccount(id, "uid|token|name|birthday|backup|info", text + "|" + token + "|" + text3 + "|" + text2 + "|" + text4 + "|Live", isAllowEmptyValue: false);
						SetCellAccount(indexRow, "cUid", text);
						SetCellAccount(indexRow, "cToken", token);
						SetCellAccount(indexRow, "cName", text3, isAllowEmptyValue: false);
						SetCellAccount(indexRow, "cBirthday", text2);
						SetCellAccount(indexRow, "cInfo", "Live");
						SetCellAccount(indexRow, "cBackup", text4);
					}
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		private void ShowTrangThai(string content)
		{
			plTrangThai.Invoke((MethodInvoker)delegate
			{
				if (!plTrangThai.Visible)
				{
					plTrangThai.Visible = true;
				}
			});
			lblTrangThai.Invoke((MethodInvoker)delegate
			{
				lblTrangThai.Text = content;
			});
		}

		private void HideTrangThai()
		{
			plTrangThai.Invoke((MethodInvoker)delegate
			{
				if (plTrangThai.Visible)
				{
					plTrangThai.Visible = false;
				}
			});
		}

		public int InteractTimelime(int indexRow, string statusProxy, Device device, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (isLike)
			{
				num4 = device.GetRandomInt(countLikeFrom, countLikeTo);
			}
			lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			List<string> list = MCommon.Common.CloneList(lstComment);
			string text = "";
			if (isComment)
			{
				num5 = device.GetRandomInt(countCommentFrom, countCommentTo);
			}
			if (isShareWall)
			{
				num6 = device.GetRandomInt(countShareFrom, countShareTo);
			}
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			int randomInt = device.GetRandomInt(timeFrom, timeTo);
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < randomInt * 1000)
			{
				int num7 = CheckStatusDevice(device, indexRow, statusProxy);
				if (num7 == 1)
				{
					device.GotoNewFeedQuick();
				}
				else if (num7 != 0)
				{
					break;
				}
				string html = device.GetHtml();
				list2 = device.GetListBoundsByText("like button. double tap and hold to react", html);
				if (list2.Count > 0 && isLike && num < num4 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text2 = list2[list2.Count - 1];
					if (text2 != "" && device.TapLongByBounds(text2, "[0,100][320,480]"))
					{
						device.DelayRandom(1.0, 1.5);
						device.ClickReactions(6);
						num++;
						device.DelayRandom(1.0, 2.0);
						html = device.GetHtml();
					}
				}
				list3 = device.GetListBoundsByText("comment button", html);
				if (list3.Count > 0 && isComment && num2 < num5 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text3 = list3[list3.Count - 1];
					if (text3 != "")
					{
						if (list.Count == 0)
						{
							list = MCommon.Common.CloneList(lstComment);
						}
						text = list[device.GetRandomInt(0, list.Count - 1)];
						list.Remove(text);
						text = MCommon.Common.SpinText(text, rd);
						if (device.TapByBounds(text3, "[0,100][320,480]"))
						{
							device.DelayRandom(1.0, 2.0);
							device.InputTextWithUnicode(text);
							device.DelayRandom(1.0, 2.0);
							if (device.TapByText("send"))
							{
								device.DelayRandom(3.0, 5.0);
							}
							device.GotoBack(2, 0.3);
							num2++;
							device.DelayRandom(1.0, 2.0);
							html = device.GetHtml();
						}
					}
				}
				list4 = device.GetListBoundsByText("share button", html);
				if (list4.Count > 0 && isShareWall && num3 < num6 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text4 = list4[list4.Count - 1];
					if (text4 != "" && device.TapByBounds(text4, "[0,100][320,480]"))
					{
						device.DelayRandom(1.5, 2.0);
						device.TapByText("share now");
						device.DelayRandom(2.0, 3.0);
						num3++;
					}
				}
				if (device.ScrollAndCheckScreenNotChange(200))
				{
					break;
				}
				device.DelayRandom(1.5, 3.0);
			}
			return 0;
		}

		private void LoadCheckTool()
		{
			deviceId = CommonCSharp.Md5Encode(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
				.AddSystemDriveSerialNumber()
				.ToString());
			lblStatus.Text = Language.GetValue("Đã kích hoạt");
		}

		private void cControl(string dt)
		{
			Invoke((MethodInvoker)delegate
			{
				try
				{
					if (dt == "start")
					{
						btnInteract.Enabled = false;
						grQuanLyThuMuc.Enabled = false;
						btnPause.Enabled = true;
					}
					else if (dt == "stop")
					{
						btnPause.Text = Language.GetValue("Dừng Tương Tác");
						btnInteract.Enabled = true;
						grQuanLyThuMuc.Enabled = true;
						btnPause.Enabled = false;
					}
				}
				catch
				{
				}
			});
		}

		private void DtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				try
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
					CountCheckedAccount();
				}
				catch
				{
				}
			}
		}

		private void DtgvAcc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 32)
			{
				ChoseRowInDatagrid("ToggleCheck");
			}
		}

		private void OpenFormUpdate(string type)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						list.Add(GetCellAccount(i, "cId"));
					}
				}
				if (list.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n ta\u0300i khoa\u0309n câ\u0300n câ\u0323p nhâ\u0323t!"), 3);
				}
				else
				{
					MCommon.Common.ShowForm(new fUpdateData(this, type));
				}
			}
			catch
			{
			}
		}

		private void mậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Password");
		}

		private void NhậpDữLiệuToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Token");
		}

		private void NhậpDữLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Cookie");
		}

		private void mailKhôiPhụcToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("User");
		}

		private void mã2FAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("2FA");
		}

		private void tokenEAAAAZToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TuLayThongTin(0);
		}

		private void TokenBussinessToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TuLayThongTin(1);
		}

		private void TuLayThongTin(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			if (type == 2)
			{
				maxThread = Convert.ToInt32(setting_general.GetValue("nudInteractThread"));
			}
			setting_general.GetValue("token");
			isStop = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = type;
				int num2 = num;
				if (num2 != 0)
				{
					if (num2 == 1)
					{
						int num3 = 0;
						while (num3 < dtgvAcc.Rows.Count && !isStop)
						{
							if (!Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
							{
								num3++;
								continue;
							}
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									string statusDataGridView3 = CommonCSharp.GetStatusDataGridView(dtgvAcc, row2, "cId");
									string statusDataGridView4 = CommonCSharp.GetStatusDataGridView(dtgvAcc, row2, "cCookies");
									string text3 = GetCellAccount(row2, "cUseragent");
									string text4 = "";
									int typeProxy2 = 0;
									if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
									{
										text4 = GetCellAccount(row2, "cProxy");
										typeProxy2 = ((text4.Split('*').Length > 1) ? Convert.ToInt32(text4.Split('*')[1]) : 0);
										text4 = text4.Split('*')[0];
									}
									if (text3 == "" && text4.Split(':').Length == 4)
									{
										text3 = Base.useragentDefault;
									}
									if (statusDataGridView4 == "")
									{
										SetStatusAccount(row2, Language.GetValue("Cookie trống!"));
									}
									else
									{
										string tokenEAAG = CommonRequest.GetTokenEAAG(statusDataGridView4, text3, text4, typeProxy2);
										if (tokenEAAG == "-1")
										{
											SetStatusAccount(row2, "Cookie die!");
										}
										else
										{
											CommonSQL.UpdateFieldToAccount(statusDataGridView3, "token", tokenEAAG);
											SetCellAccount(row2, "cToken", tokenEAAG);
											SetStatusAccount(row2, Language.GetValue("Lấy token thành công!"));
										}
									}
								}).Start();
								continue;
							}
							if (Convert.ToInt32((setting_general.GetValue("ip_iTypeChangeIp") == "") ? "0" : setting_general.GetValue("ip_iTypeChangeIp")) == 0 || Convert.ToInt32((setting_general.GetValue("ip_iTypeChangeIp") == "") ? "0" : setting_general.GetValue("ip_iTypeChangeIp")) == 7)
							{
								MCommon.Common.DelayTime(1.0);
								continue;
							}
							while (iThread > 0)
							{
								MCommon.Common.DelayTime(1.0);
							}
							if (isStop)
							{
								break;
							}
							Interlocked.Increment(ref curChangeIp);
							if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
							{
								continue;
							}
							for (int i = 0; i < 3; i++)
							{
								isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
								if (isChangeIPSuccess)
								{
									break;
								}
							}
							if (isChangeIPSuccess)
							{
								curChangeIp = 0;
								continue;
							}
							goto IL_0313;
						}
					}
				}
				else
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							num4++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num4++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								string statusDataGridView = CommonCSharp.GetStatusDataGridView(dtgvAcc, row, "cId");
								string statusDataGridView2 = CommonCSharp.GetStatusDataGridView(dtgvAcc, row, "cCookies");
								string text = GetCellAccount(row, "cUseragent");
								string text2 = "";
								int typeProxy = 0;
								if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
								{
									text2 = GetCellAccount(row, "cProxy");
									typeProxy = ((text2.Split('*').Length > 1) ? Convert.ToInt32(text2.Split('*')[1]) : 0);
									text2 = text2.Split('*')[0];
								}
								if (text == "" && text2.Split(':').Length == 4)
								{
									text = Base.useragentDefault;
								}
								if (statusDataGridView2 == "")
								{
									SetStatusAccount(row, Language.GetValue("Cookie trống!"));
								}
								else
								{
									string tokenEAAAAZ = CommonRequest.GetTokenEAAAAZ(statusDataGridView2, text, text2, typeProxy);
									if (tokenEAAAAZ == "-1")
									{
										SetStatusAccount(row, "Cookie die!");
									}
									else
									{
										CommonSQL.UpdateFieldToAccount(statusDataGridView, "token", tokenEAAAAZ);
										SetCellAccount(row, "cToken", tokenEAAAAZ);
										SetStatusAccount(row, Language.GetValue("Lấy token thành công!"));
									}
								}
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32(setting_general.GetValueInt("ip_nudChangeIpCount", 1)))
						{
							continue;
						}
						for (int j = 0; j < 3; j++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_05d0;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
				{
					MCommon.Common.DelayTime(1.0);
				}
				goto IL_05e0;
				IL_05d0:
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
				goto IL_05e0;
				IL_0313:
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
				goto IL_05e0;
				IL_05e0:
				cControl("stop");
			}).Start();
		}

		private void BtnPause_Click(object sender, EventArgs e)
		{
			try
			{
				isStop = true;
				btnPause.Enabled = false;
				btnPause.Text = Language.GetValue("Đang dư\u0300ng...");
			}
			catch
			{
			}
		}

		private void TảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BtnLoadAcc_Click(null, null);
		}

		private void BtnDeleteFile_Click(object sender, EventArgs e)
		{
			int selectedIndex = cbbThuMuc.SelectedIndex;
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có thực sự muốn xóa thư mục [{0}] không?"), cbbThuMuc.Text)) == DialogResult.Yes)
			{
				if (CommonSQL.DeleteFileToDatabase(cbbThuMuc.SelectedValue.ToString()))
				{
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Xoá thành công thư mục [{0}] !"), cbbThuMuc.Text));
					LoadCbbThuMuc();
					cbbThuMuc.SelectedIndex = selectedIndex - 1;
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Không thể xóa thư mục [{0}] !"), cbbThuMuc.Text), 2);
				}
			}
		}

		private void CbbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isExcute_CbbThuMuc_SelectedIndexChanged || cbbThuMuc.SelectedValue == null || !StringHelper.CheckStringIsNumber(cbbThuMuc.SelectedValue.ToString()) || (cbbThuMuc.SelectedValue.ToString() != "999999" && indexCbbThuMucOld == cbbThuMuc.SelectedIndex))
			{
				return;
			}
			string text = cbbThuMuc.SelectedValue.ToString();
			if (!(text == "-1"))
			{
				if (!(text == "999999"))
				{
					LoadCbbTinhTrang(GetIdFile());
				}
				else
				{
					MCommon.Common.ShowForm(new fChonThuMuc());
					if (!fChonThuMuc.isAdd || fChonThuMuc.lstChooseIdFiles == null || fChonThuMuc.lstChooseIdFiles.Count == 0)
					{
						isExcute_CbbThuMuc_SelectedIndexChanged = false;
						cbbThuMuc.SelectedIndex = ((indexCbbThuMucOld != -1) ? indexCbbThuMucOld : 0);
						isExcute_CbbThuMuc_SelectedIndexChanged = true;
					}
					else
					{
						LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFiles);
					}
				}
			}
			else
			{
				LoadCbbTinhTrang();
			}
			indexCbbThuMucOld = cbbThuMuc.SelectedIndex;
			if (cbbThuMuc.SelectedValue != null)
			{
				string text2 = cbbThuMuc.SelectedValue.ToString();
				if (text2 == "-1" || text2 == "999999")
				{
					btnDeleteFile.BackColor = Color.Gray;
					btnDeleteFile.Enabled = false;
					btnEditFile.BackColor = Color.Gray;
					btnEditFile.Enabled = false;
				}
				else
				{
					btnDeleteFile.BackColor = Color.White;
					btnDeleteFile.Enabled = true;
					btnEditFile.BackColor = Color.White;
					btnEditFile.Enabled = true;
				}
			}
		}

		private void MailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|passmail");
		}

		private void UidPassTokenCookieMailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail");
		}

		private void CountTotalAccount()
		{
			try
			{
				lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
			}
			catch
			{
			}
		}

		private void CountCheckedAccount(int count = -1)
		{
			if (count == -1)
			{
				count = 0;
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						count++;
					}
				}
			}
			lblCountSelect.Text = count.ToString();
		}

		private void TạoProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng sư\u0309 du\u0323ng chư\u0301c năng Ta\u0323o profile khi Cha\u0323y tương ta\u0301c đê\u0309 gia\u0309m tô\u0301i đa ty\u0309 lê\u0323 checkpoint!"), 3);
		}

		private void KiemTraTaiKhoan(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			string tokenTrungGian = setting_general.GetValue("token");
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				switch (type)
				{
				case 0:
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row3 = num4++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row3, Language.GetValue("Đang kiểm tra..."));
									CheckMyWall(row3, tokenTrungGian);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num4++;
						}
					}
					break;
				}
				case 1:
				{
					int num6 = 0;
					while (num6 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num6++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
									CheckMyToken(row);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num6++;
						}
					}
					break;
				}
				case 2:
				{
					int num2 = 0;
					while (num2 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row5 = num2++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row5, Language.GetValue("Đang kiểm tra..."));
									CheckMyCookie(row5);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num2++;
						}
					}
					break;
				}
				case 3:
				{
					int num5 = 0;
					while (num5 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num5++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									CheckDangCheckpoint(row2);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num5++;
						}
					}
					break;
				}
				case 4:
				{
					int num3 = 0;
					while (num3 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row4 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row4, Language.GetValue("Đang kiểm tra..."));
									CheckAccountMail(row4);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num3++;
						}
					}
					break;
				}
				case 5:
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row6 = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row6, Language.GetValue("Đang kiểm tra..."));
									CheckInfoUid(row6);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					break;
				}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
				{
					MCommon.Common.DelayTime(1.0);
				}
				cControl("stop");
			}).Start();
		}

		private void CheckInfoUid(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cEmail");
				string text = GetCellAccount(row, "cUid").Trim();
				string text2 = "";
				string uidIg = CommonRequest.GetUidIg(cellAccount2);
				string[] array = uidIg.Split('|');
				string text3 = array[0].Trim();
				string text4 = array[1].Trim();
				if (text4 != "")
				{
					if (text == "" && text3 != "")
					{
						CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text3);
						SetCellAccount(row, "cUid", text3);
					}
					CommonSQL.UpdateFieldToAccount(cellAccount, "name", text4 ?? "");
					SetCellAccount(row, "cName", text4);
					SetInfoAccount(cellAccount, row, "Live");
					text2 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
					SetStatusAccount(row, text2);
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckAccountMail(int row)
		{
			try
			{
				string text = "";
				string text2 = "";
				text = dtgvAcc.Rows[row].Cells["cEmail"].Value.ToString();
				text2 = dtgvAcc.Rows[row].Cells["cPassMail"].Value.ToString();
				if (text == "" || text2 == "")
				{
					SetStatusAccount(row, Language.GetValue("Không tìm thấy mail!"));
				}
				else if (text.EndsWith("@hotmail.com") || text.EndsWith("@outlook.com"))
				{
					string text3 = MCommon.Common.CheckAccountHotmail(text, text2);
					if (text3.Equals("1"))
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: live!"));
					}
					else
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: die!"));
					}
				}
				else if (text.EndsWith("@yandex.com"))
				{
					string text4 = MCommon.Common.CheckAccountEmail(text, text2, "imap.yandex.com");
					if (text4.Equals("1"))
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: live!"));
					}
					else
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: die!"));
					}
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Mail chưa hỗ trợ!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Lỗi!"));
			}
		}

		private void CheckMyWall(int row, string tokenTg)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				if (!CheckIsUidFacebook(cellAccount2))
				{
					SetStatusAccount(row, Language.GetValue("Uid không hợp lệ!"));
					return;
				}
				string text = "";
				string text2 = "";
				string text3 = CommonRequest.CheckLiveWall(cellAccount2);
				if (text3.StartsWith("0|"))
				{
					text = "Die";
					text2 = "Wall die";
				}
				else if (text3.StartsWith("1|"))
				{
					text = "Live";
					text2 = "Wall live";
				}
				else
				{
					text2 = Language.GetValue("Không check được!");
				}
				SetStatusAccount(row, text2);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckMyToken(int row)
		{
			try
			{
				string text = "";
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				string cellAccount3 = GetCellAccount(row, "cToken");
				if (cellAccount3.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Token trô\u0301ng!"));
					return;
				}
				string text2 = GetCellAccount(row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = GetCellAccount(row, "cProxy");
					typeProxy = ((text3.Split('*').Length > 1) ? Convert.ToInt32(text3.Split('*')[1]) : 0);
					text3 = text3.Split('*')[0];
				}
				if (text2 == "" && text3.Split(':').Length == 4)
				{
					text2 = Base.useragentDefault;
				}
				string text4 = "";
				if (!CommonRequest.CheckLiveToken(cellAccount2, cellAccount3, text2, text3, typeProxy))
				{
					text4 = "Token die";
				}
				else
				{
					text = "Live";
					text4 = "Token live";
				}
				SetStatusAccount(row, text4);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckMyCookie(int row)
		{
			try
			{
				string text = "";
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				if (cellAccount2.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Cookie trô\u0301ng!"));
					return;
				}
				string text2 = GetCellAccount(row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = GetCellAccount(row, "cProxy");
					typeProxy = ((text3.Split('*').Length > 1) ? Convert.ToInt32(text3.Split('*')[1]) : 0);
					text3 = text3.Split('*')[0];
				}
				if (text2 == "" && text3.Split(':').Length == 4)
				{
					text2 = Base.useragentDefault;
				}
				string text4 = "";
				if (!CommonRequest.CheckLiveCookie(cellAccount2, text2, text3, typeProxy).StartsWith("1|"))
				{
					text4 = "Cookie die";
				}
				else
				{
					text = "Live";
					text4 = "Cookie live";
				}
				SetStatusAccount(row, text4);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckDangCheckpoint(int row)
		{
			string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
			string email = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
			string pass = dtgvAcc.Rows[row].Cells["cPassword"].Value.ToString();
			string cellAccount = GetCellAccount(row, "cUseragent");
			string text = "";
			int typeProxy = 0;
			if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
			{
				text = GetCellAccount(row, "cProxy");
				typeProxy = ((text.Split('*').Length > 1) ? Convert.ToInt32(text.Split('*')[1]) : 0);
				text = text.Split('*')[0];
			}
			if (cellAccount == "" && text.Split(':').Length == 4)
			{
				cellAccount = Base.useragentDefault;
			}
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = CommonRequest.CheckFacebookAccount(email, pass, "", text, typeProxy);
			switch (text5.Split('|')[0])
			{
			case "3":
				text2 = "Changed pass";
				break;
			case "2":
				text2 = ((!(text5.Split('|')[1].Trim() != "")) ? Language.GetValue("Checkpoint") : ("Checkpoint: " + text5.Split('|')[1]));
				break;
			case "1":
				text4 = text5.Split('|')[1];
				text2 = "Live";
				break;
			case "5":
				text3 = Language.GetValue("Không check đươ\u0323c (Co\u0301 2fa)!");
				break;
			case "0":
			case "4":
				text3 = Language.GetValue("Không check đươ\u0323c!");
				break;
			}
			if (text3 == "")
			{
				text3 = Language.GetValue("Đa\u0303 check xong!");
			}
			if (text4 != "")
			{
				SetCellAccount(row, "cCookies", text4);
				CommonSQL.UpdateFieldToAccount(id, "cookie1", text4);
			}
			if (text2 != "")
			{
				SetInfoAccount(id, row, text2);
				CommonSQL.UpdateFieldToAccount(id, "info", text2);
			}
			SetStatusAccount(row, text3);
		}

		private void KiểmTraWallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(0);
		}

		private void KiểmTraTokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void KiểmTraCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(2);
		}

		private void KiểmTraTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(3);
		}

		private void MailToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail");
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbbSearch.SelectedIndex == -1)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn kiểu tìm kiếm!"), 3);
					return;
				}
				string columnName = cbbSearch.SelectedValue.ToString();
				string text = txbSearch.Text.Trim();
				if (text == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập nội dung tìm kiếm!"), 3);
					return;
				}
				List<int> list = new List<int>();
				text = MCommon.Common.ConvertToUnSign(text.ToLower());
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					string text2 = dtgvAcc.Rows[i].Cells[columnName].Value.ToString();
					text2 = MCommon.Common.ConvertToUnSign(text2.ToLower());
					text = MCommon.Common.ConvertToUnSign(text.ToLower());
					if (text2.Contains(text))
					{
						list.Add(i);
					}
				}
				int index = 0;
				int num = -1;
				try
				{
					num = dtgvAcc.CurrentRow.Index;
				}
				catch
				{
					num = -1;
				}
				if (list.Count <= 0)
				{
					return;
				}
				if (num >= list[list.Count - 1])
				{
					index = 0;
				}
				else
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (num < list[j])
						{
							index = j;
							break;
						}
					}
				}
				int index2 = list[index];
				dtgvAcc.CurrentCell = dtgvAcc.Rows[index2].Cells[columnName];
				dtgvAcc.ClearSelection();
				dtgvAcc.Rows[index2].Selected = true;
			}
			catch (Exception)
			{
			}
		}

		private void UidPassTokenCookieMailPassMail2faToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail|fa2");
		}

		private void ToolStripStatusLabel9_Click(object sender, EventArgs e)
		{
			Hide();
			Settings.Default.UserName = "";
			Settings.Default.PassWord = "";
			Settings.Default.Save();
			fActive fActive2 = new fActive(0, deviceId);
			fActive2.ShowInTaskbar = true;
			fActive2.ShowDialog();
		}

		private void UpdateSttOnDatatable()
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				SetCellAccount(i, "cSTT", i + 1);
			}
		}

		private void BtnShare_Click(object sender, EventArgs e)
		{
		}

		private void BtnPost_Click(object sender, EventArgs e)
		{
		}

		private void BtnViewLivestream_Click(object sender, EventArgs e)
		{
		}

		private void fAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("2fa");
		}

		private void checkAvatarToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CheckMyAvatar(int row, string token)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.CheckAvatarFromUid(uid, token))
				{
					SetStatusAccount(row, Language.GetValue("Đa\u0303 co\u0301 avatar!"));
					SetCellAccount(row, "cAvatar", "Yes");
					CommonSQL.UpdateFieldToAccount(id, "avatar", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Không co\u0301 avatar!"));
					SetCellAccount(row, "cAvatar", "No");
					CommonSQL.UpdateFieldToAccount(id, "avatar", "No");
				}
			}
			catch
			{
				SetStatusAccount(row, "Lỗi!");
			}
		}

		private void locTrungToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num = 0;
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				try
				{
					string cellAccount = GetCellAccount(i, "cEmail");
					if (list2.Contains(cellAccount) && cellAccount != "")
					{
						list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
						dtgvAcc.Rows.RemoveAt(i);
						i--;
						num++;
					}
					else
					{
						list2.Add(cellAccount);
					}
				}
				catch
				{
				}
			}
			CommonSQL.DeleteAccountToDatabase(list);
			UpdateSttOnDatatable();
			CountTotalAccount();
			CountCheckedAccount();
			MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đã loại bỏ {0} tài khoản bị trùng!"), num));
		}

		private void đăngNhâpBăngUidpassToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void đăngNhâpBăngCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void xóaProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa Profile của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a profile..."));
								DeleteProfile(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteProfile(int row)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
					return;
				}
				string path = "profile\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa profile thành công!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa profile thất bại!"));
			}
		}

		private void checkProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			string profilePath = ConfigHelper.GetPathProfile();
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.RowCount)
				{
					if (Convert.ToBoolean(GetCellAccount(num, "cChose")))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, "Check profile...");
								CheckProfile(row, profilePath);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void CheckProfile(int row, string profilePath)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				profilePath = profilePath + "\\" + cellAccount2;
				if (Directory.Exists(profilePath))
				{
					SetStatusAccount(row, Language.GetValue("Đã có profile!"));
					SetCellAccount(row, "cProfile", "Yes");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "No");
				}
			}
			catch
			{
			}
		}

		private void donDepProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fClearProfile());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(ex.ToString(), 3);
			}
		}

		public void CloseProcess(string nameProcess)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(nameProcess);
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			CloseProcess("Chrome");
		}

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}

		private void uidPass2FaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|pass|cookie");
		}

		private void mnuCauHinhChung_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhChung());
		}

		private void đinhDangKhacToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						list.Add(GetCellAccount(i, "cUid") + "|" + GetCellAccount(i, "cPassword") + "|" + GetCellAccount(i, "cToken") + "|" + GetCellAccount(i, "cCookies") + "|" + GetCellAccount(i, "cEmail") + "|" + GetCellAccount(i, "cPassMail") + "|" + GetCellAccount(i, "cFa2") + "|" + GetCellAccount(i, "cUseragent") + "|" + GetCellAccount(i, "cProxy").Split('*')[0] + "|" + GetCellAccount(i, "cName") + "|" + GetCellAccount(i, "cGender") + "|" + GetCellAccount(i, "cFollow") + "|" + GetCellAccount(i, "cFriend") + "|" + GetCellAccount(i, "cGroup") + "|" + GetCellAccount(i, "cBirthday") + "|" + GetCellAccount(i, "cDateCreateAcc") + "|" + GetCellAccount(i, "cDevice") + "|LDPlayer-" + GetCellAccount(i, "cDevice"));
					}
				}
				if (list.Count <= 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn danh sách tài khoản muốn copy thông tin!"), 3);
				}
				else
				{
					MCommon.Common.ShowForm(new fCopy(list));
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "Error Copy");
			}
		}

		private void maBaoMât6SôToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("ma2fa");
		}

		private void trạngTháiToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CapNhatThongTin(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			string tokenTrungGian = setting_general.GetValue("token");
			string cookieTrungGian = setting_general.GetValue("cookie");
			if (type == 0 && !CommonRequest.CheckLiveToken("", tokenTrungGian, "", ""))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"), 3);
				return;
			}
			if (type == 4 && CommonRequest.CheckLiveCookie(cookieTrungGian, "", "", 0).StartsWith("0|"))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại cookie trung gian!"), 3);
				return;
			}
			isStop = false;
			bool isTokenDie = false;
			bool isCookieDie = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				switch (type)
				{
				case 0:
				{
					int num3 = 0;
					while (num3 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									if (!GetInfoUsingToken(row2, tokenTrungGian, isTokenTrungGian: true))
									{
										isStop = true;
										isTokenDie = true;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num3++;
						}
					}
					goto default;
				}
				case 1:
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							num4++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num4++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								GetInfoUsingToken(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
						{
							continue;
						}
						for (int j = 0; j < 3; j++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_03b9;
					}
					goto default;
				}
				case 2:
				{
					int num2 = 0;
					while (num2 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							num2++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row3 = num2++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row3, Language.GetValue("Đang kiểm tra..."));
								GetInfoUsingCookie(row3);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
						{
							continue;
						}
						for (int i = 0; i < 3; i++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_0680;
					}
					goto default;
				}
				case 4:
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row4 = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row4, Language.GetValue("Đang kiểm tra..."));
									if (!GetInfoUsingCookieTrungGian(row4, cookieTrungGian))
									{
										isStop = true;
										isCookieDie = true;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					goto default;
				}
				default:
					{
						int tickCount = Environment.TickCount;
						while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
						{
							MCommon.Common.DelayTime(1.0);
						}
						break;
					}
					IL_03b9:
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
					break;
					IL_0680:
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
					break;
				}
				cControl("stop");
				if (isTokenDie)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Token trung gian die!"));
				}
				if (isCookieDie)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Cookie trung gian die!"));
				}
			}).Start();
		}

		private bool GetInfoUsingToken(int row, string token, bool isTokenTrungGian)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = ((text2.Split('*').Length > 1) ? Convert.ToInt32(text2.Split('*')[1]) : 0);
					text2 = text2.Split('*')[0];
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				if (isTokenTrungGian)
				{
					text = "";
					text2 = "";
					typeProxy = 0;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text4 = Language.GetValue("Không co\u0301 uid!");
				}
				else
				{
					string infoAccountFromUidUsingToken = CommonRequest.GetInfoAccountFromUidUsingToken(token, cellAccount2, text, text2, typeProxy);
					if (infoAccountFromUidUsingToken == "-1")
					{
						SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
						return false;
					}
					string[] array = infoAccountFromUidUsingToken.Split('|');
					if (Convert.ToBoolean(array[0]))
					{
						text3 = "Live";
						CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
						SetCellAccount(row, "cName", array[1]);
						SetCellAccount(row, "cGender", array[2]);
						SetCellAccount(row, "cBirthday", array[3]);
						if (array[5] != "")
						{
							SetCellAccount(row, "cEmail", array[5]);
						}
						SetCellAccount(row, "cFriend", array[6]);
						SetCellAccount(row, "cGroup", array[7]);
						text4 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
					}
					else
					{
						text3 = "Die";
						text4 = Language.GetValue("Tài khoản die!");
					}
				}
				SetStatusAccount(row, text4);
				if (text3 != "")
				{
					SetInfoAccount(cellAccount, row, text3);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
			return true;
		}

		private void GetInfoUsingCookie(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				GetCellAccount(row, "cToken");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = ((text2.Split('*').Length > 1) ? Convert.ToInt32(text2.Split('*')[1]) : 0);
					text2 = text2.Split('*')[0];
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text3 = Language.GetValue("Cookie trô\u0301ng");
				}
				else
				{
					string infoAccountFromUidUsingCookie = CommonRequest.GetInfoAccountFromUidUsingCookie(cellAccount2, text, text2, typeProxy);
					if (infoAccountFromUidUsingCookie == "-1")
					{
						text3 = "Cookie die";
					}
					else
					{
						string[] array = infoAccountFromUidUsingCookie.Split('|');
						if (Convert.ToBoolean(array[0]))
						{
							text4 = "Live";
							CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
							SetCellAccount(row, "cName", array[1]);
							SetCellAccount(row, "cGender", array[2]);
							SetCellAccount(row, "cBirthday", array[3]);
							if (array[5] != "")
							{
								SetCellAccount(row, "cEmail", array[5]);
							}
							SetCellAccount(row, "cFriend", array[6]);
							SetCellAccount(row, "cGroup", array[7]);
							text3 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
						}
						else
						{
							text4 = "Die";
							text3 = Language.GetValue("Tài khoản die!");
						}
					}
				}
				SetStatusAccount(row, text3);
				if (text4 != "")
				{
					SetInfoAccount(cellAccount, row, text4);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private bool GetInfoUsingCookieTrungGian(int row, string cookie)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string text = "";
				string infoAccountFromUidUsingCookieTrungGian = CommonRequest.GetInfoAccountFromUidUsingCookieTrungGian(cellAccount2, cookie);
				if (infoAccountFromUidUsingCookieTrungGian == "-1")
				{
					SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
					return false;
				}
				string[] array = infoAccountFromUidUsingCookieTrungGian.Split('|');
				if (Convert.ToBoolean(array[0]))
				{
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender", array[1] + "|" + array[2]);
					SetCellAccount(row, "cName", array[1]);
					SetCellAccount(row, "cGender", array[2]);
					if (array[6] != "")
					{
						SetCellAccount(row, "cFriend", array[6]);
						CommonSQL.UpdateFieldToAccount(cellAccount, "friends", array[6]);
					}
					if (array[7] != "")
					{
						SetCellAccount(row, "cGroup", array[7]);
						CommonSQL.UpdateFieldToAccount(cellAccount, "groups", array[7]);
					}
					SetInfoAccount(cellAccount, row, "Live");
					text = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
				}
				else
				{
					SetInfoAccount(cellAccount, row, "Die");
					text = Language.GetValue("Tài khoản Die!");
				}
				SetStatusAccount(row, text);
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
			return true;
		}

		private void UpdateInfoWhenInteracting(Chrome chrome, int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string infoAccountFromUidUsingCookie = CommonChrome.GetInfoAccountFromUidUsingCookie(chrome);
				if (!infoAccountFromUidUsingCookie.Contains("|"))
				{
					if (infoAccountFromUidUsingCookie == "-1")
					{
						SetInfoAccount(cellAccount, row, "Die");
					}
					return;
				}
				string[] array = infoAccountFromUidUsingCookie.Split('|');
				CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups|dateCreateAcc|follow" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + "|" + array[9] + "|" + array[10] + ((array[5] != "") ? ("|" + array[5]) : ""), isAllowEmptyValue: false);
				SetCellAccount(row, "cName", array[1], isAllowEmptyValue: false);
				SetCellAccount(row, "cGender", array[2], isAllowEmptyValue: false);
				SetCellAccount(row, "cBirthday", array[3], isAllowEmptyValue: false);
				SetCellAccount(row, "cEmail", array[5], isAllowEmptyValue: false);
				SetCellAccount(row, "cFriend", array[6], isAllowEmptyValue: false);
				SetCellAccount(row, "cGroup", array[7], isAllowEmptyValue: false);
				SetCellAccount(row, "cDateCreateAcc", array[9], isAllowEmptyValue: false);
				SetCellAccount(row, "cFollow", array[10], isAllowEmptyValue: false);
				SetInfoAccount(cellAccount, row, "Live");
			}
			catch
			{
			}
		}

		public int HDXoaThongBaoVPCS(int indexRow, string statusProxy, Chrome chrome, int typeDelete, bool isDeleteMessage, string tenHanhDong = "")
		{
			int num = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				if (typeDelete == 1 && Base.rd.Next(1, 11) > 7)
				{
					return 0;
				}
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + " " + tenHanhDong + "...");
				bool flag = false;
				for (int i = 0; i < 3; i++)
				{
					num = 0;
					CommonChrome.GoToNotifications(chrome);
					string cssSelector = chrome.GetCssSelector("a", "href", "/notifications.php?more");
					if (cssSelector != "" && chrome.Click(4, cssSelector) == 1)
					{
						chrome.DelayRandom(3, 5);
					}
					List<string> list = new List<string>();
					list = chrome.ExecuteScript("var y=[];var x=document.querySelectorAll('a'); for(i=0;i<x.length;i++){if(x[i].getAttribute('href')!=null && x[i].getAttribute('href').includes('/support/view_details/')) y.push(x[i].getAttribute('href'))};return y.join('|')").ToString().Split('|')
						.ToList();
					list = MCommon.Common.RemoveEmptyItems(list);
					if (list.Count == 0)
					{
						break;
					}
					for (int j = 0; j < list.Count; j++)
					{
						chrome.GotoURL("https://m.facebook.com" + list[j]);
						chrome.DelayRandom(2, 4);
						cssSelector = chrome.GetCssSelector("a", "href", "/si/actor_experience/action_experience");
						if (cssSelector != "")
						{
							chrome.Click(4, cssSelector);
							chrome.DelayRandom(2, 4);
							cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
							if (!(cssSelector != "") || chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) != 1)
							{
								continue;
							}
							chrome.DelayRandom(2, 4);
							cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
							if (cssSelector != "" && chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) == 1)
							{
								chrome.DelayRandom(2, 4);
							}
							if (chrome.CheckExistElement("[data-nt-switch-case='{\"v\":\"default\"}']", 4.0) != 1 || chrome.Click(4, "[data-nt-switch-case='{\"v\":\"default\"}']") != 1)
							{
								continue;
							}
							chrome.DelayRandom(2, 4);
							for (int k = 0; k < 5; k++)
							{
								cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
								if (!(cssSelector != "") || chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) != 1)
								{
									break;
								}
								chrome.DelayRandom(2, 4);
							}
							continue;
						}
						if (isDeleteMessage)
						{
							cssSelector = chrome.GetCssSelector("a", "href", "/support/reporter/remove/");
							chrome.Click(4, cssSelector);
							chrome.DelayRandom(2, 4);
							if (chrome.CheckExistElement("[data-testid=\"supportInbox/confirmDialog/confirm\"]", 3.0) == 1 && chrome.Click(4, "[data-testid=\"supportInbox/confirmDialog/confirm\"]") == 1)
							{
								chrome.DelayRandom(2, 4);
							}
						}
						num++;
						if (num == list.Count)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		private void GetInfoUsingToken(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cToken");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = ((text2.Split('*').Length > 1) ? Convert.ToInt32(text2.Split('*')[1]) : 0);
					text2 = text2.Split('*')[0];
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text4 = Language.GetValue("Token trô\u0301ng");
				}
				else
				{
					string infoAccountFromUidUsingToken = CommonRequest.GetInfoAccountFromUidUsingToken(cellAccount2, "", text, text2, typeProxy);
					if (infoAccountFromUidUsingToken == "-1")
					{
						text4 = "Token die";
					}
					else
					{
						string[] array = infoAccountFromUidUsingToken.Split('|');
						if (Convert.ToBoolean(array[0]))
						{
							text3 = "Live";
							CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
							SetCellAccount(row, "cName", array[1]);
							SetCellAccount(row, "cGender", array[2]);
							SetCellAccount(row, "cBirthday", array[3]);
							if (array[5] != "")
							{
								SetCellAccount(row, "cEmail", array[5]);
							}
							SetCellAccount(row, "cFriend", array[6]);
							SetCellAccount(row, "cGroup", array[7]);
						}
						else
						{
							text3 = "Die";
						}
						text4 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
					}
				}
				SetStatusAccount(row, text4);
				if (text3 != "")
				{
					SetInfoAccount(cellAccount, row, text3);
				}
			}
			catch
			{
				SetStatusAccount(row, "Không check đươ\u0323c!");
			}
		}

		private void sưDungTokenTrungGianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapTokenTrungGian());
			if (fNhapTokenTrungGian.isOK)
			{
				CapNhatThongTin(0);
			}
		}

		private void sưDungTokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CapNhatThongTin(1);
		}

		private void sưDungCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Tính năng này có thể khiến tài khoản bị khóa, bạn vẫn muốn sử dụng?")) == DialogResult.Yes)
			{
				CapNhatThongTin(2);
			}
		}

		private void BackupCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Tính năng này hiện tại đang chạy bằng Cookie nên rất dễ Die tài khoản!") + "\r\n" + Language.GetValue("Khuyến cáo nên sư\u0309 du\u0323ng chư\u0301c năng Backup khi Cha\u0323y tương ta\u0301c đê\u0309 gia\u0309m tô\u0301i đa ty\u0309 lê\u0323 checkpoint!") + "\r\n" + Language.GetValue("Bạn có chắc vẫn muốn sử dụng tính năng này?")) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			isStop = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (true)
				{
					if (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							num++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								BackupAccountOneThread(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (!isStop)
						{
							Interlocked.Increment(ref curChangeIp);
							if (curChangeIp >= Convert.ToInt32(setting_general.GetValueInt("ip_nudChangeIpCount", 1)))
							{
								for (int i = 0; i < 3; i++)
								{
									isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValue("ip_txtProfileNameDcom"), Convert.ToInt32((setting_general.GetValue("ip_cbbHostpot") == "") ? "0" : setting_general.GetValue("ip_cbbHostpot")), setting_general.GetValue("ip_txtNordVPN"));
									if (isChangeIPSuccess)
									{
										break;
									}
								}
								if (!isChangeIPSuccess)
								{
									MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
									break;
								}
								curChangeIp = 0;
							}
							continue;
						}
					}
					_ = Environment.TickCount;
					while (iThread > 0)
					{
						MCommon.Common.DelayTime(1.0);
					}
					break;
				}
				cControl("stop");
			}).Start();
		}

		private List<string> GhepFileList(List<string> lstId, int soLuongAccMoiLan = 50, string separator = ",")
		{
			int num = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)lstId.Count * 1.0 / (double)soLuongAccMoiLan)));
			List<string> list = new List<string>();
			for (int i = 0; i < num; i++)
			{
				list.Add(string.Join(separator, lstId.GetRange(soLuongAccMoiLan * i, (soLuongAccMoiLan * i + soLuongAccMoiLan <= lstId.Count) ? soLuongAccMoiLan : (lstId.Count % soLuongAccMoiLan))));
			}
			return list;
		}

		private void BackupAccountOneThread(int row)
		{
			int indexRow = row;
			string text = "";
			string text2 = "";
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cookie = GetCellAccount(row, "cCookies");
				string token = GetCellAccount(row, "cToken");
				string cellAccount2 = GetCellAccount(row, "cUid");
				if (cellAccount2 == "")
				{
					cellAccount2 = Regex.Match(cookie, "c_user=(.*?);").Groups[1].Value;
				}
				string useragent = GetCellAccount(row, "cUseragent");
				string proxy = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					proxy = GetCellAccount(row, "cProxy");
					if (proxy.Split('*').Length > 1)
					{
						typeProxy = Convert.ToInt32(proxy.Split('*')[1]);
					}
					else
					{
						typeProxy = 0;
					}
					proxy = proxy.Split('*')[0];
				}
				if (useragent == "" && proxy.Split(':').Length == 4)
				{
					useragent = Base.useragentDefault;
				}
				if (token == "" && CommonRequest.CheckLiveCookie(cookie, useragent, proxy, typeProxy).StartsWith("1|"))
				{
					token = CommonRequest.GetTokenEAAAAZ(cookie, useragent, proxy, typeProxy);
				}
				if (token != "" && CommonRequest.CheckLiveToken(cookie, token, useragent, proxy, typeProxy))
				{
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup nga\u0300y sinh..."));
					string myBirthday = CommonRequest.GetMyBirthday(cookie, token, useragent, proxy, typeProxy);
					if (myBirthday == "-1")
					{
						CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", "Token die!");
						return;
					}
					cellAccount2 = myBirthday.Split('|')[0];
					text = myBirthday.Split('|')[1];
					text2 = myBirthday.Split('|')[2];
					lock (_lock)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllText("backup\\" + cellAccount2 + "\\ngaysinh.txt", myBirthday);
					}
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup a\u0309nh") + "...");
					List<string> listImageBackup = new List<string>();
					int iThread = 0;
					object _lock_countSuccess = new object();
					int countSuccess = 0;
					List<string> myListUidNameFriend = CommonRequest.GetMyListUidNameFriend(cookie, token, useragent, proxy, typeProxy);
					int totalFriend = myListUidNameFriend.Count;
					List<string> lstQuery = GhepFileList(myListUidNameFriend);
					_ = lstQuery.Count;
					new Thread((ThreadStart)delegate
					{
						while (iThread > 0)
						{
							CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup ảnh") + ": " + countSuccess + "/" + totalFriend + "...");
							Thread.Sleep(100);
						}
					}).Start();
					if (lstQuery.Count > 0)
					{
						int num = ((lstQuery.Count > 10) ? 10 : lstQuery.Count);
						int num2 = 0;
						while (num2 < lstQuery.Count)
						{
							if (iThread < num)
							{
								Interlocked.Increment(ref iThread);
								int stt = num2++;
								new Thread((ThreadStart)delegate
								{
									string text4 = lstQuery[stt];
									List<string> list = CommonRequest.BackupImageOne(text4, cookie, token, useragent, proxy, typeProxy);
									if (list.Count > 0)
									{
										lock (listImageBackup)
										{
											listImageBackup.AddRange(list);
										}
									}
									lock (_lock_countSuccess)
									{
										countSuccess += text4.Split(',').Length;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Thread.Sleep(100);
							}
						}
						while (iThread > 0)
						{
							Thread.Sleep(100);
						}
						if (listImageBackup.Count > 0)
						{
							lock (_lock2)
							{
								Directory.CreateDirectory("backup\\" + cellAccount2);
								File.WriteAllLines("backup\\" + cellAccount2 + "\\" + cellAccount2 + ".txt", listImageBackup);
							}
						}
						else
						{
							CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
						}
					}
					else
					{
						CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
					}
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Backup bình luận..."));
					List<string> myListComments = CommonRequest.GetMyListComments(cookie, useragent, proxy, typeProxy);
					lock (_lock3)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllLines("backup\\" + cellAccount2 + "\\lscomment.txt", myListComments);
					}
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Backup nhă\u0301n tin gâ\u0300n đây..."));
					List<string> myListUidMessage = CommonRequest.GetMyListUidMessage(cookie, useragent, proxy, typeProxy);
					lock (_lock4)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllLines("backup\\" + cellAccount2 + "\\banbeinbox.txt", myListUidMessage);
					}
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đa\u0303 backup xong") + ": " + countSuccess + "!");
					string text3 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "uid|token|name|birthday|backup|info", cellAccount2 + "|" + token + "|" + text2 + "|" + text + "|" + text3 + "|Live", isAllowEmptyValue: false);
					SetCellAccount(indexRow, "cUid", cellAccount2);
					SetCellAccount(indexRow, "cToken", token);
					SetCellAccount(indexRow, "cName", text2, isAllowEmptyValue: false);
					SetCellAccount(indexRow, "cBirthday", text);
					SetCellAccount(indexRow, "cInfo", "Live");
					SetCellAccount(indexRow, "cBackup", text3);
				}
				else
				{
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup được: Token/Cookie die!"));
				}
			}
			catch
			{
				CommonCSharp.UpdateStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Lỗi backup!"));
			}
		}

		private void LoadSetting()
		{
			setting_general = new JSON_Settings("configGeneral");
			setting_Interact = new JSON_Settings("configInteract");
			setting_InteractGeneral = new JSON_Settings("configInteractGeneral");
		}

		private void taoFileHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadSetting();
			string template = Base.template_backup;
			int iThread = 0;
			int maxThread = 10;
			new Thread((ThreadStart)delegate
			{
				try
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									try
									{
										CreateAndCopyHtmlFromBackupTxt(row, template);
										Interlocked.Decrement(ref iThread);
									}
									catch (Exception ex2)
									{
										CommonCSharp.ExportError(null, ex2.ToString());
									}
								}).Start();
							}
							else
							{
								CommonCSharp.DelayTime(1.0);
							}
						}
						else
						{
							num++;
						}
					}
					while (iThread > 0)
					{
						CommonCSharp.DelayTime(1.0);
					}
				}
				catch (Exception ex)
				{
					CommonCSharp.ExportError(null, ex.ToString());
				}
			}).Start();
		}

		private void CreateAndCopyHtmlFromBackupTxt(int row, string template, bool isOpen = false, string pathDestination = "")
		{
			try
			{
				string text = "";
				string statusDataGridView = CommonCSharp.GetStatusDataGridView(dtgvAcc, row, "cCookie");
				string text2 = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text2 == "")
				{
					text2 = Regex.Match(statusDataGridView, "c_user=(.*?);").Groups[1].Value;
				}
				text = ((!File.Exists("backup\\" + text2 + "\\ngaysinh.txt")) ? "||" : File.ReadAllText("backup\\" + text2 + "\\ngaysinh.txt"));
				CommonCSharp.UpdateStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Đang tạo file Html..."));
				if (text2 != "")
				{
					string text3 = text.Split('|')[2].Replace("\"", "\\\"").Replace("'", "\\'");
					string text4 = text.Split('|')[1];
					if (text3 == "")
					{
						text3 = "NoName";
					}
					if (text4 == "")
					{
						text4 = "00/00/0000";
					}
					template = template.Replace("{{uid}}", text2).Replace("{{birthday}}", text4).Replace("{{name}}", text3);
					string text5 = "backup\\" + text2;
					if (!Directory.Exists(text5))
					{
						return;
					}
					if (File.Exists(text5 + "\\lscomment.txt"))
					{
						string text6 = "";
						List<string> list = File.ReadAllLines(text5 + "\\lscomment.txt").ToList();
						int count = list.Count;
						for (int i = 0; i < count; i++)
						{
							text6 = text6 + "\"" + list[i].Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
						}
						if (text6 != "")
						{
							text6 = text6.Remove(text6.Length - 1, 1);
							template = template.Replace("{comments}", text6);
						}
						else
						{
							template = template.Replace("{comments}", "");
						}
					}
					else
					{
						template = template.Replace("{comments}", "");
					}
					if (File.Exists(text5 + "\\banbeinbox.txt"))
					{
						string text7 = "";
						List<string> list2 = File.ReadAllLines(text5 + "\\banbeinbox.txt").ToList();
						int count2 = list2.Count;
						for (int j = 0; j < count2; j++)
						{
							text7 = text7 + "\"" + list2[j].Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
						}
						if (text7 != "")
						{
							text7 = text7.Remove(text7.Length - 1, 1);
							template = template.Replace("{messages}", text7);
						}
						else
						{
							template = template.Replace("{messages}", "");
						}
					}
					else
					{
						template = template.Replace("{messages}", "");
					}
					if (File.Exists(text5 + "\\" + text2 + ".txt"))
					{
						string text8 = "";
						string text9 = "";
						string text10 = File.ReadAllText(text5 + "\\" + text2 + ".txt");
						string[] array = text10.Split(new string[1] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
						for (int k = 0; k < array.Length; k++)
						{
							string[] array2 = array[k].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
							if (array2.Length != 0)
							{
								text9 = "";
								for (int l = 0; l < array2.Length; l++)
								{
									string[] array3 = array2[l].Split('*');
									text9 = text9 + "\"" + array3[2].Split('|')[0] + "\",";
								}
								text9 = text9.Remove(text9.Length - 1, 1);
								text8 = text8 + "{\"uid\":\"" + array2[0].Split('*')[0] + "\",\"name\":\"" + array2[0].Split('*')[1] + "\",\"photos\":[" + text9 + "],\"show\":true},";
							}
						}
						text8 = text8.Remove(text8.Length - 1, 1);
						template = template.Replace("{photos}", text8);
					}
					else
					{
						template = template.Replace("{photos}", "");
					}
					File.WriteAllText(text5 + "\\" + text2 + ".html", template);
					CommonCSharp.UpdateStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Ta\u0323o tha\u0300nh công!"));
					return;
				}
				CommonCSharp.UpdateStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Không co\u0301 uid!"));
			}
			catch
			{
				CommonCSharp.UpdateStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Lô\u0303i ta\u0323o file!"));
			}
		}

		private bool CreateHTML(string uid, string template, string pathFolder = "backup\\")
		{
			bool result = false;
			try
			{
				string text = "";
				text = ((!File.Exists(pathFolder + "\\" + uid + "\\ngaysinh.txt")) ? "||" : File.ReadAllText(pathFolder + "\\" + uid + "\\ngaysinh.txt"));
				if (uid != "")
				{
					string text2 = text.Split('|')[2].Replace("\"", "\\\"").Replace("'", "\\'");
					string text3 = text.Split('|')[1];
					if (text2 == "")
					{
						text2 = "NoName";
					}
					if (text3 == "")
					{
						text3 = "00/00/0000";
					}
					template = template.Replace("{{uid}}", uid).Replace("{{birthday}}", text3).Replace("{{name}}", text2);
					string text4 = pathFolder + "\\" + uid;
					if (Directory.Exists(text4))
					{
						if (File.Exists(text4 + "\\lscomment.txt"))
						{
							string text5 = "";
							List<string> list = File.ReadAllLines(text4 + "\\lscomment.txt").ToList();
							int count = list.Count;
							for (int i = 0; i < count; i++)
							{
								text5 = text5 + "\"" + list[i].Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
							}
							if (text5 != "")
							{
								text5 = text5.Remove(text5.Length - 1, 1);
								template = template.Replace("{comments}", text5);
							}
							else
							{
								template = template.Replace("{comments}", "");
							}
						}
						else
						{
							template = template.Replace("{comments}", "");
						}
						if (File.Exists(text4 + "\\banbeinbox.txt"))
						{
							string text6 = "";
							List<string> list2 = File.ReadAllLines(text4 + "\\banbeinbox.txt").ToList();
							int count2 = list2.Count;
							for (int j = 0; j < count2; j++)
							{
								text6 = text6 + "\"" + list2[j].Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
							}
							if (text6 != "")
							{
								text6 = text6.Remove(text6.Length - 1, 1);
								template = template.Replace("{messages}", text6);
							}
							else
							{
								template = template.Replace("{messages}", "");
							}
						}
						else
						{
							template = template.Replace("{messages}", "");
						}
						if (File.Exists(text4 + "\\" + uid + ".txt"))
						{
							string text7 = "";
							string text8 = "";
							string text9 = File.ReadAllText(text4 + "\\" + uid + ".txt");
							string[] array = text9.Split(new string[1] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
							for (int k = 0; k < array.Length; k++)
							{
								string[] array2 = array[k].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
								if (array2.Length != 0)
								{
									text8 = "";
									for (int l = 0; l < array2.Length; l++)
									{
										string[] array3 = array2[l].Split('*');
										text8 = text8 + "\"" + array3[2].Split('|')[0] + "\",";
									}
									text8 = text8.Remove(text8.Length - 1, 1);
									text7 = text7 + "{\"uid\":\"" + array2[0].Split('*')[0] + "\",\"name\":\"" + array2[0].Split('*')[1] + "\",\"photos\":[" + text8 + "],\"show\":true},";
								}
							}
							text7 = text7.Remove(text7.Length - 1, 1);
							template = template.Replace("{photos}", text7);
						}
						else
						{
							template = template.Replace("{photos}", "");
						}
						File.WriteAllText(text4 + "\\" + uid + ".html", template);
						result = true;
						return result;
					}
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		private void mơFileHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			new Thread((ThreadStart)delegate
			{
				try
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									try
									{
										string statusDataGridView = CommonCSharp.GetStatusDataGridView(dtgvAcc, row, "cCookies");
										string text = CommonCSharp.GetStatusDataGridView(dtgvAcc, row, "cUid");
										if (text == "")
										{
											text = Regex.Match(statusDataGridView, "c_user=(.*?);").Groups[1].Value;
										}
										if (File.Exists("backup\\" + text + "\\" + text + ".html"))
										{
											Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\backup\\" + text + "\\" + text + ".html");
										}
										else
										{
											CommonCSharp.UpdateStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Chưa tạo html!"));
										}
										Interlocked.Decrement(ref iThread);
									}
									catch (Exception ex2)
									{
										CommonCSharp.ExportError(null, ex2.ToString());
									}
								}).Start();
							}
							else
							{
								CommonCSharp.DelayTime(1.0);
							}
						}
						else
						{
							num++;
						}
					}
					while (iThread > 0)
					{
						CommonCSharp.DelayTime(1.0);
					}
				}
				catch (Exception ex)
				{
					CommonCSharp.ExportError(null, ex.ToString());
				}
			}).Start();
		}

		private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fSelectFolder());
			string pathFolder = fSelectFolder.pathFolder;
			if (pathFolder == "")
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				try
				{
					if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						continue;
					}
					string text = dtgvAcc.Rows[i].Cells["cUid"].Value.ToString();
					try
					{
						if (File.Exists(FileHelper.GetPathToCurrentFolder() + "\\backup\\" + text + "\\" + text + ".html"))
						{
							File.Copy("backup\\" + text + "\\" + text + ".html", pathFolder + "\\" + text + ".html");
							num++;
						}
					}
					catch
					{
					}
				}
				catch
				{
				}
			}
			MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Copy thành công {0} tệp backup html!"), num));
		}

		private void thưMụcToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyFolder(ConfigHelper.GetPathBackup());
		}

		private void dtgvAcc_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			List<string> list = new List<string> { "cStt", "cFriend", "cGroup", "cFollow" };
			if (list.Contains(e.Column.Name))
			{
				e.SortResult = int.Parse((e.CellValue1.ToString() == "") ? "-1" : e.CellValue1.ToString()).CompareTo(int.Parse((e.CellValue2.ToString() == "") ? "-1" : e.CellValue2.ToString()));
				e.Handled = true;
			}
			else
			{
				e.SortResult = ((e.CellValue1.ToString() == "") ? "" : e.CellValue1.ToString()).CompareTo((e.CellValue2.ToString() == "") ? "" : e.CellValue2.ToString());
				e.Handled = true;
			}
		}

		private void câuHinhHiênThiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fullString = new JSON_Settings("configDatagridview").GetFullString();
			MCommon.Common.ShowForm(new fCauHinhHienThi());
			if (fullString != new JSON_Settings("configDatagridview").GetFullString())
			{
				LoadConfigManHinh();
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
		}

		private void useragentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Useragent");
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (CountChooseRowInDatagridview() == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n như\u0303ng ta\u0300i khoa\u0309n muô\u0301n nhâ\u0323p Proxy!"), 3);
			}
			else
			{
				MCommon.Common.ShowForm(new fImportProxy());
			}
		}

		private void checkProxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								CheckProxy(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private void CheckProxy(int row)
		{
			try
			{
				string text = dtgvAcc.Rows[row].Cells["cProxy"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, "Proxy trô\u0301ng!");
					return;
				}
				int typeProxy = 0;
				if (text.EndsWith("*1"))
				{
					typeProxy = 1;
				}
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
				int num = 0;
				int num2 = 0;
				string text2 = "";
				bool flag = false;
				for (int i = 0; i < 10; i++)
				{
					text2 = MCommon.Common.CheckProxy(text, typeProxy);
					if (text2 != "")
					{
						num++;
						if (num == 3)
						{
							flag = true;
							break;
						}
					}
					else
					{
						num2++;
						if (num2 == 3)
						{
							break;
						}
					}
				}
				if (!flag)
				{
					SetStatusAccount(row, "Proxy Die!");
				}
				else
				{
					SetStatusAccount(row, "Proxy Live!");
				}
			}
			catch
			{
				SetStatusAccount(row, "Lỗi!");
			}
		}

		private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Proxy");
		}

		private void useragentToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("useragent");
		}

		private void proxyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("proxy");
		}

		private void mởThưMụcBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			isStop = false;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (isStop)
				{
					break;
				}
				if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				string text = "backup\\" + GetCellAccount(i, "cUid");
				if (Directory.Exists(text))
				{
					try
					{
						Process.Start(text);
						SetStatusAccount(i, Language.GetValue("Mở thành công!"));
					}
					catch
					{
						SetStatusAccount(i, Language.GetValue("Mở thất bại!"));
					}
				}
				else
				{
					SetStatusAccount(i, Language.GetValue("Chưa backup!"));
				}
			}
		}

		private void ghiChuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Notes");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Alt)
			{
				try
				{
					Process.Start(Path.GetDirectoryName(Application.ExecutablePath));
				}
				catch
				{
				}
			}
		}

		private void ngàySinhToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Birthday");
		}

		private void cbbTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isExcute_CbbTinhTrang_SelectedIndexChanged || cbbTinhTrang.SelectedValue == null || !StringHelper.CheckStringIsNumber(cbbTinhTrang.SelectedValue.ToString()) || (cbbTinhTrang.SelectedValue.ToString() != "-1" && indexCbbTinhTrangOld == cbbTinhTrang.SelectedIndex))
			{
				return;
			}
			string text = cbbThuMuc.SelectedValue.ToString();
			string text2 = text;
			if (!(text2 == "-1"))
			{
				if (!(text2 == "999999"))
				{
					LoadAccountFromFile(GetIdFile(), cbbTinhTrang.Text);
				}
				else
				{
					LoadAccountFromFile(fChonThuMuc.lstChooseIdFiles, cbbTinhTrang.Text);
				}
			}
			else
			{
				LoadAccountFromFile(null, cbbTinhTrang.Text);
			}
			indexCbbTinhTrangOld = cbbTinhTrang.SelectedIndex;
		}

		private bool CreateShortcutChrome(string profilePath, string nameShortcut)
		{
			try
			{
				nameShortcut = MCommon.Common.ConvertToUnSign(nameShortcut);
				if (profilePath.StartsWith("profiles\\"))
				{
					profilePath = Application.StartupPath + "\\" + profilePath;
				}
				string path = Application.StartupPath + "\\images\\chrome.ico";
				if (!File.Exists(path))
				{
					using FileStream outputStream = new FileStream(path, FileMode.Create);
					Resources.chrome.Save(outputStream);
				}
				if (MCommon.Common.CreateShortcutChrome(nameShortcut, setting_InteractGeneral.GetValue("txtPathShortcut"), profilePath, path, setting_InteractGeneral.GetValue("txtPathChromeOrigin")))
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void giưLaiProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteAccount(isDeleteProfile: false);
		}

		private void kiểmTraMailpassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(4);
		}

		private void đăngNhậpTrìnhDuyệtMớiToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void loginHotmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoginMail();
		}

		private void LoginMail()
		{
			LoadSetting();
			List<int> lstPossition = new List<int>();
			for (int i = 0; i < CountChooseRowInDatagridview(); i++)
			{
				lstPossition.Add(0);
			}
			lstThread = new List<Thread>();
			new Thread((ThreadStart)delegate
			{
				try
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							int row = num++;
							Thread thread = new Thread((ThreadStart)delegate
							{
								int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
								LoginMailOneThread(row, indexOfPossitionApp);
							})
							{
								Name = row.ToString()
							};
							lstThread.Add(thread);
							thread.Start();
						}
						else
						{
							num++;
						}
					}
				}
				catch (Exception ex)
				{
					MCommon.Common.ExportError(null, ex, "LoginHotmail()");
				}
			}).Start();
		}

		private void LoginMailOneThread(int indexRow, int indexPos)
		{
			Chrome chrome = null;
			string cellAccount = GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cPassMail");
			try
			{
				SetStatusAccount(indexRow, Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
				Point pointFromIndexPosition = MCommon.Common.GetPointFromIndexPosition(indexPos, 5, 2);
				Point sizeChrome = MCommon.Common.GetSizeChrome(5, 2);
				bool flag = false;
				try
				{
					chrome = new Chrome
					{
						DisableImage = false,
						Size = sizeChrome,
						Position = pointFromIndexPosition,
						TimeWaitForSearchingElement = 3,
						TimeWaitForLoadingPage = 60
					};
					if (setting_general.GetValueInt("typeBrowser") != 0)
					{
						chrome.LinkToOtherBrowser = setting_general.GetValue("txtLinkToOtherBrowser");
					}
					if (!chrome.Open())
					{
						SetStatusAccount(indexRow, Language.GetValue("Lỗi mở trình duyệt!"));
						return;
					}
					SetStatusAccount(indexRow, Language.GetValue("Đang đăng nhâ\u0323p..."));
					if (cellAccount.Contains("hotmail") || cellAccount.Contains("outlook"))
					{
						chrome.GotoURL("https://login.live.com/login.srf");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("[name=\"loginfmt\"]", 10.0) == 1)
						{
							chrome.SendKeys(2, "loginfmt", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(1, "idSIButton9");
							if (chrome.CheckExistElement("[name=\"passwd\"]", 10.0) == 1)
							{
								chrome.DelayTime(2.0);
								chrome.SendKeys(2, "passwd", cellAccount2);
								chrome.DelayTime(2.0);
								chrome.Click(1, "idSIButton9", 0, 0, "", 0, 10);
								for (int i = 0; i < 10; chrome.DelayTime(1.0), i++)
								{
									switch (chrome.CheckExistElements(0.0, "[name=\"DontShowAgain\"]", "#O365_MainLink_NavMenu"))
									{
									default:
										switch (chrome.CheckExistElements(0.0, "#idA_IL_ForgotPassword0", "[name=\"passwd\"]"))
										{
										case 2:
											SetStatusAccount(indexRow, Language.GetValue("Không có pass mail!"));
											return;
										case 1:
											SetStatusAccount(indexRow, Language.GetValue("Mail sai pass!"));
											return;
										}
										if (chrome.GetURL().Contains("https://account.live.com/Abuse"))
										{
											SetStatusAccount(indexRow, Language.GetValue("Mail đã bị khóa!"));
											return;
										}
										continue;
									case 1:
										chrome.Click(2, "DontShowAgain");
										chrome.DelayTime(0.1);
										chrome.Click(1, "idSIButton9");
										break;
									case 2:
										break;
									}
									break;
								}
								if (!chrome.GetURL().StartsWith("https://outlook.live.com"))
								{
									chrome.GotoURL("https://outlook.live.com/mail/0/");
								}
								flag = true;
							}
						}
					}
					else if (cellAccount.Contains("yandex"))
					{
						chrome.GotoURL("https://passport.yandex.com/auth?from=mail&origin=hostroot_homer_auth_com&retpath=https%3A%2F%2Fmail.yandex.com%2F&backpath=https%3A%2F%2Fmail.yandex.com%3Fnoretpath%3D1");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("#passp-field-login", 10.0) == 1)
						{
							chrome.SendKeys(1, "passp-field-login", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(4, ".Button2_type_submit");
							if (chrome.CheckExistElement("#passp-field-passwd", 10.0) == 1)
							{
								chrome.SendKeys(1, "passp-field-passwd", cellAccount2);
								chrome.DelayTime(0.1);
								chrome.Click(4, ".Button2_type_submit");
								while (true)
								{
									switch (chrome.CheckExistElements(10.0, ".mail-ComposeButton", ".Textinput-Hint_state_error", "[data-t=\"phone_skip\"]"))
									{
									case 3:
										goto IL_0566;
									case 1:
										flag = true;
										break;
									}
									break;
									IL_0566:
									chrome.DelayTime(1.0);
									chrome.Click(4, "[data-t=\"phone_skip\"]");
									chrome.DelayTime(2.0);
								}
							}
						}
					}
					else
					{
						chrome.GotoURL("https://outlook.office.com/mail/inbox");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("[name=\"loginfmt\"]", 10.0) == 1)
						{
							chrome.SendKeys(2, "loginfmt", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(1, "idSIButton9");
							if (chrome.CheckExistElement("[name=\"passwd\"]", 10.0) == 1)
							{
								chrome.SendKeys(2, "passwd", cellAccount2);
								chrome.DelayTime(2.0);
								chrome.Click(1, "idSIButton9", 0, 0, "", 0, 10);
								int num = chrome.CheckExistElements(10.0, "[name=\"DontShowAgain\"]", "#O365_MainLink_NavMenu");
								int num2 = num;
								int num3 = num2;
								if (num3 == 1)
								{
									chrome.Click(2, "DontShowAgain");
									chrome.DelayTime(0.1);
									chrome.Click(1, "idSIButton9");
								}
								chrome.GotoURLIfNotExist("https://outlook.office.com/mail/inbox");
								flag = true;
							}
						}
					}
					if (flag)
					{
						SetStatusAccount(indexRow, Language.GetValue("Đăng nhâ\u0323p thành công!"));
					}
				}
				catch (Exception ex)
				{
					SetStatusAccount(indexRow, Language.GetValue("Lô\u0303i đăng nhâ\u0323p!"));
					MCommon.Common.ExportError(chrome, ex, "Login Error!");
				}
			}
			catch (Exception ex2)
			{
				SetStatusAccount(indexRow, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				MCommon.Common.ExportError(chrome, ex2);
			}
		}

		private void RandomThuTuTaiKhoan(int soLuot = 1)
		{
			try
			{
				for (int i = 0; i < soLuot; i++)
				{
					if (dtgvAcc.RowCount <= 1)
					{
						continue;
					}
					List<DataGridViewRow> list = new List<DataGridViewRow>();
					foreach (DataGridViewRow item in (IEnumerable)dtgvAcc.Rows)
					{
						list.Add(item);
					}
					int num = list.Count;
					while (num > 1)
					{
						num--;
						int index = Base.rd.Next(num + 1);
						DataGridViewRow value = list[index];
						list[index] = list[num];
						list[num] = value;
					}
					dtgvAcc.Rows.Clear();
					foreach (DataGridViewRow item2 in list)
					{
						dtgvAcc.Rows.Add(item2);
					}
				}
			}
			catch
			{
			}
		}

		public int CountChooseRowInDatagridview()
		{
			int result = 0;
			try
			{
				result = Convert.ToInt32(lblCountSelect.Text);
			}
			catch
			{
			}
			return result;
		}

		private void xóaDữLiệuBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa dữ liệu backup của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a dữ liệu backup..."));
								DeleteBackup(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteBackup(int row)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
					return;
				}
				string path = "backup\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa dữ liệu backup thành công!"));
					SetCellAccount(row, "cBackup", "");
					CommonSQL.UpdateFieldToAccount(id, "backup", "");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa dữ liệu backup thất bại!"));
			}
		}

		private void checkBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CheckBackup(int row, string backupPath)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				backupPath = backupPath + "\\" + text + "\\" + text + ".txt";
				if (File.Exists(backupPath))
				{
					SetStatusAccount(row, Language.GetValue("Đã backup!"));
					SetCellAccount(row, "cBackup", MCommon.Common.GetDateCreatFile(backupPath));
					CommonSQL.UpdateFieldToAccount(id, "backup", MCommon.Common.GetDateCreatFile(backupPath));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
					SetCellAccount(row, "cBackup", "");
					CommonSQL.UpdateFieldToAccount(id, "backup", "");
				}
			}
			catch
			{
			}
		}

		private void checkInfoUIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(5);
		}

		private void tảiXuốngAvatarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapTokenTrungGian_DownAvatar());
			if (!fNhapTokenTrungGian_DownAvatar.isOK)
			{
				return;
			}
			LoadSetting();
			string token = setting_general.GetValue("token");
			if (!CommonRequest.CheckLiveToken("", token, "", ""))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"), 2);
				return;
			}
			string pathFolder = setting_general.GetValue("pathFolderAvatar");
			if (!Directory.Exists(pathFolder))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại Nơi lưu Avatar!"), 2);
				return;
			}
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								DownloadAvatar(row, token, pathFolder);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private void DownloadAvatar(int row, string token, string pathFolder)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.DownLoadImageByUid(uid, token, pathFolder))
				{
					SetStatusAccount(row, Language.GetValue("Tải xuống thành công!"));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Tải xuống thất bại!"));
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "DownloadAvatar");
				SetStatusAccount(row, Language.GetValue("Tải xuống thất bại!"));
			}
		}

		private void taiKhoanĐaXoaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fBin());
		}

		private void xóaCacheToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa Cache Profile của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a Cache Profile..."));
								DeleteCacheProfile(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteCacheProfile(int row)
		{
			try
			{
				dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					return;
				}
				string text2 = setting_general.GetValue("txbPathProfile") + "\\" + text;
				if (Directory.Exists(text2))
				{
					Directory.Delete(text2 + "\\Default\\Cache", recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa Cache Profile thành công!"));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa Cache Profile thất bại!"));
			}
		}

		private void lọcTrùngDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchLocTrung());
		}

		private void xửLýChuỗiOnlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "http://app.minsoftware.vn/textfree.html");
			}
			catch
			{
				Process.Start("http://app.minsoftware.vn/textfree.html");
			}
		}

		private void checkHotmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchCheckImapHotmail());
		}

		private void dtgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
				CountCheckedAccount();
			}
			catch
			{
			}
		}

		private void quảnLýThưMụcToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void metroButton2_Click_1(object sender, EventArgs e)
		{
			List<string> idFile = GetIdFile();
			if (idFile != null && idFile.Count == 1)
			{
				fEditFile fEditFile2 = new fEditFile(idFile[0], cbbThuMuc.Text);
				fEditFile2.ShowInTaskbar = false;
				fEditFile2.ShowDialog();
				int selectedIndex = cbbThuMuc.SelectedIndex;
				if (fEditFile2.isSuccess)
				{
					LoadCbbThuMuc();
					indexCbbThuMucOld = -1;
					cbbThuMuc.SelectedIndex = selectedIndex;
				}
			}
		}

		private void checkProxyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchCheckProxy());
		}

		private void sửDụngCookieTrungGianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapCookieTrungGian());
			if (fNhapCookieTrungGian.isOK)
			{
				CapNhatThongTin(4);
			}
		}

		private void lToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fLocTheoDanhSachUid());
			if (fLocTheoDanhSachUid.lstUID.Count > 0)
			{
				List<string> lstUid = MCommon.Common.CloneList(fLocTheoDanhSachUid.lstUID);
				DataTable accFromUid = CommonSQL.GetAccFromUid(lstUid);
				dtgvAcc.Rows.Clear();
				LoadDtgvAccFromDatatable(accFromUid);
			}
		}

		private void càiĐặtToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhTuongTac());
		}

		public void SetStatusAccount(int indexRow, string value, Device device = null)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", value);
			if (device != null)
			{
				if (value.StartsWith("("))
				{
					value = value.Substring(value.IndexOf(")") + 1);
				}
				device.LoadHanhDongLD(value);
			}
		}

		public void SetInfoAccount(string id, int indexRow, string value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cInfo", value);
			SetRowColor(indexRow);
			CommonSQL.UpdateFieldToAccount(id, "info", value);
		}

		public void SetCellAccount(int indexRow, string column, object value, bool isAllowEmptyValue = true)
		{
			if (isAllowEmptyValue || !(value.ToString().Trim() == ""))
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
			}
		}

		public void SetCellAccount(int indexRow, int column, object value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
		}

		public string GetStatusAccount(int indexRow)
		{
			string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, "cStatus");
			if (statusDataGridView.StartsWith("("))
			{
				return statusDataGridView.Substring(statusDataGridView.IndexOf(')') + 1).Trim();
			}
			return statusDataGridView;
		}

		public string GetInfoAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, "cInfo");
		}

		public string GetCellAccount(int indexRow, string column)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, column);
		}

		public string GetCellAccount(int indexRow, int column)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, column);
		}

		private void SetRowColor(int indexRow = -1)
		{
			LoadSetting();
			if (setting_general.GetValueInt("typePhanBietMau") == 0)
			{
				if (indexRow == -1)
				{
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						string infoAccount = GetInfoAccount(i);
						if (infoAccount == "Live")
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
						}
						else if (infoAccount.Contains("Die") || infoAccount.Contains(Language.GetValue("Checkpoint")) || infoAccount.Contains("Changed pass"))
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
						}
					}
				}
				else
				{
					string infoAccount2 = GetInfoAccount(indexRow);
					if (infoAccount2 == "Live")
					{
						dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
					}
					else if (infoAccount2.Contains("Die") || infoAccount2.Contains(Language.GetValue("Checkpoint")) || infoAccount2.Contains("Changed pass"))
					{
						dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
					}
				}
			}
			else if (indexRow == -1)
			{
				for (int j = 0; j < dtgvAcc.RowCount; j++)
				{
					string infoAccount3 = GetInfoAccount(j);
					if (infoAccount3 == "Live")
					{
						dtgvAcc.Rows[j].DefaultCellStyle.ForeColor = Color.Green;
					}
					else if (infoAccount3.Contains("Die") || infoAccount3.Contains(Language.GetValue("Checkpoint")) || infoAccount3.Contains("Changed pass"))
					{
						dtgvAcc.Rows[j].DefaultCellStyle.ForeColor = Color.Red;
					}
				}
			}
			else
			{
				string infoAccount4 = GetInfoAccount(indexRow);
				if (infoAccount4 == "Live")
				{
					dtgvAcc.Rows[indexRow].DefaultCellStyle.ForeColor = Color.Green;
				}
				else if (infoAccount4.Contains("Die") || infoAccount4.Contains(Language.GetValue("Checkpoint")) || infoAccount4.Contains("Changed pass"))
				{
					dtgvAcc.Rows[indexRow].DefaultCellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void SetRowColor(int indexRow, int typeColor)
		{
			switch (typeColor)
			{
			case 2:
				dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				break;
			case 1:
				dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
				break;
			}
		}

		private void LoadConfigManHinh()
		{
			setting_ShowDtgv = new JSON_Settings("configDatagridview");
			dtgvAcc.Columns["cToken"].Visible = setting_ShowDtgv.GetValueBool("cToken");
			dtgvAcc.Columns["cCookies"].Visible = setting_ShowDtgv.GetValueBool("ckbCookie");
			dtgvAcc.Columns["cEmail"].Visible = setting_ShowDtgv.GetValueBool("ckbEmail");
			dtgvAcc.Columns["cName"].Visible = setting_ShowDtgv.GetValueBool("ckbTen");
			dtgvAcc.Columns["cFriend"].Visible = setting_ShowDtgv.GetValueBool("ckbBanBe");
			dtgvAcc.Columns["cGroup"].Visible = setting_ShowDtgv.GetValueBool("ckbNhom");
			dtgvAcc.Columns["cBirthday"].Visible = setting_ShowDtgv.GetValueBool("ckbNgaySinh");
			dtgvAcc.Columns["cGender"].Visible = setting_ShowDtgv.GetValueBool("ckbGioiTinh");
			dtgvAcc.Columns["cPassword"].Visible = setting_ShowDtgv.GetValueBool("ckbMatKhau");
			dtgvAcc.Columns["cPassMail"].Visible = setting_ShowDtgv.GetValueBool("ckbMatKhauMail");
			dtgvAcc.Columns["cBackup"].Visible = setting_ShowDtgv.GetValueBool("ckbBackup");
			dtgvAcc.Columns["cFa2"].Visible = setting_ShowDtgv.GetValueBool("ckbMa2FA");
			dtgvAcc.Columns["cUseragent"].Visible = setting_ShowDtgv.GetValueBool("ckbUseragent");
			dtgvAcc.Columns["cProxy"].Visible = setting_ShowDtgv.GetValueBool("ckbProxy");
			dtgvAcc.Columns["cDateCreateAcc"].Visible = setting_ShowDtgv.GetValueBool("ckbNgayTao");
			dtgvAcc.Columns["cAvatar"].Visible = setting_ShowDtgv.GetValueBool("ckbAvatar");
			dtgvAcc.Columns["cProfile"].Visible = setting_ShowDtgv.GetValueBool("ckbProfile");
			dtgvAcc.Columns["cInfo"].Visible = setting_ShowDtgv.GetValueBool("ckbTinhTrang");
			dtgvAcc.Columns["cThuMuc"].Visible = setting_ShowDtgv.GetValueBool("ckbThuMuc");
			dtgvAcc.Columns["cGhiChu"].Visible = setting_ShowDtgv.GetValueBool("ckbGhiChu");
			dtgvAcc.Columns["cFollow"].Visible = setting_ShowDtgv.GetValueBool("ckbFollow");
			dtgvAcc.Columns["cInteractEnd"].Visible = setting_ShowDtgv.GetValueBool("ckbInteractEnd");
			dtgvAcc.Columns["cDevice"].Visible = setting_ShowDtgv.GetValueBool("ckbDevice");
		}

		private void dtgvAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (isCountCheckAccountWhenChayTuongTac && e.ColumnIndex == 0)
			{
				CountCheckedAccount();
			}
		}

		private void CopyFolder(string sourceFolder)
		{
			MCommon.Common.ShowForm(new fSelectFolder());
			string pathFolder = fSelectFolder.pathFolder;
			if (pathFolder == "")
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				try
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						string cellAccount = GetCellAccount(i, "cUid");
						list.Add(sourceFolder + "\\" + cellAccount + "|" + pathFolder + "\\" + cellAccount);
					}
				}
				catch
				{
				}
			}
			if (list.Count > 0)
			{
				MCommon.Common.ShowForm(new fShowProgressBar(list));
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đa\u0303 copy dư\u0303 liê\u0323u xong!"));
			}
		}

		private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fContact());
		}

		private void checkFileBackupLDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.RowCount)
				{
					if (Convert.ToBoolean(GetCellAccount(num, "cChose")))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, "Check profile LD...");
								CheckBackupLD(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void CheckBackupLD(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string path = "profile\\" + cellAccount2;
				if (Directory.Exists(path))
				{
					SetStatusAccount(row, Language.GetValue("Đã backup LD!"));
					SetCellAccount(row, "cProfile", "Yes");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup LD!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "No");
				}
			}
			catch
			{
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fMoLDPlayer());
		}

		private void lấyTokenCookieTừDữLiệuBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			string pathLDPlayer = ConfigHelper.GetPathLDPlayer(1);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.RowCount)
				{
					if (Convert.ToBoolean(GetCellAccount(num, "cChose")))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, "Đang check...");
								GetTokenCookie(row, pathLDPlayer);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void GetTokenCookie(int indexRow, string pathLDPlayer)
		{
			try
			{
				string cellAccount = GetCellAccount(indexRow, "cId");
				GetCellAccount(indexRow, "cUid");
				string cellAccount2 = GetCellAccount(indexRow, "cDevice");
				string text = pathLDPlayer + "\\vms\\leidian" + cellAccount2;
				if (cellAccount2 == "" || !Directory.Exists(text))
				{
					SetStatusAccount(indexRow, "Tài khoản này chưa tạo LD!");
					return;
				}
				SetStatusAccount(indexRow, "Đang lấy token/cookie...");
				string tokenCookieFromLDPlayer = GetTokenCookieFromLDPlayer(text);
				if (tokenCookieFromLDPlayer != "|")
				{
					string text2 = tokenCookieFromLDPlayer.Split('|')[0];
					string text3 = tokenCookieFromLDPlayer.Split('|')[1];
					if (text2 != "")
					{
						SetCellAccount(indexRow, "cToken", text2);
						CommonSQL.UpdateFieldToAccount(cellAccount, "token", text2);
					}
					if (text3 != "")
					{
						SetCellAccount(indexRow, "cCookies", text3);
						CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", text3);
					}
					SetStatusAccount(indexRow, "Đã cập nhật token/cookie!");
					SetRowColor(indexRow, 2);
				}
				else
				{
					SetStatusAccount(indexRow, "Không lấy được token/cookie!");
				}
			}
			catch
			{
				SetStatusAccount(indexRow, "Không lấy được token/cookie!");
			}
		}

		public string GetTokenCookieFromLDPlayer(string pathToLDPlayer)
		{
			string path = Path.Combine(pathToLDPlayer, "data.vmdk");
			string text = "";
			string text2 = "";
			string result = "";
			if (File.Exists(path))
			{
				using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using BufferedStream stream2 = new BufferedStream(stream);
					using StreamReader streamReader = new StreamReader(stream2);
					string text3;
					while ((text3 = streamReader.ReadLine()) != null)
					{
						if (!text3.Contains("access_token\":\""))
						{
							if (text3.Contains("accessToken\":\""))
							{
								string text4 = Regex.Split(text3, "accessToken\":\"")[1].Split('"')[0];
								Console.WriteLine(text4);
								text = text4;
								if (text2 != "" && text != "")
								{
									break;
								}
							}
							else
							{
								if (!text3.Contains("[{\"name\":\"c_user\""))
								{
									continue;
								}
								string json = "[{\"name\":\"c_user\"" + text3.Split(new string[1] { "[{\"name\":\"c_user\"" }, StringSplitOptions.None)[1].Split(']')[0].Replace("\\\"", "\"") + "]";
								JArray jArray = JArray.Parse(json);
								List<string> list = new List<string>();
								foreach (JToken item in jArray)
								{
									list.Add(item["name"]!.ToString() + "=" + item["value"]!.ToString());
								}
								string text5 = string.Join("; ", list);
								text2 = text5;
								if (text2 != "" && text != "")
								{
									break;
								}
							}
							continue;
						}
						string text6 = Regex.Split(text3, "access_token\":\"")[1].Split('"')[0];
						text = text6;
						string json2 = Regex.Split(text3, "session_cookie_string\":\"")[1].Split(']')[0].Replace("\\\"", "\"") + "]";
						JArray jArray2 = JArray.Parse(json2);
						List<string> list2 = new List<string>();
						foreach (JToken item2 in jArray2)
						{
							list2.Add(item2["name"]!.ToString() + "=" + item2["value"]!.ToString());
						}
						string text7 = string.Join("; ", list2);
						text2 = text7;
						break;
					}
				}
				result = text + "|" + text2;
			}
			return result;
		}

		private void xóaLDPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				LoadSetting();
				string pathLD = ConfigHelper.GetPathLDPlayer(1);
				if (pathLD == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer trống!"), 3);
					return;
				}
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				cControl("start");
				int iThread = 0;
				int maxThread = setting_general.GetValueInt("nudHideThread", 10);
				isStop = false;
				new Thread((ThreadStart)delegate
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang check..."));
									DeleteDeviceOneThread(row, pathLD);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					cControl("stop");
				}).Start();
			}
			catch
			{
			}
		}

		private void DeleteDeviceOneThread(int indexRow, string pathLD)
		{
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cDevice");
			if (cellAccount2 != "" && Directory.Exists(pathLD + "\\vms\\leidian" + cellAccount2))
			{
				try
				{
					SetStatusAccount(indexRow, Language.GetValue("Đang xo\u0301a LDPlayer..."));
					Directory.Delete(pathLD + "\\vms\\leidian" + cellAccount2, recursive: true);
					SetCellAccount(indexRow, "cDevice", "");
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "device", "");
					SetStatusAccount(indexRow, Language.GetValue("Xóa LDPlayer thành công!"));
				}
				catch
				{
					SetStatusAccount(indexRow, Language.GetValue("Xóa LDPlayer thất bại!"));
				}
			}
			else
			{
				SetStatusAccount(indexRow, Language.GetValue("Chưa tạo LDPlayer!"));
			}
		}

		private void dọnDẹpLDPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fClearLDPlayer());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(ex.ToString(), 3);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fUpAvatar().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void btnPost_Click_2(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fDangBai().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fDangStory().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fDoiThongTin().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void OpenFormViewChrome()
		{
			bool flag = false;
			FormCollection openForms = Application.OpenForms;
			foreach (Form item in openForms)
			{
				if (item.Name == "fInterfaceChrome")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				new fViewChrome().Show();
			}
		}

		private void CloseFormViewChrome()
		{
			FormCollection openForms = Application.OpenForms;
			foreach (Form frm in openForms)
			{
				if (frm.Name == "fInterfaceChrome")
				{
					frm.Invoke((MethodInvoker)delegate
					{
						frm.Close();
					});
					break;
				}
			}
		}

		private void btnInteract_Chrome_Click(object sender, EventArgs e)
		{
		}

		private void tiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void btnRandomIndexRow_Click(object sender, EventArgs e)
		{
			RandomThuTuTaiKhoan();
		}

		private void mã2FAToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			OpenFormUpdate("2FA");
		}

		private void fAToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyRowDatagrid("2fa");
		}

		private void maBaoMât6SôToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyRowDatagrid("ma2fa");
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|pass|2fa");
		}

		private void checkInfoUIDToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(5);
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fMain));
			dtgvAcc = new System.Windows.Forms.DataGridView();
			cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cCookies = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFollow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFriend = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cMailRecovery = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cUseragent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDateCreateAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cThuMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cInteractEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ctmsAcc = new MetroFramework.Controls.MetroContextMenu(components);
			chọnLiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tinhTrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			trạngTháiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bỏChọnTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			fAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			maBaoMât6SôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			uidPass2FaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			proxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			xóaTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkInfoUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mailKhôiPhụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mậtKhẩuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			mã2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cookieToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			useragentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ghiChuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chuyểnThưMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chứcNăngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			locTrungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tảiLạiDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			taiKhoanĐaXoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tiệnÍchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			lọcTrùngDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xửLýChuỗiOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			grQuanLyThuMuc = new System.Windows.Forms.GroupBox();
			btnLoadAcc = new MetroFramework.Controls.MetroButton();
			btnEditFile = new MetroFramework.Controls.MetroButton();
			btnDeleteFile = new MetroFramework.Controls.MetroButton();
			AddFileAccount = new MetroFramework.Controls.MetroButton();
			cbbTinhTrang = new MetroFramework.Controls.MetroComboBox();
			cbbThuMuc = new MetroFramework.Controls.MetroComboBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			BtnSearch = new MetroFramework.Controls.MetroButton();
			cbbSearch = new System.Windows.Forms.ComboBox();
			txbSearch = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			lblKey = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
			txbUid = new System.Windows.Forms.ToolStripStatusLabel();
			lblUser = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
			lblDateExpried = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnPause = new System.Windows.Forms.Button();
			btnInteract = new System.Windows.Forms.Button();
			btnPost = new System.Windows.Forms.Button();
			plTrangThai = new System.Windows.Forms.Panel();
			lblTrangThai = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			plChucNang = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			btnRandomIndexRow = new MetroFramework.Controls.MetroButton();
			grTimKiem = new System.Windows.Forms.GroupBox();
			button7 = new System.Windows.Forms.Button();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
			ctmsAcc.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			menuStrip1.SuspendLayout();
			grQuanLyThuMuc.SuspendLayout();
			statusStrip1.SuspendLayout();
			plTrangThai.SuspendLayout();
			panel1.SuspendLayout();
			plChucNang.SuspendLayout();
			grTimKiem.SuspendLayout();
			SuspendLayout();
			dtgvAcc.AllowUserToAddRows = false;
			dtgvAcc.AllowUserToDeleteRows = false;
			dtgvAcc.AllowUserToResizeRows = false;
			dtgvAcc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			dtgvAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvAcc.Columns.AddRange(cChose, cStt, cId, cUid, cToken, cCookies, cEmail, cPhone, cName, cFollow, cFriend, cGroup, cBirthday, cGender, cPassword, cMailRecovery, cPassMail, cBackup, cFa2, cUseragent, cProxy, cDateCreateAcc, cAvatar, cProfile, cThuMuc, cInteractEnd, cDevice, cInfo, cGhiChu, cStatus);
			dtgvAcc.ContextMenuStrip = ctmsAcc;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dtgvAcc.DefaultCellStyle = dataGridViewCellStyle2;
			dtgvAcc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvAcc.Location = new System.Drawing.Point(5, 161);
			dtgvAcc.Name = "dtgvAcc";
			dtgvAcc.RowHeadersVisible = false;
			dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvAcc.Size = new System.Drawing.Size(1224, 500);
			dtgvAcc.TabIndex = 0;
			dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(DtgvAcc_CellClick);
			dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
			dtgvAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellValueChanged);
			dtgvAcc.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(dtgvAcc_SortCompare);
			dtgvAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(DtgvAcc_KeyDown);
			cChose.HeaderText = "Chọn";
			cChose.Name = "cChose";
			cChose.Width = 40;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cStt.DefaultCellStyle = dataGridViewCellStyle3;
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.Width = 35;
			cId.HeaderText = "Id";
			cId.Name = "cId";
			cId.Visible = false;
			cId.Width = 90;
			cUid.HeaderText = "UID";
			cUid.Name = "cUid";
			cUid.Width = 80;
			cToken.HeaderText = "Token";
			cToken.Name = "cToken";
			cToken.Visible = false;
			cToken.Width = 70;
			cCookies.HeaderText = "Cookie";
			cCookies.Name = "cCookies";
			cCookies.Width = 70;
			cEmail.HeaderText = "User";
			cEmail.Name = "cEmail";
			cEmail.Width = 60;
			cPhone.HeaderText = "Phone";
			cPhone.Name = "cPhone";
			cPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cPhone.Visible = false;
			cPhone.Width = 90;
			cName.HeaderText = "Tên";
			cName.Name = "cName";
			cName.Width = 70;
			cFollow.HeaderText = "Followers";
			cFollow.Name = "cFollow";
			cFollow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			cFollow.Visible = false;
			cFollow.Width = 80;
			cFriend.HeaderText = "Following";
			cFriend.Name = "cFriend";
			cFriend.Visible = false;
			cFriend.Width = 70;
			cGroup.HeaderText = "Nho\u0301m";
			cGroup.Name = "cGroup";
			cGroup.Visible = false;
			cGroup.Width = 60;
			cBirthday.HeaderText = "Nga\u0300y sinh";
			cBirthday.Name = "cBirthday";
			cBirthday.Visible = false;
			cBirthday.Width = 90;
			cGender.HeaderText = "Giới Tính";
			cGender.Name = "cGender";
			cGender.Visible = false;
			cGender.Width = 80;
			cPassword.HeaderText = "Mật khẩu";
			cPassword.Name = "cPassword";
			cPassword.Width = 70;
			cMailRecovery.HeaderText = "Email khôi phục";
			cMailRecovery.Name = "cMailRecovery";
			cMailRecovery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cMailRecovery.Visible = false;
			cMailRecovery.Width = 120;
			cPassMail.HeaderText = "Mật khẩu mail";
			cPassMail.Name = "cPassMail";
			cPassMail.Visible = false;
			cPassMail.Width = 120;
			cBackup.HeaderText = "Backup";
			cBackup.Name = "cBackup";
			cBackup.Visible = false;
			cBackup.Width = 70;
			cFa2.HeaderText = "Mã 2FA";
			cFa2.Name = "cFa2";
			cFa2.Visible = false;
			cFa2.Width = 65;
			cUseragent.HeaderText = "Useragent";
			cUseragent.Name = "cUseragent";
			cUseragent.Visible = false;
			cUseragent.Width = 70;
			cProxy.HeaderText = "Proxy";
			cProxy.Name = "cProxy";
			cProxy.Visible = false;
			cProxy.Width = 55;
			cDateCreateAcc.HeaderText = "Nga\u0300y ta\u0323o";
			cDateCreateAcc.Name = "cDateCreateAcc";
			cDateCreateAcc.Visible = false;
			cDateCreateAcc.Width = 85;
			cAvatar.HeaderText = "Avatar";
			cAvatar.Name = "cAvatar";
			cAvatar.Visible = false;
			cAvatar.Width = 50;
			cProfile.HeaderText = "Profile";
			cProfile.Name = "cProfile";
			cProfile.Visible = false;
			cProfile.Width = 50;
			cThuMuc.HeaderText = "Thư mục";
			cThuMuc.Name = "cThuMuc";
			cInteractEnd.HeaderText = "Lâ\u0300n tương ta\u0301c cuô\u0301i";
			cInteractEnd.Name = "cInteractEnd";
			cDevice.HeaderText = "LD Index";
			cDevice.Name = "cDevice";
			cDevice.Width = 80;
			cInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			cInfo.HeaderText = "Tình Trạng";
			cInfo.Name = "cInfo";
			cInfo.Width = 90;
			cGhiChu.HeaderText = "Ghi Chú";
			cGhiChu.Name = "cGhiChu";
			cGhiChu.Visible = false;
			cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cStatus.HeaderText = "Trạng Thái";
			cStatus.MinimumWidth = 200;
			cStatus.Name = "cStatus";
			ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { chọnLiveToolStripMenuItem, bỏChọnTấtCảToolStripMenuItem, copyToolStripMenuItem, xóaTàiKhoảnToolStripMenuItem, checkCookieToolStripMenuItem, cậpNhậtDữLiệuToolStripMenuItem, chuyểnThưMụcToolStripMenuItem, chứcNăngToolStripMenuItem1, tảiLạiDanhSáchToolStripMenuItem });
			ctmsAcc.Name = "ctmsAcc";
			ctmsAcc.Size = new System.Drawing.Size(171, 202);
			ctmsAcc.Opening += new System.ComponentModel.CancelEventHandler(CtmsAcc_Opening);
			chọnLiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { tấtCảToolStripMenuItem, liveToolStripMenuItem, tinhTrangToolStripMenuItem, trạngTháiToolStripMenuItem });
			chọnLiveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chọnLiveToolStripMenuItem.Image");
			chọnLiveToolStripMenuItem.Name = "chọnLiveToolStripMenuItem";
			chọnLiveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			chọnLiveToolStripMenuItem.Text = "Chọn";
			tấtCảToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tấtCảToolStripMenuItem.Image");
			tấtCảToolStripMenuItem.Name = "tấtCảToolStripMenuItem";
			tấtCảToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			tấtCảToolStripMenuItem.Text = "Tất cả";
			tấtCảToolStripMenuItem.Click += new System.EventHandler(TấtCảToolStripMenuItem_Click);
			liveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("liveToolStripMenuItem.Image");
			liveToolStripMenuItem.Name = "liveToolStripMenuItem";
			liveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			liveToolStripMenuItem.Text = "Bôi đen";
			liveToolStripMenuItem.Click += new System.EventHandler(LiveToolStripMenuItem_Click);
			tinhTrangToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tinhTrangToolStripMenuItem.Image");
			tinhTrangToolStripMenuItem.Name = "tinhTrangToolStripMenuItem";
			tinhTrangToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			tinhTrangToolStripMenuItem.Text = "Ti\u0300nh tra\u0323ng";
			trạngTháiToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("trạngTháiToolStripMenuItem.Image");
			trạngTháiToolStripMenuItem.Name = "trạngTháiToolStripMenuItem";
			trạngTháiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			trạngTháiToolStripMenuItem.Text = "Trạng thái";
			trạngTháiToolStripMenuItem.Click += new System.EventHandler(trạngTháiToolStripMenuItem_Click);
			bỏChọnTấtCảToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("bỏChọnTấtCảToolStripMenuItem.Image");
			bỏChọnTấtCảToolStripMenuItem.Name = "bỏChọnTấtCảToolStripMenuItem";
			bỏChọnTấtCảToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			bỏChọnTấtCảToolStripMenuItem.Text = "Bỏ chọn tất cả";
			bỏChọnTấtCảToolStripMenuItem.Click += new System.EventHandler(BỏChọnTấtCảToolStripMenuItem_Click);
			copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10] { mailToolStripMenuItem, passToolStripMenuItem, fAToolStripMenuItem, maBaoMât6SôToolStripMenuItem, cookieToolStripMenuItem, uidPassToolStripMenuItem, toolStripMenuItem1, uidPass2FaToolStripMenuItem, uidToolStripMenuItem, proxyToolStripMenuItem1 });
			copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			copyToolStripMenuItem.Text = "Copy";
			mailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailToolStripMenuItem.Image");
			mailToolStripMenuItem.Name = "mailToolStripMenuItem";
			mailToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			mailToolStripMenuItem.Text = "User";
			mailToolStripMenuItem.Click += new System.EventHandler(MailToolStripMenuItem_Click_1);
			passToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passToolStripMenuItem.Image");
			passToolStripMenuItem.Name = "passToolStripMenuItem";
			passToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			passToolStripMenuItem.Text = "Pass";
			passToolStripMenuItem.Click += new System.EventHandler(PassToolStripMenuItem_Click);
			fAToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fAToolStripMenuItem.Image");
			fAToolStripMenuItem.Name = "fAToolStripMenuItem";
			fAToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			fAToolStripMenuItem.Text = "2FA";
			fAToolStripMenuItem.Click += new System.EventHandler(fAToolStripMenuItem_Click_1);
			maBaoMât6SôToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("maBaoMât6SôToolStripMenuItem.Image");
			maBaoMât6SôToolStripMenuItem.Name = "maBaoMât6SôToolStripMenuItem";
			maBaoMât6SôToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			maBaoMât6SôToolStripMenuItem.Text = "Ma\u0303 ba\u0309o mâ\u0323t 6 sô\u0301 từ 2FA";
			maBaoMât6SôToolStripMenuItem.Click += new System.EventHandler(maBaoMât6SôToolStripMenuItem_Click_1);
			cookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cookieToolStripMenuItem.Image");
			cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
			cookieToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			cookieToolStripMenuItem.Text = "Cookie";
			cookieToolStripMenuItem.Click += new System.EventHandler(CookieToolStripMenuItem_Click);
			uidPassToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassToolStripMenuItem.Image");
			uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
			uidPassToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			uidPassToolStripMenuItem.Text = "User|Pass";
			uidPassToolStripMenuItem.Click += new System.EventHandler(UidPassToolStripMenuItem_Click);
			toolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem1.Image");
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
			toolStripMenuItem1.Text = "User|Pass|2Fa";
			toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
			uidPass2FaToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPass2FaToolStripMenuItem.Image");
			uidPass2FaToolStripMenuItem.Name = "uidPass2FaToolStripMenuItem";
			uidPass2FaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			uidPass2FaToolStripMenuItem.Text = "User|Pass|Cookie";
			uidPass2FaToolStripMenuItem.Click += new System.EventHandler(uidPass2FaToolStripMenuItem_Click);
			uidToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidToolStripMenuItem.Image");
			uidToolStripMenuItem.Name = "uidToolStripMenuItem";
			uidToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			uidToolStripMenuItem.Text = "Uid";
			uidToolStripMenuItem.Click += new System.EventHandler(UidToolStripMenuItem_Click);
			proxyToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("proxyToolStripMenuItem1.Image");
			proxyToolStripMenuItem1.Name = "proxyToolStripMenuItem1";
			proxyToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
			proxyToolStripMenuItem1.Text = "Proxy";
			proxyToolStripMenuItem1.Click += new System.EventHandler(proxyToolStripMenuItem1_Click);
			xóaTàiKhoảnToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("xóaTàiKhoảnToolStripMenuItem.Image");
			xóaTàiKhoảnToolStripMenuItem.Name = "xóaTàiKhoảnToolStripMenuItem";
			xóaTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			xóaTàiKhoảnToolStripMenuItem.Text = "Xóa ta\u0300i khoa\u0309n";
			xóaTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(giưLaiProfileToolStripMenuItem_Click);
			checkCookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { checkInfoUIDToolStripMenuItem, checkProxyToolStripMenuItem });
			checkCookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkCookieToolStripMenuItem.Image");
			checkCookieToolStripMenuItem.Name = "checkCookieToolStripMenuItem";
			checkCookieToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			checkCookieToolStripMenuItem.Text = "Kiểm tra tài khoản";
			checkInfoUIDToolStripMenuItem.Name = "checkInfoUIDToolStripMenuItem";
			checkInfoUIDToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			checkInfoUIDToolStripMenuItem.Text = "Check Tên ta\u0300i khoa\u0309n";
			checkInfoUIDToolStripMenuItem.ToolTipText = "Không cần dùng token\r\nCâ\u0323p nhâ\u0323t thông tin: Ho\u0323 tên, Giớ\u0301i ti\u0301nh, [Email], [Ba\u0323n be\u0300], [Nho\u0301m], [Nga\u0300y sinh]";
			checkInfoUIDToolStripMenuItem.Click += new System.EventHandler(checkInfoUIDToolStripMenuItem_Click_1);
			checkProxyToolStripMenuItem.Name = "checkProxyToolStripMenuItem";
			checkProxyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			checkProxyToolStripMenuItem.Text = "Check Proxy";
			checkProxyToolStripMenuItem.Click += new System.EventHandler(checkProxyToolStripMenuItem_Click);
			cậpNhậtDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { mailKhôiPhụcToolStripMenuItem, mậtKhẩuToolStripMenuItem1, mã2FAToolStripMenuItem, cookieToolStripMenuItem3, useragentToolStripMenuItem, proxyToolStripMenuItem, ghiChuToolStripMenuItem });
			cậpNhậtDữLiệuToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cậpNhậtDữLiệuToolStripMenuItem.Image");
			cậpNhậtDữLiệuToolStripMenuItem.Name = "cậpNhậtDữLiệuToolStripMenuItem";
			cậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			cậpNhậtDữLiệuToolStripMenuItem.Text = "Cập nhật dữ liệu";
			mailKhôiPhụcToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailKhôiPhụcToolStripMenuItem.Image");
			mailKhôiPhụcToolStripMenuItem.Name = "mailKhôiPhụcToolStripMenuItem";
			mailKhôiPhụcToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			mailKhôiPhụcToolStripMenuItem.Text = "User";
			mailKhôiPhụcToolStripMenuItem.Click += new System.EventHandler(mailKhôiPhụcToolStripMenuItem_Click);
			mậtKhẩuToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("mậtKhẩuToolStripMenuItem1.Image");
			mậtKhẩuToolStripMenuItem1.Name = "mậtKhẩuToolStripMenuItem1";
			mậtKhẩuToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
			mậtKhẩuToolStripMenuItem1.Text = "Password";
			mậtKhẩuToolStripMenuItem1.Click += new System.EventHandler(mậtKhẩuToolStripMenuItem1_Click);
			mã2FAToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mã2FAToolStripMenuItem.Image");
			mã2FAToolStripMenuItem.Name = "mã2FAToolStripMenuItem";
			mã2FAToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			mã2FAToolStripMenuItem.Text = "Mã 2FA";
			mã2FAToolStripMenuItem.Click += new System.EventHandler(mã2FAToolStripMenuItem_Click_1);
			cookieToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("cookieToolStripMenuItem3.Image");
			cookieToolStripMenuItem3.Name = "cookieToolStripMenuItem3";
			cookieToolStripMenuItem3.Size = new System.Drawing.Size(127, 22);
			cookieToolStripMenuItem3.Text = "Cookie";
			cookieToolStripMenuItem3.Click += new System.EventHandler(NhậpDữLiệuToolStripMenuItem1_Click);
			useragentToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("useragentToolStripMenuItem.Image");
			useragentToolStripMenuItem.Name = "useragentToolStripMenuItem";
			useragentToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			useragentToolStripMenuItem.Text = "Useragent";
			useragentToolStripMenuItem.Click += new System.EventHandler(useragentToolStripMenuItem_Click);
			proxyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("proxyToolStripMenuItem.Image");
			proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
			proxyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			proxyToolStripMenuItem.Text = "Proxy";
			proxyToolStripMenuItem.Click += new System.EventHandler(proxyToolStripMenuItem_Click);
			ghiChuToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_note_48px;
			ghiChuToolStripMenuItem.Name = "ghiChuToolStripMenuItem";
			ghiChuToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			ghiChuToolStripMenuItem.Text = "Ghi chu\u0301";
			ghiChuToolStripMenuItem.Click += new System.EventHandler(ghiChuToolStripMenuItem_Click);
			chuyểnThưMụcToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chuyểnThưMụcToolStripMenuItem.Image");
			chuyểnThưMụcToolStripMenuItem.Name = "chuyểnThưMụcToolStripMenuItem";
			chuyểnThưMụcToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			chuyểnThưMụcToolStripMenuItem.Text = "Chuyển thư mục";
			chứcNăngToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { locTrungToolStripMenuItem, lToolStripMenuItem });
			chứcNăngToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("chứcNăngToolStripMenuItem1.Image");
			chứcNăngToolStripMenuItem1.Name = "chứcNăngToolStripMenuItem1";
			chứcNăngToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
			chứcNăngToolStripMenuItem1.Text = "Chức năng";
			locTrungToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("locTrungToolStripMenuItem.Image");
			locTrungToolStripMenuItem.Name = "locTrungToolStripMenuItem";
			locTrungToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			locTrungToolStripMenuItem.Text = "Lo\u0323c tru\u0300ng ta\u0300i khoa\u0309n";
			locTrungToolStripMenuItem.Click += new System.EventHandler(locTrungToolStripMenuItem_Click);
			lToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_mail_filter_24px1;
			lToolStripMenuItem.Name = "lToolStripMenuItem";
			lToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			lToolStripMenuItem.Text = "Lọc danh sách theo UID";
			lToolStripMenuItem.Click += new System.EventHandler(lToolStripMenuItem_Click);
			tảiLạiDanhSáchToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tảiLạiDanhSáchToolStripMenuItem.Image");
			tảiLạiDanhSáchToolStripMenuItem.Name = "tảiLạiDanhSáchToolStripMenuItem";
			tảiLạiDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			tảiLạiDanhSáchToolStripMenuItem.Text = "Tải lại danh sách";
			tảiLạiDanhSáchToolStripMenuItem.Click += new System.EventHandler(TảiLạiDanhSáchToolStripMenuItem_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = pnlHeader;
			bunifuDragControl1.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1235, 29);
			pnlHeader.TabIndex = 0;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(6, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			pictureBox1.DoubleClick += new System.EventHandler(pictureBox1_DoubleClick);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Dock = System.Windows.Forms.DockStyle.Right;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.Location = new System.Drawing.Point(1139, 0);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(32, 29);
			button2.TabIndex = 0;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Dock = System.Windows.Forms.DockStyle.Right;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(1171, 0);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(32, 29);
			button1.TabIndex = 1;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(1203, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 29);
			btnMinimize.TabIndex = 2;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(43, 6);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(639, 16);
			bunifuCustomLabel1.TabIndex = 3;
			bunifuCustomLabel1.Text = "Max Instagram Pro v2.5.1 - Phần Mềm Quản Lý Va\u0300 Chăm So\u0301c Tài Khoản Intagram - MIN SOFTWARE";
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.RoyalBlue;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1236, 38);
			bunifuCards1.TabIndex = 0;
			menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { hệThốngToolStripMenuItem, càiĐặtToolStripMenuItem, thoátToolStripMenuItem, taiKhoanĐaXoaToolStripMenuItem, tiệnÍchToolStripMenuItem, liênHệToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(1, 37);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			menuStrip1.Size = new System.Drawing.Size(1234, 25);
			menuStrip1.Stretch = false;
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			hệThốngToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_job;
			hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
			hệThốngToolStripMenuItem.Size = new System.Drawing.Size(124, 21);
			hệThốngToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh chung";
			hệThốngToolStripMenuItem.Click += new System.EventHandler(mnuCauHinhChung_Click);
			càiĐặtToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_opposite_opinion;
			càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
			càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(144, 21);
			càiĐặtToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh tương ta\u0301c";
			càiĐặtToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			càiĐặtToolStripMenuItem.Click += new System.EventHandler(càiĐặtToolStripMenuItem_Click_1);
			thoátToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_show_property_48px;
			thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			thoátToolStripMenuItem.Size = new System.Drawing.Size(132, 21);
			thoátToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
			thoátToolStripMenuItem.Click += new System.EventHandler(câuHinhHiênThiToolStripMenuItem_Click);
			taiKhoanĐaXoaToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_delete_bin_21;
			taiKhoanĐaXoaToolStripMenuItem.Name = "taiKhoanĐaXoaToolStripMenuItem";
			taiKhoanĐaXoaToolStripMenuItem.Size = new System.Drawing.Size(134, 21);
			taiKhoanĐaXoaToolStripMenuItem.Text = "Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a";
			taiKhoanĐaXoaToolStripMenuItem.Click += new System.EventHandler(taiKhoanĐaXoaToolStripMenuItem_Click);
			tiệnÍchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { checkProxyToolStripMenuItem1, lọcTrùngDữLiệuToolStripMenuItem, xửLýChuỗiOnlineToolStripMenuItem });
			tiệnÍchToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_circled_menu;
			tiệnÍchToolStripMenuItem.Name = "tiệnÍchToolStripMenuItem";
			tiệnÍchToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
			tiệnÍchToolStripMenuItem.Text = "Tiện ích";
			tiệnÍchToolStripMenuItem.Click += new System.EventHandler(tiệnÍchToolStripMenuItem_Click);
			checkProxyToolStripMenuItem1.Image = maxcare.Properties.Resources.icons8_cloud_firewall_64px1;
			checkProxyToolStripMenuItem1.Name = "checkProxyToolStripMenuItem1";
			checkProxyToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
			checkProxyToolStripMenuItem1.Text = "Check Proxy";
			checkProxyToolStripMenuItem1.Click += new System.EventHandler(checkProxyToolStripMenuItem1_Click);
			lọcTrùngDữLiệuToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_mail_filter_24px;
			lọcTrùngDữLiệuToolStripMenuItem.Name = "lọcTrùngDữLiệuToolStripMenuItem";
			lọcTrùngDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			lọcTrùngDữLiệuToolStripMenuItem.Text = "Lọc trùng dữ liệu";
			lọcTrùngDữLiệuToolStripMenuItem.Click += new System.EventHandler(lọcTrùngDữLiệuToolStripMenuItem_Click);
			xửLýChuỗiOnlineToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_rss;
			xửLýChuỗiOnlineToolStripMenuItem.Name = "xửLýChuỗiOnlineToolStripMenuItem";
			xửLýChuỗiOnlineToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			xửLýChuỗiOnlineToolStripMenuItem.Text = "Xử lý chuỗi cơ bản";
			xửLýChuỗiOnlineToolStripMenuItem.Click += new System.EventHandler(xửLýChuỗiOnlineToolStripMenuItem_Click);
			liênHệToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_safety_float;
			liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
			liênHệToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
			liênHệToolStripMenuItem.Text = "Liên hệ";
			liênHệToolStripMenuItem.Click += new System.EventHandler(liênHệToolStripMenuItem_Click);
			grQuanLyThuMuc.Controls.Add(btnLoadAcc);
			grQuanLyThuMuc.Controls.Add(btnEditFile);
			grQuanLyThuMuc.Controls.Add(btnDeleteFile);
			grQuanLyThuMuc.Controls.Add(AddFileAccount);
			grQuanLyThuMuc.Controls.Add(cbbTinhTrang);
			grQuanLyThuMuc.Controls.Add(cbbThuMuc);
			grQuanLyThuMuc.Controls.Add(label2);
			grQuanLyThuMuc.Controls.Add(label1);
			grQuanLyThuMuc.Controls.Add(button9);
			grQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grQuanLyThuMuc.Location = new System.Drawing.Point(566, 67);
			grQuanLyThuMuc.Name = "grQuanLyThuMuc";
			grQuanLyThuMuc.Size = new System.Drawing.Size(662, 53);
			grQuanLyThuMuc.TabIndex = 5;
			grQuanLyThuMuc.TabStop = false;
			grQuanLyThuMuc.Text = "Quản lý thư mục";
			btnLoadAcc.BackgroundImage = maxcare.Properties.Resources.available_updates_25px;
			btnLoadAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			btnLoadAcc.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLoadAcc.Location = new System.Drawing.Point(498, 19);
			btnLoadAcc.Name = "btnLoadAcc";
			btnLoadAcc.Size = new System.Drawing.Size(25, 25);
			btnLoadAcc.TabIndex = 6;
			toolTip1.SetToolTip(btnLoadAcc, "Load lại danh sách");
			btnLoadAcc.UseSelectable = true;
			btnLoadAcc.Click += new System.EventHandler(BtnLoadAcc_Click);
			btnEditFile.BackColor = System.Drawing.Color.Gray;
			btnEditFile.BackgroundImage = maxcare.Properties.Resources.icons8_edit_24px1;
			btnEditFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnEditFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnEditFile.Enabled = false;
			btnEditFile.Location = new System.Drawing.Point(435, 19);
			btnEditFile.Name = "btnEditFile";
			btnEditFile.Size = new System.Drawing.Size(25, 25);
			btnEditFile.TabIndex = 5;
			toolTip1.SetToolTip(btnEditFile, "Sửa tên thư mục");
			btnEditFile.UseSelectable = true;
			btnEditFile.Click += new System.EventHandler(metroButton2_Click_1);
			btnDeleteFile.BackColor = System.Drawing.Color.Gray;
			btnDeleteFile.BackgroundImage = maxcare.Properties.Resources.icons8_subtract_25px;
			btnDeleteFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnDeleteFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDeleteFile.Enabled = false;
			btnDeleteFile.Location = new System.Drawing.Point(466, 19);
			btnDeleteFile.Name = "btnDeleteFile";
			btnDeleteFile.Size = new System.Drawing.Size(25, 25);
			btnDeleteFile.TabIndex = 5;
			toolTip1.SetToolTip(btnDeleteFile, "Xóa thư mục");
			btnDeleteFile.UseSelectable = true;
			btnDeleteFile.Click += new System.EventHandler(BtnDeleteFile_Click);
			AddFileAccount.BackgroundImage = maxcare.Properties.Resources.icons8_plus_math_25px1;
			AddFileAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			AddFileAccount.Cursor = System.Windows.Forms.Cursors.Hand;
			AddFileAccount.Location = new System.Drawing.Point(404, 19);
			AddFileAccount.Name = "AddFileAccount";
			AddFileAccount.Size = new System.Drawing.Size(25, 25);
			AddFileAccount.TabIndex = 4;
			toolTip1.SetToolTip(AddFileAccount, "Thêm thư mục");
			AddFileAccount.UseSelectable = true;
			AddFileAccount.Click += new System.EventHandler(AddFileAccount_Click_1);
			cbbTinhTrang.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTinhTrang.DropDownWidth = 300;
			cbbTinhTrang.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbTinhTrang.FormattingEnabled = true;
			cbbTinhTrang.ItemHeight = 19;
			cbbTinhTrang.Items.AddRange(new object[1] { "[Tất cả tình trạng]" });
			cbbTinhTrang.Location = new System.Drawing.Point(277, 19);
			cbbTinhTrang.Name = "cbbTinhTrang";
			cbbTinhTrang.Size = new System.Drawing.Size(121, 25);
			cbbTinhTrang.TabIndex = 3;
			cbbTinhTrang.UseSelectable = true;
			cbbTinhTrang.SelectedIndexChanged += new System.EventHandler(cbbTinhTrang_SelectedIndexChanged);
			cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbThuMuc.DropDownWidth = 350;
			cbbThuMuc.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbThuMuc.FormattingEnabled = true;
			cbbThuMuc.ItemHeight = 19;
			cbbThuMuc.Location = new System.Drawing.Point(72, 19);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(167, 25);
			cbbThuMuc.TabIndex = 1;
			cbbThuMuc.UseSelectable = true;
			cbbThuMuc.SelectedIndexChanged += new System.EventHandler(CbbThuMuc_SelectedIndexChanged);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(241, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 16);
			label2.TabIndex = 2;
			label2.Text = "Lọc:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(8, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 16);
			label1.TabIndex = 0;
			label1.Text = "Thư mục:";
			button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button9.BackColor = System.Drawing.Color.White;
			button9.Cursor = System.Windows.Forms.Cursors.Hand;
			button9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button9.Image = maxcare.Properties.Resources.upload_to_ftp_25px;
			button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button9.Location = new System.Drawing.Point(530, 18);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(130, 27);
			button9.TabIndex = 7;
			button9.Text = "Nhập tài khoản";
			button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(Button3_Click);
			BtnSearch.BackgroundImage = maxcare.Properties.Resources.icons8_search_24px_1;
			BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			BtnSearch.Location = new System.Drawing.Point(253, 18);
			BtnSearch.Name = "BtnSearch";
			BtnSearch.Size = new System.Drawing.Size(24, 24);
			BtnSearch.TabIndex = 2;
			BtnSearch.UseSelectable = true;
			BtnSearch.Click += new System.EventHandler(BtnSearch_Click);
			cbbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbSearch.DropDownWidth = 100;
			cbbSearch.FormattingEnabled = true;
			cbbSearch.Location = new System.Drawing.Point(12, 18);
			cbbSearch.Name = "cbbSearch";
			cbbSearch.Size = new System.Drawing.Size(86, 24);
			cbbSearch.TabIndex = 0;
			txbSearch.BorderColor = System.Drawing.Color.SeaGreen;
			txbSearch.Location = new System.Drawing.Point(104, 19);
			txbSearch.Name = "txbSearch";
			txbSearch.Size = new System.Drawing.Size(143, 23);
			txbSearch.TabIndex = 1;
			statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				toolStripStatusLabel1, lblStatus, toolStripStatusLabel3, lblKey, toolStripStatusLabel8, txbUid, lblUser, toolStripStatusLabel9, toolStripStatusLabel10, lblDateExpried,
				toolStripStatusLabel5, lblCountSelect, toolStripStatusLabel7, lblCountTotal
			});
			statusStrip1.Location = new System.Drawing.Point(0, 664);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1235, 22);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 9;
			statusStrip1.Text = "statusStrip1";
			statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(statusStrip1_ItemClicked);
			toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
			toolStripStatusLabel1.Text = "Trạng thái:";
			lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.Color.Green;
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(97, 17);
			lblStatus.Text = "Đang kiê\u0309m tra...";
			toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(82, 17);
			toolStripStatusLabel3.Text = "Mã thiết bị:";
			lblKey.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblKey.ForeColor = System.Drawing.Color.Teal;
			lblKey.Name = "lblKey";
			lblKey.Size = new System.Drawing.Size(49, 17);
			lblKey.Text = "******";
			toolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel8.Name = "toolStripStatusLabel8";
			toolStripStatusLabel8.Size = new System.Drawing.Size(42, 17);
			toolStripStatusLabel8.Text = "User:";
			txbUid.Name = "txbUid";
			txbUid.Size = new System.Drawing.Size(0, 17);
			lblUser.Name = "lblUser";
			lblUser.Size = new System.Drawing.Size(56, 17);
			lblUser.Text = "******";
			toolStripStatusLabel9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel9.IsLink = true;
			toolStripStatusLabel9.Name = "toolStripStatusLabel9";
			toolStripStatusLabel9.Size = new System.Drawing.Size(66, 17);
			toolStripStatusLabel9.Text = "Đăng xuâ\u0301t";
			toolStripStatusLabel9.Click += new System.EventHandler(ToolStripStatusLabel9_Click);
			toolStripStatusLabel10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel10.Name = "toolStripStatusLabel10";
			toolStripStatusLabel10.Size = new System.Drawing.Size(99, 17);
			toolStripStatusLabel10.Text = "Ngày hết hạn:";
			lblDateExpried.Name = "lblDateExpried";
			lblDateExpried.Size = new System.Drawing.Size(74, 17);
			lblDateExpried.Text = "20/10/2020";
			toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			toolStripStatusLabel5.Size = new System.Drawing.Size(66, 17);
			toolStripStatusLabel5.Text = "Đã chọn:";
			lblCountSelect.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblCountSelect.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
			lblCountSelect.Name = "lblCountSelect";
			lblCountSelect.Size = new System.Drawing.Size(16, 17);
			lblCountSelect.Text = "0";
			toolStripStatusLabel7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			toolStripStatusLabel7.Size = new System.Drawing.Size(53, 17);
			toolStripStatusLabel7.Text = "Tất cả:";
			lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblCountTotal.ForeColor = System.Drawing.Color.Maroon;
			lblCountTotal.Name = "lblCountTotal";
			lblCountTotal.Size = new System.Drawing.Size(16, 17);
			lblCountTotal.Text = "0";
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = bunifuCustomLabel1;
			bunifuDragControl2.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 30000;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 40;
			btnPause.BackColor = System.Drawing.Color.White;
			btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPause.Enabled = false;
			btnPause.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnPause.Image = (System.Drawing.Image)resources.GetObject("btnPause.Image");
			btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPause.Location = new System.Drawing.Point(141, 78);
			btnPause.Name = "btnPause";
			btnPause.Size = new System.Drawing.Size(128, 32);
			btnPause.TabIndex = 3;
			btnPause.Text = "Dừng Tương Tác";
			btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			toolTip1.SetToolTip(btnPause, "Dư\u0300ng tương ta\u0301c");
			btnPause.UseVisualStyleBackColor = true;
			btnPause.Click += new System.EventHandler(BtnPause_Click);
			btnInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			btnInteract.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnInteract.Image = (System.Drawing.Image)resources.GetObject("btnInteract.Image");
			btnInteract.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnInteract.Location = new System.Drawing.Point(6, 79);
			btnInteract.Name = "btnInteract";
			btnInteract.Size = new System.Drawing.Size(128, 32);
			btnInteract.TabIndex = 2;
			btnInteract.Text = "Chạy Tương Tác";
			btnInteract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			toolTip1.SetToolTip(btnInteract, "Bă\u0301t đâ\u0300u cha\u0323y tương ta\u0301c");
			btnInteract.UseVisualStyleBackColor = false;
			btnInteract.Click += new System.EventHandler(BtnInteract_Click);
			btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPost.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnPost.Image = (System.Drawing.Image)resources.GetObject("btnPost.Image");
			btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPost.Location = new System.Drawing.Point(3, 1);
			btnPost.Name = "btnPost";
			btnPost.Size = new System.Drawing.Size(128, 29);
			btnPost.TabIndex = 0;
			btnPost.Text = "Đăng bài    ";
			toolTip1.SetToolTip(btnPost, "Chư\u0301c năng tư\u0323 đô\u0323ng đăng ba\u0300i");
			btnPost.UseVisualStyleBackColor = false;
			btnPost.Click += new System.EventHandler(btnPost_Click_2);
			plTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			plTrangThai.BackColor = System.Drawing.Color.Gainsboro;
			plTrangThai.Controls.Add(lblTrangThai);
			plTrangThai.Location = new System.Drawing.Point(861, 36);
			plTrangThai.Name = "plTrangThai";
			plTrangThai.Size = new System.Drawing.Size(373, 26);
			plTrangThai.TabIndex = 10;
			plTrangThai.Visible = false;
			lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
			lblTrangThai.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTrangThai.Location = new System.Drawing.Point(0, 0);
			lblTrangThai.Name = "lblTrangThai";
			lblTrangThai.Size = new System.Drawing.Size(373, 26);
			lblTrangThai.TabIndex = 0;
			lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plChucNang);
			panel1.Controls.Add(btnRandomIndexRow);
			panel1.Controls.Add(grTimKiem);
			panel1.Controls.Add(btnPause);
			panel1.Controls.Add(dtgvAcc);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(statusStrip1);
			panel1.Controls.Add(grQuanLyThuMuc);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1237, 688);
			panel1.TabIndex = 11;
			plChucNang.Controls.Add(button5);
			plChucNang.Controls.Add(button3);
			plChucNang.Controls.Add(btnPost);
			plChucNang.Location = new System.Drawing.Point(2, 124);
			plChucNang.Name = "plChucNang";
			plChucNang.Size = new System.Drawing.Size(408, 31);
			plChucNang.TabIndex = 13;
			button5.Cursor = System.Windows.Forms.Cursors.Hand;
			button5.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button5.Image = maxcare.Properties.Resources.icons8_male_user_24px;
			button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			button5.Location = new System.Drawing.Point(273, 1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(128, 29);
			button5.TabIndex = 4;
			button5.Text = "Up Avatar   ";
			button5.UseVisualStyleBackColor = false;
			button5.Click += new System.EventHandler(button5_Click_1);
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Image = (System.Drawing.Image)resources.GetObject("button3.Image");
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			button3.Location = new System.Drawing.Point(139, 1);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(128, 29);
			button3.TabIndex = 0;
			button3.Text = "Đăng story    ";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click_1);
			btnRandomIndexRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnRandomIndexRow.Cursor = System.Windows.Forms.Cursors.Hand;
			btnRandomIndexRow.Location = new System.Drawing.Point(1140, 125);
			btnRandomIndexRow.Name = "btnRandomIndexRow";
			btnRandomIndexRow.Size = new System.Drawing.Size(88, 29);
			btnRandomIndexRow.TabIndex = 12;
			btnRandomIndexRow.Text = "Random";
			btnRandomIndexRow.UseSelectable = true;
			btnRandomIndexRow.Click += new System.EventHandler(btnRandomIndexRow_Click);
			grTimKiem.Controls.Add(BtnSearch);
			grTimKiem.Controls.Add(cbbSearch);
			grTimKiem.Controls.Add(txbSearch);
			grTimKiem.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grTimKiem.Location = new System.Drawing.Point(276, 67);
			grTimKiem.Name = "grTimKiem";
			grTimKiem.Size = new System.Drawing.Size(284, 53);
			grTimKiem.TabIndex = 4;
			grTimKiem.TabStop = false;
			grTimKiem.Text = "Tìm kiếm";
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button7.Image = (System.Drawing.Image)resources.GetObject("button7.Image");
			button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button7.Location = new System.Drawing.Point(1026, 125);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(105, 29);
			button7.TabIndex = 7;
			button7.Text = "Nhập Proxy";
			button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			timer1.Enabled = true;
			timer1.Interval = 1800000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1237, 688);
			base.Controls.Add(plTrangThai);
			base.Controls.Add(btnInteract);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(menuStrip1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip1;
			base.Name = "fMain";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Max Instagram Pro";
			base.Load += new System.EventHandler(FMain_Load);
			((System.ComponentModel.ISupportInitialize)dtgvAcc).EndInit();
			ctmsAcc.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			bunifuCards1.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			grQuanLyThuMuc.ResumeLayout(false);
			grQuanLyThuMuc.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			plTrangThai.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plChucNang.ResumeLayout(false);
			grTimKiem.ResumeLayout(false);
			grTimKiem.PerformLayout();
			ResumeLayout(false);
		}
	}
}
