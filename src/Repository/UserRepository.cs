using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;

public class UserRepository : IUserRepository
{
    private DbSet<User> _users { get; set; }
    private DatabaseContext _databaseContext;

    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _users = databaseContext.Users;
    }
    public IEnumerable<User> FindAll()
    {
        return _users;
    }
    public User CreateOne(User user)
    {
        _users.Add(user);
        _databaseContext.SaveChanges();
        return user;
    }
    public User? FindOne(Guid id)
    {
        User? user = _users.FirstOrDefault(user => user.Id == id);
        return user;
    }
    public User? FindByEmail(string email)
    {
        User? user = _users.FirstOrDefault(user => user.Email == email);
        return user;
    }
    public User UpdateOne(User updatedUser)
    {
        _users.Update(updatedUser);
        _databaseContext.SaveChanges();
        return updatedUser;
    }
    public bool DeleteOne(Guid id)
    {
        User? user = FindOne(id);
        if (user is null) return false;
        _users.Remove(user);
        _databaseContext.SaveChanges();
        return true;
    }
}
