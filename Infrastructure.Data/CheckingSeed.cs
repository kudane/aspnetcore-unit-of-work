using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CheckingSeed
    {
        public int Id { get; set; }
        public bool HasSeeding { get; set; }
    }
}