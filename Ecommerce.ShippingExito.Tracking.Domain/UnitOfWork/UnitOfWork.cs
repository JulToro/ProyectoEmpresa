using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();

        void Rollback();
    }
}
