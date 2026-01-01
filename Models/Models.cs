namespace AI_Document_Automation.Models
{
    public class ExtractedData
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string VendorName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
    }
}
