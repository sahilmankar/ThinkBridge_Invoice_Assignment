# ThinkBridge_Invoice_Assignment

            //At initial level make code working with static data
            //Now data should be load from database
            //we are going to use ado.net to load data from database
            //for that first we need the packages that is System.Data.SqlClient
            //Table structure should be like this Items(ItemId int, Name varchar(50), Price float)
            //we can set our connection string to json file

            //here is the revised overall flowchart of the application below:
            //1. User sends a request to the API endpoint (e.g., GET /api/invoice).
            //2. The request is routed to the InvoiceController.
            //3. The InvoiceController uses the injected connection string to create a database connection.
            //4. The controller executes a SQL query to fetch item data from the database.
            //5. The fetched data is mapped to a list of Item objects.
            //6. And the static file has been added to the project to show the invoice in a better way