using Book.DAL;
using Book.Model;
using System.Collections.Generic;
using System.Text.Json;

namespace Book.BAL.UnitOfWork
{
    public class CartUOW
    {
        private IBookDAL ObjDAL;
        public CartUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public CartDataInsertOutput CartDataInsert(CartDataInsertInput ObjInput) => ObjDAL.InsertCartData(ObjInput);
        public List<GetCartDetailsOutput> GetCartDetails(GetCartDetailsInput ObjInput) => ObjDAL.GetCartDetails(ObjInput);
        public PlaceOrderOutput PlaceOrder(PlaceOrderInput ObjInput)
        {
            PlaceOrderInputDB ObjInputDB = new PlaceOrderInputDB
            {
                BookIds = ObjInput?.ProductIds?.Count > 0 ? JsonSerializer.Serialize(ObjInput.ProductIds) : null                
            };
            return ObjDAL.PlaceOrder(ObjInputDB);
        }
    }
}
