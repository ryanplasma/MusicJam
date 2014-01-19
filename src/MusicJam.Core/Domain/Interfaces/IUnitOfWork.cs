namespace MusicJam.Core.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Begin();

        void Commit();

        void Rollback();
    }
}
