using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SyncHub.Application.DTOs;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Repositories;
using SyncHub.Infrastructure.Data;
using SyncHub.Jobs.Interfaces;

namespace SyncHub.Jobs.Jobs
{
    public class DeckOfCardsJob
    {
        private readonly IDeckOfCardsService _deckService;
        private readonly IDeckRepository _deckRepository;
        private readonly ILogger<DeckOfCardsJob> _logger;
        private readonly ICardRepository _cardRepository;

        public DeckOfCardsJob(IDeckOfCardsService deckService, IDeckRepository deckRepository, ILogger<DeckOfCardsJob> logger, ICardRepository cardRepository)
        {
            _deckService = deckService;
            _deckRepository = deckRepository;
            _logger = logger;
            _cardRepository = cardRepository;
        }

        [AutomaticRetry(Attempts = 3)]
        public async Task FetchAndStoreDeckAsync()
        {
            try
            {
                DeckResponseDTO deckResponse = await _deckService.CreateDeckAsync();
                if (deckResponse.success)   
                {

                    await _deckRepository.AddDeckAsync(new Deck
                    {
                        Deck_Id = deckResponse.deck_id,
                        CreatedAt = DateTime.UtcNow,
                    });

                    Deck deck = await _deckRepository.GetDeckAsync(deckResponse.deck_id);
                    Random random = new Random();
                    DeckResponseDTO cardsResponse = await _deckService.DrawCardsAsync(deckResponse.deck_id, random.Next(1, 53));
                    List<Card> cards = cardsResponse.cards.Select(card => new Card
                    {
                        DeckId = deck.Id,
                        Value = card.Value,
                        Code = card.Code,
                        Image = card.Images.svg,
                        Suit = card.Suit,
                        CreatedAt = DateTime.UtcNow,
                    }).ToList();

                    if (cards.Any())
                    {
                        await _cardRepository.SaveCardsAsync(cards);

                        _logger.LogInformation($"{cards.Count} cards saved into the Db");
                    }
                    else
                    {
                        _logger.LogWarning("No card was drew for deckId: {DeckId}", deckResponse.deck_id);
                    }
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving.");
            }
        }
    }
}
