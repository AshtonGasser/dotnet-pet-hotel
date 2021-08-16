using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetAllPetOwners() {
           return _context.PetsOwners.ToList();

    }

        [HttpPost]

        public IActionResult Post([FromBody] PetOwner owner) {
            _context.Add(owner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllPetOwners), owner);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id){
            PetOwner owner = _context.PetsOwners.Find(id);

            if (owner == null) return NotFound();
            _context.PetsOwners.Remove(owner);
            _context.Remove(owner);
            _context.SaveChanges();

            return NoContent();
        }
}   
}
