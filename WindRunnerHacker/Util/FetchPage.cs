﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using LitJson;
using System.Security.Cryptography;

namespace WindRunnerHacker
{
	public enum QueryStatus
	{
		NotLogined,
		Logined,
		QueryReady,
		QueryFinish,
	};

	public partial class Account
	{
		private MyWebClient webClient = null;
		public QueryStatus QrySta = QueryStatus.NotLogined;
		
		public string PageQuery(string strSvr, string strURL)
		{
			return PageQuery(strSvr, strURL, (byte[])null, Encoding.UTF8);
		}
		
		public string PageQuery(string strSvr, string strURL, PacketDataWapper wapper)
		{
			string json_data = "null";
			if (wapper.pk_data != null)
			{
				json_data = JsonMapper.ToJson(wapper.pk_data);
			}
			//wapper.hash = SHA1Decode(json_data);
			
			Dictionary<string, string> dicPostData = new Dictionary<string, string>();
			dicPostData.Add("seq", wapper.seq.ToString());
			dicPostData.Add("hash", wapper.hash);
			dicPostData.Add("data", json_data);
			return PageQuery(strSvr, strURL, dicPostData);
		}
		
		public string PageQuery(string strSvr, string strURL, Dictionary<string, string> dicPostData)
		{
			return PageQuery(strSvr, strURL, dicPostData, Encoding.UTF8);
		}
		
		public string PageQuery(string strSvr, string strURL, Dictionary<string, string> dicPostData, Encoding enc)
		{
			byte[] qry_bytes = this.MakeBytesFromDic(dicPostData);
			return PageQuery(strSvr, strURL, qry_bytes, enc);
		}
		
		public string PageQuery(string strSvr, string strURL, byte[] qry_bytes)
		{
			return PageQuery(strSvr, strURL, qry_bytes, Encoding.UTF8);
		}
		
		public string PageQuery(string strSvr, string strURL, byte[] qry_bytes, Encoding enc)
		{
			upCall.DebugLog(strSvr + "/" + strURL);
			if (this.webClient == null)
			{
				this.webClient = new MyWebClient(strSvr, null);
			}
			
			webClient.strSvrURL = strSvr;
			
			if (this.QrySta != QueryStatus.NotLogined)
			{
				this.QrySta = QueryStatus.QueryReady;
			}
			
			
			string strEx = "";
			string result;
			
			//	直到访问网页有返回时结束
			while (true)
			{
				result = webClient.HttpQuery(strURL, qry_bytes, enc, out strEx);
				if (strEx != "")
				{
					upCall.DebugLog("访问：[" + strURL + "]时发生异常，接着重试");
					upCall.DebugLog(strEx.Substring(0, strEx.IndexOfAny(new char [] {'\r', '\n'})));
				}
				else
				{
					break;
				}
			}
			
			if (bIsLogined)
			{
				this.QrySta = QueryStatus.QueryFinish;
			}
			else
			{
				this.QrySta = QueryStatus.NotLogined;
			}
			
			return result;
		}

		public byte[] MakeBytesFromDic(Dictionary<string, string> Data)
		{
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if (sb.Length != 0)
				{
					sb.Append("&");
				}

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			string QueryString = sb.ToString();
			byte[] qry_bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(QueryString);
			
			return qry_bytes;
		}
		
		public string SHA1Decode(string origin_str)
		{
			//建立SHA1对象
			SHA1 sha = new SHA1CryptoServiceProvider();

			//将mystr转换成byte[]
			byte[] dataToHash = Encoding.GetEncoding("iso-8859-1").GetBytes(origin_str);
			
			//Hash运算
			byte[] dataHashed = sha.ComputeHash(dataToHash);

			//将运算结果转换成string
			return BitConverter.ToString(dataHashed).Replace("-", "").ToLower();
		}
	}
}