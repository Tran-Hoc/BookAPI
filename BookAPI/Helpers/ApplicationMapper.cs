using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;

namespace BookAPI.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() {

            CreateMap<Book, BookModels>().ReverseMap();
        }
    }
}
