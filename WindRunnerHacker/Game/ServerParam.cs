using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WindRunnerHacker
{
	public class ServerParam
	{
		// 检验服务器的域名
		public static string strCheckSvr = "wr-check.wemade.com";
		
		// 游戏服务器的域名
		public static string strGameSvr = "wr-game.wemade.com";
		
		// 检验URL
		public static string strCheckUrl = "windrunner/check.php";
		
		// 登录URL
		public static string strStartUrl = "windrunner/start.php";
		
		// 验证URL
		public static string strAuthUrl = "windrunner/auth.php";
		
		// 游戏URL
		public static string strGameUrl = "windrunner/game.php";
		
		// 系统语言
		public static string strSysLang = "Chinese";
		
		// sha1加密密钥
		public static string strSHA1Key = "bHuYQps5JH12vWFDssIG3ytLPdxD51xW";
		
		public static string getShaStrToS(string str)
		{
			return SHA1Decode(strSHA1Key + str);
		}
		
		public static string SHA1Decode(string origin_str)
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
		
		// 命令字
		public static Dictionary<string, string> dicCmdWord = new Dictionary<string, string>()
		{
			{"GameStart", "ToS_LIFETICK"},
			{"GameEnd", "ToS_FINISHGAME"},
		};
	}
}
