using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTO;
public class CategoryReadDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
public class CategoryCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }



}
