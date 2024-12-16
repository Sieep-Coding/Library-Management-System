using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Classes;

internal static class BooksController
{
    private static List<string> books = new()
    {
    "The Great Gatsby",
    "To Kill a Mockingbird",
    "1984",
    "Pride and Prejudice",
    "The Catcher in the Rye",
    "The Hobbit",
    "Moby-Dick",
    "War and Peace",
    "The Odyssey",
    "The Lord of the Rings",
    "Jane Eyre", "Animal Farm",
    "Brave New World",
    "The Chronicles of Narnia",
    "The Diary of a Young Girl",
    "The Alchemist",
    "Wuthering Heights",
    "Fahrenheit 451",
    "Catch-22",
    "The Hitchhiker's Guide to the Galaxy"
    };
    internal static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");

        Console.ReadKey();
    }
    internal static void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

        var review = AnsiConsole.Ask<int>("[cyan]Enter a score: (1-5)[/]");

        if (books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }

        else if (review > 5 || review <= 0)
        {
            AnsiConsole.MarkupLine("[red]Enter a score between 1 and 5.[/]");
        }

        else
        {
            var titleWithReview = $"{title}, Score: {review}";
            books.Add(titleWithReview);
            AnsiConsole.MarkupLine("[green]Book added successfully with review![/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");

        Console.ReadKey();
    }

    internal static void DeleteBook()
    {
        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(books));

        if (books.Remove(bookToDelete))
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