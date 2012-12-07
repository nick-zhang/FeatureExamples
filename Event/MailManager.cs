using System;

namespace Event
{
    public sealed class MailManager
    {
        public event EventHandler<NewMailEventInfo> NewMail;

        private void OnNewMail(NewMailEventInfo eventInfo)
        {
            if (NewMail != null)
                NewMail(this, eventInfo);
        }

        public void SimulateNewMail(string mailFrom, string mailTo, string subject)
        {
            var newMailEventInfo = new NewMailEventInfo(mailFrom, mailTo, subject);
            OnNewMail(newMailEventInfo);
        }
    }

}
