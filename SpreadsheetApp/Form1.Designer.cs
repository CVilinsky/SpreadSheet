
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Load = new System.Windows.Forms.Button();
			this.Browse_text = new System.Windows.Forms.TextBox();
			this.Browse_button = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.Save_button = new System.Windows.Forms.Button();
			this.Add_col_button = new System.Windows.Forms.Button();
			this.Add_col_text = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
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
			this.Save_button.Location = new System.Drawing.Point(651, 82);
			this.Save_button.Name = "Save_button";
			this.Save_button.Size = new System.Drawing.Size(139, 23);
			this.Save_button.TabIndex = 4;
			this.Save_button.Text = "Save";
			this.Save_button.UseVisualStyleBackColor = true;
			this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
			// 
			// Add_col_button
			// 
			this.Add_col_button.Location = new System.Drawing.Point(651, 111);
			this.Add_col_button.Name = "Add_col_button";
			this.Add_col_button.Size = new System.Drawing.Size(75, 23);
			this.Add_col_button.TabIndex = 5;
			this.Add_col_button.Text = "Add Col";
			this.Add_col_button.UseVisualStyleBackColor = true;
			this.Add_col_button.Click += new System.EventHandler(this.Add_col_button_Click);
			// 
			// Add_col_text
			// 
			this.Add_col_text.Location = new System.Drawing.Point(732, 112);
			this.Add_col_text.Name = "Add_col_text";
			this.Add_col_text.Size = new System.Drawing.Size(58, 23);
			this.Add_col_text.TabIndex = 6;
			this.Add_col_text.TextChanged += new System.EventHandler(this.Add_col_text_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(943, 450);
			this.Controls.Add(this.Add_col_text);
			this.Controls.Add(this.Add_col_button);
			this.Controls.Add(this.Save_button);
			this.Controls.Add(this.Browse_button);
			this.Controls.Add(this.Browse_text);
			this.Controls.Add(this.Load);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
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
		private System.Windows.Forms.Button Add_col_button;
		private System.Windows.Forms.TextBox Add_col_text;
	}
}

