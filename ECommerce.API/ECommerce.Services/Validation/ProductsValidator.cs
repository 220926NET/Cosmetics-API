namespace Services;


public static class ProductsValidator
{


    public static bool IsValidProductType(string productType)
    {
        if (productType == "blush" || productType == "eyeliner" || productType == "eyeshadow" || productType == "foundation" || productType == "lipstick")
        {
            return true;
        }
        return false;

    }



}