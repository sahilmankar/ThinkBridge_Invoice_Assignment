namespace Backend_API.Models;

public class InvoiceItem
{
    public int ItemID { get; set; }
    public int InvoiceID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}