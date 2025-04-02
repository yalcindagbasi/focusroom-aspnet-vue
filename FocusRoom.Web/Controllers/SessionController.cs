using FocusRoom.Application.Interfaces;
using FocusRoom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FocusRoom.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserSessions(Guid userId)
        {
            var sessions = await _sessionRepository.GetUserSessionsAsync(userId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session session)
        {
            if (session == null) return BadRequest("Invalid session data.");

            await _sessionRepository.AddAsync(session);
            return CreatedAtAction(nameof(GetUserSessions), new { userId = session.UserId }, session);
        }
    }
}
