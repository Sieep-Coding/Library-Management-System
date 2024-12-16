using System.Diagnostics;
using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Classes;
internal class BooksController
{
    internal static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        Debug.Print("Success: Books printed.");
        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
    }
    internal static void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

        var review = AnsiConsole.Ask<int>("[cyan]Enter a score: (1-5)[/]");

        if (MockDatabase.Books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
            Debug.Print("Error: Title already exists.");
        }

        else if (title == null)
        {
            AnsiConsole.MarkupLine("[red]Please insert a title.[/]");
            Debug.Print("Error: No title.");
        }

        else if (review > 5 || review < 0 || review == 0)
        {
            AnsiConsole.MarkupLine("[red]Enter a score between 1 and 5.[/]");
            Debug.Print("Error: Bad Score.");
        }

        else
        {
            var titleWithReview = $"{title}, Score: {review}";
            MockDatabase.Books.Add(titleWithReview);
            AnsiConsole.MarkupLine("[green]Book added successfully with review![/]");
            Debug.Print("Success: Added Review.");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");

        Console.ReadKey();
    }

    internal static void DeleteBook()
    {
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(MockDatabase.Books));

        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }

        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");

        Console.ReadKey();
    }
}