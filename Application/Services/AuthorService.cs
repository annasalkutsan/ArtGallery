using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public AuthorResponse GetById(Guid id)
    {
        var author = _authorRepository.GetById(id);
        var response = _mapper.Map<AuthorResponse>(author);
        return response;
    }

    public List<AuthorResponse> GetAll()
    {
        var authors = _authorRepository.GetAll();
        var response = _mapper.Map<List<AuthorResponse>>(authors);
        return response;
    }

    public async Task<AuthorResponse> Create(AuthorCreateRequest request)
    {
        var existingUser = _authorRepository.GetAll().Any(u => u.FullName.FirstName == request.FullName.FirstName);
        if (existingUser)
        {
            throw new InvalidOperationException("Author with the same nickname or email already exists.");
        }
        var author = _mapper.Map<Author>(request);
        var createdAuthor = _authorRepository.Create(author);
        await _authorRepository.SaveChanges();
        var response = _mapper.Map<AuthorResponse>(createdAuthor);
        return response;
    }
    public async Task<AuthorResponse> Update(AuthorUpdateRequest request)
    {
        var author = _mapper.Map<Author>(request);
        var updatedAuthor = _authorRepository.Update(author);
        await _authorRepository.SaveChanges();
        var response = _mapper.Map<AuthorResponse>(updatedAuthor);
        return response;
    }

    public bool Delete(Guid id)
    {
        return _authorRepository.Delete(id);
    }

    public ICollection<PaintingResponse> GetPaintings(Guid authorId)
    {
        var paintings = _authorRepository.GetAuthorPaintings(authorId);
        return _mapper.Map<ICollection<PaintingResponse>>(paintings);
    }
}