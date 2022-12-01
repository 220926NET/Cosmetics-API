using Data.Entities;
using Models; 

namespace Data; 
public interface IProductRepo {

     List<ProductDetailsDto
> GetAllLipsticks();

     List<ProductDetailsDto
> GetAllBlush();

     List<ProductDetailsDto
> GetAllEyeShadow();

     List<ProductDetailsDto
> GetAllEyeLiner();

     List<ProductDetailsDto
> GetAllFoundation();
     ProductDetailsDto GetById(int productId);
}