using OfficeOpenXml;
using Spectre.Console;
using static ExcelReader.Models;
namespace ExcelReader;

internal class Program
{
    static void Main(string[] args)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Myself");
        AnsiConsole.WriteLine("Welcome to Excel Reader by P13.");
        AnsiConsole.MarkupLine("Data from [blue]AthleteSheet.xlsx[/] will be read.");

        AnsiConsole.MarkupLine("Extracting the document [blue]Headers[/]");
        List<Header> headers = ExcelController.GetHeaders();

        AnsiConsole.MarkupLine("Ensure [red]Deletion[/] and [green]Creation[/] of the Database");
        AthleteContext context = new();
        try { context.Database.EnsureDeleted(); AnsiConsole.MarkupLine("[red]Deleting database[/]"); } catch { AnsiConsole.WriteLine("Database doesn't exist."); }
        AnsiConsole.MarkupLine("[green]Creating[/] Databse");
        context.Database.EnsureCreated();

        AnsiConsole.MarkupLine("Retrieving data from the Database.");
        List<Athlete> athletes = DBController.GetAtheltes(context);

        AnsiConsole.MarkupLine("Creating Table data.");
        Table table = new();
        table.Title("Athletes Characteristics");
        table.AddColumn("Id");
        table.ShowRowSeparators();
        headers.ForEach(header => table.AddColumn(header.Text));
        athletes.ForEach(athlete => table.AddRow(athlete.ToArray()));
        AnsiConsole.MarkupLine("Press any [yellow]Key[/] to print the data.");
        Console.ReadLine();

        AnsiConsole.Clear();
        AnsiConsole.Write(table);

        Console.ReadLine();
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Thank you[/] fo using Excel Reader");
    }
}
