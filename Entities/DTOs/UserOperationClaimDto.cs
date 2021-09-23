using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOperationClaimDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }
}
