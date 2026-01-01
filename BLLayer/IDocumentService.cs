using AI_Document_Automation.Models;
using System.Collections.Generic;

namespace AI_Document_Automation.Business
{
    public interface IDocumentService
    {
        void SaveDocument(ExtractedData data);
        List<ExtractedData> GetDocuments();
    }
}
