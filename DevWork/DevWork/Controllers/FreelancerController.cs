﻿using Contracts;
using Microsoft.AspNet.Identity;
using Models.Freelancer;
using Services;
using System;
using System.Web.Http;

namespace DevWork.Controllers
{
    [Authorize]
    [RoutePrefix("api/Freelancers")]
    public class FreelancerController : ApiController
    {
        private FreelancerService CreateFreelancerService()
        {
            var userId = User.Identity.GetUserId();
            var freelancerService = new FreelancerService(userId);
            return freelancerService;
        }

        // api/Freelancer/GetFreelancerList
        public IHttpActionResult Get()
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancers = freelancerService.GetFreelancers();
            return Ok(freelancers);
        }

        // api/Freelancer/GetFreelancerById
        public IHttpActionResult Get(string id)
        {
            FreelancerService freelancerService = CreateFreelancerService();
            var freelancer = freelancerService.GetFreelancerById(id);

            if (freelancer == null)
                return NotFound();

            return Ok(freelancer);
        }

        // api/Freelancer/Create
        public IHttpActionResult Post(FreelancerCreate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.CreateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Update
        [Authorize(Roles = "freelancer")]
        public IHttpActionResult Put(FreelancerUpdate freelancer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFreelancerService();

            if (!service.UpdateFreelancer(freelancer))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/Delete
        public IHttpActionResult Delete(string id)
        {
            var service = CreateFreelancerService();

            if (!service.DeleteFreelancer(id))
                return InternalServerError();

            return Ok();
        }
    }
}