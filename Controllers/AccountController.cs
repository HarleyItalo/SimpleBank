using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.Constants;
using SimpleBank.Usercases.CreateAccount;
using SimpleBank.Usercases.GetAccountById;
using SimpleBank.ViewModels;

namespace SimpleBank.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IGetAccountById _getAccountById;
    private readonly ICreateAccount _createAccount;
    public AccountController(IGetAccountById accountById, ICreateAccount createAccount)
    {
        _getAccountById = accountById;
        _createAccount = createAccount;
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(BaseResponseViewModel),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(AccountViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccountByID(int id)
    {
        var account = await _getAccountById.GetAccount(id);
        if (account.Item1)
            return Ok(account.Item2);

        return NotFound(new BaseResponseViewModel(404, Messages.NOT_FOUND));
    }

    [HttpPost("Create")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(BaseResponseViewModel),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(AccountViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAccount(CreateAccountViewModel createAccount)
    {
        var account = await _createAccount.Create(createAccount);
        if (account != null)
        {
            return Ok(account);
        }
        return BadRequest(new BaseResponseViewModel(400, Messages.INVALID_REQUEST));
    }
}
