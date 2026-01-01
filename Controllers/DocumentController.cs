using AI_Document_Automation.Business;
using AI_Document_Automation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<ExtractedData> documents = _documentService.GetDocuments();
            return Ok(documents);
        }

        // POST: api/Document
        [HttpPost]
        public IActionResult AddDocument([FromBody] ExtractedData data)
        {
            _documentService.SaveDocument(data);
            return Ok(data);
        }
    }
}
