using System;
namespace NetCoreApi.Models.Domain
{
    public abstract class ETrace
    {
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Active { get; set; }
    }
}
