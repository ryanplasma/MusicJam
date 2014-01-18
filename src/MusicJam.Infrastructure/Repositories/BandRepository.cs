using MusicJam.Core.Domain.Model;
using MusicJam.Core.Domain.Repositories;
using NHibernate;

namespace MusicJam.Infrastructure.Repositories
{
    public class BandRepository : IBandRepository
    {
        private ISession _session;

        public BandRepository(ISession session)
        {
            _session = session;
        }

        public void Add(Band band)
        {
            _session.Save(band);
        }
    }
}
