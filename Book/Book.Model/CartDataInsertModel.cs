using Common;
using System.Collections.Generic;

namespace Book.Model
{
    public class CartDataInsertInput
    {
        public int IntUserId { get; set; }
        public string StrBookId { get; set; }
        public int DecQty { get; set; }
        public string StrTag { get; set; }
        public int IntEdition { get; set; }
        public decimal DecPrice { get; set; }
        [SQLOutputParam("IntOutput")]
        public int IntOutput { get; set; }
    }
    public class CartDataInsertOutput
    {
        [SQLOutputParam("IntOutput")]
        public int IntOutput { get; set; }
    }
    public class GetCartDetailsInput
    {
        public int IntUid { get; set; }
    }
    public class GetCartDetailsOutput
    {
        public string StrCartId { get; set; }
        public int IntUserId { get; set; }
        public string StrProductId { get; set; }
        public int DecQty { get; set; }
        public string StrTag { get; set; }
        public int IntEdition { get; set; }
        public decimal DecPrice { get; set; }
        public string StrBookName { get; set; }
    }
    public class PlaceOrderInput
    {
        public List<BookIds> ProductIds { get; set; }
    }
    public class BookIds
    {
        public string strBookId { get; set; }
    }
    public class PlaceOrderInputDB
    {
        public string BookIds { get; set; }
        [SQLOutputParam("IntOutput")]
        public int IntOutput { get; set; }
    }
    public class PlaceOrderOutput
    {
        [SQLOutputParam("IntOutput")]
        public int IntOutput { get; set; }
    }
}
