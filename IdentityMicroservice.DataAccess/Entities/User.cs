using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityMicroservice.DataAccess.Entities
{
    public class User :IdentityUser
    {
        public DateTime CreatedAtTimeUtc { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
