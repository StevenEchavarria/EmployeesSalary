using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesSalary.Common.Utils
{
    public static class Log
    {
        public static void WriteLog(string text)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
            {
                file.WriteLine(text);
            }

            /*
             public static void LogErrorMessage(Exception e, string Directory)
{
    using (StreamWriter w = File.AppendText(Directory + "/log.txt"))
    {
         Log(e.ToString(),w);
         w.Close();
    }

}
ASPX Class

public void Page_Load()
   {
      Logger.LogErrorMessage(ex, Server.MapPath("~"));

   }*/
        }
    }
}
