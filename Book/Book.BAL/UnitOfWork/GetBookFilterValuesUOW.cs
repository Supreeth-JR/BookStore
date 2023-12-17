using Book.DAL;
using Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BAL.UnitOfWork
{
    public class GetBookFilterValuesUOW
    {
        private readonly IBookDAL ObjDAL;
        public GetBookFilterValuesUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public GetBookFilterValuesOutput GetBookFilterValues()
        {
            GetBookFilterValuesInput ObjInput = new GetBookFilterValuesInput();
            ObjInput.StrTag = "A";
            List<AuthorFilterOutput> Authors = ObjDAL.GetBookFilter<AuthorFilterOutput>(ObjInput);
            ObjInput.StrTag = "C";
            List<CatagoryFilterOutput> Catagories = ObjDAL.GetBookFilter<CatagoryFilterOutput>(ObjInput);
            return new GetBookFilterValuesOutput { AuthorsFilter = Authors, CatagoryFilter = Catagories };
        }
    }
}
