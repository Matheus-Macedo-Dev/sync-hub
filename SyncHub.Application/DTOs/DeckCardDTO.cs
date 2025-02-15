namespace SyncHub.Application.DTOs
{
    public class DeckCardDTO
    {
        public string Code { get; set; }
        public Image Images { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
    }
    public class Image
    {
        public string png { get; set; }
        public string svg { get; set; }
    }
}
