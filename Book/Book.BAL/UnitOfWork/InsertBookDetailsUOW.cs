using Book.DAL;
using Book.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BAL.UnitOfWork
{
    public class InsertBookDetailsUOW
    {
        private readonly IBookDAL ObjDAL;
        public InsertBookDetailsUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public InsertBookDetailsOutput InsertBookDetails(InsertBookDetailsInput ObjInput) => ObjDAL.
            InsertBookDetails(new InsertBookDetailsInputDB
            {
                JsonDetail = ObjInput.JsonDetail?.Count > 0 ? JsonConvert.SerializeObject(ObjInput.JsonDetail) : null,
                JsonHeader = ObjInput.JsonHeader != null ? JsonConvert.SerializeObject(ObjInput.JsonHeader) : null
            });

        public InsertBookInfoOutput UpdateBookInfo(InsertBookInfoInput ObjInput) => ObjDAL.
            UpdateBookInfo(new InsertBookInfoInputDB
            {
                IntUserId = ObjInput.IntUserId,
                JsonBookDetails = ObjInput.BookDetails?.Count > 0 ? JsonConvert.SerializeObject(ObjInput.BookDetails) : null,
                StrBookID = ObjInput.StrBookID
            });
    }
}
