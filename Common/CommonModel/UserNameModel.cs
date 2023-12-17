using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CommonModel
{
    public class UserNameInput
    {
        public int IntUserId { get; set; }
    }
    public class UserNameOutput
    {
        public int IntUserId { get; set; }
        public string StrUserName { get; set; }
        public string StrUserRole { get; set; }
    }
}
