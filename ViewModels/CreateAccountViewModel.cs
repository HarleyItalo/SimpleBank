namespace SimpleBank.ViewModels
{
    public class CreateAccountViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double InitialBalance { get; set; }

        public CreateAccountViewModel(string name,string lastName,double initialBalance)
        {
            Name = name;
            LastName = lastName;
            InitialBalance = initialBalance;
        }
    }
}