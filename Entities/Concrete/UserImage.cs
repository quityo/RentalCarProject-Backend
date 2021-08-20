using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class UserImage : IEntity
    {
        [Key]
        public int ImageId { get; set; }


        public int UserId { get; set; }

        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}