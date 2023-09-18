using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddAsync(BookModels model)
        {
            var newModel = _mapper.Map<Book>(model);
            _context.Books!.Add(newModel);
            await _context.SaveChangesAsync();

            return newModel.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delModel = _context.Books!.SingleOrDefault(b => b.Id == id);
            if (delModel != null)
            {
                _context.Books!.Remove(delModel);
                await _context.SaveChangesAsync();
                return delModel.Id;
            }
            return -1;
        }

        public async Task<List<BookModels>> GetAllAsync()
        {
            var models = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModels>>(models);
        }

        public async Task<BookModels> GetAsync(int id)
        {
            var model = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModels>(model);
        }

        public async Task<int> UpdateAsync(int id, BookModels model)
        {
            if (id == model.Id)
            {
                var updateBook = _mapper.Map<Book>(model);
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            return -1;
        }
    }
}
