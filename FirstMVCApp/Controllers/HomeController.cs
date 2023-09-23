using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SayHello(String name)
        {
            if (String.IsNullOrEmpty(name))
                ViewData["v1"] = "Name is empty";
            else           
            ViewData["v1"] = name;
            return View();
        }
        public IActionResult Add(int x, int y)
        {
            int result = x + y;
             ViewData["result"] = result;          
            return View("Add");
        }
        public IActionResult Multiply(int x, int y)
        {
            int result = x * y;
            ViewData["result"] = result;
            return View("Add");
        }
        public IActionResult Divide(int x, int y)
        {
            int result = x/y;
            ViewData["result"] = result;
            return View("Add");
        }
        public IActionResult DoLogin(String txtuser, String txtpwd)
        {
            ViewData["userValue"] = $"{txtuser},{txtpwd}";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddNewBook()
        {
            Book book=new Book();
            return View(book);
        }
        public IActionResult SaveNewBook(Book pBook)
        {
            String fName = @"c:\temp\book.csv";
            string strBook = $"{pBook.BookID},{pBook.Title},{pBook.AuthorName},{pBook.Cost}";
            using (StreamWriter sw = new StreamWriter(fName,true))
            {
                sw.WriteLine(strBook);
            }
            return View(pBook);
        }
        private Book StringToBook(String[] data, Book book)
        {
            book.BookID = int.Parse(data[0]);
            book.Title = data[1];
            book.AuthorName = data[2];
            book.Cost = float.Parse(data[3]);
            return book;

        }
        public IActionResult ListAllBook()
        {
            String fName = @"c:\temp\book.csv";
            List<Book> list = new List<Book>();
            using (StreamReader sr = new StreamReader(fName))
            {
                string strBook = $"{sr.ReadLine()}";
                String[] data = strBook.Split(',');
                Book book = StringToBook(data, new Book());
                list.Add(book);
                while (!sr.EndOfStream)
                {
                    strBook = $"{sr.ReadLine()}";
                    data = strBook.Split(',');
                    book = StringToBook(data, new Book());
                    list.Add(book);
                }
            }
            return View(list);
        }
        public IActionResult AddNewAuthor()
        {
            Author author = new Author();
            return View();
        }
        public IActionResult SaveNewAuthor(Author pAuthor)
        {
            String fName = @"c:\temp\author.csv";
            string strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.DateOfBirth},{pAuthor.BookPublished},{pAuthor.RoyalityCompany}";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine(strAuthor);
            }
            return View(pAuthor);
        }
        private Author StringToAuthor(String[] data, Author author)
        {
            author.AuthorID = int.Parse(data[0]);
            author.AuthorName = data[1];
            author.DateOfBirth = data[2];
            author.BookPublished = int.Parse(data[3]);
            author.RoyalityCompany = data[4];
            return author;
        }
        public IActionResult ListAllAuthor()
        {
            String fName = @"c:\temp\author.csv";
            List<Author> list = new List<Author>();
            using (StreamReader sr = new StreamReader(fName))
            {
                string strAuthor = $"{sr.ReadLine()}";
                String[] data = strAuthor.Split(',');
                Author author = StringToAuthor(data, new Author());
                list.Add(author);
                while (!sr.EndOfStream)
                {
                    strAuthor = $"{sr.ReadLine()}";
                    data = strAuthor.Split(',');
                    author = StringToAuthor(data, new Author());
                    list.Add(author);
                }
            }
            return View(list);
        }
        public IActionResult DeleteAuthor()
        {
            Author author = new Author();
            return View(author);
        }
        public IActionResult EditAuthor()
        {
            Author author = new Author();
            return View(author);
        }
    }
}