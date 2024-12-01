using webapitest.DAL.Entities;

namespace webapitest.DAL
{
    public class SeederDB
    {
        private readonly DateBaseContext _context;

        public SeederDB(DateBaseContext context)
        {
            _context = context;
        }



        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();


            await PopulateCountriesAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methos
        private async Task PopulateCountriesAsync()
        {

            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });


                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }
    }

    #endregion
}
