using Microsoft.AspNetCore.Mvc;
using SimpleBank.Constants;
using SimpleBank.Usercases.CreateCreditTransaction;
using SimpleBank.Usercases.CreateDebitTransaction;
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
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> TransactionsByUser(int accountId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("Credit")]
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Credit(TransactionViewModel transaction)
    {
        var response = await _createCreditTransaction.Create(transaction);
        if (response.Item1)
            return Ok(new BaseResponseViewModel(200, response.Item2));

        return BadRequest(new BaseResponseViewModel(400, response.Item2));
    }

    [HttpPost("Debit")]
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Debit(TransactionViewModel transaction)
    {
        var response = await _createDebitTransaction.Create(transaction);
        if (response.Item1)
            return Ok(new BaseResponseViewModel(200, response.Item2));

        return BadRequest(new BaseResponseViewModel(400, response.Item2));
    }

    [HttpGet("balance/{accountId}")]
    [ProducesResponseType(typeof(BalanceViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Balance(int accountId)
    {
        var balance = await _getBalanceFromAccountId.GetBalance(accountId);
        return Ok(new BalanceViewModel(200,Messages.REQUEST_OK,balance));
    }
}
