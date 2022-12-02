using Data.Entities;
using Models; 

namespace Data; 
public interface IProductRepo {
     List<ProductDetailsDto> GetProductList(string type);
     ProductDetailsDto GetById(int productId);
     List<ProductDetailsDto> GetByApiId(int apiId);
}