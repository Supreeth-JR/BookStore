using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ECommerceLogger
    {
        public int GetLoggedID(Exception exception)
        {
            ExceptionLoggerInput ObjInput = new ExceptionLoggerInput()
            {
                ErrorMsg = exception.Message,
                StackTrace = exception.StackTrace,
            };
            ExceptionLoggerOutput ObjOutput = new ECommerceDAL("ConnectionString").
                ExecuteSPWithOutputParam<ExceptionLoggerOutput, ExceptionLoggerInput>("COM.Exception_Logger", ObjInput);
            return ObjOutput.IntLogID;
        }
    }
    public class ExceptionLoggerInput
    {
        public string ErrorMsg { get; set; }
        public string StackTrace { get; set; }
        [SQLOutputParam("IntLogID")]
        public int IntLogID { get; set; }

    }
    public class ExceptionLoggerOutput
    {
        [SQLOutputParam("IntLogID")]
        public int IntLogID { get; set; }
    }
    public class response
    {
        public static string ContentType { get; set; }
        public string message { get; set; }
        public int StatusCode { get; set; }
    }
}
