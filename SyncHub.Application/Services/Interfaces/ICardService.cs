using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;

namespace SyncHub.Application.Services.Interfaces
{
    public interface ICardService
    {
        Task<List<Card>> GetAllCardsAsync();
        Task<List<Card>> GetCardsByFilterAsync(CardFilter filter);
    }
}
