using Amazon.Runtime.Internal.Util;
using AutoMapper;
using BookStore.AutoMappings;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.NetworkInformation;

namespace BookStoreTest
{
    public class AuthorServiceTest
    {
        private Mock<IAuthorRepository> _authorRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<AuthorService>> _logger;
        private readonly IAuthorService _authorService;

        private IList<Author> Authors = new List<Author>()
        {
             new Author()
             {
                 Id=new Guid("552dd52b-627e-49cd-af85-83341bbeaa4a"),
                 Name="Author 1",
                 Bio="Author 1 Bio"
             },

             new Author()
             {
                 Id =new Guid("c04ff06c-ae2e-491d-ba6b-ce04a2360877"),
                 Name = "Author 2",
                 Bio = "Author 2 Bio"
             }              
        };

        public AuthorServiceTest()
        {
            var mockMapper =
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfiles(new[] { new AutoMapperConfigs() });
                });


            _mapper = mockMapper.CreateMapper();

            _authorRepository = new Mock<IAuthorRepository>();
            _logger = new Mock<ILogger<AuthorService>>();

            _authorService =
                new AuthorService(
                    _authorRepository.Object, _mapper, _logger.Object);
        }

        [Fact]
        public async void GetAll_Test_OK()
        {
            //setup
            var expectedCount = 2;

            _authorRepository.Setup(x =>
                x.GetAll())
                .Returns(async () =>
                    Authors.AsEnumerable());

            //inject
            //Act
            var result =
                await _authorService.GetAll();

            var enumerable = result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, enumerable.Count());
            Assert.Equal(Authors, enumerable);
        }

        [Fact]
        public async void GetById_Test_OK()
        {
            //setup
            var authorId = Guid.NewGuid();

            _authorRepository.Setup(x =>
                x.GetById(authorId))
            .Returns(async () =>
                Authors.FirstOrDefault(a => a.Id == authorId));

            //inject
            //Act
            var result = await _authorService.GetById(authorId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetById_Test_NotFound()
        {
            //setup
            var expectedId = Authors[0].Id;
            var expectedName = $"@{Authors[0].Name}";

            _authorRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Authors.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _authorService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async void AddAuthor_Test_Ok()
        {
            //setup
            var expectedCount = 3;
            var authorRequest = new AddAuthorRequest()
            {
                Name = "Author 3",
                Bio = "Author 3 Bio"
            };

            _authorRepository.Setup(x =>
                    x.AddAuthor(It.IsAny<Author>()))
                .Callback(() =>
                {
                    Authors.Add(new Author()
                    {
                        Name = "Author 3",
                        Bio = "Author 3 Bio"
                    });
                });


            //inject
            //Act
            var result =
                await _authorService.AddAuthor(authorRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, Authors.Count);
        }

        [Fact]
        public async void AddAuthor_Test_NotFound()
        {
            //setup
            var expectedId = Authors[0].Id;
            var expectedName = $"@{Authors[0].Name}";

            _authorRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Authors.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _authorService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async void Delete_Test_OK()
        {
            //setup
            var expectedId = Authors[0].Id;
            var expectedName = $"@{Authors[0].Name}";

            _authorRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Authors.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _authorService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }
    }
}