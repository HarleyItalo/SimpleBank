using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.Constants;
using SimpleBank.Models;
using SimpleBank.Usercases.CreateCreditTransaction;
using SimpleBank.Usercases.CreateDebitTransaction;
using SimpleBank.Usercases.GetAccountById;
using SimpleBank.Usercases.GetBalanceFromAccountId;
using SimpleBank.ViewModels;

namespace SimpleBank.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ICreateDebitTransaction _createDebitTransaction;
    private readonly ICreateCreditTransaction _createCreditTransaction;
    private readonly IGetBalanceFromAccountId _getBalanceFromAccountId;
    public TransactionsController(
        ICreateDebitTransaction createDebitTransaction,
        ICreateCreditTransaction createCreditTransaction,
        IGetBalanceFromAccountId getBalanceFromAccountId)
    {
        _createDebitTransaction = createDebitTransaction;
        _createCreditTransaction = createCreditTransaction;
        _getBalanceFromAccountId = getBalanceFromAccountId;
    }

    [HttpGet("ByUser/{accountId}")]
    public async Task<IActionResult> TransactionsByUser(int accountId)
    {
        throw new NotImplementedException();
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

    [HttpGet("balance/{accountId}")]
    [ProducesResponseType(typeof(BalanceViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Balance(int accountId)
    {
        var balance = await _getBalanceFromAccountId.GetBalance(accountId);
        
        return Ok(new BalanceViewModel(200,Messages.REQUEST_OK,balance));
    }
}
