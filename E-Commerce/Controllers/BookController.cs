using Book.BAL;
using Book.Model;
using E_Commerce.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookRepo ObjRepositry;
        public BookController(IBookRepo ObjRepositry)
        {
            this.ObjRepositry = ObjRepositry;
        }
        [HttpPost]
        [Route("InsertAuthorInfo")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult InsertAuthorInfo(InsertAuthorInfoInput ObjInput)
        {
            return Ok(ObjRepositry.InsertAuthorInfo(ObjInput));
        }
        [HttpPost]
        [Route("InsertCatagory")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult InsertCatagory(InsertCatagoryInput ObjInput)
        {
            return Ok(ObjRepositry.InsertCatagory(ObjInput));
        }
        [HttpPost]
        [Route("InsertBookDetails")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult InsertBookDetails(InsertBookDetailsInput ObjInput)
        {
            return Ok(ObjRepositry.InsertBookDetails(ObjInput));
        }
        [HttpPost]
        [Route("SearchBook")]
        public IActionResult SearchBookDetails(SearchBookInput ObjInput)
        {
            return Ok(ObjRepositry.GetBookSearchOutput(ObjInput));
        }
        [HttpPost]
        [Route("SearchAuthor")]
        public IActionResult SearchAuthor(SearchBookInput ObjInput)
        {
            return Ok(ObjRepositry.GetAuthorSearchOutput(ObjInput));
        }
        [HttpPost]
        [Route("SearchCatagory")]
        public IActionResult SearchCatagory(SearchBookInput ObjInput)
        {
            return Ok(ObjRepositry.GetCatagorySearchOutput(ObjInput));
        }
        [HttpPost]
        [Route("GetBookInfo")]
        public IActionResult GetBookInfo(BookInfoInput ObjInput)
        {
            return Ok(ObjRepositry.GetBookInfo(ObjInput));
        }
        [HttpPost]
        [Route("GetBooKData")]
        public IActionResult GetBooKData(BookInfoInput ObjInput)
        {
            return Ok(ObjRepositry.GetBooKData(ObjInput));
        }
        [HttpPut]
        [Route("UpdateBookInfo")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult UpdateBookInfo(InsertBookInfoInput ObjInput)
        {
            return Ok(ObjRepositry.UpdateBookInfo(ObjInput));
        }
        [HttpPost]
        [Route("UploadBookImage")]
        //[ServiceFilter(typeof(ECommerceAuth))]
        public IActionResult UploadBookImage([FromForm] BookImageUploadInput ObjInput)
        {
            return Ok(ObjRepositry.UploadImage(ObjInput));
        }
        [HttpGet]
        [Route("GetBookImage")]
        public IActionResult GetBookImage(string StrBookId, int IntBookEdition)
        {
            GetBookImageInput ObjInput = new GetBookImageInput()
            {
                IntEdition = IntBookEdition,
                StrBookID = StrBookId
            };
            return Ok(ObjRepositry.GetBookImage(ObjInput));
        }
        [HttpGet]
        [Route("GetBookFilterValues")]
        public IActionResult GetBookFilterValues()
        {
            return Ok(ObjRepositry.GetBookFilterValues());
        }
        [HttpGet]
        [Route("GetBookImageForCarousel")]
        public IActionResult GetBookImageForCarousel()
        {
            GetBookImageInput ObjInput = new GetBookImageInput()
            {
                IntEdition = 0,
                StrBookID = null
            };
            return Ok(ObjRepositry.GetBookImage(ObjInput));
        }
        [HttpPost]
        [Route("GetBooks")]
        public IActionResult GetBooks(GetBooksInput ObjInput)
        {            
            return Ok(ObjRepositry.GetBooks(ObjInput));
        }
    }
}
