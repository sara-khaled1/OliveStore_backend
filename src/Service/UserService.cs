using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.Utility;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service;

public class UserService : IUserService
{
    private IConfiguration _config;
    private IUserRepository _userRepository;
    private IMapper _mapper;
    public UserService(IUserRepository userRepository, IConfiguration config, IMapper mapper)
    {
        _userRepository = userRepository;
        _config = config;
        _mapper = mapper;
    }
    public string? SignIn(UserSignIn userSign)
    {
        User? user = _userRepository.FindByEmail(userSign.Email);
        if (user is null) return null;

        byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);

        bool isCorrectPass = PasswordUtility.VerifyPassword(userSign.Password, user.Password, pepper);
        if (!isCorrectPass) return null;
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
    public IEnumerable<UserReadDto> FindAll()
    {
        var user = _userRepository.FindAll();
        var userRead = user.Select(_mapper.Map<UserReadDto>);
        return userRead;
    }
    public UserReadDto? FindOne(Guid id)
    {
        User? user = _userRepository.FindOne(id);
        UserReadDto? userRead = _mapper.Map<UserReadDto>(user);
        return userRead;
    }
    public UserReadDto? FindByEmail(string email)
    {
        User? user = _userRepository.FindByEmail(email);
        UserReadDto? userRead = _mapper.Map<UserReadDto>(user);
        return userRead;
    }
    public UserReadDto? UpdateOne(Guid id, User user)
    {
        User? updatedUser = _userRepository.FindOne(id);
        if (updatedUser is not null)
        {
            updatedUser.FullName = user.FullName;
            updatedUser.Phone = user.Phone;
            var userAllInfo = _userRepository.UpdateOne(updatedUser);
            var userRead = _mapper.Map<UserReadDto>(userAllInfo);
            return userRead;
        }
        else return null;
    }
    public bool DeleteOne(Guid id)
    {
        return _userRepository.DeleteOne(id);
    }
    public UserReadDto? SignUp(UserCreateDto user)
    {
        User? foundUser = _userRepository.FindByEmail(user.Email);
        if (foundUser is not null)
        {
            return null;
        }
        byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);

        PasswordUtility.HashPassword(user.Password, out string hashedPassword, pepper);
        user.Password = hashedPassword;

        var createUser = _mapper.Map<User>(user);
        var newUser = _userRepository.CreateOne(createUser);
        var userRead = _mapper.Map<UserReadDto>(newUser);
        return userRead;
    }
}
