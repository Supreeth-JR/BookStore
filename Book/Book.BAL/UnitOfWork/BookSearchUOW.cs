using Book.DAL;
using Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BAL.UnitOfWork
{
    public class BookSearchUOW
    {
        private readonly IBookDAL ObjDAL;
        public BookSearchUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public List<BooksSearchOutput> GetBookSearchOutput(SearchBookInput ObjInput) => ObjDAL.SearchOutput<BooksSearchOutput>(ObjInput);
        public List<AuthorSearchOutput> GetAuthorSearchOutput(SearchBookInput ObjInput) => ObjDAL.SearchOutput<AuthorSearchOutput>(ObjInput);
        public List<CatagorySearchOutput> GetCatagorySearchOutput(SearchBookInput ObjInput) => ObjDAL.SearchOutput<CatagorySearchOutput>(ObjInput);
    }
}
