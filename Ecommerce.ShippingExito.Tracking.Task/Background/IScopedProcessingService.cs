using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Task.Background
{
    public interface IScopedProcessingService: IDisposable
    {
        void RunTask();
    }
}
