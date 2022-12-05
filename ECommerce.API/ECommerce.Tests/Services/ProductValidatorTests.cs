using Xunit;
using Services;

namespace ECommerce.Tests.Services;

public class ProductsValidatorTests
{

    [Fact]
    public void INPUT_NOT_VALID()
    {
        Assert.Equal(false, ProductsValidator.IsValidProductType("ksdjkf"));


    }
    [Fact]
    public void INPUT_NOT_VALID_2()
    {
        Assert.Equal(false, ProductsValidator.IsValidProductType("eyeliner2"));


    }
    [Fact]
    public void INPUT_NOT_VALID_3()
    {
        Assert.Equal(false, ProductsValidator.IsValidProductType("eyeshadow3"));


    }

    [Fact]
    public void INPUT_IS_VALID_BLUSH()
    {
        Assert.Equal(true, ProductsValidator.IsValidProductType("blush"));


    }


    [Fact]
    public void INPUT_IS_VALID_EYELINER()
    {
        Assert.Equal(true, ProductsValidator.IsValidProductType("eyeliner"));


    }


    [Fact]
    public void INPUT_IS_VALID_EYESHADOW()
    {
        Assert.Equal(true, ProductsValidator.IsValidProductType("eyeshadow"));


    }


    [Fact]
    public void INPUT_IS_VALID_FOUDNATION()
    {
        Assert.Equal(true, ProductsValidator.IsValidProductType("foundation"));


    }

    [Fact]
    public void INPUT_IS_VALID_LIPSTICK()
    {
        Assert.Equal(true, ProductsValidator.IsValidProductType("lipstick"));


    }



}