using LibraryRecords.Models;
using LibraryRecords.Models.Data;
using LibraryRecords.Models.ViewModels;
using LibraryRecords.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Net;

namespace LibraryRecords.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly ITransactionService _transactionservice;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, ITransactionService transactionservice)
        {
            _logger = logger;
            _bookService = bookService;
            _transactionservice = transactionservice;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult Detail(int id)
        {
            var book = _bookService.GetBook(id);
            return View(book);
        }
        public IActionResult CheckOut(int id)
        {
            var book = _bookService.GetBook(id);
            var model = new CheckOutViewModel
            {
                BookId = book.Id,
                CheckOutDate = DateTime.Now,
                DueDate = Helper.DateAdd(DateTime.Now, 15)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutViewModel model)
        {
            // Kitap var mı kontrolü
            var book = _bookService.GetBook((model.BookId));
            if (book == null)
            {
                // Kitap bulunamadı
                return NotFound();
            }

            // Kitap ödünç alınmış mı kontrolü
            if (book.IsCheckedOut)
            {
                // Kitap zaten ödünç alınmış
                return BadRequest("Kitap zaten ödünç alınmış.");
            }

            // LibraryTransaction kaydı
            var transaction = new LibraryTransaction
            {
                BookId = model.BookId,
                DueDate = model.DueDate,
                CheckOutDate = model.CheckOutDate,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                TCKN = model.TCKN,
                IsCheckedOut = false,
                ActualReturnDate = DateTime.MinValue // İade yapılmadığı için varsayılan değer
            };

            book.IsCheckedOut = true;

            _transactionservice.AddTransaction(transaction);
            _bookService.SaveBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult CheckIn(int id)
        {
            var book = _bookService.GetBook(id);

            var lastTransaction = book.Transactions.OrderByDescending(t => t.DueDate).FirstOrDefault();

            // ViewModel oluştur
            var viewModel = new ChechInViewModel
            {
                BookId = book.Id,
                Name = lastTransaction.Name,
                PhoneNumber = lastTransaction.PhoneNumber,
                DueDate = lastTransaction.DueDate,
                ReturnDate = DateTime.Now // İade tarihi, form yüklendiği anki tarih
            };

            return View(viewModel);

            return View(book);
        }

        [HttpPost]
        public IActionResult CheckIn(ChechInViewModel model)
        {
            // Kitap var mı kontrolü
            var book = _bookService.GetBook((model.BookId));
            if (book == null)
            {
                // Kitap bulunamadı
                return NotFound();
            }

            // Kitap ödünç alınmış mı kontrolü
            if (!book.IsCheckedOut)
            {
                // Kitap zaten ödünç alınmamış
                return BadRequest("Kitap zaten ödünç alınmamış.");
            }

            // Son ödünç alma işlemi
            var lastTransaction = book.Transactions.OrderByDescending(t => t.DueDate).FirstOrDefault();

            // İade tarihi
            var returnDate = DateTime.Now;

            if (returnDate > lastTransaction.DueDate)
            {
                TimeSpan timeSpan = returnDate.Subtract(lastTransaction.DueDate);
                lastTransaction.LateFee = (int)timeSpan.TotalDays > 0 ? (int)timeSpan.TotalDays * 10 : 10;
            }

            // Kitabı ödünç alındı olarak işaretle
            book.IsCheckedOut = false;

            // Son işlemi güncelle (iade tarihini ekleyerek)
            lastTransaction.ActualReturnDate = returnDate;
            lastTransaction.IsCheckedOut = true;

            _transactionservice.SaveTransaction(lastTransaction);
            _bookService.SaveBook(book);

            return RedirectToAction("Index");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}