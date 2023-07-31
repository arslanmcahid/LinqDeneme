using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IBookReaderService: IService<BookReader>
    {
        public Task<CustomResponseDto<BookReaderDto>> GetAllReverseForId();    
        public Task<CustomResponseDto<BookReaderDto>> GetSameEmail();
    }
}
