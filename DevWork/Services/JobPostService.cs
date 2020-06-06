﻿using Contracts;
using Data;
using Microsoft.AspNet.Identity;
using Models;
using Models.Employer;
using Models.JobPost;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class JobPostService : IJobPostService
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public JobPostService(string userId)
        {
            _userId = userId;
        }

        public bool CreateJobPost(JobPostCreate jobPostCreate)
        {
            var entity = new JobPost()
            {
                JobTitle = jobPostCreate.JobTitle,
                Content = jobPostCreate.Content,
                StateId = jobPostCreate.StateId,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow,
                EmployerId = _userId
            };

            _ctx.JobPosts.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<JobPostListItem> GetJobs()
        {
            var query = _ctx.JobPosts.Where(m => m.IsActive == true).Select(e => new JobPostListItem
            {
                JobPostId = e.JobPostId,
                JobTitle = e.JobTitle,
                State = e.State.StateName,
                CreatedDate = e.CreatedDate
            });

            return query.ToList();
        }

        public JobPostDetail GetJobPostById(int jobPostId)
        {
            var entity = _ctx.JobPosts.Single(j => j.JobPostId == jobPostId);
            return new JobPostDetail
            {
                JobTitle = entity.JobTitle,
                Content = entity.Content,
                State = entity.State.StateName,
                IsAwarded = entity.IsAwarded,
                CreatedDate = entity.CreatedDate,
                EmployerId = entity.EmployerId,
                FreelancerId = entity.FreelancerId,
                IsActive = entity.IsActive
            };
        }

        // TODO Get jobPosts by string EmployerId
        public List<JobPostListItem> GetJobsByEmployerId(string employerId)
        {
            var query = _ctx.JobPosts.Where(e => e.EmployerId == employerId).Select(e => new JobPostListItem
            {
                JobPostId = e.JobPostId,
                JobTitle = e.JobTitle,
                State = e.State.StateName,
                CreatedDate = e.CreatedDate,
                IsActive = e.IsActive
            });

            return query.ToList();
        }

        public bool JobPostUpdate(JobPostUpdate jobPostUpdate)
        {
            var entity = _ctx.JobPosts.Single(j => j.JobPostId == jobPostUpdate.JobPostId && j.EmployerId == _userId.ToString());
            entity.JobPostId = jobPostUpdate.JobPostId;
            entity.JobTitle = jobPostUpdate.JobTitle;
            entity.Content = jobPostUpdate.Content;
            entity.StateId = jobPostUpdate.State;
            entity.IsAwarded = jobPostUpdate.IsAwarded;
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            entity.FreelancerId = jobPostUpdate.FreelancerId;

            return _ctx.SaveChanges() == 1;
        }

        public bool JobPostDelete(int jobPostId)
        {
            var entity = _ctx.JobPosts.Single(j => j.JobPostId == jobPostId);
            entity.IsActive = false;
            return _ctx.SaveChanges() == 1;
        }
    }
}
