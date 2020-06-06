using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Employer;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreelancerAPI.Controllers
{
    [Authorize]
    public class EmployerController : ApiController
    {
        private EmployerService CreateEmployerService()
        {
            //UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employerService = new EmployerService(userId);
            return employerService;
        }

        // api/Employer/Create
        public IHttpActionResult CreateEmployer(EmployerCreate employer)
        {
            //Employer currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            //employer.FirstName = currentUser.FirstName;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployerService();

            if (!service.CreateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/GetEmployersList
        public IHttpActionResult Get()
        {
            EmployerService employerService = CreateEmployerService();
            var employers = employerService.GetEmployers();
            return Ok(employers);
        }

        // api/Employer/GetEmployerById
        public IHttpActionResult Get(int id)
        {
            EmployerService employerService = CreateEmployerService();
            var employer = employerService.GetEmployerById(id);
            return Ok(employer);
        }

        // api/Employer/Update
        public IHttpActionResult Put(EmployerUpdate employer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployerService();

            if (!service.UpdateEmployer(employer))
                return InternalServerError();

            return Ok();
        }

        // api/Employer/Delete
        public IHttpActionResult Post(int id)
        {
            var service = CreateEmployerService();

            if (!service.DeleteEmployer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
