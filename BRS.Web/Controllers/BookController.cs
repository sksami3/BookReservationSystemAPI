using AutoMapper;
using BRS.Core.Entity;
using BRS.Core.Interfaces.Services;
using BRS.Core.ViewModel.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;
using System.Transactions;

namespace BRS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IReservationHistoryService _historyService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public BookController(
            IBookService bookService,
            IReservationHistoryService historyService,
            IAuthorService authorService,
            IMapper mapper
            )
        {
            _bookService = bookService;
            _historyService = historyService;
            _authorService = authorService;
            _mapper = mapper;
        }
        #region Book CRUD 
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var book = await _bookService.GetBooks();
                return Ok(_mapper.Map<IEnumerable<BookVM>>(book));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            try
            {
                var bookVM = _mapper.Map<BookVM>(await _bookService.GetBookById(new Guid(id)));
                return Ok(bookVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAllReservedBook")]
        public async Task<IActionResult> GetAllReservedBook()
        {
            try
            {
                var reservedBooks = await _bookService.GetBookListByStatus(Core.Enums.Status.reserved);
                return Ok(reservedBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAllAvailableBook")]
        public async Task<IActionResult> GetAllAvailableBook()
        {
            try
            {
                var availableBooks = await _bookService.GetBookListByStatus(Core.Enums.Status.unreserved);
                return Ok(availableBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> CreateBook(BookVM bookVM)
        {
            try
            {
                if (!string.IsNullOrEmpty(bookVM.Author_Id))
                    bookVM.AuthorId = Guid.Parse(bookVM.Author_Id);
                var createdBook = await _bookService.Add(_mapper.Map<Book>(bookVM));
                var book = await _bookService.GetBookById(createdBook.Id);
                if (!string.IsNullOrEmpty(book.AuthorId.ToString()) && book.AuthorId != Guid.Empty)
                    book.Author = await _authorService.GetAuthorById((Guid)book.AuthorId);

                return Ok(_mapper.Map<BookEditInsertVM>(book));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> EditBook(BookEditInsertVM bookVM)
        {
            try
            {
                await _bookService.Update(_mapper.Map<Book>(bookVM));
                return Ok(_mapper.Map<BookEditInsertVM>(await _bookService.GetBookById(bookVM.Id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Transaction failed: " + ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            try
            {
                await _bookService.SoftDelete(new Guid(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Transaction failed: " + ex.Message);
            }
        }
        #endregion

        #region Book Reservation
        /// <summary>
        /// Endpoint for reserving a book with the provided book ID and comment.
        /// </summary>
        /// <returns>
        /// If successful, returns an Ok response with the details of the newly reserved book.
        /// If unsuccessful, returns a 500 Internal Server Error with a transaction failure message.
        /// </returns>
        [HttpPost("Reserve")]
        public async Task<IActionResult> ReserveBook(string bookId, string comment)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var newBook = await _bookService.ReserveBook(new Guid(bookId), comment);
                    await _historyService.Add(new ReservationHistory { BookId = newBook.Id, Status = newBook.Status, Comment = newBook.Comment });
                    scope.Complete();

                    return Ok(newBook);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Transaction failed: " + ex.Message);
                }
            }

        }

        /// <summary>
        /// Endpoint for unreserving a book with the provided book ID and comment.
        /// </summary>
        /// <returns>
        /// If successful, returns an Ok response with the details of the newly reserved book.
        /// If unsuccessful, returns a 500 Internal Server Error with a transaction failure message.
        /// </returns>
        [HttpPost("UnreserveBook")]
        public async Task<IActionResult> UnreserveBook(string bookId)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var newBook = await _bookService.UnreserveBook(new Guid(bookId));
                    await _historyService.Add(new ReservationHistory { BookId = newBook.Id, Status = newBook.Status });
                    scope.Complete();

                    return Ok(newBook);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Transaction failed: " + ex.Message);
                }
            }

        }
        #endregion
    }
}
