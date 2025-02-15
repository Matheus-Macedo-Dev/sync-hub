using Microsoft.EntityFrameworkCore;
using SyncHub.Application.Services.Interfaces;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;
using SyncHub.Domain.Repositories;
using SyncHub.Infrastructure.Data;

namespace SyncHub.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<List<Card>> GetCardsByFilterAsync(CardFilter filter)
        {
            return await _cardRepository.GetCardsByFilterAsync(filter);
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAllCardsAsync();
        }
    }
}
