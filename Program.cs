using System;

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
			Simulator SIM = new Simulator(5, 5, 1, 10);
			Console.WriteLine("CHecl");

			//Sheet.addRow(1);
			//Console.WriteLine(Sheet.getCell(1, 2));
			//Console.WriteLine(Sheet);
		}
	}
}
