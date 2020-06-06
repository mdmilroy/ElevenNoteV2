using Data;
using Models.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Services
{
    public class FreelancerService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly string _userId;
        public FreelancerService(string userId)
        {
            _userId = userId;
        }

        public bool CreateFreelancer(FreelancerCreate model)
        {
            var entity = new Freelancer()
            {
                Id = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = $"{model.FirstName} {model.LastName}",
                CodingLanguage = model.CodingLanguage
            };

            db.Freelancers.Add(entity);
            return db.SaveChanges() == 1;
        }
        public ICollection<FreelancerListItem> GetFreelancers()
        {
            var query = db.Freelancers.Select(f => new FreelancerListItem
            {
                FullName = f.FullName,
                CodingLanguage = f.CodingLanguage,
                Rating = f.Rating
            });
            return query.ToList();
        }
        public FreelancerDetail GetFreelancerById(string id)
        {
            var entity = db.Freelancers.Single(f => f.Id == id);
            return new FreelancerDetail
            {
                FullName = entity.FullName,
                CodingLanguage = entity.CodingLanguage,
                ProjectsCompleted = entity.ProjectsCompleted,
                Rating = entity.Rating,
                AccountActive = entity.AccountActive
            };
        }
        public bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate)
        {
            var entity = db.Freelancers.Single(f => f.Id == _userId);
            entity.FirstName = freelancerToUpdate.FirstName;
            entity.LastName = freelancerToUpdate.LastName;
            entity.CodingLanguage = freelancerToUpdate.CodingLanguage;
            entity.ProjectsCompleted = freelancerToUpdate.ProjectsCompleted;
            entity.Rating = freelancerToUpdate.Rating;
            entity.AccountActive = freelancerToUpdate.AccountActive;
            return db.SaveChanges() == 1;
        }
        public bool DeleteFreelancer(string id)
        {
            var entity = db.Freelancers.Single(f => f.Id == _userId);
            entity.AccountActive = false;
            return db.SaveChanges() == 1;
        }
    }
}
