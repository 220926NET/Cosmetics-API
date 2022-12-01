namespace Models;


public class ProductDetailsDto
{

    public int Id { get; set; }
    public int ApiId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int Inventory { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string ColourName {get; set;}
    public string HexValue { get; set; }
    public double Discount { get; set; } = 0.00;

    public ProductDetailsDto() {}
}