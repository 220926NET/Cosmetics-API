using AutoMapper;
using Data.Entities;
using Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PostReviewDTO, Review>();
        CreateMap<Review, ReviewDTO>();
        CreateMap<Data.Entities.User, Models.ReviewDTO.UserDTO>();
        CreateMap<Data.Entities.Product, Models.ReviewDTO.ProductDTO>();
    }
}