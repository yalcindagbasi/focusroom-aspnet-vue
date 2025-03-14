using FocusRoom.Application.Interfaces;
using FocusRoom.Domain.Entities;
using FocusRoom.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusRoom.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly FocusRoomDbContext _context;

        public SessionRepository(FocusRoomDbContext context)
        {
            _context = context;
        }

        public async Task<List<Session>> GetUserSessionsAsync(Guid userId) =>
            await _context.Sessions.Where(s => s.UserId == userId).ToListAsync();

        public async Task AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }
    }
}
