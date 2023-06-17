using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.DL.Repository;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;


        public AuthorService(
            IAuthorRepository authorRepository,
            IMapper mapper,
            ILogger<AuthorService> logger) 
        {
            _authorRepository= authorRepository;
            _mapper= mapper;
            _logger = logger;
        }

        public async Task<Author?> AddAuthor(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
           
            author.Id = Guid.NewGuid();
           
            await _authorRepository.AddAuthor(author);

            return author;
        }

        public async Task <IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task <Author?> GetById(Guid id)
        { 
            var result = await _authorRepository.GetById(id);

            if (result == null) return null;

            result.Name = $"@{result.Name}";

            return result;
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authorRepository.DeleteAuthor(id);
        }
    }
}
