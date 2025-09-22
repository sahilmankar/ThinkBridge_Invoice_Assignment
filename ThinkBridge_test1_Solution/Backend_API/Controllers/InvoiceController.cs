
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Backend_API.Models;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public InvoiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetInvoice()
        {
            var invoiceReport = new Dictionary<int, InvoiceReport>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetInvoiceReport", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int invoiceID = Convert.ToInt32(reader["InvoiceID"]);
                            string customerName = reader["CustomerName"]?.ToString();
                            string itemName = reader["ItemName"]?.ToString();
                            double itemPrice = reader["ItemPrice"] != DBNull.Value ? Convert.ToDouble(reader["ItemPrice"]) : 0;

                            if (!invoiceReport.ContainsKey(invoiceID))
                            {
                                invoiceReport[invoiceID] = new InvoiceReport
                                {
                                    InvoiceID = invoiceID,
                                    CustomerName = customerName,
                                    Items = new List<InvoiceItemDetail>()
                                };
                            }

                            invoiceReport[invoiceID].Items.Add(new InvoiceItemDetail
                            {
                                ItemName = itemName,
                                ItemPrice = itemPrice
                            });
                        }
                    }
                }
            }

            if (invoiceReport.Count > 0)
            {
                return Ok(invoiceReport.Values);
            }

            return NotFound("No invoices found");
        }
    }
}
