using MusicJam.Core.Domain.Model;
using NUnit.Framework;
using BandModel = MusicJam.Core.Domain.Model.Band;

namespace MusicJam.Core.Tests.Domain.Model
{
    [TestFixture]
    public class Band
    {
        [Test]
        public void AddMember_increases_member_collection_by_one()
        {
            var band = new BandModel();
            band.AddMember(new Member());
            Assert.AreEqual(1, band.Members.Count);
        }

        [Test]
        public void AddMember_sets_band_property_on_member()
        {
            var band = new BandModel();
            var member = new Member();
            band.AddMember(member);
            Assert.AreSame(band, member.Band);
        }

        [Test]
        public void AddAlbum_increases_album_collection_by_one()
        {
            var band = new BandModel();
            band.AddAlbum(new Album());
            Assert.AreEqual(1, band.Albums.Count);
        }

        [Test]
        public void AddAlbum_sets_band_property_on_album()
        {
            var band = new BandModel();
            var album = new Album();
            band.AddAlbum(album);
            Assert.AreSame(band, album.Band);
        }
    }
}
