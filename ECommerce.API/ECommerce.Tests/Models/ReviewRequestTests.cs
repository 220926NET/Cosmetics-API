using Xunit;
using Models;

namespace ECommerce.Tests;

public class ReviewRequestTests
{
    [Fact]
    public void ReviewRequest_Create()
    {
        ReviewRequest reviewRequest = new ReviewRequest {
            UserId = 11,
            ApiId = 22, 
            ProductId = 33, 
            Text = "Amazing",
            Rating = 5
        };

        Assert.Equal(reviewRequest.UserId, 11);
        Assert.Equal(reviewRequest.ApiId, 22);
        Assert.Equal(reviewRequest.ProductId, 33);
        Assert.Equal(reviewRequest.Text, "Amazing");
        Assert.Equal(reviewRequest.Rating, 5);
    }
}