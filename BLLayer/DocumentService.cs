using AI_Document_Automation.Models;
using AI_Document_Automation.Repository;
using System.Collections.Generic;

namespace AI_Document_Automation.Business
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public void SaveDocument(ExtractedData data)
        {
            _repository.Save(data);
        }

        public List<ExtractedData> GetDocuments()
        {
            return _repository.GetAll();
        }
    }
}
