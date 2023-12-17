using Book.DAL;
using Book.Model;
using System.Collections.Generic;

namespace Book.BAL.UnitOfWork
{
    public class GetBooksUOW
    {
        private readonly IBookDAL ObjDAL;
        public GetBooksUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public List<GetBooksOutput> GetBooks(GetBooksInput ObjInput) => ObjDAL.GetBooks(ObjInput);
    }
}
