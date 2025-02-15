using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;

namespace SyncHub.Domain.Repositories
{
    public interface ICardRepository
    {
        Task SaveCardsAsync(List<Card> cards);
        Task<List<Card>> GetAllCardsAsync();
        Task<List<Card>> GetCardsByFilterAsync(CardFilter filter);
    }
}
