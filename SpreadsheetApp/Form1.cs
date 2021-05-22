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
			//this.Add_col_text.KeyPress += Add_col_text_KeyPress;
			this.row_get.KeyPress += row_get_KeyPress;
			this.col_get.KeyPress += col_get_KeyPress;
			this.row_set.KeyPress += row_get_KeyPress;
			this.col_set.KeyPress += col_get_KeyPress;
			this.add_col_text.KeyPress += add_col_text_KeyPress;
			toolTip1.SetToolTip(Browse_button, "Browse for the file");
			toolTip2.SetToolTip(Get_Value, "Get the value at the given Row - Col");
			toolTip3.SetToolTip(set_value, "Set the string at the desired Row - Col");
			toolTip4.SetToolTip(search_string, "Search for the desired string");
			toolTip5.SetToolTip(add_col, "Add a new column to the right of the given column");
		}

		private void Add_col_text_KeyPress(object sender, KeyPressEventArgs e)
		{
			
				e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			
		}

		public void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void Load_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
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
			Sheet.save(Browse_text.Text);
		}

		
		

		private void Add_col_text_TextChanged(object sender, EventArgs e)
		{

		}

		private void Get_Value_Click(object sender, EventArgs e)
		{
			int row = Int32.Parse(row_get.Text);
			int col = Int32.Parse(col_get.Text);
			string result=Sheet.getCell(row, col);
			if (result == "")
				result = "Empty";
			System.Windows.Forms.MessageBox.Show(result);

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void row_get_TextChanged(object sender, EventArgs e)
		{

		}
		private void row_get_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		private void add_col_text_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		
		private void col_get_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		private void row_set_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void col_set_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		private void col_get_TextChanged(object sender, EventArgs e)
		{

		}

		private void get_size_Click(object sender, EventArgs e)
		{
			int rows = 0;
			int cols = 0;
			Sheet.getSize(ref rows, ref cols);
			System.Windows.Forms.MessageBox.Show($"{rows} Rows x {cols} Columns");
		}

		private void set_value_Click(object sender, EventArgs e)
		{
			int row = Int32.Parse(row_set.Text);
			int col = Int32.Parse(col_set.Text);
			this.Sheet.setCell(row, col,Set_box.Text);
			Sheet.save(Browse_text.Text);
			Load_Click(sender, e);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void add_col_Click(object sender, EventArgs e)
		{
			int col = Int32.Parse(add_col_text.Text);
			this.Sheet.addCol(col);
			Sheet.save(Browse_text.Text);
			Load_Click(sender, e);
		}

		private void search_string_Click(object sender, EventArgs e)
		{
			int row = 0;
			int col = 0;
			bool check=Sheet.searchString(search_box.Text, ref row, ref col);
			if (check==true)
			System.Windows.Forms.MessageBox.Show($" The string '{search_box.Text}' is at ({row} , {col})");
			else
				System.Windows.Forms.MessageBox.Show($" The string '{search_box.Text}' was not found");
		}
	}
}
