using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DealerOrders.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://projects//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt", new string[]
            {
                "Message:" + e.Message,
                "Stacktrace:" + e.StackTrace
            });
        }
    }
}