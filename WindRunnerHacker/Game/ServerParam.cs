using System;
using System.Collections.Generic;

namespace WindRunnerHacker
{
	public class ServerParam
	{
		// 游戏的域名地址
		public static string strGameSvr = "smpsjlgwr.linegame.jp:10010";
		
		// 游戏URL
		public static string strGameUrl = "windrunner_line/game.php";
		
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
