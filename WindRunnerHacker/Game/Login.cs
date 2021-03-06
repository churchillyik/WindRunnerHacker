﻿using System;
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
			
			// ----------------------------------------------------------------------------------------------------
			// GameStart
			PacketStart pk_start = new PacketStart();
			pk_start.cmd = "ToS_START";
			pk_start.clientVersion = "I2.14";
			
			wapper.pk_data = pk_start;
			result = curAcc.PageQuery(ServerParam.strGameSvr, ServerParam.strStartUrl, wapper);
			
			// ----------------------------------------------------------------------------------------------------
			// GameAuth
			PacketAuth pk_auth = new PacketAuth();
			pk_auth.cmd = "ToS_AUTH";
			pk_auth.userId = "89793590877302032";
			pk_auth.kakaoToken = "DsMp3scEgTftAQ1V398XAorIE7a06VsUEi7Yfrv1/zlLlghArpqTVctV2vJ9StWKgJ6u4eaicxza1oiSKE2aHoa+3U/yWnfNsivwBLzIalk0+eLkOpeVVQ==";
			pk_auth.clientVersion = "I2.14";
			pk_auth.friends = new string[] {"89455177694208000","89428422561973665"};
			pk_auth.deviceName = "UNKNOWN";
			pk_auth.osInfo = "0.0";
			pk_auth.macAddress = "";
			pk_auth.appId = "";
			pk_auth.osId = "";
			
			//wapper.hash = "9dbdb3f035a7b55f96bd61efa75b60e692745453";
			wapper.pk_data = pk_auth;
			result = curAcc.PageQuery(ServerParam.strGameSvr, ServerParam.strAuthUrl, wapper);
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
			Encoding Ansi = Encoding.UTF8;
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