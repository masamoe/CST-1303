using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<Document> Get(string Id)
        {

            var doc = new Document()
            {
                Id = Id,
                Title = "Title",
                Author = "Author",
                Text = "Text"
            };

            return new Document();
        }
    }
}
