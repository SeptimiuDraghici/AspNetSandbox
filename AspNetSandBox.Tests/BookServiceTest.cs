using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            //Assume

            var bookService = new BooksService();

            //Act

            bookService.Post(new Book
            {
                Title = "Metro 2035",
                Author = "Dmitry Glukhovsky",
                Language = "English"
            });
            bookService.Delete(2);
            bookService.Post(new Book
            {
                Title = "Shining",
                Author = "Stephen King",
                Language = "English"
            });

            //Assert

            Assert.Equal("Metro 2035", bookService.Get(3).Title);
        }
    }
}
