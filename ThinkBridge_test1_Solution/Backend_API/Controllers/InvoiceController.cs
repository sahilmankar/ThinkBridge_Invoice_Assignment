
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
        
        [HttpGet]
        public IActionResult GetInvoice()
        {
            
            List<InvoiceReport> items = null;
            SqlConnection conn = new SqlConnection("Data Source=SAHIL\\SQLEXPRESS01;Initial Catalog=ThinkBridge_InvoiceDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetInvoiceStatement", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            items = new List<InvoiceReport>();
            while (reader.Read())
            {
                items.Add(new InvoiceReport
                {
                    ItemName = reader["ItemName"].ToString(),
                    ItemPrice = Convert.ToDouble(reader["ItemPrice"]),
                    CustomerName = reader["CustomerName"].ToString(),

                });
            }
            if (items.Count > 0) // NullReferenceException 
            {
                return Ok(new { items });
            }
            return NotFound("No invoice found");
        }
    }
}
