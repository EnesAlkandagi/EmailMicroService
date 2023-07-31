using Core.Utilities.Results;
using NotificationMicroService.Models;

namespace NotificationMicroService.Business.Abstract
{
    public interface IEmailService
    {
        public Result SendEmail(EmailMessageModel emailMessageModel);
    }
}
