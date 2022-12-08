using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entites.Entitiy
{
    public class User:IdentityUser
    {
        public User()
        {
            Flats = new HashSet<Flat>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string CarNo { get; set; }

        public ICollection<Flat> Flats { get; set; }
    }
}
