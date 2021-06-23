using AutoMapper;
using Booking.DataLayer.Tables.Bookings;
using Booking.DataLayer.Tables.Companies;
using Booking.DataLayer.Tables.Dictionaries;
using Booking.DataLayer.Tables.Hotels;
using Domain = Booking.DataLayer.Tables;
using DTO = Booking.BusinessLayer.DTOs;

namespace Booking.BusinessLayer.MapperProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<DTO.Country, Country>()
                .ReverseMap();
            CreateMap<DTO.City, City>()
                .ReverseMap();
            CreateMap<DTO.Apartment, Apartment>()
                .ReverseMap();
            CreateMap<DTO.Check, Check>()
                .ReverseMap();
            CreateMap<DTO.Company, Company>()
                .ReverseMap();
            CreateMap<DTO.Hotel, Hotel>()
                .ReverseMap();
            CreateMap<DTO.Order, Order>()
                .ReverseMap();
            CreateMap<DTO.Service, Service>()
                .ReverseMap();
            CreateMap<DTO.HotelImage, HotelImage>()
                .ReverseMap();
        }
    }
}