namespace SyncHub.Application.DTOs
{
    public class DeckResponseDTO
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool? shuffled { get; set; }
        public int? remaining { get; set; }
        public IEnumerable<DeckCardDTO>? cards { get; set; }
    }
}
