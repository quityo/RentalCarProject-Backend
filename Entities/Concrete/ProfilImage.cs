using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class ProfilImage : IEntity
    {
        [Key]
        public int ProfilImageId { get; set; }


        public int UserId { get; set; }

        public string ProfilImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
