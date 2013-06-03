﻿using System;

namespace WindRunnerHacker
{
	public class PacketDataWapper
	{
		public int seq;
		public int hash;
		public PacketData pk_data;
	}
	
	public class PacketData
	{
		public string lang;
		public string cmd;
		public string userId;
		public string accessToken;
		public PacketData(Account curAcc)
		{
			lang = ServerParam.strSysLang;
			userId = curAcc.userData.userId;
			accessToken = curAcc.userData.accessToken;
		}
	}
	
	public class PacketGameStart : PacketData
	{
		public PacketGameStart(Account curAcc) : base(curAcc)
		{
			cmd = ServerParam.dicCmdWord["GameStart"];
		}
	}
	
	public class PacketGameEnd : PacketData
	{
		public int playScore;
		public int playDistance;
		public int playMoney;
		public int todayMissionSuccess;
		public int beatCount;
		public string sCode;
		public string playData;
		public PacketGameEnd(Account curAcc) : base(curAcc)
		{
			cmd = ServerParam.dicCmdWord["GameEnd"];
		}
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