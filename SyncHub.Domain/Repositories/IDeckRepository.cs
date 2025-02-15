using SyncHub.Domain.Entities;

namespace SyncHub.Domain.Repositories
{
    public interface IDeckRepository
    {
        Task AddDeckAsync(Deck deck);
        Task<Deck> GetDeckAsync(string deckId);
    }
}
