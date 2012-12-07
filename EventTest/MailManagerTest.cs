using Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventTest
{
    [TestClass]
    public class MailManagerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mailManager = new MailManager();
            new Fax(mailManager);

            mailManager.SimulateNewMail("Nick", "Carry", "Hello World");
        }
    }
}
