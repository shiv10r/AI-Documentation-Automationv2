using AI_Document_Automation.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AI_Document_Automation.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IConfiguration _configuration;

        public DocumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Save(ExtractedData data)
        {
            // Get connection string from appsettings.json
            var connStr = _configuration.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connStr);
            conn.Open();

            var query = @"INSERT INTO ExtractedDocuments
                          (InvoiceNumber, Date, Amount, VendorName, CustomerName)
                          VALUES (@InvoiceNumber, @Date, @Amount, @VendorName, @CustomerName)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@InvoiceNumber", data.InvoiceNumber);
            cmd.Parameters.AddWithValue("@Date", data.Date);
            cmd.Parameters.AddWithValue("@Amount", data.Amount);
            cmd.Parameters.AddWithValue("@VendorName", data.VendorName);
            cmd.Parameters.AddWithValue("@CustomerName", data.CustomerName);

            cmd.ExecuteNonQuery();
        }
    }
}
