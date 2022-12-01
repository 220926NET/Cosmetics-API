using Models;
using Data;
using Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class ProductRepo : IProductRepo
{

    private readonly CosmeticsContext _context;

    private readonly ILogger<IProductRepo> _logger;

    public ProductRepo(ILogger<IProductRepo> logger, CosmeticsContext context)
    {
        _context = context;
        _logger = logger;

    }


    public List<ProductDetailsDto> GetProductList(string type)
    {

        List<ProductDetailsDto> products = new List<ProductDetailsDto>();
        int lastProduct = 0;

        foreach (var item in _context.Products.Where(product => product.ProductType == type).ToList())
        {
            if (lastProduct != item.ApiId) {
                lastProduct = item.ApiId;

                products.Add(new ProductDetailsDto()
                {
                    Id = item.ProductId,
                    ApiId = item.ApiId,
                    Name = item.ProductName,
                    Type = item.ProductType,
                    Brand = item.Brand,
                    Inventory = item.Inventory,
                    Price = item.Price,
                    Description = item.Description!,
                    Image = item.Image!,
                    HexValue = item.HexValue!,
                    Discount = DiscountPercent(item.ApiId)
                });
            }
        }

        return products;

    }

    private double DiscountPercent(int productId) {
        double discount = 0.00;
        // Check if a Deal for the specified Product's ID exists
        if (_context.Deals.Any(d => d.Product == productId)) {
            foreach (Deal deal in _context.Deals.Where(d => d.Product == productId)) {
                if (deal.StartTime <= DateTime.UtcNow && deal.EndTime >= DateTime.UtcNow) {
                    discount += (double) deal.Discount;
                }
            }
        }
        
        return discount;
    }

    public ProductDetailsDto GetById(int productId)
    {
        Entities.Product info = _context.Products.Where(i => i.ProductId == productId).First();

        return new ProductDetailsDto()
                {
                    Id = info.ProductId,
                    Name = info.ProductName,
                    Type = info.ProductType,
                    Brand = info.Brand,
                    Inventory = info.Inventory,
                    Price = info.Price,
                    Description = info.Description!,
                    Image = info.Image!,
                    HexValue = info.HexValue!,
                    Discount = DiscountPercent(info.ApiId)
                };
    }

    public List<ProductDetailsDto> GetByApiId(int apiId)
    {
        List<ProductDetailsDto> info = new List<ProductDetailsDto>();

        foreach (Entities.Product pInfo in _context.Products.Where(i => i.ApiId == apiId).ToList()) {
            info.Add(new ProductDetailsDto()
                {
                    Id = pInfo.ProductId,
                    ApiId = pInfo.ApiId,
                    Name = pInfo.ProductName,
                    Type = pInfo.ProductType,
                    Brand = pInfo.Brand,
                    Inventory = pInfo.Inventory,
                    Price = pInfo.Price,
                    Description = pInfo.Description!,
                    Image = pInfo.Image!,
                    ColourName = pInfo.ColourName!,
                    HexValue = pInfo.HexValue!,
                    Discount = DiscountPercent(apiId)
                });
        }

        return info;
    }
}