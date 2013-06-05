
namespace WindRunnerHacker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lvAcc = new System.Windows.Forms.ListView();
			this.chAccName = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.delAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editAccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClearLog = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.32815F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.67185F));
			this.tableLayoutPanel1.Controls.Add(this.lvAcc, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 391);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lvAcc
			// 
			this.lvAcc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chAccName});
			this.lvAcc.ContextMenuStrip = this.contextMenuStrip1;
			this.lvAcc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvAcc.FullRowSelect = true;
			this.lvAcc.GridLines = true;
			this.lvAcc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvAcc.Location = new System.Drawing.Point(3, 3);
			this.lvAcc.MultiSelect = false;
			this.lvAcc.Name = "lvAcc";
			this.lvAcc.Size = new System.Drawing.Size(172, 385);
			this.lvAcc.TabIndex = 0;
			this.lvAcc.UseCompatibleStateImageBehavior = false;
			this.lvAcc.View = System.Windows.Forms.View.Details;
			this.lvAcc.DoubleClick += new System.EventHandler(this.LvAccDoubleClick);
			// 
			// chAccName
			// 
			this.chAccName.Text = "LINE平台用户名";
			this.chAccName.Width = 160;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addAccToolStripMenuItem,
									this.delAccToolStripMenuItem,
									this.editAccToolStripMenuItem,
									this.loginToolStripMenuItem,
									this.logoutToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
			// 
			// addAccToolStripMenuItem
			// 
			this.addAccToolStripMenuItem.Name = "addAccToolStripMenuItem";
			this.addAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.addAccToolStripMenuItem.Text = "&A. 添加帐号";
			this.addAccToolStripMenuItem.Click += new System.EventHandler(this.AddAccToolStripMenuItemClick);
			// 
			// delAccToolStripMenuItem
			// 
			this.delAccToolStripMenuItem.Name = "delAccToolStripMenuItem";
			this.delAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.delAccToolStripMenuItem.Text = "&D. 删除帐号";
			this.delAccToolStripMenuItem.Click += new System.EventHandler(this.DelAccToolStripMenuItemClick);
			// 
			// editAccToolStripMenuItem
			// 
			this.editAccToolStripMenuItem.Name = "editAccToolStripMenuItem";
			this.editAccToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.editAccToolStripMenuItem.Text = "&E. 修改帐号";
			this.editAccToolStripMenuItem.Click += new System.EventHandler(this.EditAccToolStripMenuItemClick);
			// 
			// loginToolStripMenuItem
			// 
			this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
			this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loginToolStripMenuItem.Text = "&L. 登录帐号";
			this.loginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItemClick);
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.logoutToolStripMenuItem.Text = "&O. 登出帐号";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItemClick);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbLog, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(181, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 385);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(542, 148);
			this.panel1.TabIndex = 0;
			// 
			// tbLog
			// 
			this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLog.Location = new System.Drawing.Point(3, 187);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.Size = new System.Drawing.Size(542, 195);
			this.tbLog.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClearLog);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 157);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(542, 24);
			this.panel2.TabIndex = 2;
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(4, 1);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(75, 23);
			this.btnClearLog.TabIndex = 0;
			this.btnClearLog.Text = "清空日志";
			this.btnClearLog.UseVisualStyleBackColor = true;
			this.btnClearLog.Click += new System.EventHandler(this.BtnClearLogClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 391);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WindRunnerHacker";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnClearLog;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editAccToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem delAccToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAccToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ColumnHeader chAccName;
		private System.Windows.Forms.ListView lvAcc;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
