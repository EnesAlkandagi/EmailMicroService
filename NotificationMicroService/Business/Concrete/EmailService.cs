using Core.Utilities.Results;
using NotificationMicroService.Business.Abstract;
using NotificationMicroService.Core;
using NotificationMicroService.Core.Helpers;
using NotificationMicroService.Models;

namespace NotificationMicroService.Business.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;

        }
        public Result SendEmail(EmailMessageModel emailMessageModel)
        {
            EmailHelper _emailHelper = new EmailHelper();
            var emailMessage = _emailHelper.CreateEmailMessage(emailMessageModel, _emailConfiguration);
            var result = _emailHelper.Send(emailMessage, _emailConfiguration);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult(result.Message);
        }
    }
}
