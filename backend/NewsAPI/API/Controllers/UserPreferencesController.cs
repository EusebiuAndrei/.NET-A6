using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/user-preferences")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IUserPreferencesRepository _repository;

        public UserPreferencesController(IUserPreferencesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // all preferences of all users
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserPreferences>> GetAll() => _repository.GetAll().ToList();

        [HttpGet("user/{userId}", Name = "GetUserPreferences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserPreferences>> GetUserPreferences(string id) => _repository.GetUserPreferences(id).ToList();

        [HttpGet("{preferenceId}", Name = "GetUserPreference")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserPreferences> GetById(int id)
        {
            var userPreferences = _repository.GetUserPreferenceById(id);
            
            if (userPreferences == null)
            {
                return NotFound();
            }

            return userPreferences;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] UserPreferences userPreferences)
        {
            _repository.Create(userPreferences);
            return CreatedAtAction(nameof(GetById), new { id = userPreferences.Id }, userPreferences);
        }

        [HttpDelete("{preferenceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Remove(int id)
        {
            _repository.Remove(id);
            return NoContent();
        }

    }

}