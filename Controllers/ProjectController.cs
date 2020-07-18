using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using collabnetwork_.net_c_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
//using collabnetwork_.net_c_.Helper;

namespace collaby_backend.Controllers
{

    [Route("api/projects")]
    [ApiController]
    [AllowAnonymous]
    //[EnableCors("AllowOrigin")]
    //[Authorize]
    public class ProjectController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public ActionResult<String> Test()
        {
            return "testString";
        }

        [HttpGet] //get all projects
        public ActionResult<IEnumerable<Project>> project()
        {
            List<Project> projectList = new List<Project>();
            projectList = _context.Project.Where(o=>o.Status <= 1).ToList();
            return projectList;
        }

        [HttpGet("user/{username}")] //get projects from sepecific user
        public ActionResult<IEnumerable<Project>> GetUserprojects(string username)
        {
            List<Project> projectList = new List<Project>();

            long userId = _context.User.First(o => o.UserName == username).Id;
            projectList = _context.Project.Where(o => o.UserId == userId && o.Status <= 1).OrderByDescending(o => o.DateCreated).ToList();

            return projectList;
        }

        // GET api/projects/single/
        [HttpGet("project/{projectId}")] //get specific project
        public ActionResult<Project> Getproject(long projectId)
        {
            Project project = _context.Project.First(o => o.Id == projectId);
            return project;
        }

        [HttpGet("drafts")]
        public ActionResult<IEnumerable<Project>> GetDrafts(long projectId)
        {
            List<Project> projectList = new List<Project>();
            projectList = _context.Project.Where(o => o.Status == 0).OrderByDescending(o => o.Id).ToList();
            return projectList;
        }

        [HttpGet("draft/{draftId}")]
        public ActionResult<Project> GetDraft(long draftId)
        {
            Project project = _context.Project.First(o => o.Id == draftId);
            /*if (GetUserId() != project.UserId)
            {
                return StatusCode(401);
            }*/
            return project;
        }

        [HttpPost]
        public async Task<Object> project([FromBody]Project project)
        {

            if(project.Status == 0){
                project.DateCreated = null;
            }
            /*else
            {
                Users user = _context.Users.First(o => o.Id == userId);
                user.Totalprojects += 1;
                _context.Entry(user).State = EntityState.Modified;
            }
            project.UserId = userId;*/

            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return Ok(new { response = "Record has been successfully added" });
        }

        [HttpPut]
        public async Task<Object> Edit([FromBody]Project project)
        {

            Project currentproject = _context.Project.First(o => o.Id == project.Id);

            /*if (currentproject.UserId != GetUserId())
            {
                return StatusCode(401);
            }
            else
            {
                project.UserId = currentproject.UserId;
            }*/

            if (currentproject.Status <= 1)
            {
                project.DateCreated = DateTime.UtcNow;
            }
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { response = "Project has been successfully updated" });
        }

        [HttpDelete("{projectId}")]
        public async Task<Object> Delete([FromRoute]long projectId)
        {   
            Project project = _context.Project.First(o=>o.Id == projectId);

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return Ok(new { response = "Project has been successfully deleted" });
        }
    }
}