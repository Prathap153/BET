

namespace BET.Application.Validations
{
    public class ExpensesValidator : IExpensesValidator
    {
        public void ValidateEntity(Expenses expenses)
        {
            Guard.IsNotNull(expenses.Category_Id, nameof(expenses.Category_Id));
            Guard.IsNotNull(expenses.Project_Id, nameof(expenses.Project_Id));
            Guard.IsNotNull(expenses.Amount, nameof(expenses.Amount));
            Guard.IsNotNull(expenses.Payment_Date, nameof(expenses.Payment_Date));
        }
    }
}
