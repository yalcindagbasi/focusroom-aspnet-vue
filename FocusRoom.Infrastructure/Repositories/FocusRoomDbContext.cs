using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FocusRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FocusRoom.Infrastructure.Persistence;

public class FocusRoomDbContext : DbContext
{
    public FocusRoomDbContext(DbContextOptions<FocusRoomDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
}
