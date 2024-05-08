namespace sda_onsite_2_csharp_backend_teamwork.src.DTO;
public class ProductReadDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

}

public class ProductCreateDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }

}