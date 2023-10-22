using System.Text.RegularExpressions;

namespace maxcare
{
	public class CommonIG
	{
		public static string GetUidFromCookie(string cookie)
		{
			try
			{
				return Regex.Match(cookie + ";", "ds_user_id=(.*?);").Groups[1].Value;
			}
			catch
			{
			}
			return "";
		}
	}
}
