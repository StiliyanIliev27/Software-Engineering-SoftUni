using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary.Test
{
    public class TextBookTests
    {
        private TextBook textBook;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("The Shining", "Stephen King", "Horror");
        }
        
        [Test]
        public void TextBookShouldInitializeCorrectly()
        {
            string expectedTitle = textBook.Title;
            string expectedAuthor = textBook.Author;
            string expectedCategory = textBook.Category;

            Assert.AreEqual(expectedTitle, textBook.Title);
            Assert.AreEqual(expectedAuthor, textBook.Author);
            Assert.AreEqual(expectedCategory, textBook.Category);
        }
       
        [Test]
        public void TextBookSettersShouldWorkProperly()
        {
            string expectedTitle = "haha";
            string expectedAuthor = "Jonhie";
            string expectedCategory = "Comedy";
            int expectedInventoryNumber = 1;
            string expectedHolder = "Bony";

            textBook.Title = "haha";
            textBook.Author = "Jonhie";
            textBook.Category = "Comedy";
            textBook.InventoryNumber = 1;
            textBook.Holder = "Bony";

            Assert.AreEqual(expectedTitle, textBook.Title);
            Assert.AreEqual(expectedAuthor, textBook.Author);
            Assert.AreEqual(expectedCategory, textBook.Category);
            Assert.AreEqual(expectedInventoryNumber, textBook.InventoryNumber);
            Assert.AreEqual(expectedHolder, textBook.Holder);
        }

        [Test]
        public void TextBookToStringMethodShoudWorkCorrectly()
        {
            StringBuilder expectedMessage = new StringBuilder();

            expectedMessage.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            expectedMessage.AppendLine($"Category: {textBook.Category}");
            expectedMessage.AppendLine($"Author: {textBook.Author}");

            Assert.AreEqual(expectedMessage.ToString().TrimEnd(), textBook.ToString());
        }
    }
}
