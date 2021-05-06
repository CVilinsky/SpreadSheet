using System;

namespace HW3
{
	class Program
	{
		static void Main(string[] args)
		{
			SharableSpreadaheet Sheet = new SharableSpreadaheet(10, 10);
			Sheet.setCell(1, 1, "Inbar Homo");
			//Console.WriteLine(Sheet.getCell(1, 1));
			//Console.WriteLine(Sheet);
		}
	}
}
