using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAPI.Models.Domain
{
    public class EUser : ETrace
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Cpf { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Decimal? Balance { get; set; }
        public int GroupId { get; set; }

        public EGroup Group { get; set; }
        public ICollection<EUserRole> UserRoles { get; set; } = Enumerable.Empty<EUserRole>().ToList();
    }
}
