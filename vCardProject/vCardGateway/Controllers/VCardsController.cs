using System;
using System.Collections.Generic;
using System.Web.Http;
using vCardGateway.Models;
using vCardGateway.Logic;


namespace vCardGateway.Controllers
{
    public class VCardsController : ApiController
    {

        [Route("api/vcards")]
        [UserAuthentication]
        public IEnumerable<VCard> Get()
        {
            SQLVCardsHandler handler = null;

            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLVCardsHandler();
                if (type != "Admin")
                {
                    return handler.getAllVCards(id);
                }

                
                return handler.getAllVCards();
            }
            catch (Exception e)
            {
                return new List<VCard>();
            }
        }
        
        [UserAuthentication]
        [Route("api/vcards/{number}")]
        public IHttpActionResult GetVCard(int number)
        {
            SQLVCardsHandler handler = null;

            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLVCardsHandler();

                VCard vCard = handler.getVCard(number);

                if (vCard == null)
                {
                    return NotFound();
                }
                if (type != "Admin" || id != vCard.ownerId)
                {
                    return Unauthorized();
                }          

                return Ok(vCard);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [UserAuthentication]
        [Route("api/vcards")]
        public IHttpActionResult Post([FromBody]VCard vCard)
        {
            SQLVCardsHandler handler = null;
            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLVCardsHandler();

                if (IsNumberValid(vCard.phoneNumber))
                {
                    return BadRequest("Number is Invalid!");
                }

                VCard result = handler.createVcard(vCard.phoneNumber, id);

                if (result != null)
                {
                    return Created("api/vcards/"+ vCard.phoneNumber, result);
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

        [UserAuthentication]
        [Route("api/vcards/{number}")]
        public IHttpActionResult Delete([FromBody] int confirmationCode, int number)
        {

            SQLVCardsHandler handler = null;
            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLVCardsHandler();

                if (IsNumberValid(number))
                {
                    return BadRequest("Number is Invalid!");
                }

                VCard vCard = handler.getVCard(number);

                if (vCard == null)
                {
                    return NotFound();
                }

                if (id == vCard.ownerId)
                {
                    return Unauthorized();
                }

                if (vCard.balance != 0)
                {
                    return Conflict();
                }

                bool result = handler.deleteVcard(number);

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

        private bool IsNumberValid(int number)
        {
            if (number.ToString().Length != 9)
            {
                return false;
            }
            if (number.ToString().StartsWith("9"))
            {
                return false;
            }
            return true;
        }
    }
}