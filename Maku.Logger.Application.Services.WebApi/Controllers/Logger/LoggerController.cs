using System.Web.Http;
using Maku.Logger.Application.Dto;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Application.Services.WebApi.Controllers.Logger
{
    [RoutePrefix("api/makulogger")]
    public class LoggerController : ApiController
    {
        private readonly ILoggerServiceCommand _loggerServiceCommand;

        public LoggerController(ILoggerServiceCommand loggerServiceCommand)
        {
            _loggerServiceCommand = loggerServiceCommand;
        }

        [HttpPost, Route("createlog")]
        public IHttpActionResult CreateLog([FromBody] MessageCommandDto messageCommandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(_loggerServiceCommand.Message(messageCommandDto.Description, messageCommandDto.CreatedBy));
        }
    }
}
