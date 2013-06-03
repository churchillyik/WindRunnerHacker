using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindRunnerHacker
{
	public partial class QueryManager
	{
		public static string gAccountFilePath = "Account";
		public void LoadAccounts(List<Account> lstAccs)
		{
			if (lstAccs == null)
			{
				return;
			}
			else
			{
				lstAccs.Clear();
			}
			if (!File.Exists(gAccountFilePath))
			{
				return;
			}
			
			string[] lines = File.ReadAllLines(gAccountFilePath);
			foreach (string line in lines)
			{
				string[] pair = line.Split(new char[] {'\t'});
				if (pair.Length != 2)
				{
					DebugLog("帐号文件行[" + line + "]无效");
					continue;
				}
				
				Account acc = new Account(pair[0], pair[1]);
				acc.upCall = this;
				lstAccs.Add(acc);
			}
		}
		
		public void SaveAccounts(List<Account> lstAccs)
		{
			if (lstAccs == null || lstAccs.Count == 0)
			{
				return;
			}
			
			StringBuilder sb = new StringBuilder();
			foreach (Account acc in lstAccs)
			{
				sb.AppendLine(acc.strUserName + "\t" + acc.strPassword);
			}
			
			WriteLog(gAccountFilePath, sb.ToString());
		}
	}
	
	public partial class Account
	{
		public QueryManager upCall = null;
		
		// 新浪的账号和密码
		public string strUserName;
		public string strPassword;
		
		// 判断用户是否登录
		public bool bIsLogined = false;
		
		public UserData userData = new UserData();
		
		public Account(string name, string pswd)
		{
			strUserName = name;
			strPassword = pswd;
		}
	}
	
	public class UserData
	{
		public string userId;
		public string accessToken;
	}
	
	public class PlayData
	{
		public int FEVER;
		public int DIE_FIREBALL;
		public int ITEM_SHIELD;
		public int END;
		public int WING_NUM;
		public int MONSTER_NUM;
		public int STARBONUS_NUM;
		
		public override string ToString()
		{
			return string.Format("FEVER={0},DIE_FIREBALL={1},ITEM_SHIELD={2},END={3},WING_NUM={4},MONSTER_NUM={5},STARBONUS_NUM={6},"
			                     , FEVER, DIE_FIREBALL, ITEM_SHIELD, END, WING_NUM, MONSTER_NUM, STARBONUS_NUM);
		}

	}
	
	//-------------------------------------------------------------------------
	public class PlayerDatas
	{
		
	}
	
	public class ItemDatas
	{
	}
	
	public class CharacterDatas
	{
	}
	
	public class RideDatas
	{
	}
	
	public class PetDatas
	{
	}
	
	public class HCPetPoint
	{
	}
	
	public class EventDatas
	{
	}
	
	public class TextDatas
	{
	}
	
	public class PriceDatas
	{
	}
	
	public class SystemAlertList
	{
	}
	
	public class NotifyMsgList
	{
	}
	
	public class NotifyPopupList
	{
	}
	
	public class ActionPopup
	{
	}
	
	public class RewardBoxCount
	{
	}
	
	// ----------------------------------------------------
	public class PlayResult
	{
	}
	
	public class Options
	{
		public string C;
		public string R;
		public string P;
		public string P2;
		public int CL;
		public int RL;
		public int RE;
	}
	
	public class UpdatedFriendDatas
	{
	}
	
	public class StatDatas
	{
	}
}
