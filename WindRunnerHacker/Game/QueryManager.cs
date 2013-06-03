using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace WindRunnerHacker
{
	public partial class QueryManager
	{	
		public event EventHandler<UIUpdateArgs> OnUIUpdate;
		private object SycLock = new object();
		
		public QueryManager()
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
		}
		
		public void init()
		{

		}
		
		public void DebugLog(string log)
		{
			LogArgs arg = new LogArgs();
			arg.strLog = log;
			arg.uiType = UIUpdateTypes.LogAppending;
			OnUIUpdate(this, arg);
		}
		
		public void ClearLog()
		{
			UIUpdateArgs arg = new UIUpdateArgs();
			arg.uiType = UIUpdateTypes.LogClear;
			OnUIUpdate(this, arg);
		}
		
		public void UIUpdateRefreshAll()
		{
			UIUpdateArgs arg = new UIUpdateArgs();
			arg.uiType = UIUpdateTypes.RefreshAll;
			OnUIUpdate(this, arg);
		}
		
		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(DateTime.Now.ToString());
			sb.AppendLine(ex.Message);
			sb.AppendLine(ex.StackTrace);
			
			WriteLog("Crash.log", sb.ToString());
		}
		
		public static void WriteLog(string file_name, string content)
		{
			FileStream fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
			sw.Write(content);
			sw.Close();
		}
	}
	
	public enum UIUpdateTypes
	{
		None,
		LogAppending,
		LogClear,
		RefreshAll,
	};
	
	public class UIUpdateArgs : EventArgs
	{
		public UIUpdateTypes uiType;
	};
	
	public class LogArgs : UIUpdateArgs
	{
		public string strLog;
	};
}
