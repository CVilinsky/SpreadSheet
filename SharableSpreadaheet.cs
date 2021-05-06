using System;
using System.IO;

class SharableSpreadaheet
{
    string[,] Sheet;
    int rowL;
    int colL;
    public SharableSpreadaheet(int nRows, int nCols)
    {
        // construct a nRows*nCols spreadsheet
        this.Sheet = new string[nRows, nCols];
        this.rowL = nCols;
        this.colL = nRows;
    }
    public String getCell(int row, int col)
    {
        // return the string at [row,col]

        return this.Sheet[row,col];
    }
    public bool setCell(int row, int col, String str)
    {
        // set the string at [row,col]
        this.Sheet[row, col] = str;
        //Console.WriteLine("Cell [{0},{1}] changed to {2}", row, col, str);
        return true;
    }
    public bool searchString(String str, ref int row, ref int col)
    {
        // search the cell with string str, and return true/false accordingly.
        // stores the location in row,col.
        // return the first cell that contains the string (search from first row to the last row)
        return true;
    }
    public bool exchangeRows(int row1, int row2)
    {
        // exchange the content of row1 and row2
        string temp;
        for (int i=1;i<rowL;i++)
		{
            temp = this.Sheet[row1, i];
            this.Sheet[row1, i] = this.Sheet[row2, i];
            this.Sheet[row2, i] = temp;
		}
        return true;
    }
    public bool exchangeCols(int col1, int col2)
    {
        // exchange the content of col1 and col2
        string temp;
        for (int i=1;i<colL;i++)
		{
            temp = Sheet[i, col1];
            this.Sheet[i, col1] = this.Sheet[i, col2];
            this.Sheet[i, col2] = temp;

        }
        return true;
    }
    public bool searchInRow(int row, String str, ref int col)
    {
        // perform search in specific row
        for (int i=1;i<rowL;i++)
		{
            if (this.Sheet[row, i] == str)
            {
                col = i;
                break;
            }
		}
        return true;
    }
    public bool searchInCol(int col, String str, ref int row)
    {
        // perform search in specific col
        for (int i = 1; i < colL; i++)
        {
            if (this.Sheet[i, col] == str)
            {
                row = i;
                break;
            }
        }
        return true;
    }
    public bool searchInRange(int col1, int col2, int row1, int row2, String str, ref int row, ref int col)
    {
        // perform search within spesific range: [row1:row2,col1:col2] 
        //includes col1,col2,row1,row2
        for (int i = col1; i <= col2; i++)
        {
            for (int j=row1;j<=row2;j++)
			{
                if (this.Sheet[j, i] == str)
				{
                    row = j;
                    col = i;
                    break;
				}
			}
            break;
        }
        return true;
    }
    public bool addRow(int row1)
    {
        //add a row after row1
        SharableSpreadaheet NewS = new SharableSpreadaheet(this.colL + 1, this.rowL);

        for (int i=0;i<=row1;i++)
		{
            for (int j = 0; j < this.rowL; j++)
            { 
                NewS.Sheet[i, j] = this.Sheet[i, j];
            }
        }
        for (int i=row1+2;i<NewS.colL;i++)
		{
            for (int j = 0; j < this.rowL; j++)
                NewS.Sheet[i, j] = this.Sheet[i-1, j];
		}
        this.Sheet = NewS.Sheet;
        this.colL++;
        return true;
    }
    public bool addCol(int col1)
    {
        //add a column after col1
        SharableSpreadaheet NewS = new SharableSpreadaheet(colL, rowL + 1);
        for (int i=0;i<=col1;i++)
		{
            for (int j=0;j<colL;j++)
			{
                NewS.Sheet[i, j] = this.Sheet[i, j];
			}
		}
        for (int i=col1+2;i<NewS.rowL;i++)
		{
            for (int j = 0; j < colL; j++)
                NewS.Sheet[i, j] = this.Sheet[i, j-1];
		}
        this.Sheet = NewS.Sheet;
        this.rowL++;
        return true;
    }
    public void getSize(ref int nRows, ref int nCols)
    {
        // return the size of the spreadsheet in nRows, nCols
        nRows = this.colL;
        nCols = this.rowL;

    }
    public void setConcurrentSearchLimit(int nUsers)
    {
        // this function aims to limit the number of users that can perform the search operations concurrently.
        // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
        // In this case additional search operations will wait for existing search to finish.
    }

    public bool save(String fileName)
    {
        // save the spreadsheet to a file fileName.
        // you can decide the format you save the data. There are several options.
        using (StreamWriter file= new StreamWriter(fileName))
		{
            for (int i=0;i<this.colL;i++)
			{
                string data = "";
                for (int j = 0; j < this.rowL; j++)
                { 
                    data += this.Sheet[i, j] + ",";
                }
                file.WriteLine(data);
            }
           
		}
        return true;
    }
    public bool load(String fileName)
    {
        // load the spreadsheet from fileName
        // replace the data and size of the current spreadsheet with the loaded data
        using (StreamReader r = new StreamReader(fileName))
		{
            string[] lines = File.ReadAllLines(fileName);
            int nCol = lines[0].Split(',').Length - 1;
            int nRow = lines.Length;

            string[,] NSheet = new string[nRow,nCol];
            for (int i=0;i<nRow;i++)
			{
                for (int j=0;j<nCol;j++)
				{
                    NSheet[i, j] = lines[i].Split(",")[j];
				}
			}
            this.Sheet = NSheet;
		}
            return true;
    }
}



