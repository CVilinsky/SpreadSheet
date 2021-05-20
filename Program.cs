using System;
using System.Diagnostics;

namespace HW3
{
	class Program
	{
		static void Main(string[] args)
		{
			//SharableSpreadaheet Sheet = new SharableSpreadaheet(3, 3);
			//Sheet.setCell(1, 2, "Inbar Homo");
			//Sheet.setCell(2, 2, "Inbar Lo Homo Aval Ulay");
			//Sheet.exchangeRows(1, 2);
			//Sheet.exchangeCols(1, 2);
			//Sheet.save("sheet_t.dat");
			//Sheet.setCell(1, 2, "TT");
			////Sheet.load("sheet_t.dat");
			//Sheet.setCell(1, 2, "Chen");
			var timer = new Stopwatch();
			timer.Start();
			Simulator SIM = new Simulator(3, 3, 4, 50);
			timer.Stop();
			TimeSpan taken = timer.Elapsed;
			Console.WriteLine(taken);
			Console.WriteLine("CHecl");
			SharableSpreadasheet Sheet = new SharableSpreadasheet(3, 3);
			Sheet.load("spreadsheet.dat");
			//Sheet.addRow(4);
			Console.WriteLine("Check 2");
			//Sheet.addRow(1);
			//Console.WriteLine(Sheet.getCell(1, 2));
			//Console.WriteLine(Sheet);public partial class Form1 : Form
			
		
		}
	}
}
