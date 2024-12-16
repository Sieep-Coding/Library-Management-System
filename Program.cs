using Spectre.Console;

var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book" };

var books = new List<string>()
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

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What do you want to do next?")
            .AddChoices(menuChoices));

    switch (choice)
    {
        case "View Book":
            AnsiConsole.MarkupLine("[yellow]List of Books:[/]");
            foreach (var book in books)
            {
                AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
            }
            break;
        case "Add Book":
            break;
        case "Delete Book":
            break;
    }
}