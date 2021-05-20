using System;
using System.IO;
using System.Threading;

public class SharableSpreadasheet
{
    string[,] Sheet;
    int rowL;
    int colL;
    bool LimitSet;
    Semaphore SearchLimit;
    Mutex[] Mutex_array_row;
    Mutex[] Mutex_array_col;
    Mutex add_row;
    Mutex add_col;
    /*
     * In the constructor I create the mutex locks, and an initial "SearchLimit" for the setConcurent function
     * I hold a mutex for each row, and for each column (in conclusion m+n mutexes)
     * to make sure I have no problems, in each given time only one row/column can be added
     */
    public SharableSpreadasheet(int nRows, int nCols)
    {
        // construct a nRows*nCols spreadsheet
        this.SearchLimit = new Semaphore(1, 1);
        this.Sheet = new string[nRows, nCols];
        this.add_col = new Mutex();
        this.add_row = new Mutex() ;
        this.Mutex_array_row = new Mutex[nRows];
        for (int i = 0; i < nRows; i++)
            Mutex_array_row[i] = new Mutex();
        this.Mutex_array_col = new Mutex[nCols];
        for (int i = 0; i < nCols; i++)
            Mutex_array_col[i] = new Mutex();
        this.rowL = nCols;
        this.colL = nRows;
    }
    public String getCell(int row, int col)
    {
        // return the string at [row,col]
        string to_ret;
        to_ret = this.Sheet[row, col];
        return to_ret;
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
        if (LimitSet == true) //check the flag if setConcurrent was activated
		{
            SearchLimit.WaitOne();
            Console.WriteLine("Increased Search Limit");
        }
            
        for (int i=0;i<this.colL;i++)
        {
            for (int j = 0; j < this.rowL; j++)
			{
                if (getCell(i,j)==str)
				{
                    row = i;
                    col = j;
                    if (LimitSet == true)
                    {
                        try
                        {
                            SearchLimit.Release();
                            Console.WriteLine("Decreased Search Limit");
                        }
                        catch { }

                    }
                    return true;
				}
			}
		}
        if (LimitSet == true)
            try { SearchLimit.Release();
                Console.WriteLine("Decreased Search Limit");
            }
            catch { }
        return false;
    }
    /*
     * First of all, lock the two rows that are going to be switched, I do so with the mutex.
     * afterwards, use a temp variable that will hold the content of a cell and this way I switch.
     * after the rows have been exchanged, unlock the mutex.
     */
    public bool exchangeRows(int row1, int row2)
    {
        // exchange the content of row1 and row2
        Mutex_array_row[row1].WaitOne(); 
        Mutex_array_row[row2].WaitOne();
        string temp;
        for (int i=1;i<rowL;i++)
		{
            temp = this.Sheet[row1, i];
			this.Sheet[row1, i] = this.Sheet[row2, i];
			this.Sheet[row2, i] = temp;
		}
        Mutex_array_row[row1].ReleaseMutex();
        Mutex_array_row[row2].ReleaseMutex();
        return true;
    }
    /*
     * The same as for the Rows.
     */
    public bool exchangeCols(int col1, int col2)
    {
        // exchange the content of col1 and col2
        this.Mutex_array_col[col1].WaitOne();
        this.Mutex_array_col[col2].WaitOne();
        string temp;
        for (int i=1;i<colL;i++)
		{
            temp = Sheet[i, col1];
            this.Sheet[i, col1] = this.Sheet[i, col2];
            this.Sheet[i, col2] = temp;
        }
        this.Mutex_array_col[col1].ReleaseMutex();
        this.Mutex_array_col[col2].ReleaseMutex();
        return true;
    }
    /*
     * I lock the row that I need to look inside, to make sure things will not change while I look for the string.
     * Release the mutex in the end.
     */
    public bool searchInRow(int row, String str, ref int col)
    {
        // perform search in specific row
        if (LimitSet == true)
		{
            SearchLimit.WaitOne();
            Console.WriteLine("Increased Search Limit");
        }
            
        this.Mutex_array_row[row].WaitOne();
        for (int i=1;i<rowL;i++)
		{
            if (this.Sheet[row, i] == str)
            {
                col = i;
                this.Mutex_array_row[row].ReleaseMutex();
                if (LimitSet == true)
                {
                    try
                    {
                        SearchLimit.Release();
                        Console.WriteLine("Decreased Search Limit");
                    }
                    catch { }

                }
                return true;
            }
		}
        if (LimitSet == true)
            try { SearchLimit.Release();
                Console.WriteLine("Decreased Search Limit");
            }
            catch { }
        this.Mutex_array_row[row].ReleaseMutex();
        return false;
    }
    /*
     * Same as in the Row function. 
     */
    public bool searchInCol(int col, String str, ref int row)
    {
        // perform search in specific col
        if (LimitSet == true) { 
            SearchLimit.WaitOne();
            Console.WriteLine("Increased Search Limit");
        }
        Mutex_array_col[col].WaitOne();
        for (int i = 1; i < colL; i++)
        {
            if (this.Sheet[i, col] == str)
            {
                row = i;
                Mutex_array_col[col].ReleaseMutex();
                if (LimitSet == true)
                {
                    try
                    {
                        SearchLimit.Release();
                        Console.WriteLine("Decreased Search Limit");
                    }
                    catch { }

                }
                return true;
            }
        }
        if (LimitSet == true)
            try { SearchLimit.Release();
                Console.WriteLine("Decreased Search Limit");
            }
            catch { }

            Mutex_array_col[col].ReleaseMutex();
        return false;
    }
    /*
     * In this function I don't lock the range, because it might lock the whole sheet, an extreme aproach.
     * if anywhere I find the string, I set the row and col references.
     * afterwards I exit the function.
     */
    public bool searchInRange(int col1, int col2, int row1, int row2, String str, ref int row, ref int col)
    {
        // perform search within spesific range: [row1:row2,col1:col2] 
        //includes col1,col2,row1,row2
        if (LimitSet == true)
		{
            SearchLimit.WaitOne();
            Console.WriteLine("Increased Search Limit");
        }
            
        for (int i = col1; i <= col2; i++)
        {
            for (int j=row1;j<=row2;j++)
			{
                if (this.Sheet[j, i] == str)
				{
                    row = j;
                    col = i;
                    if (LimitSet == true)
                    {
                        try
                        {
                            SearchLimit.Release();
                            Console.WriteLine("Decreased Search Limit");
                        }
                        catch { }

                    }
                    return true;
                }
			}
            break;
        }
        if (LimitSet == true) {
            try { SearchLimit.Release();
                Console.WriteLine("Decreased Search Limit");
            }
            catch { }

            }
            
        return false;
    }
    /*First I use the add_row mutex, to make sure no other rows are added for now.
     * I create a new spreadsheet, and a larger mutex array for the rows.
     * I copy the content of the last mutex_array and add a new mutex in the end.
     * I lock all the rows under the desired row.
     * Now I copy all the cells from the first spreadsheet above the desired row.
     * When we finish that we copy the content of the first spreadsheet to the new one, but 2 rows under the desired row.
     * afterwards, unlock the mutexs in the array, and the add_row mutex.
     * 
     */
    public bool addRow(int row1)
    {
        //add a row after row1
        this.add_row.WaitOne();
        SharableSpreadasheet NewS = new SharableSpreadasheet(this.colL + 1, this.rowL);
        Mutex[] NewMutex_array = new Mutex[colL+1];
        Array.Copy(this.Mutex_array_row, 0, NewMutex_array, 0, colL);
        this.Mutex_array_row = NewMutex_array;
        this.Mutex_array_row[colL] = new Mutex();
        for (int i=row1+1;i<colL;i++)
		{
            this.Mutex_array_row[i].WaitOne();
		}
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
            {
                NewS.Sheet[i, j] = this.Sheet[i-1, j];
            }
		}
        for (int i = row1 + 1; i < colL; i++)
        {
            this.Mutex_array_row[i].ReleaseMutex();
        }

        this.Sheet = NewS.Sheet;
        this.colL++;
        this.add_row.ReleaseMutex();
        return true;
    }
    /*
     * Same as for the addRow.
     */
    public bool addCol(int col1)
    {
        //add a column after col1
        this.add_col.WaitOne();
        SharableSpreadasheet NewS = new SharableSpreadasheet(colL, rowL + 1);
        Mutex[] NewMutex_array = new Mutex[rowL + 1];
        Array.Copy(this.Mutex_array_col, 0, NewMutex_array, 0, rowL);
        this.Mutex_array_col = NewMutex_array;
        this.Mutex_array_col[rowL] = new Mutex();
        for (int i = col1 + 1; i < rowL; i++)
        {
            this.Mutex_array_col[i].WaitOne();
        }
        for (int i=0;i<=col1;i++)
		{
            for (int j=0;j<colL;j++)
			{
                NewS.Sheet[j, i] = this.Sheet[j, i];
			}
		}
        for (int i=col1+2;i<NewS.rowL;i++)
		{
            for (int j = 0; j < colL; j++)
                NewS.Sheet[j, i] = this.Sheet[j, i-1];
		}
        for (int i = col1 + 1; i < rowL; i++)
        {
            this.Mutex_array_col[i].ReleaseMutex();
        }
        this.Sheet = NewS.Sheet;
        this.rowL++;
        this.add_col.ReleaseMutex();
        return true;
    }
    public void getSize(ref int nRows, ref int nCols)
    {
        // return the size of the spreadsheet in nRows, nCols
        nRows = this.colL;
        nCols = this.rowL;

    }
    /*
     * Set the searchlimit, also raise the flag that a searchlimit has been set.
     */
    public bool setConcurrentSearchLimit(int nUsers)
    {
        // this function aims to limit the number of users that can perform the search operations concurrently.
        // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
        // In this case additional search operations will wait for existing search to finish.
        this.SearchLimit = new Semaphore(nUsers, nUsers);
        LimitSet = true;
        return true;
    }
    /*
     * Save the spreadsheet in a "csv" format.
     */
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
    /*
     * load the spreadsheet and populate it.
     * also, create the mutex arrays.
     */
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
            this.Mutex_array_row = new Mutex[nRow];
            for (int i = 0; i < nRow; i++)
                Mutex_array_row[i] = new Mutex();
            this.Mutex_array_col = new Mutex[nCol];
            for (int i = 0; i < nCol; i++)
                Mutex_array_col[i] = new Mutex();
            this.rowL = nCol;
            this.colL = nRow;

        }
            return true;
    }
}



