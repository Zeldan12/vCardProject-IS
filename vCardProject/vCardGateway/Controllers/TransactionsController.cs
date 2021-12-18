using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vCardGateway.Logic;
using vCardGateway.Models;

namespace vCardGateway.Controllers
{
    public class TransactionsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/transactions")]
        public IEnumerable<Transaction> Get()
        {
            SQLTransactionHandler handler = null;

            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;

                handler = new SQLTransactionHandler();
                if (type != "Admin")
                {
                    return new List<Transaction>();
                }


                return handler.getAllTransactions();
            }
            catch (Exception e)
            {
                return new List<Transaction>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/transactions/{id}")]
        public IHttpActionResult Get(int id)
        {
            SQLTransactionHandler handler = null;

            try
            {
                string type = RequestContext.Principal.Identity.AuthenticationType;
                if (type != "Admin")
                {
                    return Unauthorized();
                }

                
                handler = new SQLTransactionHandler();

                Transaction transaction = handler.getTransaction(id);

                return Ok(transaction);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/vcards/{number}/transactions")]
        public IEnumerable<Transaction> GetVcardTransactions(int number)
        {
            SQLTransactionHandler handler = null;
            SQLVCardsHandler handlerv = null;
            try
            {
                int id = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;
                handlerv = new SQLVCardsHandler();

                VCard vCard = handlerv.getVCard(number);

                handler = new SQLTransactionHandler();
                if (type != "Admin" && id != vCard.ownerId)
                {
                    return new List<Transaction>();
                }

                return handler.getAllTransactions(number);
            }
            catch (Exception e)
            {
                return new List<Transaction>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/vcards/{number}/transactions/{id}")]
        public IHttpActionResult GetVcardTransaction(int number, int id)
        {
            SQLTransactionHandler handler = null;
            SQLVCardsHandler handlerv = null;
            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);
                string type = RequestContext.Principal.Identity.AuthenticationType;
                handlerv = new SQLVCardsHandler();

                VCard vCard = handlerv.getVCard(number);

                if (type != "Admin" && id != vCard.ownerId)
                {
                    return Unauthorized();
                }


                handler = new SQLTransactionHandler();

                Transaction transaction = handler.getTransaction(id);

                if (transaction.vCardNumber == number)
                {
                    NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/vcards/{number}/transactions")]
        public IHttpActionResult Post(int number, [FromBody]Transaction transaction)
        {
            SQLTransactionHandler handler = null;
            SQLVCardsHandler handlerv = null;
            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);

                handlerv = new SQLVCardsHandler();

                VCard vCard = handlerv.getVCard(number);

                if (authId != vCard.ownerId)
                {
                    return Unauthorized();
                }

                handler = new SQLTransactionHandler();

                transaction.vCardNumber = vCard.phoneNumber;
                transaction.date = DateTime.Now;
                transaction.oldValue = vCard.balance;
                transaction.newValue = transaction.oldValue - transaction.value;
                transaction.transactionType = "D";

                if (transaction.paymentType == PaymentType.VCARD)
                {
                    VCard pairv = handlerv.getVCard(int.Parse(transaction.transactionAcomplice));
                    Transaction pair = new Transaction
                    {
                        vCardNumber = int.Parse(transaction.transactionAcomplice),
                        transactionAcomplice = transaction.vCardNumber.ToString(),
                        date = transaction.date,
                        transactionType = "C",
                        paymentType = transaction.paymentType,
                        value = transaction.value,
                        oldValue = pairv.balance,
                        newValue = pairv.balance + transaction.value,
                    };
                    handler.createVcardTransactions(transaction, pair);
                }


                return Ok();
                
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
        /// <param name="number"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [UserAuthentication]
        [Route("api/vcards/{number}/transactions/{id}")]
        public IHttpActionResult Put(int id, int number, [FromBody] string description)
        {
            SQLTransactionHandler handler = null;
            SQLVCardsHandler handlerv = null;
            try
            {
                int authId = int.Parse(RequestContext.Principal.Identity.Name);

                handlerv = new SQLVCardsHandler();

                VCard vCard = handlerv.getVCard(number);

                if (id != vCard.ownerId)
                {
                    return Unauthorized();
                }


                handler = new SQLTransactionHandler();

                Transaction transaction = handler.getTransaction(id);

                if (transaction != null || transaction.vCardNumber != number )
                {
                    return NotFound();
                }

                if(handler.updateTransaction(id, description))
                {
                    return Ok();
                }
                
                return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


    }
}
