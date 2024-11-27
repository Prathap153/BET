
namespace BET.Application.Validations
{
    public class BusinessUnitValidator : IBusinessUnitValidator
    {
        public void ValidateEntity(BusinessUnit businessUnit)
        {
            Guard.IsNotNullOrWhiteSpace(businessUnit.Name, nameof(businessUnit.Name));
        }
    }
}
