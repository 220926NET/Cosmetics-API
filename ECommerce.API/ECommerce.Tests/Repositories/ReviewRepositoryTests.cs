using Xunit;
using Moq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests.Repositories;

public class ReviewRepositoryTests
{
    [Fact]
    public void CreateReview()
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            Review result = mock.reviewRepository.CreateReview(new Review {
                UserId = 1,
                ProductId = 17,
                Text = "Was ok",
                Rating = 3
            });

            Assert.Equal(result.UserId, 1);
            Assert.Equal(result.ProductId, 17);
            Assert.Equal(result.Text, "Was ok");
            Assert.Equal(result.Rating, 3);
        }
    }
    
    [Fact]
    public void ApiIdToPrimaryProductId()
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            int result = mock.reviewRepository.ApiIdToPrimaryProductId(91);
            Assert.Equal(result, 11);

            result = mock.reviewRepository.ApiIdToPrimaryProductId(97);
            Assert.Equal(result, 17);
        }
    }

    [Fact]
    public void ProductIdToPrimaryProductId()
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            int result = mock.reviewRepository.ProductIdToPrimaryProductId(11);
            Assert.Equal(result, 11);

            result = mock.reviewRepository.ProductIdToPrimaryProductId(12);
            Assert.Equal(result, 11);

            result = mock.reviewRepository.ProductIdToPrimaryProductId(17);
            Assert.Equal(result, 17);
        }
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    public void GetByReviewId(bool includeUser = false, bool includeProduct = false)
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            Review result = mock.reviewRepository.GetByReviewId(21, includeUser, includeProduct);

            Assert.Equal(result.Id, 21);
            Assert.Equal(result.UserId, 1);
            Assert.Equal(result.ProductId, 11);

            if (includeUser)
            {
                Assert.Equal(result.User.FirstName, "John");
            }

            if (includeProduct)
            {
                Assert.Equal(result.Product.ProductName, "Acme Lipstick 1337");
            }
        }
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    public void GetByApiId(bool includeUser = false, bool includeProduct = false)
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            List<Review> resultList = mock.reviewRepository.GetByApiId(91, includeUser, includeProduct);
            Review result = resultList[0];

            Assert.Equal(result.Id, 21);
            Assert.Equal(result.UserId, 1);
            Assert.Equal(result.ProductId, 11);

            if (includeUser)
            {
                Assert.Equal(result.User.FirstName, "John");
            }

            if (includeProduct)
            {
                Assert.Equal(result.Product.ProductName, "Acme Lipstick 1337");
            }
        }
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    public void GetByProductId(bool includeUser = false, bool includeProduct = false)
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            List<Review> resultList = mock.reviewRepository.GetByProductId(11, includeUser, includeProduct);
            Review result = resultList[0];

            Assert.Equal(result.Id, 21);
            Assert.Equal(result.UserId, 1);
            Assert.Equal(result.ProductId, 11);

            if (includeUser)
            {
                Assert.Equal(result.User.FirstName, "John");
            }

            if (includeProduct)
            {
                Assert.Equal(result.Product.ProductName, "Acme Lipstick 1337");
            }
        }
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    public void GetByUserId(bool includeUser = false, bool includeProduct = false)
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            List<Review> resultList = mock.reviewRepository.GetByUserId(2, includeUser, includeProduct);
            Review result = resultList[0];

            Assert.Equal(result.Id, 22);
            Assert.Equal(result.UserId, 2);
            Assert.Equal(result.ProductId, 11);

            if (includeUser)
            {
                Assert.Equal(result.User.FirstName, "Jane");
            }

            if (includeProduct)
            {
                Assert.Equal(result.Product.ProductName, "Acme Lipstick 1337");
            }
        }
    }

    [Fact]
    public void Delete()
    {
        using(MockReviewRepo mock = new MockReviewRepo())
        {
            Assert.True(mock.reviewRepository.Delete(23));
            Assert.False(mock.reviewRepository.Delete(999));
        }
    }   
}
/*
Use for testing
https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/writing-test-doubles

https://github.com/moq/moq4/wiki/Quickstart#properties

For creating inmemory database
https://www.thecodebuzz.com/dbcontext-mock-and-unit-test-entity-framework-net-core/
*/