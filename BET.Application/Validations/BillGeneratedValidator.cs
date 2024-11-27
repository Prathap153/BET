
namespace BET.Application.Validations
{
    public class BillGeneratedValidator : IBillGeneratedValidator
    {
        public void ValidateEntity(BillGenerated billGenerated)
        {
            Guard.IsNotNull(billGenerated.Category_Id, nameof(billGenerated.Category_Id));
            Guard.IsNotNull(billGenerated.Due_Date, nameof(billGenerated.Due_Date));
            Guard.IsNotNull(billGenerated.Amount_Generated, nameof(billGenerated.Amount_Generated));
        }
    }
}
