using System;
using MusicJam.Core.Domain.Interfaces;
using NHibernate;

namespace MusicJam.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _transaction = _session.BeginTransaction();
        }

        /// <summary>
        /// Should probably check if transaction is active
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
            catch (Exception e)
            {
                Rollback();
                _transaction.Dispose();
            }
        }

        /// <summary>
        /// Should probably check if something can rollback
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
