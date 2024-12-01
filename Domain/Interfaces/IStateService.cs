using webapitest.DAL.Entities;

namespace webapitest.Domain.Interfaces
{
        public interface IStateService
        {
            Task<IEnumerable<State>> GetStateAsync();
            Task<State> GetStateByIdAsync(Guid Id);
            Task<State> CreateStateAsync(State state);
            Task<State> EditStateAsync(State state);
            Task<State> DeleteStateAsync(Guid Id);
        }
}
