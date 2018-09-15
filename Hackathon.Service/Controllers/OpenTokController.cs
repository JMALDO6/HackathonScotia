
namespace Hackathon.Service.Controllers
{
    using OpenTokSDK;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("OpenTok")]
    public class OpenTokController : ApiController
    {
        /// <summary>
        /// The API key
        /// </summary>
        private readonly OpenTok _openTokContext;


        /// <summary>
        /// Initializes a new instance of the <see cref="OpenTokController"/> class.
        /// </summary>
        public OpenTokController()
        {
            var apiKey = Convert.ToInt32(ConfigurationManager.AppSettings["ApiKey"]);
            var apiSecret = ConfigurationManager.AppSettings["ApiSecret"];
            _openTokContext = new OpenTok(apiKey, apiSecret);
        }

        /// <summary>
        /// Gets the sesssion identifier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSesssionId")]
        public IHttpActionResult GetSesssionId()
        {
            return Ok(_openTokContext.CreateSession().Id);
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetToken")]
        public IHttpActionResult GetToken(string sessionId, string user)
        {
            var inOneDay = (DateTime.UtcNow.Add(TimeSpan.FromDays(1)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var token = _openTokContext.GenerateToken(sessionId, Role.PUBLISHER, expireTime: inOneDay, data: user);
            return Ok(token);
        }
    }
}
