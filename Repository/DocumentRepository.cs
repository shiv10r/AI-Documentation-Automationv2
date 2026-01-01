using AI_Document_Automation.Models;
using System.Data.SqlClient;

namespace AI_Document_Automation.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly string _connectionString;

        public DocumentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Fetch all documents from DB
        public List<ExtractedData> GetAll()
        {
            var documents = new List<ExtractedData>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT InvoiceNumber, Date, Amount, VendorName, CustomerName FROM ExtractedDocuments", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    documents.Add(new ExtractedData
                    {
                        InvoiceNumber = reader["InvoiceNumber"].ToString(),
                        Date = reader["Date"].ToString(),
                        Amount = reader["Amount"].ToString(),
                        VendorName = reader["VendorName"].ToString(),
                        CustomerName = reader["CustomerName"].ToString()
                    });
                }
            }

            return documents;
        }
    }
}
