using System;

namespace Event
{
    public class Fax
    {
        public Fax(MailManager mailManager)
        {
            mailManager.NewMail += FaxMsg;
        }

        private static void FaxMsg(object sender, NewMailEventInfo e)
        {
            Console.Out.WriteLine("Faxing Message...");
            Console.Out.WriteLine("From:{0}, To:{1}, Subject:{2}", e.MailFrom, e.MailTo, e.Subject);
        }

        public static void Unregister(MailManager mailManager)
        {
            mailManager.NewMail -= FaxMsg;
        }
    }
}
