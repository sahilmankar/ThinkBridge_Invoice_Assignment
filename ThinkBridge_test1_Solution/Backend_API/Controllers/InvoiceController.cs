
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetInvoice()
        {
            
            List<Item> items = null;
            //items = new List<Item>
            //{
            //    new Item { name = "Item1", price = 10.0 },
            //    new Item { name = "Item2", price = 20.0 }
            //};
            //Now data should be load from database
            //we are going to use ado.net to load data from database
            //for that first we need the packages that is System.Data.SqlClient
            //so now after installing the package we can use the following code to load data from database
            //Table structure should be like this Items(Id int, Name varchar(50), Price float)
            //we can set our connection string to json file
            // "ConnectionStrings": {
            //    "DefaultConnection": "Data Source=SAHIL\\SQLEXPRESS01;Initial Catalog=ThinkBridge_InvoiceDB;Integrated Security=True"
            //}
            // and will write the connection for that in program.cs file
            //and will use simple dependency injection to inject the connection string in our controller

            SqlConnection conn = new SqlConnection("Data Source=SAHIL\\SQLEXPRESS01;Initial Catalog=ThinkBridge_InvoiceDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name, Price FROM Items", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            items = new List<Item>();
           // reader.Read();
            while (reader.Read())
            {
                items.Add(new Item
                {
                    name = reader["Name"].ToString(),
                    price = Convert.ToDouble(reader["Price"])
                });
            }
            if (items.Count > 0) // NullReferenceException 
            {
                return Ok(new { items });
            }
            return NotFound("No invoice found");
        }

        public class Item
        {
            public string name { get; set; }
            public double price { get; set; }
        }
    }
}
