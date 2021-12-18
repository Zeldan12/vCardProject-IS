using System;
using System.Collections.Generic;
using System.Web.Http;
using vCardGateway.Logic;
using vCardGateway.Models;

namespace vCardGateway.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        [UserAuthentication]
        public IEnumerable<User> Get()
        {
            SQLUsersHandler handler = null;

            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLUsersHandler();
                if (type != "Admin")
                {
                    return new List<User>();
                }


                return handler.getAllUsers();
            }
            catch (Exception e)
            {
                return new List<User>();
            }
        }

        // GET: api/Users/5
        [UserAuthentication]
        public IHttpActionResult Get(int id)
        {
            SQLUsersHandler handler = null;

            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLUsersHandler();

                User user = handler.getUser(id);

                if (user == null)
                {
                    return NotFound();
                }
                if (type != "Admin" && id != authId)
                {
                    return Unauthorized();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        [UserAuthentication]
        [Route("api/users/me")]
        public IHttpActionResult GetMe()
        {
            int authId = int.Parse(RequestContext.Principal.Identity.Name);
            return Get(authId);
        }

        // POST: api/Users

        public IHttpActionResult Post([FromBody] User user)
        {
            SQLUsersHandler handler = null;
            SQLBankHandler bankHandler = null;
            try
            {
                bankHandler = new SQLBankHandler();

                BankEntity bank = bankHandler.getBank(user.bankUrl);
                handler = new SQLUsersHandler();
                user.type = "User";
                user.bankId = bank.id;
                bool result = handler.createUser(user);

                if (result)
                {
                    return Created("api/users/me", user);
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
        [Route("api/users/me")]
        public IHttpActionResult PutMe([FromBody]User user)
        {
            int authId = int.Parse(RequestContext.Principal.Identity.Name);
            return Put(authId, user);
        }

        // PUT: api/Users/5
        [UserAuthentication]
        public IHttpActionResult Put(int id,[FromBody] User user)
        {
            SQLUsersHandler handler = null;

            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLUsersHandler();

                User oldUser = handler.getUser(id);

                if (oldUser == null)
                {
                    return NotFound();
                }
                if (type != "Admin")
                {
                    if (id != authId)
                    {
                        return Unauthorized();
                    }

                    user.type = "User";
                }
                else
                {
                    user.type = oldUser.type;
                    user.active = oldUser.active;
                }
                if(user.name == null) user.name = oldUser.name;
                if(user.email == null) user.email = oldUser.email;
                if(user.photoURL == null) user.photoURL = oldUser.photoURL;
                user.id = id;

                handler.updateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [UserAuthentication]
        [Route("api/users/me/password")]
        public IHttpActionResult PutMePassword([FromBody] string newPassword)
        {
            int authId = int.Parse(RequestContext.Principal.Identity.Name);
            return PutPassword(authId, newPassword);
        }

        [Route("api/users/{int}/password")]
        [UserAuthentication]
        public IHttpActionResult PutPassword(int id, [FromBody] string newPassword)
        {
            SQLUsersHandler handler = null;

            try
            {
                if (newPassword == null)
                {
                    return BadRequest();
                }
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLUsersHandler();

                if (id != authId)
                {
                    return Unauthorized();
                }

                handler.updateUserPassword(newPassword, id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [UserAuthentication]
        [Route("api/users/me/code")]
        public IHttpActionResult PutMeCode([FromBody] int newCode)
        {
            int authId = int.Parse(RequestContext.Principal.Identity.Name);
            return PutCode(authId, newCode);
        }

        [Route("api/users/{int}/code")]
        [UserAuthentication]
        public IHttpActionResult PutCode(int id, [FromBody] int newCode)
        {
            SQLUsersHandler handler = null;

            try
            {
                if (newCode == 0)
                {
                    return BadRequest();
                }
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLUsersHandler();

                if (id != authId)
                {
                    return Unauthorized();
                }

                handler.updateUserCode(newCode, id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

       /* [UserAuthentication]
        [Route("api/users/me")]
        public IHttpActionResult DeleteMe()
        {
            int authId = int.Parse(RequestContext.Principal.Identity.Name);
            return Delete(authId);
        }

        [UserAuthentication]
        [Route("api/users/{int}")]
        public IHttpActionResult Delete(int id)
        {

            SQLVCardsHandler handler = null;
            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
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

        }*/

    }
}

