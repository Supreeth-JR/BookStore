using System;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class UserLoginInput
    {
        [EmailAddress]
        public string StrEmail { get; set; }
        public string StrPassword { get; set; }
    }
    public class UserLoginOutput
    {
        public int IntUserID { get; set; }
        public string StrEmail { get; set; }        
        public Guid strSession { get; set; }
        public string StrToken { get; set; }
        public string StrUserRole { get; set; }
    }
}
