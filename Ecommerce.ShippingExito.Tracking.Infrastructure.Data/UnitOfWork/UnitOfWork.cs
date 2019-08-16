using Ecommerce.ShippingExito.Tracking.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : Disposable, IUnitOfWork where TContext : DbContext, new()
    {
        private DbContext DataContext;

        public virtual int Commit()
        {
            return DataContext.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return DataContext.SaveChangesAsync();
        }

        public DbContext GetDatabase()
        {
            return DataContext ?? (DataContext = new TContext());
        }

        public UnitOfWork(DbContext dbContext)
        {
            DataContext = dbContext;
        }

        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }

        public void Rollback()
        {
            DataContext
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }

    }
}
