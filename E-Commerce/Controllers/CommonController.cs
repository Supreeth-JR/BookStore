using Book.BAL;
using Book.Model;
using E_Commerce.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : Controller
    {
        private IBookRepo ObjRepositry;
        public CommonController(IBookRepo ObjRepositry)
        {
            this.ObjRepositry = ObjRepositry;
        }
        [HttpPost]
        [Route("InsertCartData")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult InsertCartData(CartDataInsertInput ObjInput)
        {
            return Ok(ObjRepositry.InsertCartData(ObjInput));
        }
        [HttpPost]
        [Route("GetCartDetails")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult GetCartDetails(GetCartDetailsInput ObjInput)
        {
            return Ok(ObjRepositry.GetCartDetails(ObjInput));
        }
        [HttpPost]
        [Route("PlaceOrder")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult PlaceOrder(PlaceOrderInput ObjInput)
        {
            return Ok(ObjRepositry.PlaceOrder(ObjInput));
        }
    }
}
