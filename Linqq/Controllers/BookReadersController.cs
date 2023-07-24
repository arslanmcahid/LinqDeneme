using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linqq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReadersController : ControllerBase
    {
        private readonly BookReaderService _bookReaderService;
        private readonly IMapper _mapper;

        public BookReadersController(BookReaderService bookReaderService, IMapper mapper)
        {
            _bookReaderService = bookReaderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllReaders()
        {
            var readers = _bookReaderService.GetAllReaders();
            var readerDtos = _mapper.Map<List<BookReaderDto>>(readers);
            return Ok(readerDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetReaderById(int id)
        {
            var reader = _bookReaderService.GetReaderById(id);
            if (reader == null)
            {
                return NotFound();
            }

            var readerDto = _mapper.Map<BookReaderDto>(reader);
            return Ok(readerDto);
        }

        [HttpPost]
        public IActionResult AddReader(BookReaderDto readerDto)
        {
            var reader = _mapper.Map<BookReader>(readerDto);
            _bookReaderService.AddReader(reader);
            return CreatedAtAction(nameof(GetReaderById), new { id = reader.Id }, readerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReader(int id, BookReaderDto readerDto)
        {
            var existingReader = _bookReaderService.GetReaderById(id);
            if (existingReader == null)
            {
                return NotFound();
            }

            var reader = _mapper.Map<BookReader>(readerDto);
            reader.Id = id;
            _bookReaderService.UpdateReader(reader);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReader(int id)
        {
            var reader = _bookReaderService.GetReaderById(id);
            if (reader == null)
            {
                return NotFound();
            }

            _bookReaderService.DeleteReader(reader);
            return NoContent();
        }
    }
}