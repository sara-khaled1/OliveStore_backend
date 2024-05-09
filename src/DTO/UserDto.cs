namespace sda_onsite_2_csharp_backend_teamwork.src.DTO;

public class UserReadDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
public class UserCreateDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Phone { get; set; }
}
public class UserSignIn
{
    public string Email { get; set; }
    public string Password { get; set; }
}