using FocusRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusRoom.Application.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<Session?>> GetUserSessionsAsync(Guid userId);
        Task AddAsync(Session session);
    }
}
