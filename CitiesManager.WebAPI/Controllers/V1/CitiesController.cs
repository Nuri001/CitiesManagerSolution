using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.Infrastructure.DatabaseContext;
using CitiesManager.Core.Entities;
using Microsoft.AspNetCore.Cors;

namespace CitiesManager.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    //[EnableCors("4100Client")]
    public class CitiesController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {

            return await _context.Cities.OrderBy(temp => temp.CityName).ToListAsync();
        }

        // GET: api/Cities/5
        /// <summary>
        /// To get list of cities (including city ID and city name) cron 'cities' table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Produces("application/xml")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {

            var city = await _context.Cities.FirstOrDefaultAsync(temp => temp.CityID == id);

            if (city == null)
            {
                return Problem(detail: "Invalid City Id", statusCode: 400, title: "City Search");
                // return BadRequest();
            }

            return city;
        }

        // PUT: api/Cities/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, [Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            if (id != city.CityID)
            {
                return BadRequest();
            }
            var existingcity = await _context.Cities.FindAsync(id);
            if (existingcity == null)
            {
                return NotFound();
            }
            existingcity.CityName = city.CityName;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cities

        [HttpPost]
        public async Task<ActionResult<City>> PostCity([Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            if (_context.Cities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cities'  is null.");
            }
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.CityID }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (_context.Cities == null)
            {
                return NotFound(); //HTTP 404
            }
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(Guid id)
        {
            return (_context.Cities?.Any(e => e.CityID == id)).GetValueOrDefault();
        }
    }
}
