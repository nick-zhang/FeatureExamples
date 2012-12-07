using Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventTest
{
    [TestClass]
    public class MailManagerTest
    {
        [TestMethod]
        public void ShouldResponseToNewMailEvent()
        {
            var mailManager = new MailManager();
            new Fax(mailManager);

            mailManager.SimulateNewMail("Nick", "Carry", "Hello World");
        }

        [TestMethod]
        public void ShouldNotResponseToNewMailEventWhenUnregistered()
        {
            var mailManager = new MailManager();
            var fax = new Fax(mailManager);

            mailManager.SimulateNewMail("Nick", "Carry", "Hello World");

            fax.Unregister(mailManager);
            mailManager.SimulateNewMail("Nancy", "James", "Good Morning");
        }
    }
}
