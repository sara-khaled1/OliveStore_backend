using System.Text;
using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.Utility;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service;
//Map 
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

    public UserReadDto? SignUp(User user)
    {
        User? foundUser =
         _userRepository.FindOne(user.Id);
        if (foundUser is not null)
        {
            return null;
        }
        byte[] pepper =
        Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);

        PasswordUtility.HashPassword(user.Password, out string hashedPassword, pepper);
        user.Password = hashedPassword;


        var createdUser = _userRepository.CreateOne(user);
        var userRead = _mapper.Map<UserReadDto>(createdUser);
        return userRead;
    }
}
