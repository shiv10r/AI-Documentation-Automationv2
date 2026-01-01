using AI_Document_Automation.Models;

namespace AI_Document_Automation.Repository
{
    public interface IDocumentRepository
    {
        void Save(ExtractedData data);
    }
}
