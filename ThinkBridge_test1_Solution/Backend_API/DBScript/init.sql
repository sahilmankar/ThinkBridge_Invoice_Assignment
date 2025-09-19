CREATE TABLE  Items
(
ItemID int PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Price Float NOT NULL
)

CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);

CREATE TABLE InvoiceItems (
    InvoiceItemID INT PRIMARY KEY,
    InvoiceID INT,
	ItemID INT,
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID)

);

INSERT INTO Items VALUES(1,'Item1',20)
INSERT INTO Invoices (InvoiceID, CustomerName) VALUES (1, 'John Doe');
INSERT INTO InvoiceItems (InvoiceItemID,ItemID, InvoiceID) VALUES (1,1, 1);



CREATE PROCEDURE GetInvoiceReport
AS
BEGIN
SELECT Name AS ItemName, Price AS ItemPrice, CustomerName 
FROM Items 
LEFT JOIN InvoiceItems
ON Items.ItemID = InvoiceItems.ItemID
LEFT JOIN Invoices ON Invoices.InvoiceID = InvoiceItems.InvoiceID
END