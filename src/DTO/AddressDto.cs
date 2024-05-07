using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTO;

public class AddressReadDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
}
public class AddressCreateDto
{
    public Guid UserId { get; set; }//???? do we need it????!!!!!??!!?!?!?
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Zip_code { get; set; }
}
