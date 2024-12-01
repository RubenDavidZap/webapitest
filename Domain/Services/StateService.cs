using Microsoft.EntityFrameworkCore;
using webapitest.DAL.Entities;
using webapitest.DAL;
using webapitest.Domain.Interfaces;

namespace webapitest.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DateBaseContext _context;

        public StateService(DateBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStateAsync()
        {
            try
            {
                var states = await _context.States
                    .Include(s => s.Country) // Incluir la relación con Country
                    .ToListAsync();
                return states;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid Id)
        {
            try
            {
                var state = await _context.States
                    .Include(s => s.Country) // Incluir la relación con Country
                    .FirstOrDefaultAsync(x => x.Id == Id);
                return state;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;

                _context.States.Add(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid Id)
        {
            try
            {
                var state = await GetStateByIdAsync(Id);
                if (state == null)
                {
                    return null;
                }
                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
