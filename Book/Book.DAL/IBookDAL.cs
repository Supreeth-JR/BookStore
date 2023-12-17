using Book.Model;
using System.Collections.Generic;

namespace Book.DAL
{
    public interface IBookDAL
    {
        InsertAuthorInfoOutput InsertAuthorInfo(InsertAuthorInfoInput ObjInput);
        InsertAuthorInfoOutput InsertCatagory(InsertCatagoryInput ObjInput);
        InsertBookDetailsOutput InsertBookDetails(InsertBookDetailsInputDB ObjInput);
        List<T> SearchOutput<T>(SearchBookInput ObjInput) where T : class, new();
        List<BookInfoOutput> GetBookInfos(BookInfoInput ObjInput);
        InsertBookInfoOutput UpdateBookInfo(InsertBookInfoInputDB ObjInput);
        BookImageUploadOutput UploadImage(BookImageUploadInputDB ObjInput);
        List<GetBookImageOutput> GetBookImage(GetBookImageInput ObjInput);
        List<T> GetBookFilter<T>(GetBookFilterValuesInput ObjInput) where T : class, new();
        List<GetBooksOutput> GetBooks(GetBooksInput ObjInput);
        CartDataInsertOutput InsertCartData(CartDataInsertInput ObjInput);
        List<GetCartDetailsOutput> GetCartDetails(GetCartDetailsInput ObjInput);
        PlaceOrderOutput PlaceOrder(PlaceOrderInputDB ObjInput);
    }
}
