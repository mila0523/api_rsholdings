using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;
using api_rsholdings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;
using api_rsholdings.viewModels;

namespace api_rsholdings.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        public AppDbContext rsholdings_db = new AppDbContext();

        [HttpGet]
        [Route("GetClients")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var results = await rsholdings_db.Clients.ToArrayAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient( Client client)
        {
            var date = DateTime.Now;
            string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss.fffffff");

            var newClient = new Client
            {
                ClientId = client.ClientId,
                Name = client.Name,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                DateAdded = Convert.ToDateTime(formattedDateTime),
                RegistrationNum = client.RegistrationNum,
                VatNum = client.VatNum
            };
            try
            {
                rsholdings_db.Add(newClient);
                await rsholdings_db.SaveChangesAsync();
                return Ok(newClient);
            }
            catch (Exception)
            {
                return BadRequest("Invalid transaction");
            }       
        }

        [HttpPost]
        [Route("EditClient")]
        public async Task<IActionResult> EditClient(string clientId, string name, string phone, string email, string physicalAddress, string contactPerson, string registrationNum, string vatNum)
        {
            var clientToUpdate = rsholdings_db.Clients.Where(c => c.ClientId == clientId).FirstOrDefault();

            if(clientToUpdate != null)
            {
                clientToUpdate.Name = name;
                clientToUpdate.PhoneNumber = phone;
                clientToUpdate.Email = email;
                clientToUpdate.Address = physicalAddress;
                clientToUpdate.ContactPerson = contactPerson;
                clientToUpdate.RegistrationNum = registrationNum;
                clientToUpdate.VatNum = vatNum;

                try
                {
                    await rsholdings_db.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Invalid transaction");
                }
            }
            else
            {
                return StatusCode(404, "Error! Customer not found");
            }
        }

        [HttpPost]
        [Route("DeleteClient/{id}")]
        public async Task<IActionResult> Deletelient(string clientId)
        {
            var clientToDel = rsholdings_db.Clients.Where(c => c.ClientId == clientId).FirstOrDefault();

            if (clientToDel!= null)
            {
                rsholdings_db.Clients.Remove(clientToDel);
                try
                {
                    await rsholdings_db.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Invalid transaction");
                }
            }
            else
            {
                return StatusCode(404, "Error! Customer not found");
            }
        }
    }
}
