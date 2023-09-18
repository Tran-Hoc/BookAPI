using BookAPI.Models;

namespace BookAPI.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModels>> GetAllAsync();
        public Task<BookModels> GetAsync(int id);
        public Task<int> AddAsync(BookModels model);
        public Task<int> UpdateAsync(int id, BookModels model);
        public Task<int> DeleteAsync(int id);
    }
}
