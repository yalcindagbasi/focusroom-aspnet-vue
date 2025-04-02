using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusRoom.Domain.Entities
{
    public class Session
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int FocusMinutes { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime SessionDate { get; set; } = DateTime.UtcNow;
    }
}
