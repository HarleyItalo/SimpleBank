using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.Models;
using SimpleBank.Usercases.CreateCreditTransaction;
using SimpleBank.Usercases.CreateDebitTransaction;
using SimpleBank.Usercases.GetAccountById;
using SimpleBank.ViewModels;

namespace SimpleBank.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IGetAccountById _getAccountById;
    private readonly ICreateDebitTransaction _createDebitTransaction;
    private readonly ICreateCreditTransaction _createCreditTransaction;
    public TransactionsController(
        IGetAccountById accountById,
        ICreateDebitTransaction createDebitTransaction,
        ICreateCreditTransaction createCreditTransaction)
    {
        _getAccountById = accountById;
        _createDebitTransaction = createDebitTransaction;
        _createCreditTransaction = createCreditTransaction;
    }

    [HttpGet("ByUser/{accountId}")]
    public async Task<IActionResult> TransactionsByUser(int accountId)
    {
        var account = await _getAccountById.GetAccount(accountId);
        if (account == null)
            return NotFound();

        return NotFound();
    }

    [HttpPost("Credit")]
    public async Task<IActionResult> Credit(TransactionViewModel transaction)
    {
        var response = await _createCreditTransaction.Create(transaction);
        if (response.Item1)
            return Ok(new BaseResponse(200, response.Item2));

        return BadRequest(new BaseResponse(400, response.Item2));
    }

    [HttpPost("Debit")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Debit(TransactionViewModel transaction)
    {
        var response = await _createDebitTransaction.Create(transaction);
        if (response.Item1)
            return Ok(new BaseResponse(200, response.Item2));

        return BadRequest(new BaseResponse(400, response.Item2));
    }

    [HttpGet("balance/{id}")]
    public async Task<IActionResult> Balance(int accountId)
    {
        var account = await _getAccountById.GetAccount(accountId);
        if (account == null)
            return NotFound();


        return BadRequest();
    }
}
