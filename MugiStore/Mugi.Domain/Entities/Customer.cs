namespace Mugi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public enum GenderType
        {
            Nam,
            Nữ,
            Khác
        }

        public virtual Account Account { get; set; }

        public int AccountId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public GenderType Gender { get; set; }
    }
}