using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service;
public class AddressService : IAddressService
{
    private IAddressRepository _addressRepository;
    private IMapper _mapper;
    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    public IEnumerable<AddressReadDto> FindAll()
    {
        var address = _addressRepository.FindAll();
        var addressRead = address.Select(_mapper.Map<AddressReadDto>);
        return addressRead;
    }
    public AddressReadDto? FindOne(Guid id)
    {
        Address? address = _addressRepository.FindOne(id);
        AddressReadDto? addressRead = _mapper.Map<AddressReadDto>(address);
        return addressRead;
    }
    public AddressReadDto CreateOne(AddressCreateDto address, string userId)
    {
        var toAddress = _mapper.Map<Address>(address);
        toAddress.UserId = new Guid(userId);
        var createAddress = _addressRepository.CreateOne(toAddress);
        var addressRead = _mapper.Map<AddressReadDto>(createAddress);
        return addressRead;
    }
    public AddressReadDto? UpdateOne(Guid id, Address address)
    {
        Address? updatedAddress = _addressRepository.FindOne(id);
        if (updatedAddress is not null)
        {
            updatedAddress.Country = address.Country;

            var addressAllInfo = _addressRepository.UpdateOne(updatedAddress);
            var addressRead = _mapper.Map<AddressReadDto>(addressAllInfo);
            return addressRead;
        }
        return null;
    }
    public bool DeleteOne(Guid id)
    {
        return _addressRepository.DeleteOne(id);
    }
}
