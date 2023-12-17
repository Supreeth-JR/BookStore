using Book.Model;
using Common;
using System.Collections.Generic;

namespace Book.DAL
{
    public class BookDAL: IBookDAL
    {
        public InsertAuthorInfoOutput InsertAuthorInfo(InsertAuthorInfoInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<InsertAuthorInfoOutput, InsertAuthorInfoInput>("BOOK.Insert_Author_Info", ObjInput);
        public InsertAuthorInfoOutput InsertCatagory(InsertCatagoryInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<InsertAuthorInfoOutput, InsertCatagoryInput>("BOOK.Insert_Catagory", ObjInput);
        public InsertBookDetailsOutput InsertBookDetails(InsertBookDetailsInputDB ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<InsertBookDetailsOutput, InsertBookDetailsInputDB>("BOOK.Insert_Book_Details", ObjInput);
        public List<T> SearchOutput<T>(SearchBookInput ObjInput) where T : class, new() => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<T, SearchBookInput>("BOOK.Search_SP", ObjInput);
        public List<BookInfoOutput> GetBookInfos(BookInfoInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<BookInfoOutput, BookInfoInput>("BOOK.Get_Book_Info", ObjInput);
        public InsertBookInfoOutput UpdateBookInfo(InsertBookInfoInputDB ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<InsertBookInfoOutput, InsertBookInfoInputDB>("BOOK.SP_Update_Book_Info", ObjInput);
        public BookImageUploadOutput UploadImage(BookImageUploadInputDB ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<BookImageUploadOutput, BookImageUploadInputDB>("Book.Upload_Image", ObjInput);
        public List<GetBookImageOutput> GetBookImage(GetBookImageInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<GetBookImageOutput, GetBookImageInput>("BOOK.Get_Book_Image", ObjInput);
        public List<T> GetBookFilter<T>(GetBookFilterValuesInput ObjInput) where T : class, new() => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<T, GetBookFilterValuesInput>("BOOK.Get_Cat_Auth", ObjInput);
        public List<GetBooksOutput> GetBooks(GetBooksInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<GetBooksOutput, GetBooksInput>("BOOK.Get_Books", ObjInput);
        public CartDataInsertOutput InsertCartData(CartDataInsertInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<CartDataInsertOutput, CartDataInsertInput>("USR.Add_Item_To_Cart", ObjInput);
        public List<GetCartDetailsOutput> GetCartDetails(GetCartDetailsInput ObjInput) => new ECommerceDAL("ConnectionString").
            ExeccuteSingleModel<GetCartDetailsOutput, GetCartDetailsInput>("USR.Get_Cart_Data", ObjInput);
        public PlaceOrderOutput PlaceOrder(PlaceOrderInputDB ObjInput) => new ECommerceDAL("ConnectionString").
            ExecuteSPWithOutputParam<PlaceOrderOutput, PlaceOrderInputDB>("USR.SP_Place_Order", ObjInput);
    }
}
