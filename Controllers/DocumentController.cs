using AI_Document_Automation.Business;
using Microsoft.AspNetCore.Mvc;

namespace AI_Document_Automation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/Document
        [HttpGet]
        public IActionResult GetAllDocuments()
        {
            var documents = _documentService.GetDocuments();
            return Ok(documents);
        }
    }
}
