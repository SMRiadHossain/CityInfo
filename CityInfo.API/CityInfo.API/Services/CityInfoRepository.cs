﻿using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync()
        {
            return await _context.PointsOfInterest.OrderBy(c => c.Name).ToListAsync();
        }



        public async Task<City?>GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if(includePointsOfInterest)
            {
                return await _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _context.Cities
                .Where(c => c.Id == cityId) .FirstOrDefaultAsync();
        }

        public async Task<User>GetUserAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId).ToListAsync();
        }

        public async Task<PointOfInterest?>GetPointOfInterestForCityAsync(int cityId, 
            int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }
        public async Task AddPointOfInterestForCityAsync(int cityId, int userId,
            PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if(city != null) 
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }
            var user = await GetUserAsync(userId);
            if(user != null)
            {
                user.PointsOfInterest.Add(pointOfInterest);
            }
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            

            return city;

        }

        public async Task<User> AddNewUserAsync(User user)
        {
            await _context.Users.AddAsync(user);


            return user;

        }


        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);

        }

        public void DeleteCity(City city)
        {
            _context.Cities.Remove(city);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()>=0);
        }


        public async Task<bool> UserExistAsync(string userName)
        {
            return await _context.Users.AnyAsync(c => c.userName == userName);
        }
        public async Task<bool> UserExistAsync(int userId)
        {
            return await _context.Users.AnyAsync(c => c.Id == userId);
        }

        public async Task<bool> PasswordValidAsync(string password)
        {
            return await _context.Users.AnyAsync(c => c.password == password);
        }

        public Task AddNewUserAsync(UserDto finalUSerDetails)
        {
            throw new NotImplementedException();
        }
    }
}