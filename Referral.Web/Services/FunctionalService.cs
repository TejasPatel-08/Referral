//using System;
//using System.IO;
//using System.Net;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace Referral.Web.Services
//{
//    public class FunctionalService
//    {
//        public async Task SendEmailBySendGridAsync(string apiKey, string fromEmail, string fromFullName, string subject, string message, string email)
//        {
//            var client = new SendGridClient(apiKey);
//            var msg = new SendGridMessage()
//            {
//                From = new EmailAddress(fromEmail, fromFullName),
//                Subject = subject,
//                PlainTextContent = message,
//                HtmlContent = message
//            };
//            msg.AddTo(new EmailAddress(email, email));
//            await client.SendEmailAsync(msg);
//        }

//        public async Task SendEmailByGmailAsync(string fromEmail, string fromFullName, string subject, string messageBody, string toEmail, string toFullName, string smtpUser, string smtpPassword, string smtpHost, int smtpPort, bool smtpSSL)
//        {
//            if (!string.IsNullOrWhiteSpace(toEmail))
//            {
//                var body = messageBody;
//                var message = new MailMessage();
//                message.To.Add(new MailAddress(toEmail, toFullName));
//                message.From = new MailAddress(fromEmail, fromFullName);
//                message.Subject = subject;
//                message.Body = body;
//                message.IsBodyHtml = true;

//                using (var smtp = new SmtpClient())
//                {
//                    var credential = new NetworkCredential
//                    {
//                        UserName = smtpUser,
//                        Password = smtpPassword
//                    };
//                    smtp.Credentials = credential;
//                    smtp.Host = smtpHost;
//                    smtp.Port = smtpPort;
//                    smtp.EnableSsl = smtpSSL;
//                    await smtp.SendMailAsync(message);
//                }
//            }
//        }

//        public async Task SendSmsByBulkSmsAsync(string user, string password, string sender, string type, string url, string message, string number)
//        {
//            string result = "";
//            if (!string.IsNullOrWhiteSpace(number) && number.Length >= 10)
//            {
//                message = HttpUtility.UrlPathEncode(message);
//                String strPost = "?user=" + HttpUtility.UrlPathEncode(user) + "&password=" + HttpUtility.UrlPathEncode(password) + "&sender=" + HttpUtility.UrlPathEncode(sender) + "&mobile=" + HttpUtility.UrlPathEncode(number) + "&type=" + HttpUtility.UrlPathEncode(type) + "&message=" + message;
//                StreamWriter myWriter = null;
//                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strPost);
//                objRequest.Method = "POST";
//                objRequest.ContentLength = Encoding.UTF8.GetByteCount(strPost);
//                objRequest.ContentType = "application/x-www-form-urlencoded";
//                try
//                {
//                    myWriter = new StreamWriter(objRequest.GetRequestStream());
//                    await myWriter.WriteAsync(strPost);
//                }
//                catch (Exception)
//                {

//                }
//                finally
//                {
//                    myWriter.Close();
//                }
//                var objResponse = await objRequest.GetResponseAsync();
//                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
//                {
//                    result = await sr.ReadToEndAsync();
//                }
//            }
//        }

//        public async Task SendSmsByTwillioAsync(string sid, string token, string from, string message, string number)
//        {
//            TwilioClient.Init(sid, token);
//            await MessageResource.CreateAsync(new PhoneNumber("+91" + number.Replace("(", "").Replace(")", "")),
//                 from: new PhoneNumber(from),
//                 body: message);
//        }
//    }
//}
