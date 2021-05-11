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
		public Simulator(int rows, int cols, int nThreads, int nOperations)
		{
			SharableSpreadaheet Sheet = new SharableSpreadaheet(rows, cols);
			OP(Sheet, getFunc(nOperations), rows, cols, nOperations);
			//for (int i = 0; i < nThreads; i++)
			//{
			//	//ThreadPool.QueueUserWorkItem(new WaitCallback(DoTasks));
			//}

		}
		public String OP(SharableSpreadaheet Sheet, string[] func, int rows, int cols, int nOperation)
		{
			Console.WriteLine("Starting Simulation\n-----------------------");
			Console.WriteLine("Number of Rows - {0}\nNumber of Cols - {1}\n Number of Operations - {2}", rows,
				cols, nOperation);
			
			string[] SOB = new string[10] {"Jefry Apstain", "Kim Jung Hun", "Alla ho wakbar", "Baby Jesus", "Rami Puzis",
													"Beni Hadayag", "Aids", "Borat Sagadiev", "Kim Kardasian", "The KKK"};
			Console.WriteLine("\nStart casing:");
			for (int i = 0; i < nOperation; i++)
			{
				int[] nRow = new int[rows];
				int[] nCol = new int[cols];
				Console.WriteLine("Case {0}", i + 1);
				//random setup
				Random rnd = new Random(69);
				int col1 = rnd.Next(1, cols + 1);
				int row1 = rnd.Next(1, rows + 1);
				if (col1 == cols)
				{
					col1 = rnd.Next(1, cols);
				}
				if (row1 == rows)
				{
					row1 = rnd.Next(1, rows);
				}
				int col2 = rnd.Next(col1, cols);
				int row2 = rnd.Next(row1, rows);
				string name = SOB[rnd.Next(SOB.Length)];

				string oper = func[i];
				switch (oper)
				{
					case "save":
						Console.WriteLine("Saving Speardsheet...");
						Sheet.save("spreadsheet.dat");
						Console.WriteLine("Saved.\n");
						break;

					case "getSize":
						Console.WriteLine("Getting Size...");
						Sheet.getSize(ref rows, ref cols);
						Console.WriteLine("Size:\n({0},{1}", rows, cols);
						Console.WriteLine("Got Size.\n");
						break;

					case "getCell":
						Console.WriteLine("Getting cell...");
						string cell = Sheet.getCell(row1, col1);
						Console.WriteLine("Cell value: {0}", cell);
						Console.WriteLine("Got Cell.\n");
						break;

					case "setCell":
						Console.WriteLine("Setting cell ({0},{1})...");
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

					case "searchString":
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

					case "exchangeRows":
						Console.WriteLine("Start exchanging rows...");
						if (row1 == rows)
						{
							row1 = rnd.Next(1, row2);
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

					case "exchangeCols":
						Console.WriteLine("Start exchanging Cols...");
						if (col1 == cols)
						{
							col1 = rnd.Next(1, col2);
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

					case "searchInRow":
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


					case "searchInCol":
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

					case "searchInRange":
						Console.WriteLine("Start Searching...");
						Console.WriteLine("Word to Search: {0}...\nCols to Search in: {1},{2}\n Rows to Search in: {3},{4}...",
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

					case "addRow":
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

					case "addCol":
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
