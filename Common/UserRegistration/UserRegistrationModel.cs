using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class UserRegistrationInput
    {
        [RegularExpression(@"^[a-zA-Z0-9 ]*$",ErrorMessage ="Name cannot contain special character")]
        [StringLength(maximumLength:50,ErrorMessage ="Name length cannot be more than 50 characters",MinimumLength =1)]
        public string StrName { get; set; }
        [Compare("StrReEnterPassword",ErrorMessage ="Password and Re-enter password doesn't match")]
        [StringLength(maximumLength: 50, ErrorMessage = "Password length cannot be more than 50 characters", MinimumLength = 1)]
        public string StrPassWord { get; set; }
        [NotMapped]
        [StringLength(maximumLength: 50, ErrorMessage = "Password length cannot be more than 50 characters", MinimumLength = 1)]
        public string StrReEnterPassword { get; set; }
        [EmailAddress]
        public string StrEmailID { get; set; }
        [Phone]
        public string StrMobileNumber { get; set; }

        public string StrRole { get; set; }
        [SQLOutputParam("IntReturn")]
        public int IntReturn { get; set; }
    }
    public class UserRegistrationOutput
    {
        [SQLOutputParam("IntReturn")]
        public int IntReturn { get; set; }
    }
}
