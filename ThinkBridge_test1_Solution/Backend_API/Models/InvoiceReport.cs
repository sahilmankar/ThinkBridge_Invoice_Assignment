namespace Backend_API.Models
{
    public class InvoiceReport
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }
        public List<InvoiceItemDetail> Items { get; set; } = new List<InvoiceItemDetail>();
    }

    public class InvoiceItemDetail
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
    }
}