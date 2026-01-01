using AI_Document_Automation.Models;
using System.Collections.Generic;

namespace AI_Document_Automation.Repository
{
    public interface IDocumentRepository
    {
        void Save(ExtractedData data);
        List<ExtractedData> GetAll();
    }
}
