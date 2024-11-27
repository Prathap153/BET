
namespace BET.Application.Validations
{
    public class IncomeValidator : IIncomeValidator
    {
        public void ValidateEntity(Income income)
        {
            Guard.IsNotNull(income.Category_Id, nameof(income.Category_Id));
            Guard.IsNotNull(income.Amount, nameof(income.Amount));
            Guard.IsNotNull(income.Receive_Date, nameof(income.Receive_Date));  
        }
    }
}
