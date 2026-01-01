using AI_Document_Automation.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AI_Document_Automation.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly string _connectionString;

        public DocumentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Save(ExtractedData data)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO ExtractedDocuments (InvoiceNumber, Date, Amount, VendorName, CustomerName) " +
                            "VALUES (@InvoiceNumber, @Date, @Amount, @VendorName, @CustomerName)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceNumber", data.InvoiceNumber);
                    command.Parameters.AddWithValue("@Date", data.Date);
                    command.Parameters.AddWithValue("@Amount", data.Amount);
                    command.Parameters.AddWithValue("@VendorName", data.VendorName);
                    command.Parameters.AddWithValue("@CustomerName", data.CustomerName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ExtractedData> GetAll()
        {
            var list = new List<ExtractedData>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM ExtractedDocuments";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ExtractedData
                            {
                                Id = (int)reader["Id"],
                                InvoiceNumber = reader["InvoiceNumber"].ToString(),
                                Date = reader["Date"].ToString(),
                                Amount = reader["Amount"].ToString(),
                                VendorName = reader["VendorName"].ToString(),
                                CustomerName = reader["CustomerName"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
