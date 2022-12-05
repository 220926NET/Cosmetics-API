using Xunit;
using Moq;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Tests.Data;

public class ReviewRepositoryTest
{
    [Fact]
    public void INPUT_NOT_VALID()
    {
        //var builder = WebApplication.CreateBuilder(args);
        var mock = new Mock<CosmeticsContext>();
        //DbContext context = new DbContext();
        //DbSet set = new DbSet<Review>();
        //mock.Setup(context => context.Reviews).Returns(set);
    }
}
/*
Use for testing
https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/writing-test-doubles

https://github.com/moq/moq4/wiki/Quickstart#properties
*/