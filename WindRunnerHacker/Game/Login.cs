using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using System.IO;

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

			Dictionary<string, string> pkg_data = new Dictionary<string, string>();
			Match m = null;
			string result = "";
			// CheckSvr
			pkg_data.Add("OSTYPE", "I");
			string param = CreateQueryString(pkg_data);
			
			PacketDataWapper wapper = new PacketDataWapper();
			wapper.seq = 0;
			wapper.hash = "4a56a496352b4ccecf7192fe8ce98ce9a5a6cfa6";
			wapper.pk_data = null;
			result = curAcc.PageQuery(ServerParam.strCheckSvr, ServerParam.strCheckUrl + "?" + param, wapper);
			
			m = Regex.Match(result, "\"URL\":\"(.*?)\"", RegexOptions.Singleline);
			if (!m.Success)
			{
				return;
			}
			string url = m.Groups[1].Value.Replace("\\", "");
			m = Regex.Match(url, "http://(.*?)/(.*?)php", RegexOptions.Singleline);
			if (!m.Success)
			{
				return;
			}
			ServerParam.strGameSvr = m.Groups[1].Value;
			ServerParam.strStartUrl = m.Groups[2].Value + "php";
			
			// GameStart
			PacketStart pk_start = new PacketStart();
			pk_start.cmd = "ToS_START";
			pk_start.clientVersion = "I2.14";
			
			wapper.seq = 1;
			wapper.hash = "24a792a93b572ae611e861a1dbf4d38ac575d7d0";
			wapper.pk_data = pk_start;
			result = curAcc.PageQuery(ServerParam.strGameSvr, ServerParam.strStartUrl, wapper);
			DebugLog(result);
			
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