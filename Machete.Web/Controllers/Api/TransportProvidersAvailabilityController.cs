﻿using System;
using System.Linq;
using AutoMapper;
using Machete.Domain;
using Machete.Service;
using Machete.Web.Helpers.Api;
using Microsoft.AspNetCore.Mvc;

namespace Machete.Web.Controllers.Api
{
    [Route("api/transportprovidersavailability")]
    [ApiController]
    public class TransportProvidersAvailabilityController : MacheteApiController
    {
        private readonly ITransportProvidersAvailabilityService serv;
        private readonly IMapper map;

        public TransportProvidersAvailabilityController(ITransportProvidersAvailabilityService serv, IMapper map)
        {
            this.serv = serv;
            this.map = map;
        }

        // GET: api/TransportRule
        [ClaimsAuthorization(claimType: CAType.Role, claimValues: new[] { CV.Admin, CV.Employer })]
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            try
            {
                var result = serv.GetAll()
                    .Select(e => map.Map<Domain.TransportProviderAvailability, TransportProviderAvailability>(e))
                    .AsEnumerable();
                return new JsonResult(new { data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        // GET: api/TransportRule/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransportRule
        [HttpPost("")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TransportRule/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TransportRule/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
