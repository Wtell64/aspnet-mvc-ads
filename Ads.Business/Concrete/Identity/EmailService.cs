using Ads.Business.Abstract.Identity;
using Ads.Business.Dtos.Users;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Ads.Business.Concrete.Identity;

public class EmailService : IEmailService
{

	private readonly EmailSenderDto _emailSenderDto;

	public EmailService(IOptions<EmailSenderDto> options)
	{
		_emailSenderDto = options.Value;
	}

	public async Task SendEmailAsync(string approvalEmailLink, string toEMail, string subject, string content)
	{
		var smptClient = new SmtpClient();

		smptClient.Host = _emailSenderDto.Host;
		smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		smptClient.UseDefaultCredentials = false;
		smptClient.Port = 587;
		smptClient.Credentials = new NetworkCredential(_emailSenderDto.Email, _emailSenderDto.Password);
		smptClient.EnableSsl = true;

		var mailMessage = new MailMessage();

		mailMessage.From = new MailAddress(_emailSenderDto.Email);
		mailMessage.To.Add(toEMail);
		mailMessage.Subject = $"LocalHost | {subject}";
		mailMessage.IsBodyHtml = true;
		mailMessage.Body = $@"
											 <h5>{content} için aşağıdaki linke tıklayınız.</h5>
											 <p><a href='https://localhost:7175{approvalEmailLink}'>{subject} </a></p>";

		await smptClient.SendMailAsync(mailMessage);

	}

}
