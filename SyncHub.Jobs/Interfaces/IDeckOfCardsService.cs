using SyncHub.Application.DTOs;

namespace SyncHub.Jobs.Interfaces
{
    public interface IDeckOfCardsService
    {
        Task<DeckResponseDTO> CreateDeckAsync();
        Task<DeckResponseDTO> DrawCardsAsync(string deckId, int count = 1);
    }
}
