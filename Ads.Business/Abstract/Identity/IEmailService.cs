namespace Ads.Business.Abstract.Identity;

public interface IEmailService
{
  Task SendEmailAsync(string approvalEmailLink, string toEMail, string subject, string content);
  Task RecieveEmailAsync(string message, string userName, string userEmail);
}
