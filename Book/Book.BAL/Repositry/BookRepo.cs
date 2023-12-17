using Book.BAL.UnitOfWork;
using Book.DAL;
using Book.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book.BAL
{
    public class BookRepo : IBookRepo
    {
        private readonly IBookDAL ObjDAL;
        public BookRepo(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public InsertAuthorInfoOutput InsertAuthorInfo(InsertAuthorInfoInput ObjInput) => new AuthorInfoUOW(ObjDAL).InsertAuthorInfo(ObjInput);
        public InsertAuthorInfoOutput InsertCatagory(InsertCatagoryInput ObjInput) => new AuthorInfoUOW(ObjDAL).InsertCatagory(ObjInput);
        public InsertBookDetailsOutput InsertBookDetails(InsertBookDetailsInput ObjInput) => new InsertBookDetailsUOW(ObjDAL).InsertBookDetails(ObjInput);
        public List<BooksSearchOutput> GetBookSearchOutput(SearchBookInput ObjInput) => new BookSearchUOW(ObjDAL).GetBookSearchOutput(ObjInput);
        public List<AuthorSearchOutput> GetAuthorSearchOutput(SearchBookInput ObjInput) => new BookSearchUOW(ObjDAL).GetAuthorSearchOutput(ObjInput);
        public List<CatagorySearchOutput> GetCatagorySearchOutput(SearchBookInput ObjInput) => new BookSearchUOW(ObjDAL).GetCatagorySearchOutput(ObjInput);
        public IEnumerable<BookInfoOutput> GetBookInfo(BookInfoInput ObjInput) => new GetBookInfoUOW(ObjDAL).GetBookInfo(ObjInput);
        public BookInfoHeader GetBooKData(BookInfoInput ObjInput) => new GetBookInfoUOW(ObjDAL).GetBooKData(ObjInput);
        public InsertBookInfoOutput UpdateBookInfo(InsertBookInfoInput ObjInput) => new InsertBookDetailsUOW(ObjDAL).UpdateBookInfo(ObjInput);
        public BookImageUploadOutput UploadImage([FromForm] BookImageUploadInput ObjInput) => new UploadImagesUOW(ObjDAL).UploadImage(ObjInput);
        public List<GetBookImageOutput> GetBookImage(GetBookImageInput ObjInput) => new UploadImagesUOW(ObjDAL).GetBookImage(ObjInput);
        public GetBookFilterValuesOutput GetBookFilterValues() => new GetBookFilterValuesUOW(ObjDAL).GetBookFilterValues();
        public List<GetBooksOutput> GetBooks(GetBooksInput ObjInput) => new GetBooksUOW(ObjDAL).GetBooks(ObjInput);
        public CartDataInsertOutput InsertCartData(CartDataInsertInput ObjInput) => new CartUOW(ObjDAL).CartDataInsert(ObjInput);
        public List<GetCartDetailsOutput> GetCartDetails(GetCartDetailsInput ObjInput) => new CartUOW(ObjDAL).GetCartDetails(ObjInput);
        public PlaceOrderOutput PlaceOrder(PlaceOrderInput ObjInput) => new CartUOW(ObjDAL).PlaceOrder(ObjInput);
    }
}
