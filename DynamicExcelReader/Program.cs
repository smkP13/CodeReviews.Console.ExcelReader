using OfficeOpenXml;
using Spectre.Console;
using static DynamicExcelReader.Models;
namespace DynamicExcelReader;

internal class Program
{
    static void Main(string[] args)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Myself");
        AnsiConsole.WriteLine("Welcome to Excel Reader by P13.");
        AnsiConsole.MarkupLine("Data from [blue]Excel Sheet[/] will be read.");

        AnsiConsole.MarkupLine("Extracting the document [blue]Headers[/]");
        List<Header>? headers = DynamicExcelController.GetHeaders();
        if (headers != null)
        {
            AnsiConsole.MarkupLine("Ensure [red]Deletion[/] and [green]Creation[/] of the Database");
            DynamicContext context = new();
            try { context.Database.EnsureDeleted(); AnsiConsole.MarkupLine("[red]Deleting database[/]"); } catch { AnsiConsole.WriteLine("Database doesn't exist."); }
            AnsiConsole.MarkupLine("[green]Creating[/] Databse");
            context.Database.EnsureCreated();

            AnsiConsole.MarkupLine("Retrieving data from the Database.");
            List<DynamicData> datas = DBController.GetDataFromDb(context);

            AnsiConsole.MarkupLine("Creating Table data.");
            Table table = new();
            table.Title("Data Presentation");
            table.AddColumn("Id");
            table.ShowRowSeparators();
            headers.ForEach(header => table.AddColumn(header.Text));
            datas.ForEach(data => table.AddRow(data.keyValuePairs.Values.ToArray()));
            AnsiConsole.MarkupLine("Press any [yellow]Key[/] to print the data.");
            Console.ReadLine();

            AnsiConsole.Clear();
            AnsiConsole.Write(table);
        }
        else AnsiConsole.MarkupLine("No Headers. Data need headers to be displayed correctly. Please verify the sheet fileName or The excel sheets.");
        Console.ReadLine();
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Thank you[/] fo using Excel Reader");
    }
}
