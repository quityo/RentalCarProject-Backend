using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
     public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int? CardId { get; set; }
        public string CardNumber { get; set; }
        public int DailyPrice { get; set; }
        public string ExpirationDate { get; set; }
        public string CardCvv { get; set; }

    }
}
