using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction;

public interface IAddressService
{
    public IEnumerable<AddressReadDto> FindAll();
    public AddressReadDto? FindOne(Guid id);
    public AddressReadDto CreateOne(AddressCreateDto address);
    public AddressReadDto? UpdateOne(Guid id, Address address);
    public bool DeleteOne(Guid id);
}
