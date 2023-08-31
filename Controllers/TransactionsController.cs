using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.Models;
using SimpleBank.Usercases.GetAccountById;

namespace SimpleBank.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IGetAccountById getAccountById;
    public TransactionsController(IGetAccountById accountById)
    {
        getAccountById = accountById;
    }

    [HttpGet("ByUser/{accountId}")]
    public async Task<IActionResult> TransactionsByUser(int accountId)
    {
        var account = await getAccountById.GetAccount(accountId);
        if (account == null)
            return NotFound();

        return NotFound();
    }

    [HttpPost("Credit")]
    public async Task<IActionResult> Credit(Transaction transaction)
    {
        return BadRequest();
    }


    [HttpPost("Debit")]
    public async Task<IActionResult> Debit(Transaction transaction)
    {
        return BadRequest();
    }

    [HttpGet("balance/{id}")]
    public async Task<IActionResult> Balance(int accountId)
    {
        var account = await getAccountById.GetAccount(accountId);
        if (account == null)
            return NotFound();
        
        
        return BadRequest();
    }
}
