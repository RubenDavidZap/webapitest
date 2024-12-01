using Microsoft.EntityFrameworkCore;
using webapitest.DAL.Entities;
using webapitest.DAL;
using webapitest.Domain.Interfaces;

namespace webapitest.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DateBaseContext _context;

        public CountryService(DateBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountryAsync()
        {

            try
            {
                var countries = await _context.Countries.ToListAsync();
                return countries;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> GetCountryByIdAsync(Guid Id)
        {

            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id);
                return country;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {

            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return country;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> DeleteCountryAsync(Guid Id)
        {
            try
            {
                var country = await GetCountryByIdAsync(Id);
                if (country == null)
                {
                    return null;
                }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
