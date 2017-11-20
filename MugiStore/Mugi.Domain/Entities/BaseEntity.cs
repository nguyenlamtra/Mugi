using System;

namespace Mugi.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}