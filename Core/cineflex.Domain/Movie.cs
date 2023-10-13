
using cineflex.Domain.Common;

namespace cineflex.Domain
{
    public class Movie : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
