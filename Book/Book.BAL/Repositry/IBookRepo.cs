using Book.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book.BAL
{
    public interface IBookRepo
    {
        InsertAuthorInfoOutput InsertAuthorInfo(InsertAuthorInfoInput ObjInput);
        InsertAuthorInfoOutput InsertCatagory(InsertCatagoryInput ObjInput);
        InsertBookDetailsOutput InsertBookDetails(InsertBookDetailsInput ObjInput);
        List<BooksSearchOutput> GetBookSearchOutput(SearchBookInput ObjInput);
        List<AuthorSearchOutput> GetAuthorSearchOutput(SearchBookInput ObjInput);
        List<CatagorySearchOutput> GetCatagorySearchOutput(SearchBookInput ObjInput);
        IEnumerable<BookInfoOutput> GetBookInfo(BookInfoInput ObjInput);
        BookInfoHeader GetBooKData(BookInfoInput ObjInput);
        InsertBookInfoOutput UpdateBookInfo(InsertBookInfoInput ObjInput);
        BookImageUploadOutput UploadImage([FromForm] BookImageUploadInput ObjInput);
        List<GetBookImageOutput> GetBookImage(GetBookImageInput ObjInput);
        GetBookFilterValuesOutput GetBookFilterValues();
        List<GetBooksOutput> GetBooks(GetBooksInput ObjInput);
        CartDataInsertOutput InsertCartData(CartDataInsertInput ObjInput);
        List<GetCartDetailsOutput> GetCartDetails(GetCartDetailsInput ObjInput);
        PlaceOrderOutput PlaceOrder(PlaceOrderInput ObjInput);
    }
}
