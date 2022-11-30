namespace Models;


public class ProductDetailsDto
{

    public int Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string Brand { get; set; }

    public int Inventory { get; set; }

    public decimal Price { get; set; }


    public string Description { get; set; }

    public string Image { get; set; }


    public List<String>? ColorHexValues { get; set; }

    public ProductDetailsDto()
    {

    }

}