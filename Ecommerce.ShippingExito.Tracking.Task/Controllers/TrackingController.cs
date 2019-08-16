using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ShippingExito.Tracking.Application.Services;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ShippingExito.Tracking.Task.Controllers
{
    [Route("api/tracking")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _iTrackingService;

        public TrackingController(ITrackingService iTrackingService)
        {
            _iTrackingService = iTrackingService;
        }

        //[HttpGet]
        //public IActionResult GetCarriers()
        //{
        //    //var carriers = _iTrackingService.GetCarriers();

        //    //if (carriers == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return Ok(carriers);
        //}


        //public bool TrackingProcess()
        //{

        //}

    }
}