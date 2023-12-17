using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    public class GetBookFilterValuesInput
    {
        public string StrTag { get; set; }
    }
    public class GetBookFilterValuesOutput
    {
        public List<AuthorFilterOutput> AuthorsFilter { get; set; }
        public List<CatagoryFilterOutput> CatagoryFilter { get; set; }
    }
    public class AuthorFilterOutput
    {
        public string StrAuthorID { get; set; }
        public string StrAuthorName { get; set; }
        public string StrAuthorLastName { get; set; }
        public string StrFullName { get; set; }
    }
    public class CatagoryFilterOutput
    {
        public string StrCatagoryId { get; set; }
        public string StrCatagoryName { get; set; }
    }
}
