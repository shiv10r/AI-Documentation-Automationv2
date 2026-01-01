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

        public ExtractedData ProcessDocument()
        {
            var data = new ExtractedData
            {
                InvoiceNumber = "INV-1001",
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Amount = "1500",
                VendorName = "Demo Vendor",
                CustomerName = "Demo Customer"
            };

            _repository.Save(data);
            return data;
        }
    }
}
