using Microsoft.EntityFrameworkCore;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncHub.Infrastructure.Data.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly MyContext _context;
        public DeckRepository(MyContext myContext) 
        {
            _context = myContext;
        }

        public async Task AddDeckAsync(Deck deck)
        {
           await _context.Decks.AddAsync(deck);
           await _context.SaveChangesAsync();
        }

        public async Task<Deck> GetDeckAsync(string deckId)
        {
            return await _context.Decks.Where(d => d.Deck_Id == deckId).SingleOrDefaultAsync();
        }
    }
}
