using System.IO;
System.DateTime now = System.DateTime.Now;
Console.WriteLine("Hello, Inventory Control System!");
Console.WriteLine("Enter 1 to add an item, 2 to view inventory, or 3 to exit.");
int input = int.Parse(Console.ReadLine());
switch (input)
{
	case 1:
		Console.WriteLine("Adding an item to inventory...");
		Console.WriteLine("Enter item name:");
		string itemName = Console.ReadLine();
		Console.WriteLine("Enter quiantity:");
		int quantity = int.Parse(Console.ReadLine());
		Console.WriteLine("Item Added Successfully");
        break;
	case 2:
		Console.WriteLine("Viewing inventory...");
		// Code to view inventory would go here
		break;
	case 3:
		Console.WriteLine("Exiting the system...");
		break;

    default:
		Console.WriteLine("Invalid option. Please try again.");
        break;
}

Console.WriteLine("Exiting the system. Goodbye!");
Console.ReadKey();