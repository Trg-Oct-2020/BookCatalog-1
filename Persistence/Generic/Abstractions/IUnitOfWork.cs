﻿using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalog.Persistence.Generic.Abstractions
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IDisposable BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

        void CommitTransaction();

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    }
}
