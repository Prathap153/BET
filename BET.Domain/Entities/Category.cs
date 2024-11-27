using BET.Domain.Common.Base;

namespace BET.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
