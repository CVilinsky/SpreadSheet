using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
	public partial class Form1 : Form
	{
		SharableSpreadasheet Sheet = new SharableSpreadasheet(3, 3);
		public Form1()
		{
			InitializeComponent();
			this.Add_col_text.KeyPress += Add_col_text_KeyPress;
		}

		private void Add_col_text_KeyPress(object sender, KeyPressEventArgs e)
		{
			
				e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			
		}

		DataTable table = new DataTable();
		public void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void Load_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			int rows = 0;
			int cols = 0;
			Sheet.load(Browse_text.Text);
			Sheet.getSize(ref rows, ref cols);
			for (int i = 0; i < cols; i++)
			{
				dataGridView1.Columns.Add($"col {i + 1}", $"Column {i + 1}");
			}

			Sheet.getSize(ref rows, ref cols);
			for (int i = 0; i < rows; i++)
			{
				string[] row = new string[cols];
				for (int j = 0; j < cols; j++)
				{
					row[j] = Sheet.getCell(i, j);
				}
				dataGridView1.Rows.Add(row);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Browse_button_Click(object sender, EventArgs e)
		{
			var fDialog = new OpenFileDialog
			{
				Title = "Choose File To Read",
				InitialDirectory = @"C:\",
				Filter = "All files(*.*)|*.*|All files(*.*)|*.*",
				FilterIndex = 2,
				RestoreDirectory = true
			};
			fDialog.ShowDialog();
			Browse_text.Text = fDialog.FileName;
		}

		private void Save_button_Click(object sender, EventArgs e)
		{

		}

		
		private void Add_col_button_Click(object sender, EventArgs e)
		{
			int add_after = Int32.Parse(Add_col_text.Text);
			Sheet.addCol(add_after);
			Sheet.save("spreadsheet.dat");
			dataGridView1.Refresh();
		}

		private void Add_col_text_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
