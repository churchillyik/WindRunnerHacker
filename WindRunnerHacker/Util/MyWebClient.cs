using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Collections;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WindRunnerHacker
{
	public class MyWebClient
	{
		public string strSvrURL;
		private WebProxy pxy = null;
		
		private HttpWebRequest request;
		private CookieContainer cookies = null;
		private string strLastQueryPageURI = null;
		public MyWebClient(string svr_url, string pxy_addr)
		{
			strSvrURL = svr_url;
			if (pxy != null)
			{
				pxy = new WebProxy(pxy_addr);
			}
		}
		
		private void CreateRequest(string Uri)
		{
			request = (HttpWebRequest)WebRequest.Create(Uri);
			if (pxy != null)
			{
				request.Proxy = pxy;
			}
			if (cookies == null)
			{
				cookies = new CookieContainer();
			}
			request.CookieContainer = cookies;
			if (strLastQueryPageURI != null)
			{
				request.Referer = strLastQueryPageURI;
			}
			strLastQueryPageURI = Uri;
			request.Timeout = 30000;
			request.UserAgent = "windrunner/2.14 CFNetwork/609.1.4 Darwin/13.0.0";
			request.Accept = "*/*";
			request.Headers.Add("Accept-Language", "zh-cn");
			request.Headers.Add("Accept-Encoding", "gzip, deflate");
			request.ServicePoint.Expect100Continue = false;
			request.KeepAlive = true;
		}
		
		public string HttpQuery(string Uri, byte[] qry_bytes, Encoding enc, out string strEx)
		{
			strEx = "";
			try
			{
				string BaseAddress = string.Format("http://{0}/", strSvrURL);
				CreateRequest(BaseAddress + Uri);
				if (qry_bytes == null)
				{
					return HttpGet(enc);
				}
				else
				{
					return HttpPost(qry_bytes, enc);
				}
			}
			catch (Exception e)
			{
				strEx = e.ToString();
				return "";
			}
		}
		
		private string HttpGet(Encoding enc)
		{
			request.Method = "GET";
			return FetchResponse(enc);
		}
		
		private string HttpPost(byte[] qry_bytes, Encoding enc)
		{
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = qry_bytes.Length;
			
			Stream newStream = request.GetRequestStream();
			newStream.Write(qry_bytes, 0, qry_bytes.Length);
			newStream.Close();
			
			return FetchResponse(enc);
		}
		
		private string FetchResponse(Encoding enc)
		{
			string result = null;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			
			// 更新cookie
			foreach (Cookie rsp_c in response.Cookies)
			{
				CookieCollection cc = cookies.GetCookies(request.RequestUri);
				bool bIsExist = false;
				foreach (Cookie req_c in cc)
				{
					if (req_c.Name == rsp_c.Name)
					{
						bIsExist = true;
						req_c.Value = rsp_c.Value;
						req_c.Expires = rsp_c.Expires;
						req_c.Expired = rsp_c.Expired;
					}
				}
				if (!bIsExist)
				{
					cookies.Add(rsp_c);
				}
			}
			
			if (response.ContentEncoding == "gzip")
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(GZipStream zipStream = new GZipStream(streamReceive, CompressionMode.Decompress))
						using (StreamReader sr = new StreamReader(zipStream, enc))
							result = sr.ReadToEnd();
				}
			}
			else
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(StreamReader sr = new StreamReader(streamReceive, enc))
						result = sr.ReadToEnd();
				}
			}

			return result;
		}
	}
}