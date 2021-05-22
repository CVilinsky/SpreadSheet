
namespace SpreadsheetApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Load = new System.Windows.Forms.Button();
			this.Browse_text = new System.Windows.Forms.TextBox();
			this.Browse_button = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.Save_button = new System.Windows.Forms.Button();
			this.Get_Value = new System.Windows.Forms.Button();
			this.row_get = new System.Windows.Forms.TextBox();
			this.col_get = new System.Windows.Forms.TextBox();
			this.row = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.get_size = new System.Windows.Forms.Button();
			this.set_value = new System.Windows.Forms.Button();
			this.row_set = new System.Windows.Forms.TextBox();
			this.col_set = new System.Windows.Forms.TextBox();
			this.Set_box = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.add_col = new System.Windows.Forms.Button();
			this.add_col_text = new System.Windows.Forms.TextBox();
			this.search_string = new System.Windows.Forms.Button();
			this.search_box = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new System.Drawing.Size(645, 418);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// Load
			// 
			this.Load.Location = new System.Drawing.Point(792, 41);
			this.Load.Name = "Load";
			this.Load.Size = new System.Drawing.Size(139, 23);
			this.Load.TabIndex = 1;
			this.Load.Text = "Load";
			this.Load.UseVisualStyleBackColor = true;
			this.Load.Click += new System.EventHandler(this.Load_Click);
			// 
			// Browse_text
			// 
			this.Browse_text.Location = new System.Drawing.Point(651, 12);
			this.Browse_text.Name = "Browse_text";
			this.Browse_text.Size = new System.Drawing.Size(280, 23);
			this.Browse_text.TabIndex = 2;
			// 
			// Browse_button
			// 
			this.Browse_button.Location = new System.Drawing.Point(651, 41);
			this.Browse_button.Name = "Browse_button";
			this.Browse_button.Size = new System.Drawing.Size(139, 23);
			this.Browse_button.TabIndex = 3;
			this.Browse_button.Text = "Browse";
			this.Browse_button.UseVisualStyleBackColor = true;
			this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
			// 
			// Save_button
			// 
			this.Save_button.Location = new System.Drawing.Point(725, 86);
			this.Save_button.Name = "Save_button";
			this.Save_button.Size = new System.Drawing.Size(139, 23);
			this.Save_button.TabIndex = 4;
			this.Save_button.Text = "Save";
			this.Save_button.UseVisualStyleBackColor = true;
			this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
			// 
			// Get_Value
			// 
			this.Get_Value.Location = new System.Drawing.Point(651, 130);
			this.Get_Value.Name = "Get_Value";
			this.Get_Value.Size = new System.Drawing.Size(139, 23);
			this.Get_Value.TabIndex = 5;
			this.Get_Value.Text = "Get Value";
			this.Get_Value.UseVisualStyleBackColor = true;
			this.Get_Value.Click += new System.EventHandler(this.Get_Value_Click);
			// 
			// row_get
			// 
			this.row_get.Location = new System.Drawing.Point(810, 130);
			this.row_get.Name = "row_get";
			this.row_get.Size = new System.Drawing.Size(30, 23);
			this.row_get.TabIndex = 6;
			this.row_get.TextChanged += new System.EventHandler(this.row_get_TextChanged);
			// 
			// col_get
			// 
			this.col_get.Location = new System.Drawing.Point(866, 131);
			this.col_get.Name = "col_get";
			this.col_get.Size = new System.Drawing.Size(30, 23);
			this.col_get.TabIndex = 8;
			this.col_get.TextChanged += new System.EventHandler(this.col_get_TextChanged);
			// 
			// row
			// 
			this.row.AutoSize = true;
			this.row.Location = new System.Drawing.Point(810, 112);
			this.row.Name = "row";
			this.row.Size = new System.Drawing.Size(30, 15);
			this.row.TabIndex = 9;
			this.row.Text = "Row";
			this.row.Click += new System.EventHandler(this.label1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(866, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 15);
			this.label1.TabIndex = 10;
			this.label1.Text = "Col";
			// 
			// get_size
			// 
			this.get_size.Location = new System.Drawing.Point(651, 279);
			this.get_size.Name = "get_size";
			this.get_size.Size = new System.Drawing.Size(139, 23);
			this.get_size.TabIndex = 11;
			this.get_size.Text = "Get Size";
			this.get_size.UseVisualStyleBackColor = true;
			this.get_size.Click += new System.EventHandler(this.get_size_Click);
			// 
			// set_value
			// 
			this.set_value.Location = new System.Drawing.Point(651, 159);
			this.set_value.Name = "set_value";
			this.set_value.Size = new System.Drawing.Size(139, 23);
			this.set_value.TabIndex = 12;
			this.set_value.Text = "Set Value";
			this.set_value.UseVisualStyleBackColor = true;
			this.set_value.Click += new System.EventHandler(this.set_value_Click);
			// 
			// row_set
			// 
			this.row_set.Location = new System.Drawing.Point(810, 160);
			this.row_set.Name = "row_set";
			this.row_set.Size = new System.Drawing.Size(30, 23);
			this.row_set.TabIndex = 13;
			// 
			// col_set
			// 
			this.col_set.Location = new System.Drawing.Point(866, 160);
			this.col_set.Name = "col_set";
			this.col_set.Size = new System.Drawing.Size(30, 23);
			this.col_set.TabIndex = 14;
			// 
			// Set_box
			// 
			this.Set_box.Location = new System.Drawing.Point(792, 189);
			this.Set_box.Name = "Set_box";
			this.Set_box.Size = new System.Drawing.Size(121, 23);
			this.Set_box.TabIndex = 15;
			this.Set_box.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(681, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 20);
			this.label2.TabIndex = 16;
			this.label2.Text = "Text to Set";
			// 
			// add_col
			// 
			this.add_col.Location = new System.Drawing.Point(651, 250);
			this.add_col.Name = "add_col";
			this.add_col.Size = new System.Drawing.Size(139, 23);
			this.add_col.TabIndex = 17;
			this.add_col.Text = "Add Column";
			this.add_col.UseVisualStyleBackColor = true;
			this.add_col.Click += new System.EventHandler(this.add_col_Click);
			// 
			// add_col_text
			// 
			this.add_col_text.Location = new System.Drawing.Point(810, 250);
			this.add_col_text.Name = "add_col_text";
			this.add_col_text.Size = new System.Drawing.Size(30, 23);
			this.add_col_text.TabIndex = 18;
			// 
			// search_string
			// 
			this.search_string.Location = new System.Drawing.Point(651, 221);
			this.search_string.Margin = new System.Windows.Forms.Padding(2);
			this.search_string.Name = "search_string";
			this.search_string.Size = new System.Drawing.Size(139, 23);
			this.search_string.TabIndex = 21;
			this.search_string.Text = "Search String";
			this.search_string.UseVisualStyleBackColor = true;
			this.search_string.Click += new System.EventHandler(this.search_string_Click);
			// 
			// search_box
			// 
			this.search_box.Location = new System.Drawing.Point(792, 222);
			this.search_box.Margin = new System.Windows.Forms.Padding(2);
			this.search_box.Name = "search_box";
			this.search_box.Size = new System.Drawing.Size(121, 23);
			this.search_box.TabIndex = 22;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(1007, 450);
			this.Controls.Add(this.search_box);
			this.Controls.Add(this.search_string);
			this.Controls.Add(this.add_col_text);
			this.Controls.Add(this.add_col);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Set_box);
			this.Controls.Add(this.col_set);
			this.Controls.Add(this.row_set);
			this.Controls.Add(this.set_value);
			this.Controls.Add(this.get_size);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.row);
			this.Controls.Add(this.col_get);
			this.Controls.Add(this.row_get);
			this.Controls.Add(this.Get_Value);
			this.Controls.Add(this.Save_button);
			this.Controls.Add(this.Browse_button);
			this.Controls.Add(this.Browse_text);
			this.Controls.Add(this.Load);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "SpreadsheetApp";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button Load;
		private System.Windows.Forms.TextBox Browse_text;
		private System.Windows.Forms.Button Browse_button;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button Save_button;
		private System.Windows.Forms.Button Get_Value;
		private System.Windows.Forms.TextBox row_get;
		private System.Windows.Forms.TextBox col_get;
		private System.Windows.Forms.Label row;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button get_size;
		private System.Windows.Forms.Button set_value;
		private System.Windows.Forms.TextBox row_set;
		private System.Windows.Forms.TextBox col_set;
		private System.Windows.Forms.TextBox Set_box;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button add_col;
		private System.Windows.Forms.TextBox add_col_text;
		private System.Windows.Forms.Button search_string;
		private System.Windows.Forms.TextBox search_box;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.Windows.Forms.ToolTip toolTip3;
		private System.Windows.Forms.ToolTip toolTip4;
		private System.Windows.Forms.ToolTip toolTip5;
		private System.Windows.Forms.ToolTip toolTip6;
	}
}

