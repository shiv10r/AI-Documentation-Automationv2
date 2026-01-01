using AI_Document_Automation.Business;
using Microsoft.AspNetCore.Mvc;

namespace AI_Document_Automation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var result = _service.ProcessDocument();
            return Ok(result);
        }
    }
}
