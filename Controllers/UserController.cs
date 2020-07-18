using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using collabnetwork_.net_c_.Models;
using collabnetwork_.net_c_.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
//using System.IdentityModel.Tokens.Jwt;

namespace collaby_backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;
        //private ApplicationUserDb _appUserContext;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*private long GetUserId(){

            string token = Request.Headers["Authorization"];
            int userId = Int16.Parse(Jwt.decryptJSONWebToken(token)["Id"].ToString());

            return userId;
        }
        private bool isAdmin(){

            string token = Request.Headers["Authorization"];
            string adminId = Jwt.decryptJSONWebToken(token)["IsAdmin"].ToString();
            if(adminId == "1"){
                return true;
            }
            return false;
        }*/

        [HttpGet("usernameSearch/{username}")]
        public ActionResult<User> UserNameSearch(String username)
        {
            User user = _context.User.First(obj=>obj.UserName == username);
            return user;
        }

        [HttpGet("test")]
        public ActionResult<String> Test()
        {
            return "testString";
        }

        [HttpGet("nameSearch/{name}")]
        public ActionResult<IEnumerable<User>> NameSearch(String name)
        {
            List<User> UserList;
            String[] fullName;

            if(name.Contains('_')){
                //search by last name if first character is a space
                if(name[0] == '_'){
                    UserList = _context.User.Where(b => b.LastName == name.Replace("_","")).ToList();
                //otherwise find any matching first and last names
                }else{
                    fullName = name.Split("_");
                    UserList = _context.User.Where(b => (b.FirstName == fullName[0]) && (b.LastName == fullName[1])).ToList();
                }
            //search by first
            }else{
                UserList = _context.User.Where(b => b.FirstName == name).ToList();
            }
            if(UserList == null){
                return NotFound();
            }
            return UserList;
        }

        [HttpPost]
        public async Task<Object> Create([FromBody]User user)
        {
            string[] resultArr = new string[4];

            resultArr[0]=Verify.ValidateEmail(user.Email);
            resultArr[1]=Verify.ValidateName(new string[]{user.FirstName, user.LastName});
            resultArr[2]=Verify.ValidateUserName(user.UserName);
            resultArr[3]=Verify.ValidatePassword(user.Password);
            
            foreach(string result in resultArr){
                if(result != null){ return Ok(new { response = result}); }
            }

            DateTime currentTime = DateTime.UtcNow;
            string timeString = (currentTime.Ticks/10000).ToString(); //salt string for hashing
            user.Password = Hashing.GenerateSHA256String(user.Password,timeString);

            try{
                //Users privateInfo = new Users{ UserName = user.UserName, Password = user.Password, Email = user.Email, DateCreated = currentTime };
                _context.Add(user);
                await _context.SaveChangesAsync(); //first confirm if email and username are unquie (should be auto handled by database)
            }catch{
                return Ok(new { response = "Username or Email has already been used"});
            }

            return Ok(new { response = "new user created"});
        }

        [HttpPut]
        public async Task<Object> Edit(User user){

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { response = "User has been successfully updated"});
        }

        [HttpDelete("{id}")]
        public async Task<Object> Delete(long id){

            /*if(!isAdmin()){
                return StatusCode(401);
            }*/

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { response = "User with the username of "+user.UserName+" and Id of "+user.Id.ToString()+" has been deleted"});
        }
    }
}