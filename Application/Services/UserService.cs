using Application.DTO;
using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
        
    public UserService(IUserRepository userRepository, IMapper mapper, IAuthorRepository authorRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authorRepository = authorRepository;
    }
    
    public UserResponse GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        var response = _mapper.Map<UserResponse>(user);
        return response;
    }

    public List<UserResponse> GetAll()
    {
        var users = _userRepository.GetAll();
        var response = _mapper.Map<List<UserResponse>>(users);
        return response;
    }

    public async Task<UserResponse> Registration(UserCreateRequest request)
    {
        // Проверка существования пользователя с таким же никнеймом или email
        var existingUser = _userRepository.GetAll().Any(u => u.NickName == request.NickName || u.Email == request.Email);
        if (existingUser)
        {
            throw new InvalidOperationException("User with the same nickname or email already exists.");
        }

        // Создание нового пользователя
        var user = _mapper.Map<User>(request);
        var createdUser = _userRepository.Create(user);
        await _userRepository.SaveChanges();
        var response = _mapper.Map<UserResponse>(createdUser);
        return response;
    }

    public UserResponse Login(UserLoginRequest request)
    {
        // Ищем пользователя по его никнейму и паролю
        var user = _userRepository.GetAll().SingleOrDefault(u => u.NickName == request.NickName && u.Password == request.Password);
        // Если пользователь не найден, выбрасываем исключение UnauthorizedAccessException
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }
        var response = _mapper.Map<User, UserResponse>(user);
        return response;
    }
    
    public async Task<UserResponse> Update(UserUpdateRequest request)
    {
        var user = _userRepository.GetById(request.Id);
        if (user == null)
        {
            throw new ArgumentNullException("User not found");
        }
        user.Update(request.Email, request.PaymentDetails.FirstName, request.PaymentDetails.LastName, request.PaymentDetails.CardNumber, request.PaymentDetails.CheckingAccount, request.Role);
        var updatedUser = _userRepository.Update(user);
        await _userRepository.SaveChanges();
        return _mapper.Map<UserResponse>(updatedUser);
    }

    public bool Delete(Guid id)
    {
        return _userRepository.Delete(id);
    }
    
    public ICollection<OrderResponse> GetUserOrders(Guid userId)
    {
        var orders = _userRepository.GetUserOrders(userId);
        return _mapper.Map<ICollection<OrderResponse>>(orders);
    }
}