// See https://aka.ms/new-console-template for more information
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
string filePath = "C:\\Users\\Usuario\\Documents\\Inventario.xlsx";
XLWorkbook workbook; 
IXLWorksheet worksheet; 
System.DateTime now = System.DateTime.Now;

if (File.Exists(filePath))
{
    workbook = new XLWorkbook(filePath);
    Console.WriteLine("Archivo existente abierto para actualización.");
    if (workbook.Worksheets.Contains("Inventario"))
    {
        worksheet = workbook.Worksheet("Inventario");
    }
    else
    {
        worksheet = workbook.Worksheets.Add("Inventario");
        worksheet.Cell("B2").Value = "Item Name";
        worksheet.Cell("C2").Value = "Item Quantity";
        worksheet.Cell("D2").Value = "Date Added";
    }
}
else
{
    workbook = new XLWorkbook();
    worksheet = workbook.Worksheets.Add("Inventario");
    now = System.DateTime.Now;
    worksheet.Cell("B2").Value = "Item Name";
    worksheet.Cell("C2").Value = "Item Quantity";
    worksheet.Cell("D2").Value = "Date Added";
Console.WriteLine("Archivo no encontrado. Creando nuevo libro.");
}

Console.WriteLine("Hello, Inventory Control System!");
Console.WriteLine("Enter 1 to add an item, 2 to view inventory, or 3 to exit.");
if (!int.TryParse(Console.ReadLine(), out int input)) 
{
    Console.WriteLine("Entrada no válida. El programa finalizará.");
    return;
}

switch (input)
{
    case 1:
        Console.WriteLine("--- LEYENDO ÍTEM ---");

        int nextRow = worksheet.LastRowUsed().RowNumber() + 1;
        Console.WriteLine($"Última fila usada: {nextRow - 1}");
    if (nextRow <= 2) nextRow = 3; 
    
    Console.WriteLine($"Añadiendo ítem a la fila: {nextRow}"); 

    Console.WriteLine("Enter item name:");
    string itemName = Console.ReadLine();
    worksheet.Cell(nextRow, 2).Value = itemName;

    Console.WriteLine("Enter item quantity:");
    if (int.TryParse(Console.ReadLine(), out int itemQuantity))
    {
        worksheet.Cell(nextRow, 3).Value = itemQuantity; 
    }
    else
    {
            Console.WriteLine("Cantidad no válida. El campo quedará vacío.");
    }
    
    worksheet.Cell(nextRow, 4).Value = now.ToString("yyyy-MM-dd HH:mm:ss");
    
    Console.WriteLine("Ítem añadido correctamente.");
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
