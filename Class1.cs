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
		public String OP(string func)
		{

			return "HI";
		}

		public static string[] getFunc(int nOperations)
		{
			string[] funcList = new String[nOperations];
			string[] randL = new string[12] { "save", "getSize", "addColl","addRow", "searchInRange", "getCell", "setCell",
											 "searchString", "exchangeRows", "exchangeCols", "searchInRow", "searchInCol" };
			Random rnd = new Random();
			for (int i = 0; i < nOperations; i++)
			{
				string item = randL[rnd.Next(randL.Length)];
				funcList[i] = item;

			}

			return funcList;
		}
		public static void DoTasks()
		{
			string[] rand_oper = new string[10];



		}
	}
}
