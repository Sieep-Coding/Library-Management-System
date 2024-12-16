namespace TCSA.OOP.LibraryManagementSystem.Classes
{
    internal class Book
    {
        string Name;
        int Pages;
        internal Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
            Console.WriteLine($"Name: {Name}, Pages: {Pages}");
        }
    }
}
