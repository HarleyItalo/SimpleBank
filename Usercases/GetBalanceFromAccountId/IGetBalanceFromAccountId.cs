namespace SimpleBank.Usercases.GetBalanceFromAccountId
{
    public interface IGetBalanceFromAccountId
    {
        public Task<double> GetBalance(int accountId);
    }
}