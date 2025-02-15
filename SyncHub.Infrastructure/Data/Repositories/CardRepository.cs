using Microsoft.EntityFrameworkCore;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;
using SyncHub.Domain.Repositories;

namespace SyncHub.Infrastructure.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly MyContext _context;

        public CardRepository(MyContext context)
        {
            _context = context;
        }

        public async Task SaveCardsAsync(List<Card> cards)
        {
            await _context.Cards.AddRangeAsync(cards);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _context.Cards
                            .Include(x => x.Deck)
                            .ToListAsync();
        }
        public async Task<List<Card>> GetCardsByFilterAsync(CardFilter filter)
        {
            IQueryable<Card> query = _context.Cards.Include(x => x.Deck).AsQueryable();
            
            if (!string.IsNullOrEmpty(filter.Value))
            {
                query = query.Where(x => string.Equals(x.Value,filter.Value));
            }
            if (!string.IsNullOrEmpty(filter.Suit))
            {
                query = query.Where(x => x.Suit.Contains(filter.Suit));
            }

            return await query.ToListAsync();
        }
    }
}
