using System;

namespace WindRunnerHacker
{
	public class PacketDataWapper
	{
		public string hash;
		public PacketData pk_data = null;
	}
	
	public class PacketData
	{
		public string cmd;
	}
	
	public class PacketStart : PacketData
	{
		public string clientVersion;
	}
	
	public class PacketAuth : PacketData
	{
		public string userId;
		public string kakaoToken;
		public string clientVersion;
		public string[] friends;
		public string deviceName;
		public string osInfo;
		public string macAddress;
		public string appId;
		public string osId;
	}
	
	//-------------------------------------------------------------------------
	public class RecvData
	{
		public string cmd;
		public PlayerDatas C_PlayerDatas;
		public ItemDatas C_ItemDatas;
		public CharacterDatas C_CharacterDatas;
		public RideDatas C_RideDatas;
		public PetDatas C_PetDatas;
		public HCPetPoint C_HCPetPoint;
		public EventDatas C_EventDatas;
		public TextDatas C_TextDatas;
		public PriceDatas C_PriceDatas;
		public SystemAlertList C_SystemAlertList;
		public NotifyMsgList C_NotifyMsgList;
		public NotifyPopupList C_NotifyPopupList;
		public ActionPopup C_ActionPopup;
		public RewardBoxCount C_RewardBoxCount;
		public string echo;
		public string arg;
	}

	public class RecvGameStart : RecvData
	{
	}
	
	public class RecvGameEnd : RecvData
	{
		public PlayResult playResult;
		public int bestScore;
		public int bestDist;
		public Options bestOpts;
		public int weekScore;
		public int weekDist;
		public Options weekOpts;
		public int bestDistRecord;
		public int weekDistRecord;
		public UpdatedFriendDatas updatedFriendDatas;
		public int messageCount;
		public int todayMissionStatus;
		public StatDatas statDatas;
		public long resetRecordTime;
		public string resetRecordMsg;
		public int myLastWeekScore;
		public int myLastWeekDist;
		public Options myLastWeekOpts;
		public string promotion;
	}
}
