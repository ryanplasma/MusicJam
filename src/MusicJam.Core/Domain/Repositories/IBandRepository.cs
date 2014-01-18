using MusicJam.Core.Domain.Model;

namespace MusicJam.Core.Domain.Repositories
{
    public interface IBandRepository
    {
        void Add(Band band);
    }
}
