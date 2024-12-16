using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Classes;
using TCSA.OOP.LibraryManagementSystem.Models;

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption.MenuOptions>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption.MenuOptions>()));

    switch (choice)
    {
        case MenuOption.MenuOptions.ViewBooks:
            BooksController.ViewBooks();
            break;
        case MenuOption.MenuOptions.AddBook:
            BooksController.AddBook();
            break;
        case MenuOption.MenuOptions.DeleteBook:
            BooksController.DeleteBook();
            break;
    }
}