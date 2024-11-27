

namespace BET.Application.Validations
{
    public class PaymentsValidator : IPaymentsValidator
    {
        public void ValidateEntity(Payments payments)
        {
            Guard.IsNotNull(payments.Bill_Id, nameof(payments.Bill_Id));
            Guard.IsNotNull(payments.Payment_Date, nameof(payments.Payment_Date));
            Guard.IsNotNull(payments.Status, nameof(payments.Status));
        }
    }
}
