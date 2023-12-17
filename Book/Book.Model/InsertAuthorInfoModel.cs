using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Model
{
    public class InsertAuthorInfoInput
    {
        [StringLength(50,ErrorMessage ="Author name must be in 50 length")]
        [Required(ErrorMessage ="Author Name required")]
        public string StrAuthorName { get; set; }
        [StringLength(50, ErrorMessage = "Author name must be in 50 length")]        
        public string StrAuthorLastName { get; set; }
        [StringLength(50, ErrorMessage = "Author country must be in 50 length")]
        public string StrAuthorCountry { get; set; }
        public DateTime? DtAuthorDOB { get; set; }
        [StringLength(1000, ErrorMessage = "Author about must be in 50 length")]
        [Required(ErrorMessage ="Author about is required")]
        public string StrAuthorAbout { get; set; }
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
    public class InsertAuthorInfoOutput
    {
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
    public class InsertCatagoryInput
    {
        public string StrCatagoryName { get; set; }
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
}
