using System;
using System.Collections.Generic;

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
		
		// 命令字
		public static Dictionary<string, string> dicCmdWord = new Dictionary<string, string>()
		{
			{"GameStart", "ToS_LIFETICK"},
			{"GameEnd", "ToS_FINISHGAME"},
		};
	}
}
