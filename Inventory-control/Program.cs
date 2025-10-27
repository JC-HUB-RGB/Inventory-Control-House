// See https://aka.ms/new-console-template for more information
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
var workbook = new XLWorkbook();
var worksheet = workbook.Worksheets.Add("Inventario");
System.DateTime now = System.DateTime.Now;
worksheet.Cell("B2").Value = "Item Name";
worksheet.Cell("B3").Value = "Item Quantity";
worksheet.Cell("B4").Value = "Date Added";
Console.WriteLine("Hello, Inventory Control System!");
Console.WriteLine("Enter 1 to add an item, 2 to view inventory, or 3 to exit.");
double input = Convert.ToDouble(Console.ReadLine());

switch (input)
{
    case 1:
        Console.WriteLine("Leer item");
        Console.WriteLine("Enter item name:");
        string itemName = Convert.ToString(Console.ReadLine());
        worksheet.Cell("C2").Value = itemName;

        Console.WriteLine("Enter item quantity:");
        int itemQuantity = Convert.ToInt32(Console.ReadLine());
        worksheet.Cell("C3").Value = itemQuantity;

        worksheet.Cell("C4").Value = now.ToString("yyyy-MM-dd HH:mm:ss");
        break;
    case 2:
        Console.WriteLine("");
        // Code to view inventory would go here
        break;
    case 3:
        Console.WriteLine("");
        break;
    default:
        Console.WriteLine("Invalid option. Please try again.");
        break;
}
string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string fileName = "Inventario.xlsx";
string fullPath = Path.Combine(desktopPath, fileName);
workbook.SaveAs(fullPath);