using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        
        public string CompanyName { get; set; }
        public int? CustomerFindex { get; set; }
    }
}
