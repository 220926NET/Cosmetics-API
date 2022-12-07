using Xunit;
using Moq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;

public class CosmeticsContextTests
{
    [Fact]
    public void Create()
    {
        CosmeticsContext cosmeticsContext = new CosmeticsContext();
        Assert.NotNull(cosmeticsContext);
    }
}