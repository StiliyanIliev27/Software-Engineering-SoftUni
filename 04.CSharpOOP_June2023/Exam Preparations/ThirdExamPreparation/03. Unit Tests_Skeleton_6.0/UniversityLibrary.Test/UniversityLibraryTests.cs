namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Linq;
    using System.Text;

    public class UniversityLibraryTests
    {
        private UniversityLibrary library;
        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
        }

        [Test]        
        public void UniversityLibraryConstructorShouldInitializeCorrectly()
        {
            Assert.IsNotNull(library.Catalogue);
        }

        [Test]
        public void UniversityLibraryShouldAddTextBookCorrectly()
        {
            TextBook expectedBook = new("The Shining", "Stephen King", "Horror");

            StringBuilder expectedMessageSb = new StringBuilder();            

            string actualMessage = library.AddTextBookToLibrary(expectedBook);

            expectedMessageSb.AppendLine($"Book: {expectedBook.Title} - {expectedBook.InventoryNumber}");
            expectedMessageSb.AppendLine($"Category: {expectedBook.Category}");
            expectedMessageSb.AppendLine($"Author: {expectedBook.Author}");

            string expectedMessage = expectedMessageSb.ToString().TrimEnd();

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(library.Catalogue.First(), expectedBook);
            Assert.AreEqual(expectedBook.InventoryNumber, 1);
        }

        [Test]
        public void UniversityLibraryLoanTextBookShouldJumpInFirstIfCase()
        {
            TextBook book = new("The Shining", "Stephen King", "Horror");

            book.Holder = "Gosho";
            book.InventoryNumber = 1;

            _ = library.AddTextBookToLibrary(book);

            string actualMessage = library.LoanTextBook(1, "Gosho");

            string expectedMessage = $"Gosho still hasn't returned {book.Title}!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UniversityLibraryLoanTextBookShouldJumpInElseCase()
        {
            TextBook book = new("The Shining", "Stephen King", "Horror");

            book.Holder = "Peter";
            book.InventoryNumber = 1;

            _ = library.AddTextBookToLibrary(book);

            string actualMessage = library.LoanTextBook(1, "Gosho");//holder == gosho

            string expectedMessage = $"{book.Title} loaned to Gosho.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(book.Holder, "Gosho");
        }

        [Test]
        public void UniversityLibraryReturnBookShouldWorkProperly()
        {
            TextBook book = new("The Shining", "Stephen King", "Horror");

            book.InventoryNumber = 1;

            library.AddTextBookToLibrary(book);

            string actualMessage = library.ReturnTextBook(1);

            string expectedMessage = $"{book.Title} is returned to the library.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(book.Holder, string.Empty);
        }
    }
}