using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction;

public interface IUserService
{
    public IEnumerable<UserReadDto> FindAll();
    public UserReadDto? FindOne(Guid id);
    public UserReadDto? SignUp(User user);
    public UserReadDto? UpdateOne(Guid id, User user);
    public bool DeleteOne(Guid id);
}
