using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using System.IO;
using LitJson;

namespace WindRunnerHacker
{
	partial class QueryManager
	{
		public void Login(Account acc)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doLogin));
			t.Name = "Login";
			t.Start(acc);
		}
		
		public void doLogin(object o)
		{
			Account curAcc = (Account) o;
			if (curAcc == null)
			{
				return;
			}
			curAcc.bIsLogined = false;

			curAcc.bIsLogined = true;
			curAcc.QrySta = QueryStatus.Logined;
			DebugLog("已成功登陆！");
		}
		
		public static string sKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		public static string base64_encode(string str)
		{
			byte[] temp1 = Encoding.UTF8.GetBytes(HttpUtility.UrlEncode(str));
			string temp2 = Convert.ToBase64String(temp1);
			return temp2;
		}
		
		public static string base64_decode(string str)
		{
			byte[] sa = Convert.FromBase64String(str);
			Encoding Ansi = Encoding.GetEncoding("GB2312");
			string wa = Ansi.GetString(sa);
			return wa;
		}
		
		public static string CreateQueryString(Dictionary<string, string> Data)
		{
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if(sb.Length != 0)
				{
					sb.Append("&");
				}

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			return sb.ToString();
		}
		
		public static long UnixTimeStamp(DateTime time)
		{
			return Convert.ToInt64(time.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);
		}
		
		public static DateTime SecondsToDateTime(double seconds)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
			return dt.AddSeconds(seconds);
		}
		
		public static DateTime MillisecondsToDateTime(long milliseconds)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
			return dt.AddMilliseconds(milliseconds);
		}
	}
}