using Newtonsoft.Json;
using SyncHub.Application.DTOs;
using SyncHub.Jobs.Interfaces;

namespace SyncHub.Jobs.Services
{
    public class DeckOfCardsService : IDeckOfCardsService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://deckofcardsapi.com/api/deck";

        public DeckOfCardsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeckResponseDTO> CreateDeckAsync()
        {
            string response = await _httpClient.GetStringAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            return JsonConvert.DeserializeObject<DeckResponseDTO>(response);
        }

        public async Task<DeckResponseDTO> DrawCardsAsync(string deckId, int count = 1)
        {
            string response = await _httpClient.GetStringAsync($"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={count}");
            return JsonConvert.DeserializeObject<DeckResponseDTO>(response);
        }
    }
}
