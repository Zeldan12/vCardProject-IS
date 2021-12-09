using System;
using System.Collections.Generic;
using System.Web.Http;
using vCardGateway.Models;
using vCardGateway.Logic;
using Newtonsoft.Json.Linq;

namespace vCardGateway.Controllers
{
    public class VCardsController : ApiController
    {
        public IEnumerable<VCard> Get(JObject data, int userId)
        {
            SQLVCardsHandler handler = null;
            List<VCard> lista = new List<VCard>();

            if (data == null || data["password"] == null || data["name"] == null)
            {
                return lista;
            }

            try
            {
                User user = handler.authenticate(data["name"].ToString(), data["password"].ToString());
                if (user == null || user.type != UserType.Administrator)
                {
                    return lista;
                }

                handler = new SQLVCardsHandler();
                return handler.getAllVCards();
            }
            catch (Exception e)
            {
                return lista;
            }
        }

        [Route("api/vcards/{number}")]
        public IHttpActionResult GetVCard(JObject data, int number)
        {
            SQLVCardsHandler handler = null;

            if (data == null || data["password"] == null || data["name"] == null)
            {
                return BadRequest();
            }

            try
            {
                handler = new SQLVCardsHandler();
                User user = handler.authenticate(data["name"].ToString(), data["password"].ToString());

                if (user == null)
                {
                    return BadRequest("Authentication incorrect");
                }

                VCard vCard = handler.getVCard(number);

                if (vCard == null || user.id == vCard.ownerId)
                {
                    return NotFound();
                }

                return Ok(vCard);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post(JObject data)
        {

            SQLVCardsHandler handler = null;
            if (data == null || data["password"] == null || data["phoneNumber"] == null || data["name"] == null)
            {
                return BadRequest();

            }
            try
            {
                handler = new SQLVCardsHandler();
                User user = handler.authenticate(data["name"].ToString(), data["password"].ToString());
                if ( user == null)
                {
                    return BadRequest("Authentication incorrect");
                }
                
                int phoneNumber = IsNumberValid(data["phoneNumber"].ToString());
                if (phoneNumber == -1)
                {
                    return BadRequest("Number is Invalid!");
                }
             
                VCard result = handler.createVcard(phoneNumber, user.id);

                if (result != null)
                {
                    return Created("api/users/6/vcards"+phoneNumber,result);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        public IHttpActionResult Put(JObject data)
        {

            SQLVCardsHandler handler = null;
            if (data == null || data["password"] == null || data["phoneNumber"] == null || data["name"] == null)
            {
                return BadRequest();
            }
            try
            {
                handler = new SQLVCardsHandler();
                User user = handler.authenticate(data["name"].ToString(), data["password"].ToString());
                if (user == null)
                {
                    return BadRequest("Authentication incorrect");
                }

                int phoneNumber = IsNumberValid(data["phoneNumber"].ToString());
                if (phoneNumber == -1)
                {
                    return BadRequest("Number is Invalid!");
                }

                VCard result = handler.createVcard(phoneNumber, user.id);

                if (result != null)
                {
                    return Created("api/users/6/vcards" + phoneNumber, result);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [Route("api/vcards/{number}")]
        public IHttpActionResult Delete(JObject data,int number)
        {

            SQLVCardsHandler handler = null;
            if (data == null || data["password"] == null || data["name"] == null || data["confirmationCode"] == null)
            {
                return BadRequest();

            }
            try
            {
                handler = new SQLVCardsHandler();
                User user = handler.authenticate(data["name"].ToString(), data["password"].ToString());

                if (user == null)
                {
                    return BadRequest("Authentication incorrect");
                }

                int phoneNumber = IsNumberValid(number.ToString());

                if (phoneNumber == -1)
                {
                    return BadRequest("Number is Invalid!");
                }

                VCard vCard = handler.getVCard(phoneNumber);

                if (vCard == null || user.id == vCard.ownerId)
                {
                    return NotFound();  
                }

                if (vCard.balance != 0)
                {
                    return Conflict();
                }

                bool result = handler.deleteVcard(phoneNumber);

                if (result)
                {
                    return Ok();
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        private int IsNumberValid(string number)
        {
            if (!Int32.TryParse(number, out int phoneNumber))
            {
                return -1;
            }
            if (number.Length != 9)
            {
                return -1;
            }
            if (!number.StartsWith("9"))
            {
                return -1;
            }
            return phoneNumber;
        }
    }
}