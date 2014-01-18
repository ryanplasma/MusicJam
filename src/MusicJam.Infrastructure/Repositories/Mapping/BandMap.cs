using FluentNHibernate.Mapping;
using MusicJam.Core.Domain.Model;

namespace MusicJam.Infrastructure.Repositories.Mapping
{
    public class BandMap : ClassMap<Band>
    {
        public BandMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Bio);
            Map(x => x.Photo);
        }
    }
}
