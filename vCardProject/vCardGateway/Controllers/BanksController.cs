using System;
using System.Collections.Generic;
using System.Web.Http;
using vCardGateway.Models;
using vCardGateway.Logic;
namespace vCardGateway.Controllers
{
    public class BanksController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/banks")]
        [UserAuthentication]
        public IEnumerable<BankEntity> Get()
        {
            SQLBankHandler handler = null;

            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLBankHandler();
                if (type != "Admin")
                {
                    return new List<BankEntity>();
                }


                return handler.getAllBanks();
            }
            catch (Exception e)
            {
                return new List<BankEntity>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/banks/{id}")]
        public IHttpActionResult GetBank(int id)
        {
            SQLBankHandler handler = null;

            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLBankHandler();

                if (type != "Admin")
                {
                    return Unauthorized();
                }

                BankEntity bank = handler.getBank(id);

                return Ok(bank);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        [HttpPost]
        [UserAuthentication]
        [Route("api/banks")]
        public IHttpActionResult Post([FromBody] BankEntity bank)
        {
            SQLBankHandler handler = null;

            if (bank == null)
            {
                return BadRequest();
            }

            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                if (type != "Admin")
                {
                    return Unauthorized();
                }

                handler = new SQLBankHandler();

                bool result = handler.createBank(bank);

                if (result)
                {
                    return Ok();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/banks/{id}")]
        public IHttpActionResult Put(int id, [FromBody] BankEntity bank)
        {
            SQLBankHandler handler = null;

            if (bank == null)
            {
                return BadRequest();
            }
            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLBankHandler();

                if (type != "Admin")
                {
                    return Unauthorized();
                }
                bank.id = id;
                handler.updateBank(bank);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /*[UserAuthentication]
        [Route("api/banks/{id}")]
        public IHttpActionResult Delete( int id)
        {

            SQLBankHandler handler = null;
            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                if (type != "Admin")
                {
                    return Unauthorized();
                }

                handler = new SQLBankHandler();

                bool result = handler.deleteBank(id);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }*/
    }
}
