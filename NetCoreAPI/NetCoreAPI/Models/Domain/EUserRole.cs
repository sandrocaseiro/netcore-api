namespace NetCoreAPI.Models.Domain
{
    public class EUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public EUser User { get; set; }
        public ERole Role { get; set; }
    }
}
