using System.Data;
using System.Net.Http.Headers;
using System;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserPreferencesRepository : IUserPreferencesRepository
    {
        private readonly DataContext _context;

        public UserPreferencesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserPreferences> GetAll()
        {
            return _context.UserPreferences.ToList();
        }

        public IEnumerable<UserPreferences> GetUserPreferences(string id)
        {
            return _context.UserPreferences.Where(u => string.Equals(u.UserId, id)).Include(u => u.Topic).AsNoTracking().ToList();
        }

        public UserPreferences GetUserPreferenceById(int id)
        {
            return _context.UserPreferences.Find(id);
        }

        public void Create(UserPreferences userPreferences)
        {
            _context.Add(userPreferences);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.UserPreferences.Remove(_context.UserPreferences.FirstOrDefault(n => n.Id == id));
            _context.SaveChanges();
        }
    }
}