﻿using Microsoft.AspNet.Identity;
using Models.JobPost;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreelancerAPI.Controllers
{
    [Authorize]
    public class JobPostController : ApiController
    {
        private JobPostService CreateJobPostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var jobPostService = new JobPostService(userId);
            return jobPostService;
        }

        // api/JobPost/Create
        public IHttpActionResult Post(JobPostCreate jobPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.CreateJobPost(jobPost))
                return InternalServerError();

            return Ok();
        }

        // api/Freelancer/GetJobPostList
        public IHttpActionResult Get()
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPosts = jobPostService.GetJobPosts();
            return Ok(jobPosts);
        }

        // api/Freelancer/GetJobPostById
        public IHttpActionResult Get(int id)
        {
            JobPostService jobPostService = CreateJobPostService();
            var jobPost = jobPostService.GetJobPostById(id);
            return Ok(jobPost);
        }

        // api/JobPost/Update
        public IHttpActionResult Put(JobPostUpdate jobPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateJobPostService();

            if (!service.UpdateJobPost(jobPost))
                return InternalServerError();

            return Ok();
        }

        // api/JobPost/Delete
        public IHttpActionResult Post(int id)
        {
            var service = CreateJobPostService();

            if (!service.DeleteJobPost(id))
                return InternalServerError();

            return Ok();
        }
    }
}

