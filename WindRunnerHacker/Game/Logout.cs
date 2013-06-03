using System;
using System.Collections.Generic;
using System.Threading;

namespace WindRunnerHacker
{
	partial class QueryManager
	{
		public void Logout(Account acc)
		{
			Thread t = new Thread(new ParameterizedThreadStart(doLogout));
			t.Name = "Logout";
			t.Start(acc);
		}
		
		public void doLogout(object o)
		{
			Account curAcc = (Account) o;
			if (curAcc == null)
			{
				return;
			}
			curAcc.bIsLogined = false;

		}
	}
}
