using GalacticaCIC.Domain.Character;
using Microsoft.EntityFrameworkCore;

namespace GalacticaCIC.Common
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<CharacterEntity> Characters { get; set; } = null!;

    }
}