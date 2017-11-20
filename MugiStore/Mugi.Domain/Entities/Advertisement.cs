using System;

namespace Mugi.Domain.Entities
{
    public class Advertisement : BaseEntity
    {
        public virtual Staff Staff { get; set; }

        public int StaffId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}