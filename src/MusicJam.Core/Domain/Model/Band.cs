using System.Collections;
using System.Collections.Generic;

namespace MusicJam.Core.Domain.Model
{
    public class Band
    {
        public virtual long Id { get; protected internal set; }
        public virtual string Name { get; set; }
        public virtual string Photo { get; set; }
        public virtual string Bio { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Band()
        {
            Members = new HashSet<Member>();
            Albums = new HashSet<Album>();
        }

        public virtual Band AddMember(Member member)
        {
            member.Band = this;
            Members.Add(member);
            return this;
        }

        public virtual Band AddAlbum(Album album)
        {
            album.Band = this;
            Albums.Add(album);
            return this;
        }

    }
}
