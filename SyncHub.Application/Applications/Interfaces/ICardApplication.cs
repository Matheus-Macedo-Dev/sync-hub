using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;

namespace SyncHub.Application.Applications.Interfaces
{
    public interface ICardApplication
    {
        Task<List<Card>> GetAllCards();
        Task<List<Card>> GetCardsByFilter(CardFilter filter);
    }
}
