using Microsoft.AspNetCore.Mvc;
using webapitest.DAL.Entities;
using webapitest.Domain.Interfaces;
using webapitest.Domain.Services;

namespace webapitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController:Controller
    {
        private readonly ICountryService _CountryService;


        public CountriesController(ICountryService countryService)
        {
            _CountryService = countryService;

        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryAsync()
        {
            var countries = await _CountryService.GetCountryAsync();

            if (countries == null || !countries.Any()) return NotFound();

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid Id)
        {
            var country = await _CountryService.GetCountryByIdAsync(Id);

            if (country == null) return NotFound();

            return Ok(country);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _CountryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _CountryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound();
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete ")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid Id)
        {
            if (Id == null) return BadRequest();
            var deletedCountry = await _CountryService.DeleteCountryAsync(Id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);
        }
    }
}
