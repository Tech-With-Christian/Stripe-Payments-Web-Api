using System;
namespace stripe.domain.Models.Base
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
            UpdatedAt = DateTime.Now;
        }

        public BaseModel(Guid id, DateTime createdAt)
        {
            Id = id;
            UpdatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}

