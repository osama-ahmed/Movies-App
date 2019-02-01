using System;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Movie_App.Models
{
    class MyExcel
    {
        public static string DB_PATH = @"";
        public static BindingList<Movie> movieList = new BindingList<Movie>();
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow=0;


        public static void InitializeExcel()
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(DB_PATH);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
            lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            lastRow = 1;
        }

        public static BindingList<Movie> ReadMyExcel()
        {
            movieList.Clear();
            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "G" + index.ToString()).Cells.Value;
                movieList.Add(new Movie
                                        { 
                                            name = MyValues.GetValue(1,2).ToString(),
                                            year = Convert.ToInt32(MyValues.GetValue(1,3))
                                            /*type = MyValues.GetValue(1,4).ToString(),
                                            language = MyValues.GetValue(1,5).ToString(),
                                            img=MyValues.GetValue(1,6).ToString(),
                                            watched=(bool)MyValues.GetValue(1,7)*/
                                        });
            }
            return movieList;
        }

        public static void WriteToExcel(Movie movie)
        {
            try
            {
                lastRow += 1;
                MySheet.Cells[lastRow, 2] = movie.name;
                MySheet.Cells[lastRow, 3] = movie.year;
                MySheet.Cells[lastRow, 4] = movie.type;
                MySheet.Cells[lastRow, 5] = movie.language;
                MySheet.Cells[lastRow, 6] = movie.img;
                MySheet.Cells[lastRow, 7] = movie.watched;
                MyBook.Save();
            }
            catch (Exception ex)
            { }

        }

        /*public static List<Employee> FilterEmpList(string searchValue, string searchExpr)
        {
            List<Employee> FilteredList = new List<Employee>();

            switch (searchValue.ToUpper())
            {
                case "NAME":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Name.ToLower().Contains(searchExpr));
                    break;
                case "MOBILE_NO":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Number.ToLower().Contains(searchExpr));
                    break;
                case "EMPLOYEE_ID":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Employee_ID.ToLower().Contains(searchExpr));
                    break;
                case "EMAIL_ID":
                    FilteredList = EmpList.ToList().FindAll(emp => emp.Email_ID.ToLower().Contains(searchExpr));
                    break;
                default:
                    break;
            }
            return FilteredList;
        }*/

        public static void CloseExcel()
        {
            MyBook.Saved = true;
            MyApp.Quit();

        }
        
    }
    
}
