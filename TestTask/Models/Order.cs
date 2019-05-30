using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    [Table("[Order]")]
    public class Order: IEntity
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public decimal Amount { get; set; }
    } 
}