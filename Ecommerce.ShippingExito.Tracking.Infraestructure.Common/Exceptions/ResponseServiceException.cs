using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.Common.Exceptions
{
    public class ResponseServiceException : Exception
    {
        public ResponseServiceException()
        {
        }

        public ResponseServiceException(string message) : base(message)
        {
        }

        public ResponseServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ResponseServiceException(string extraData, string serviceName) : this(extraData)
        {
            ServiceName = serviceName;
        }

        protected ResponseServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Informacion personalizada del error.
        /// </summary>
        public string ExtraData { get; set; }
        public string ServiceName { get; set; }
    }
}
