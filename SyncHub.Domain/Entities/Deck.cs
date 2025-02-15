using System.Text.Json.Serialization;
using SyncHub.Domain.Commom;

namespace SyncHub.Domain.Entities
{
    public class Deck : BaseEntity
    {
        public string Deck_Id { get; set; }
        [JsonIgnore]
        public virtual List<Card> Cards { get; set; }
    }
}
