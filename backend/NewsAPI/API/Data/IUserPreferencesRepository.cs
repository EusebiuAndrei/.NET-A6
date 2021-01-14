using API.Entities;
using System.Collections.Generic;

namespace API.Data
{
    public interface IUserPreferencesRepository
    {
        IEnumerable<UserPreferences> GetAll();
        IEnumerable<UserPreferences> GetUserPreferences(string id);
        UserPreferences GetUserPreferenceById(int id);
        void Create(UserPreferences userPreferences);
        void Remove(int id);
    }
}