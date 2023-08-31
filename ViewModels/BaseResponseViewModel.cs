namespace SimpleBank.ViewModels
{
    public class BaseResponseViewModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public BaseResponseViewModel(int status,string message)
        {
            Status = status;
            Message = message;
        }
    }
}