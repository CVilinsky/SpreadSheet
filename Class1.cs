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
		int row;
		int col;
		int finished_threads = 0;
		public Simulator(int rows, int cols, int nThreads, int nOperations)
		{
			SharableSpreadaheet Sheet = new SharableSpreadaheet(rows, cols);
			this.row = rows;
			this.col = cols;
			object[] To_Send = new object[] { Sheet, this.row, this.col, nOperations };
			ThreadPool.SetMinThreads(1,0);
			ThreadPool.SetMaxThreads(nThreads, 0);
			
			//OP(Sheet, getFunc(nOperations), rows, cols, nOperations);
				for (int i = 0; i < nThreads; i++)
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(DoTasks), To_Send);
					Console.WriteLine("Looping time num: {0}", i + 1);
					Thread.Sleep(1000);
				}
				while(finished_threads!=nThreads)
			{
			}
			Sheet.save("spreadsheet.dat");
			Console.WriteLine("Saved and Finished");
			
		}
		public void Operations(SharableSpreadaheet Sheet, int rows, int cols, int nOperation)
			{
				Console.WriteLine("Starting Simulation\n-----------------------");
				Console.WriteLine("Number of Rows - {0}\nNumber of Cols - {1}\nNumber of Operations - {2}", rows,
					cols, nOperation);
				string[] SOB = new string[10] {"Jefry Apstain", "Kim Jung Hun", "Alla ho wakbar", "Baby Jesus", "Rami Puzis",
													"Beni Hadayag", "Aids", "Borat Sagadiev", "Kim Kardasian", "The KKK"};
				Random rnd = new Random();
				for (int i = 0; i < nOperation; i++)
				{
				Thread.Sleep(300);
					int col1 = rnd.Next(1, cols);
					int col2 = rnd.Next(col1+1, cols);

					int row1 = rnd.Next(1, rows);
					int row2 = rnd.Next(row1 + 1, rows);

					int index = rnd.Next(SOB.Length);
					string name = SOB[index];

					int func = rnd.Next(1, 12);
					Console.WriteLine("User {0}", Thread.CurrentThread.ManagedThreadId);
					Console.WriteLine("Case {0}", i + 1);

					switch (func)
					{
						case 0:
							Console.WriteLine("Saving Speardsheet...");
							Sheet.save("spreadsheet.dat");
							Console.WriteLine("Saved.\n");
							break;

						case 1:
							Console.WriteLine("Getting Size...");
							Sheet.getSize(ref rows, ref cols);
							Console.WriteLine("Size:\n({0},{1}", rows, cols);
							Console.WriteLine("Got Size.\n");
							break;

						case 2:
							Console.WriteLine("Getting cell in location ({0},{1})",row1,col1);
							string cell = Sheet.getCell(row1, col1);
							Console.WriteLine("Cell value: {0}", cell);
							Console.WriteLine("Got Cell.\n");
							break;

						case 3:
							Console.WriteLine("Setting cell {0},{1}...", row1, col1);
							Console.WriteLine("Word Choosen: {0}...", name);
							bool check = Sheet.setCell(row1, col1, name);
							if (check == true)
							{
								Console.WriteLine("Set Cell.\n");
							}
							else
							{
								Console.WriteLine("Can't Set Cell.\n");
							}
							break;

						case 4:
							Console.WriteLine("Start Searching: {0}...", name);
							bool searchCheck = Sheet.searchString(name, ref row1, ref col1);
							if (searchCheck == true)
							{
								Console.WriteLine("The string can be found in ({0},{1}).\n", row1, col1);
							}
							else
							{
								Console.WriteLine("{0} is not exist.\n", name);
							}
							break;

						case 5:
							Console.WriteLine("Start exchanging rows...");
							if (row1 == rows - 1)
							{
								row2 = row1;
								row1--;
							}
							Console.WriteLine("Rows choosen: {0},{1}...", row1, row2);
							bool exRCheck = Sheet.exchangeRows(row1, row2);
							if (exRCheck == true)
							{
								Console.WriteLine("Rows {0},{1} exchanged\n", row1, row2);
							}
							else
							{
								Console.WriteLine("Couldn't exchange.\n");
							}
							break;

						case 6:
							Console.WriteLine("Start exchanging Cols...");
							if (col1 == cols - 1)
							{
								col2 = col1;
								col1--;
							}
							Console.WriteLine("Cols choosen: {0},{1}...", col1, col2);
							bool exCCheck = Sheet.exchangeCols(col1, col2);
							if (exCCheck == true)
							{
								Console.WriteLine("Cols {0},{1} exchanged.\n", col1, col2);
							}
							else
							{
								Console.WriteLine("Couldn't exchange.\n");
							}
							break;

						case 7:
							Console.WriteLine("Start Searching...");
							Console.WriteLine("Word to Search: {0}...\nRow to Search in: {1}...", name, row1);
							bool serRcheck = Sheet.searchInRow(row1, name, ref col1);
							if (serRcheck == true)
							{
								Console.WriteLine("The word {0} was found in col {1} in row {2}.\n", name, col1, row1);
							}
							else
							{
								Console.WriteLine("The word is not in row {0}.\n", row1);
							}
							break;

						case 8:
							Console.WriteLine("Start Searching...");
							Console.WriteLine("Word to Search: {0}...\nCol to Search in: {1}...", name, col1);
							bool serCcheck = Sheet.searchInCol(col1, name, ref row2);
							if (serCcheck == true)
							{
								Console.WriteLine("The word {0} was found in row {1} in col {2}.\n", name, row1, col1);
							}
							else
							{
								Console.WriteLine("The word is not in col {0}.\n", col1);
							}
							break;

						case 9:
							Console.WriteLine("Start Searching...");
							if (col1 == cols - 1)
							{
								col2 = col1;
								col1--;
							}
							if (row1 == rows - 1)
							{
								row2 = row1;
								row1--;
							}
							Console.WriteLine("Word to Search: {0}...\nCols to Search in: {1},{2}\nRows to Search in: {3},{4}...",
								name, col1, col2, row1, row2);
							int col3 = 0;
							int row3 = 0;
							bool serInR = Sheet.searchInRange(col1, col2, row1, row2, name, ref row3, ref col3);
							if (serInR == true)
							{
								Console.WriteLine("The word {0} was found in row {1} in col {2}.\n", name, row3, col3);
							}
							else
							{
								Console.WriteLine("The word is not in exist in range.\n");
							}
							break;

						case 10:
							Console.WriteLine("Adding row after row {0}...", row1);
							bool addR = Sheet.addRow(row1);
							if (addR == true)
							{
								rows++;
								Console.WriteLine("Row {0} was added.\n", row1 + 1);
							}
							else
							{
								Console.WriteLine("Can't add the row, Sorry:(");
							}
							break;

						case 11:
							Console.WriteLine("Adding col after col {0}...", col1);
							bool addC = Sheet.addCol(col1);
							if (addC == true)
							{
								cols++;
								Console.WriteLine("Col {0} was added.\n", col1 + 1);
							}
							else
							{
								Console.WriteLine("Can't add the col, Sorry:(");
							}
							break;



					}
				}
			finished_threads++;
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
		public void DoTasks(object To_Convert)
		{
			object[] To_Convert1 = (object[])To_Convert;
			SharableSpreadaheet Sheet = (SharableSpreadaheet)To_Convert1[0];
			int rows = (int)To_Convert1[1];
			int cols = (int)To_Convert1[2];
			int nOperations = (int)To_Convert1[3];
			Operations(Sheet, rows, cols, nOperations);

		}
	}
}
