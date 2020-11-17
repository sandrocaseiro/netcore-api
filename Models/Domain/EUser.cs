using System.Collections.Generic;
using System.Linq;

namespace NetCoreApi.Models.Domain
{
	public class EUser : ETrace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Balance { get; set; }
        public int GroupId { get; set; }

        public EGroup Group { get; set; }
        public ICollection<EUserRole> UserRoles { get; set; } = Enumerable.Empty<EUserRole>().ToList();
    }
}
