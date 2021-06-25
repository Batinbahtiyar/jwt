using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KimlikController : ControllerBase
    {
        //api/Kimlik/Girisyap
        [HttpGet("[action]")]
        public IActionResult GirisYap()
        {
            return Created("",new TokenOlusturucu().TokenOlustur());
        }
        [HttpGet("[action]")]
        public IActionResult AdminGiris()
        {
            return Created("", new TokenOlusturucu().TokenAdminRoleOlustur());
        }
        [Authorize(Roles ="Admin,Member")]
        [HttpGet("[action]")]
        public IActionResult AdminSayfasi()
        {
            var sehir=User.Claims.Where(I => I.Type == "Sehir").FirstOrDefault();
            var UserName = User.Identity.Name;
            return Ok("token geçti");
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Erisim()
        {
            return Ok("token geçti");
        }
    }
}
