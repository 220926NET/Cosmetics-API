using Data;
using Models;


namespace Services;
public class ProductService : IProductService
{

    private readonly IProductRepo _repo;

    public ProductService(IProductRepo productRepo)
    {
        _repo = productRepo;
    }


    public List<ProductDetailsDto
> getAllProducts(string product)
    {

        List<ProductDetailsDto
> products = new List<ProductDetailsDto
>();

        if (product == "lipstick")
        {
            products = _repo.GetAllLipsticks();
            return products;
        }
        if (product == "eyeshadow")
        {

            products = _repo.GetAllEyeShadow();
        }
        if (product == "eyeliner")
        {

            products = _repo.GetAllEyeLiner();
        }
        if (product == "foundation")
        {

            products = _repo.GetAllFoundation();
        }
        if (product == "blush")
        {

            products = _repo.GetAllBlush();
        }


        return products;
    }

}