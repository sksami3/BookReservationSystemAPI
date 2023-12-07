using AutoMapper;
using BRS.Core.Entity;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Services;
using BRS.Core.ViewModel;
using BRS.Core.ViewModel.Book;
using Inventory.Business.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BRS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var authors = await _authorService.GetAuthors();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAuthorById(string id)
        {
            try
            {
                var author = await _authorService.GetAuthorById(new Guid(id));
                return Ok(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            try
            {
                await _authorService.Add(author);
                return Ok(GetAuthorById(author.Id.ToString()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> EditAuthor(AuthorEditVM authorEditVM)
        {
            try
            {
                await _authorService.Update(_mapper.Map<Author>(authorEditVM));
                return Ok(GetAuthorById(authorEditVM.Id.ToString()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _authorService.Delete(new Guid(id));
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
