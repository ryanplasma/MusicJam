using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MusicJam.Core.Domain.Model;
using MusicJam.Core.Domain.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Configuration = NHibernate.Cfg.Configuration;
using NHibBandRepository = MusicJam.Infrastructure.Repositories.BandRepository;

namespace MusicJam.Infrastructure.IntegrationTests.Respositories
{
    [TestFixture]
    public class BandRepository
    {
        private ISession _session;
        private ITransaction _transaction;
        private IBandRepository _repo;

        [SetUp]
        public void SetUp()
        {
            var connectionString = Properties.Settings.Default.TestConnection;
            var factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                    .Mappings(cfg => cfg.FluentMappings.AddFromAssemblyOf<NHibBandRepository>())
                    .ExposeConfiguration(CreateAndDropSchema)
                    .BuildConfiguration()
                    .CurrentSessionContext<ThreadStaticSessionContext>().BuildSessionFactory();
            _session = factory.OpenSession();
            _session.FlushMode = FlushMode.Commit;
            _transaction = _session.BeginTransaction();
            _repo = new NHibBandRepository(_session);
        }

        [TearDown]
        public void TearDown()
        {               
            _transaction.Dispose();
            _session.Dispose();
        }

        [Test]
        public void Add_saves_to_database_and_sets_the_Id()
        {
            //arrange
            var band = new Band()
            {
                Name = "Love Cloaks",
                Photo = "/path/to/things.png",
                Bio = "This is the love cloaks band"
            };

            //act
            _repo.Add(band);
            _transaction.Commit();

            //assert
            Assert.NotNull(band.Id);
        }

        public static void CreateAndDropSchema(Configuration config)
        {
            var export = new SchemaExport(config);
            export.Drop(false, true);
            export.Create(false, true);
        }
    }
}
