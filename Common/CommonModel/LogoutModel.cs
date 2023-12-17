using System;
using System.Collections.Generic;
using System.Text;

namespace Common.LoginAndLogout
{
    public class LogoutInput
    {
        public int IntUserId { get; set; }
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
    public class LogoutOutput
    {
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
}
