using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    [Table("OrderProduct")]
    public class OrderProduct: IEntity
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

    }
}