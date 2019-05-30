using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    [Table("Product")]
    public class Product: IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}