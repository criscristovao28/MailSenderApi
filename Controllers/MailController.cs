using MailSenderApi.Infra.Services;
using MailSenderApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] SendEmailViewModel email)
        {
            _mailService.SendMail(email.Emails,
                email.Subject, email.Body, email.IsHtml);

            return Ok();
        }
    }
}
