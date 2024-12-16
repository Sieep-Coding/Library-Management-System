// Ignore Spelling: TCSA OOP
using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Classes
{
    internal class UserInterface
    {
        private readonly BooksController booksController = new BooksController();
        internal void MainMenu()
        {
            while (true)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<Enums.MenuOptions>()
                        .Title("What do you want to do next?")
                        .AddChoices(Enum.GetValues<Enums.MenuOptions>()));

                switch (choice)
                {
                    case Enums.MenuOptions.ViewBooks:
                        BooksController.ViewBooks();
                        break;
                    case Enums.MenuOptions.AddBook:
                        BooksController.AddBook();
                        break;
                    case Enums.MenuOptions.DeleteBook:
                        BooksController.DeleteBook();
                        break;
                }
            }
        }
    }
}
