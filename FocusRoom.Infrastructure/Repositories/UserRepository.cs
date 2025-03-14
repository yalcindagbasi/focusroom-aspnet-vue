﻿using FocusRoom.Application.Interfaces;
using FocusRoom.Domain.Entities;
using FocusRoom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusRoom.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FocusRoomDbContext _context;
        
        public UserRepository(FocusRoomDbContext context)
        {
            _context = context;
        }
        
        public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.FindAsync(id);
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
