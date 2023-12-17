using Book.DAL;
using Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BAL.UnitOfWork
{
    public class AuthorInfoUOW
    {
        private readonly IBookDAL ObjDAL;
        public AuthorInfoUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public InsertAuthorInfoOutput InsertAuthorInfo(InsertAuthorInfoInput ObjInput) => ObjDAL.InsertAuthorInfo(ObjInput);
        public InsertAuthorInfoOutput InsertCatagory(InsertCatagoryInput ObjInput) => ObjDAL.InsertCatagory(ObjInput);
    }
}
