using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.Models;
using SimpleBank.Usercases.GetAccountById;

namespace SimpleBank.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IGetAccountById getAccountById;
    public AccountController(IGetAccountById accountById)
    {
        getAccountById = accountById;
    }
    
    [HttpGet("Find/{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccountByID(int id){
        var account = await getAccountById.GetAccount(id);
        if(account != null)
           return Ok(account);
        
        return NotFound();
    }
}
