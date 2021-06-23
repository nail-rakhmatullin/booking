using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Booking.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLayer.Services
{
    public class HotelService : IHotelService
    {
        /*
         Нужно выделить отдельный класс для BookingContext так как контекст у нас
         не меняется и мы копируем код, нужно сделать реализовать dependency injection
         (Возможно для маппера тоже) !!
        */
        private readonly BookingContext _context;
        private readonly IMapper _mapper;

        public HotelService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var domainHotels = await _context.Hotels.ToListAsync();
            var dtoHotels = _mapper.Map<IEnumerable<Hotel>>(domainHotels);
            return dtoHotels;
        }

        public Guid AddHotel(Hotel hotel)
        {
            var hotelDL = new DataLayer.Tables.Hotels.Hotel();
            _mapper.Map(hotel, hotelDL);
            hotelDL.Id = Guid.NewGuid();
            _context.Hotels.Add(hotelDL);
            _context.SaveChanges();
            return hotelDL.Id;
        }

        public async Task<Hotel> EditHotel(Hotel hotel)
        {
            var hotelDL = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotel.Id);

            if (hotelDL is not null)
            {
                hotelDL.CompanyId = hotel.CompanyId != Guid.Empty ? hotel.CompanyId : hotelDL.CompanyId;
                hotelDL.Name = hotel.Name is not null ? hotel.Name : hotelDL.Name;
                hotelDL.Description = hotel.Description is not null ? hotel.Description : hotelDL.Description;
                hotelDL.AdditionalInfo =
                    hotel.AdditionalInfo is not null ? hotel.AdditionalInfo : hotelDL.AdditionalInfo;
                hotelDL.Address = hotel.Address is not null ? hotel.Address : hotelDL.Address;
                hotelDL.Lat = hotel.Lat;
                hotelDL.Lng = hotel.Lng;
                hotelDL.Rate = hotel.Rate;
                hotelDL.CityId = hotel.CityId > 0 ? hotel.CityId : hotelDL.CityId;
                hotelDL.ModifiedAt = DateTime.Now;
                hotelDL.ModifyReason = "HotelServiceApiRequest";
                _context.SaveChanges();
            }

            return _mapper.Map<Hotel>(hotelDL);
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            var domainServices = await _context.Services.ToListAsync();
            var dtoServices = _mapper.Map<IEnumerable<Service>>(domainServices);
            return dtoServices;
        }

        public async Task<Service> CreateService(Service service)
        {
            var domainService = _mapper.Map<DataLayer.Tables.Hotels.Service>(service);
            domainService.Id = Guid.NewGuid();
            domainService.ModifiedAt = DateTime.Now;
            await _context.Services.AddAsync(domainService);
            await _context.SaveChangesAsync();
            var dtoService = _mapper.Map<Service>(domainService);
            return dtoService;
        }

        public async Task<Service> EditService(Service service)
        {
            var domainService = _mapper.Map<DataLayer.Tables.Hotels.Service>(service);
            domainService.ModifiedAt = DateTime.Now;
            domainService.ModifyReason = "Ну понадобилось,че!";
            _context.Services.Update(domainService);
            await _context.SaveChangesAsync();
            var dtoService = _mapper.Map<Service>(domainService);
            return dtoService;
        }
    }
}