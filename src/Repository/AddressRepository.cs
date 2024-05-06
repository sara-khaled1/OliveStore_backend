using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;
public class AddressRepository : IAddressRepository
{
    private DbSet<Address> _addresses { get; set; }
    private DatabaseContext _databaseContext;
    public AddressRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _addresses = databaseContext.Addresses;
    }

    public IEnumerable<Address> FindAll()
    {
        return _addresses;
    }

    public Address? FindOne(Guid id)
    {
        Address? address = _addresses.FirstOrDefault(address => address.Id == id);
        if (address is null) return null;

        return address;
    }
    public Address CreateOne(Address address)
    {
        _addresses.Add(address);
        _databaseContext.SaveChanges();
        return address;
    }
    public Address? UpdateOne(Address updatedAddress)
    {
        _addresses.Update(updatedAddress);
        _databaseContext.SaveChanges();
        return updatedAddress;
    }
    public bool DeleteOne(Guid id)
    {
        Address? address = FindOne(id);
        if (address is null) return false;
        _addresses.Remove(address);
        return true;
    }
}