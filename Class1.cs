using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW3
{
	class Simulator
	{
		public Simulator(int rows,int  cols, int nThreads, int nOperations)
		{
			SharableSpreadaheet Sheet = new SharableSpreadaheet(rows, cols);
			for (int i = 0; i < nThreads; i++)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(DoTasks));
			}
			
		}
		public static void DoTasks()
		{
			string[] rand_oper = new string[10];



		}
	}
}
