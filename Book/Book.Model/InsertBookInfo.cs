using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common;

namespace Book.Model
{
    public class InsertBookInfoInput
    {
        [Range(1,int.MaxValue,ErrorMessage ="User Id is required")]
        public int IntUserId { get; set; }
        [Required(ErrorMessage ="Book ID is required")]
        public string StrBookID { get; set; }
        public List<BookInfoDetail> BookDetails { get; set; }       
    }
    public class InsertBookInfoOutput
    {
        [SQLOutputParam("IntReturn")]
        public int IntReturn { get; set; }
    }
    public class InsertBookInfoInputDB
    {
        public int IntUserId { get; set; }
        public string StrBookID { get; set; }
        public string JsonBookDetails { get; set; }
        [SQLOutputParam("IntReturn")]
        public int IntReturn { get; set; }
    }
}
