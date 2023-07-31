using Microsoft.AspNetCore.Mvc;
using NotificationMicroService.Business.Abstract;
using NotificationMicroService.Models;

namespace NotificationMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private static IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendEmail")]
        public IActionResult SendEmail(EmailMessageDto emailMessageDto)
        {
            var message = new EmailMessageModel(emailMessageDto.PeopleToSend, emailMessageDto.Subject, emailMessageDto.Content);
            var result = _emailService.SendEmail(message);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);

        }
    }
}
