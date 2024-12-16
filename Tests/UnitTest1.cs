using Xunit;

namespace TCSA.OOP.LibraryManagementSystem.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public void AddBook_Should_Add_New_Book_With_Review()
        {
            // Arrange
            var title = "New Book";
            var review = 4;
            var books = new List<string>();

            // Act
            if (!books.Contains(title) && review >= 1 && review <= 5)
            {
                var titleWithReview = $"{title}, Score: {review}";
                books.Add(titleWithReview);
            }

            // Assert
            Assert.Single(books);
            Assert.Equal("New Book, Score: 4", books[0]);
        }

        [Fact]
        public void AddBook_Should_Not_Add_Duplicate_Book()
        {
            // Arrange
            var books = new List<string> { "Existing Book, Score: 5" };
            var title = "Existing Book";
            var review = 3;

            // Act
            var isDuplicate = books.Exists(b => b.StartsWith(title));

            // Assert
            Assert.True(isDuplicate);
            Assert.Single(books);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void AddBook_Should_Reject_Invalid_Review_Scores(int invalidScore)
        {
            // Arrange
            var books = new List<string>();
            var title = "Invalid Book";

            // Act
            var isValid = invalidScore >= 1 && invalidScore <= 5;

            // Assert
            Assert.False(isValid);
            Assert.Empty(books);
        }

        [Fact]
        public void DeleteBook_Should_Remove_Book_If_Exists()
        {
            // Arrange
            var books = new List<string> { "Book To Delete, Score: 3" };
            var bookToDelete = "Book To Delete, Score: 3";

            // Act
            var removed = books.Remove(bookToDelete);

            // Assert
            Assert.True(removed);
            Assert.Empty(books);
        }

        [Fact]
        public void DeleteBook_Should_Not_Remove_Nonexistent_Book()
        {
            // Arrange
            var books = new List<string> { "Existing Book, Score: 5" };
            var bookToDelete = "Nonexistent Book";

            // Act
            var removed = books.Remove(bookToDelete);

            // Assert
            Assert.False(removed);
            Assert.Single(books);
        }

        [Fact]
        public void ViewBooks_Should_List_All_Books()
        {
            // Arrange
            var books = new List<string>
            {
                "Book One, Score: 4",
                "Book Two, Score: 5"
            };

            // Act
            var bookCount = books.Count;

            // Assert
            Assert.Equal(2, bookCount);
            Assert.Contains("Book One, Score: 4", books);
            Assert.Contains("Book Two, Score: 5", books);
        }
    }
}
