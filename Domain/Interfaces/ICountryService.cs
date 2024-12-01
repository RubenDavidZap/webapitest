using webapitest.DAL.Entities;

namespace webapitest.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountryAsync();

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid Id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid Id);
    }
}
