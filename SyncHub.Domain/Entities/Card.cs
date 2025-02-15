using System.Text.Json.Serialization;
using SyncHub.Domain.Commom;

namespace SyncHub.Domain.Entities
{
    public class Card : BaseEntity
    {
        public int DeckId { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
        [JsonIgnore]
        public virtual Deck Deck { get; set; }
    }
}
