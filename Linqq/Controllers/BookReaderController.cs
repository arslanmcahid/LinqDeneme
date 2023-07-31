using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Linqq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReaderController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<BookReader> _service;
        private readonly IBookReaderService _bookReaderService;

        public BookReaderController(IMapper mapper, IService<BookReader> service, IBookReaderService bookReaderService)
        {
            _mapper = mapper;
            _service = service;
            _bookReaderService = bookReaderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReaders()
        {
            var readers = await _service.GetAllAsync();
            var readersDto = _mapper.Map<BookReaderDto>(readers);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200,readersDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReadersById(int id)
        {
            var reader = await _service.GetByIdAsync(id);
            var readerDto = _mapper.Map<BookReaderDto>(reader);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200, readerDto));
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookReaderDto readerDto)
        {
            var reader = await _service.AddAsync(_mapper.Map<BookReader>(readerDto));
            var reader1Dto = _mapper.Map<BookReaderDto>(reader);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200,reader1Dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReader(BookReaderDto readerDto)
        {
            await _service.UpdateAsync(_mapper.Map<BookReader>(readerDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReader(int id)
        {
            var reader = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(reader);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpGet("GetFirst10Reader/")]
        public async Task<IActionResult> GetFirst10Reader()
        {
            var readers = await _service.GetAllAsync();
            var first10readers = readers.Take(10);
            var first10reader = _mapper.Map<BookReaderDto>(first10readers);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200,first10reader));
        }
        [HttpGet("GetAllReverseForId/")]
        public async Task<IActionResult> GetAllReverseForId()
        {
            var readers = _bookReaderService.GetAllReverseForId();
            var readersDto = _mapper.Map<BookReaderDto>(readers);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200,readersDto));
        }
        [HttpGet("GetSameEmail/")]
        public async Task<IActionResult> GetSameEmail()
        {
            var readers = _bookReaderService.GetSameEmail();
            var readersDto = _mapper.Map<BookReaderDto>(readers);
            return CreateActionResult(CustomResponseDto<BookReaderDto>.Success(200,readersDto));
        }


    }
}
