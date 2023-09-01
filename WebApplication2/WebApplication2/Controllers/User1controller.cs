using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Helpers;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1controller : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly IConfiguration _configure;
        private readonly Iservice _service;
        private readonly Iuser _user;

        //private readonly Configuration _configure;

        public User1controller(MiniprojectContext context, IConfiguration configuration,Iservice iservice, Iuser iuser)
        {
            _context = context;
            _configure = configuration;
            _service = iservice;
            _user = iuser;
        }


        [HttpPost("Otp")]
        public IActionResult generateotp([FromBody] usersignupmodel user)
        {
            try
            {


            Random random = new Random();
            int x = random.Next(1000, 9000);
            DateTime dateTime = DateTime.Now;
            int otpexptime = 2;
            User user1 = new User();
            user1.Otp = x;
            user1.Useremail = user.Useremail;

                user1.OtpExpDate = dateTime.AddMinutes(otpexptime);
            _context.Users.Add(user1);
            _context.SaveChanges();
            var resp = new
            {
                id = user1.Userid
            };
                var fs = new FileStream("./Templat/WelcomeTemp.html",FileMode.Open,FileAccess.Read);
                var sr = new StreamReader(fs);
                var html = sr.ReadToEnd().Replace("##otp##",x.ToString());
                fs.Close();
                
                _service.sendmail(user.Useremail, "OTP Verification", html);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        //private const string SmtpHost = "mail.mailtest.radixweb.net"; // e.g., smtp.gmail.com

        //private const int SmtpPort = 465; // e.g., 587 for Gmail

        //private const string SmtpUsername = "testphp@mailtest.radixweb.net";

        //private const string SmtpPassword = "Radix@web#8";
        //[HttpPost("mail")]
        //public IActionResult sendmail(string recipient, string subject, string body)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("", SmtpUsername));
        //    message.To.Add(new MailboxAddress("", recipient));
        //    message.Subject = subject;


        //    var bodybuilder = new BodyBuilder();
        //    bodybuilder.TextBody = body;
        //    message.Body = bodybuilder.ToMessageBody();


        //    using (var client = new MailKit.Net.Smtp.SmtpClient())

        //    {

        //        client.Connect(SmtpHost, SmtpPort);

        //        client.Authenticate(SmtpUsername, SmtpPassword);

        //        client.Send(message);

        //        client.Disconnect(true);

        //    }
        //    return NoContent();

        //}


        [HttpPut("register/{id}")]
        public async Task<IActionResult> register([FromBody] registerdto val, int id)
        {
            try
            {

            string salt = Crypto.GenerateSalt();
            string password = val.Password + salt;
            string hashpassword = Crypto.HashPassword(password);
            //User user = new User();
            var user = _context.Users.FirstOrDefault(x => x.Userid == id);
            //user.Useremail = val.Useremail;
            user.Username = val.Username;
            var username = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (username == null)
            {
                user.UserpassHashed = hashpassword;
                user.UserpassSalt = salt;
                
                if (user.Otp.ToString() == val.otp.ToString())
                {
                    user.Otp = null;
                    user.Roleid = 2;
                    await _context.SaveChangesAsync();
                }
                else if(user.Otp.ToString()!=val.otp.ToString()) 
                {
                        _context.Users.Remove(user);
                        await _context.SaveChangesAsync();
                        return BadRequest("Invalid OTP");
                }
                else if (user.OtpExpDate < DateTime.Now)
                    {
                        _context.Users.Remove(user);
                        await _context.SaveChangesAsync();
                        return BadRequest("OTP Expired");

                    }

                    //await _context.Users.AddAsync(user);
                else
                {

                    var resp = new
                    {
                    user.Username,
                    user.Useremail
                    };
                    return Ok(resp);
                }
            }
      
            return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> authenticate([FromBody] logindto val)
        {
            try
            {

            if (val == null)
            {
                return BadRequest("error user not found");
            }
            var user = _context.Users.FirstOrDefault(x => x.Username == val.Username);
            if (user == null)
            {
                return NotFound();
            }
            if (verify(val, user.UserpassHashed, user.UserpassSalt))
            {
                //return Ok("hello");
                var token = createToken(user);
                var resp = new
                {
                    token,
                   
                };
                return Ok(resp);
            }
            else
            {
                return BadRequest("errors");
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getuserdata/{id}")]

        public async Task<IActionResult> getuserdata(int id)
        {
            try
            {

            var user =await _user.GetById(id);
            var res = new
            {
                user.Username,
                user.Useremail,
                user.Userid
            };
            return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editprofile/{id}")]

        public IActionResult edit([FromBody] usereditmodel val,int id)
        {
            try
            {

            var user = _context.Users.FirstOrDefault(x=>x.Userid == id);
                var username = _context.Users.FirstOrDefault(x => x.Username == val.Username);
                if(username == null)
                {

                if (user == null)
                {
                    return BadRequest("user not found");
                }
                user.Username = val.Username;
                
                _context.SaveChanges();
                    return Ok();

                }
               
                else {
                    return BadRequest("error in editing");
                    }
            }
            catch (Exception ex)
            {
                return BadRequest("error");
            }


        }

        [HttpPut("ForgotPassword")]
        public IActionResult forgototp([FromBody] ForgotPassEmail Email)
        {
            var u = _user.GetAll();
            var user = u.FirstOrDefault(x=>x.Useremail== Email.email);
            if(user == null)
            {
                return BadRequest("user not Found");
            }
            Random random = new Random();
            int x = random.Next(1000, 9000);
            user.Otp = x;
            var fs = new FileStream("./Templat/ForgotOTP.html", FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs);
            var html = sr.ReadToEnd().Replace("##otp##", x.ToString());
            fs.Close();
            _service.sendmail(user.Useremail, "One Time Password", html);
            _context.SaveChanges();
            return Ok(user.Userid);
        }

        [HttpPost("forgotpassotpverification/{id}")]

        public IActionResult otpVeriyfy(int id, [FromBody] forgotOtpDto forgotOtp)
        {
            var u = _user.GetAll();
            var user = u.FirstOrDefault(x=>x.Userid==id);
          
            if(user.Otp==forgotOtp.otp)
            {
                return Ok(user.Userid);
            }
            else
            {
                return NotFound("user not found");
            }

        }

        [HttpPut("changedpassword/{id}")]
        public async Task<IActionResult> changepassword([FromBody] ChangePass val, int id)
        {
            var u = _user.GetAll();
            var user = u.FirstOrDefault(x => x.Userid == id);
            string salt = Crypto.GenerateSalt();
            string password = val.Password + salt;
            string hashpassword = Crypto.HashPassword(password);
            if(user!= null)
            {
                user.UserpassHashed= hashpassword;
                user.UserpassSalt= salt;
                user.Otp = null;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Error while Changing Password");
            }

        }



        private static bool verify([FromBody] logindto val, string hash, string salt)
        {
            val.Password = val.Password + salt;
            bool isverified = Crypto.VerifyHashedPassword(hash, val.Password);
            if (!isverified)
            {
                return isverified;
            }
            return isverified;
        }

        private string createToken(User user)
        {
            var sec = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure.GetSection("Jwt:key").Value));
            var cre = new SigningCredentials(sec, SecurityAlgorithms.HmacSha256);
            var clames = new[] {

                  new Claim(ClaimTypes.Name, user.Username),
                  new Claim(ClaimTypes.PrimarySid,user.Userid.ToString()),
                  new Claim(ClaimTypes.Email,user.Useremail),
                new Claim(ClaimTypes.Role, user.Roleid.ToString())


            };
            var tok = new JwtSecurityToken(
                _configure.GetSection("Jwt:Issuer").Value,
                _configure.GetSection("Jwt:Audience").Value,
                clames,
                expires: DateTime.Now.AddMinutes(12),
                signingCredentials: cre
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tok);

            return token;
        }


    }
}
