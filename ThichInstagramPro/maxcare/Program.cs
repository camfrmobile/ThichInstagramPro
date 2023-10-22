using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			try
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";
				if (File.Exists(path))
				{
					try
					{
						List<string> list = new List<string> { "app.minsoftware.vn", "minsoftware.vn" };
						using StreamReader streamReader = new StreamReader(path);
						string empty = string.Empty;
						while ((empty = streamReader.ReadLine()) != null)
						{
							foreach (string item in list)
							{
								if (empty.ToLower().Contains(item))
								{
									MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cấu hình lại file hosts nếu muốn mở phần mềm!"), 2);
									Environment.Exit(0);
								}
							}
						}
					}
					catch
					{
					}
				}
				Application.Run(new fIntro());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng liên hê\u0323 Admin đê\u0309 đươ\u0323c hô\u0303 trơ\u0323!"), 2);
				MCommon.Common.ExportError(null, ex, "Run Program2");
				Environment.Exit(0);
			}
		}
	}
}
