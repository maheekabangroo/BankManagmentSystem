using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
//https status code

public class UsersController : Controller
{
    private readonly MyContext _context;

    public UsersController(MyContext context)
    {
        _context = context;
    }

    // Login endpoint
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            
            return BadRequest("Invalid username or password");
        }

        
        return Ok("Login successful");
    }

    // Update endpoint
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
    {
        if (id != updatedUser.Id)
        {
            return BadRequest("Invalid user ID");
        }

        _context.Entry(updatedUser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(u => u.Id == id))
            {
                return NotFound("User not found");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
}
