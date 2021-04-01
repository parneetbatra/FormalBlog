using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FormalBlog.Core
{
    public class Email
    {
        public static void Send(string To, string Subject, string Body)
        {
            try
            {
                using (MailMessage Mail = new MailMessage())
                {
                    Mail.From = new MailAddress("itsupport@bajwaimmigion.com", "Bajwa Immigration Consultants");

                    Mail.To.Add(new MailAddress(To));
                    Mail.ReplyToList.Add("enquiries@bajwaimmigration.com");
                    Mail.Subject = Subject;
                    Mail.Body = Body;
                    Mail.Priority = MailPriority.High;
                    Mail.IsBodyHtml = true;
                    Mail.BodyEncoding = UTF8Encoding.UTF8;
                    Mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess;

                    //byte[] toBytes = Encoding.ASCII.GetBytes(Body);
                    //MemoryStream ms = new MemoryStream(toBytes);
                    //AlternateView av = new AlternateView(ms, "application/pkcs7-mime; smime-type=enveloped-data;name=smime.p7m");
                    //Mail.AlternateViews.Add(av);

                    using (SmtpClient Client = new SmtpClient())
                    {
                        Client.Port = 587;
                        Client.Host = "smtp.gmail.com";
                        //Client.EnableSsl = true;
                        Client.Timeout = 20000;
                        Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //Client.UseDefaultCredentials = true;
                        //Client.Credentials = new NetworkCredential("itsupport@bajwaimmigration.com", "Trsam121");

                        Client.Credentials = new NetworkCredential("itsupport@bajwaimgration.com", "Trsam121");
                        Client.EnableSsl = true;
                        Client.UseDefaultCredentials = false;

                        Client.Send(Mail);
                    }
                    Mail.Dispose();
                }
            }
            catch (Exception ex)
            {
                Helper.Error(ex, To + " - " + Subject);
            }
        }
    }
}
