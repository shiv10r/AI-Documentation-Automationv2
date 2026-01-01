using AI_Document_Automation.Models;
using AI_Document_Automation.Repository;

namespace AI_Document_Automation.Business
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        // Get all documents
        public List<ExtractedData> GetDocuments()
        {
            return _repository.GetAll();
        }
    }
}
