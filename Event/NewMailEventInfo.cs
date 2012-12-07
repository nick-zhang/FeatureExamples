using System;

namespace Event
{
    public class NewMailEventInfo : EventArgs
    {
        private readonly string mailFrom;
        private readonly string mailTo;
        private readonly string subject;

        public NewMailEventInfo(string mailFrom, string mailTo, string subject)
        {
            this.mailFrom = mailFrom;
            this.mailTo = mailTo;
            this.subject = subject;
        }


        public string Subject
        {
            get { return subject; }
        }

        public string MailTo
        {
            get { return mailTo; }
        }

        public string MailFrom
        {
            get { return mailFrom; }
        }
    }
}
