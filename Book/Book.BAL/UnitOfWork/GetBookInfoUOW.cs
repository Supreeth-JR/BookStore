using Book.DAL;
using Book.Model;
using System.Collections.Generic;
using System.Linq;

namespace Book.BAL.UnitOfWork
{
    public class GetBookInfoUOW
    {
        private readonly IBookDAL ObjDAL;
        public GetBookInfoUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public IEnumerable<BookInfoOutput> GetBookInfo(BookInfoInput ObjInput) 
        {
            List<BookInfoOutput> Output = ObjDAL.GetBookInfos(ObjInput);
            return Output.Where(a => a.IntStock > 0).Take(6);
        } 
        public BookInfoHeader GetBooKData(BookInfoInput ObjInput)
        {
            List<BookInfoOutput> Output = ObjDAL.GetBookInfos(ObjInput);
            return Output.Select(a => new BookInfoHeader
            {
                StrAuthorId = a.StrAuthorId,
                StrCatagoryName = a.StrCatagoryName,                
                StrBookName = a.StrBookName,
                StrLanguage= a.StrLanguage,
                StrAuthorLastName = a.StrAuthorLastName,
                StrAuthorName = a.StrAuthorName,
                StrBookId = a.StrBookId,
                StrCatagoryId = a.StrCatagoryId,
                BookInfoDetails = Output.Select(x=> new BookInfoDetail 
                {
                    StrBookId = x.StrBookId,
                    DecMoney =x.DecMoney,
                    DtPublishDate = x.DtPublishDate,
                    IntEdition = x.IntEdition,
                    IntReview  = x.IntReview,
                    IntStock = x.IntStock,
                    StrBookIsNew = x.StrBookIsNew,
                    StrImageName = x.StrImageName                    
                }).ToList()
            }).FirstOrDefault();
        }
    }
}
