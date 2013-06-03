
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindRunnerHacker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private delegate void dlgWriteLog(string log);
		private delegate void dlgClearLog();
		private delegate void dlgRefreshAll();
		
		private QueryManager sInsMgr = new QueryManager();
		private List<Account> lstAccs = new List<Account>();
		private Account curAcc= null;

		void MainFormLoad(object sender, EventArgs e)
		{
			sInsMgr.OnUIUpdate += new EventHandler<UIUpdateArgs>(CallBack_UIUpdate);
			sInsMgr.init();
			sInsMgr.LoadAccounts(lstAccs);
			RefreshAccounts();
		}
		
		void CallBack_UIUpdate(object sender, UIUpdateArgs e)
		{
			try
			{
				if (e.uiType == UIUpdateTypes.LogAppending)
				{
					LogArgs e_log = e as LogArgs;
					Invoke(new dlgWriteLog(WriteLog)
					       , new object[] { e_log.strLog });
				}
				else if (e.uiType == UIUpdateTypes.LogClear)
				{
					Invoke(new dlgClearLog(ClearLog));
				}
				else if (e.uiType == UIUpdateTypes.RefreshAll)
				{
					Invoke(new dlgRefreshAll(UIUpdateRefreshAll));
				}
			}
			catch (Exception)
			{ }
		}
		
		private int nLogCnt = 0;
		private void WriteLog(string log)
		{
			if (nLogCnt >= 100)
			{
				this.tbLog.Text = "";
				nLogCnt = 0;
			}
			this.tbLog.AppendText("[" + DateTime.Now.ToString() + "] " + log + "\r\n");
			nLogCnt++;
		}
		
		private void ClearLog()
		{
			this.tbLog.Text = "";
		}
		
		private void UIUpdateRefreshAll()
		{
		}
		
		private void Buttonbehaviour(bool bLogined)
		{
		}
		
		private void LoginOrFocusAccount(Account acc)
		{
			curAcc = acc;
			this.Text = "WindRunner - " + "焦点帐号[" + curAcc.strUserName + "]";
			if (!curAcc.bIsLogined)
			{
				sInsMgr.Login(curAcc);
			}
			else
			{
				UIUpdateRefreshAll();
			}
			Buttonbehaviour(true);
		}
		
		private void LogoutAccount(Account acc)
		{
			sInsMgr.Logout(acc);
			
			Buttonbehaviour(false);
		}
		
		void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				this.loginToolStripMenuItem.Enabled = false;
				this.logoutToolStripMenuItem.Enabled = false;
				this.delAccToolStripMenuItem.Enabled = false;
				this.editAccToolStripMenuItem.Enabled = false;
				return;
			}
			Account acc = this.lstAccs[this.lvAcc.SelectedIndices[0]];
			if (acc.bIsLogined)
			{
				this.loginToolStripMenuItem.Text = "&S. 切换帐号";
				this.loginToolStripMenuItem.Enabled = true;
				this.logoutToolStripMenuItem.Enabled = true;
				this.delAccToolStripMenuItem.Enabled = true;
				this.editAccToolStripMenuItem.Enabled = true;
			}
			else
			{
				this.loginToolStripMenuItem.Text = "&L. 登录帐号";
				this.loginToolStripMenuItem.Enabled = true;
				this.logoutToolStripMenuItem.Enabled = false;
				this.delAccToolStripMenuItem.Enabled = true;
				this.editAccToolStripMenuItem.Enabled = true;
			}
		}
		
		void AddAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			AccEditForm acc_form = new AccEditForm();
			if (acc_form.ShowDialog() == DialogResult.OK && acc_form.accResult != null)
			{
				acc_form.accResult.upCall = sInsMgr;
				this.lstAccs.Add(acc_form.accResult);
				RefreshAccounts();
				sInsMgr.SaveAccounts(this.lstAccs);
			}
		}
		
		void DelAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				return;
			}
			this.lstAccs.RemoveAt(this.lvAcc.SelectedIndices[0]);
			RefreshAccounts();
			sInsMgr.SaveAccounts(this.lstAccs);
		}
		
		void EditAccToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				return;
			}
			AccEditForm acc_form = new AccEditForm();
			acc_form.accResult = this.lstAccs[this.lvAcc.SelectedIndices[0]];
			if (acc_form.ShowDialog() == DialogResult.OK)
			{
				RefreshAccounts();
				sInsMgr.SaveAccounts(this.lstAccs);
			}
		}
		
		void LoginToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				return;
			}
			for (int i = 0; i < this.lvAcc.Items.Count; i++)
			{
				if (i == this.lvAcc.SelectedIndices[0])
				{
					ListViewItem lvi = this.lvAcc.Items[i];
					lvi.BackColor = Color.LightBlue;
				}
				else
				{
					ListViewItem lvi = this.lvAcc.Items[i];
					lvi.BackColor = SystemColors.Window;
				}
			}
			LoginOrFocusAccount(this.lstAccs[this.lvAcc.SelectedIndices[0]]);
		}
		
		void LogoutToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				return;
			}
			LogoutAccount(this.lstAccs[this.lvAcc.SelectedIndices[0]]);
		}
		
		private void RefreshAccounts()
		{
			if (this.lstAccs == null)
			{
				return;
			}
			this.lvAcc.Items.Clear();
			for (int  i = 0; i < this.lstAccs.Count; i++)
			{
				this.lvAcc.Items.Add(this.lstAccs[i].strUserName);
			}
		}
		
		void BtnClearLogClick(object sender, EventArgs e)
		{
			this.tbLog.Text = "";
		}
		
		void LvAccDoubleClick(object sender, EventArgs e)
		{
			if (this.lvAcc.SelectedIndices.Count < 1)
			{
				return;
			}
			for (int i = 0; i < this.lvAcc.Items.Count; i++)
			{
				if (i == this.lvAcc.SelectedIndices[0])
				{
					ListViewItem lvi = this.lvAcc.Items[i];
					lvi.BackColor = Color.LightBlue;
				}
				else
				{
					ListViewItem lvi = this.lvAcc.Items[i];
					lvi.BackColor = SystemColors.Window;
				}
			}
			LoginOrFocusAccount(this.lstAccs[this.lvAcc.SelectedIndices[0]]);
		}
	}
}
