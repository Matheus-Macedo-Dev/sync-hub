using SyncHub.Application.Applications.Interfaces;
using SyncHub.Application.Services.Interfaces;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;

namespace SyncHub.Application.Applications
{
    public class CardApplication : ICardApplication
    {
        private readonly ICardService _cardService;
        public CardApplication(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<List<Card>> GetAllCards()
        {
           return await _cardService.GetAllCardsAsync();
        }

        public async Task<List<Card>> GetCardsByFilter(CardFilter filter)
        {
            return await _cardService.GetCardsByFilterAsync(filter);
        }

    }
}
