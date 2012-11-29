using System;
using FeatureExamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FeatureExamplesTest
{
    [TestClass]
    public class MoqTest
    {
        [TestMethod]
        public void MockPropertyOnInterfaceCanWork()
        {
            var student = new Student();

            var mock = new Mock<IProduct>();
            mock.Setup(p => p.Color).Returns("Red");

            var showColor = student.ShowColor(mock.Object);
            Assert.AreEqual("Red", showColor);
            mock.Verify();
        }
        
        [TestMethod]
        public void MockMethodOnInterfaceCanWork()
        {
            var student = new Student();

            var mock = new Mock<IProduct>();
            mock.Setup(p => p.GetPrice()).Returns(17.00);

            var showPrice1 = student.ShowPrice1(mock.Object);
            Assert.AreEqual("Expensive", showPrice1);
            mock.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void MockPropertyOnClassCanNotWork()
        {
            var student = new Student();

            var mock = new Mock<Product>();
            mock.Setup(p => p.Price).Returns(16.55);

            var showPrice = student.ShowPrice(mock.Object);
            Assert.AreEqual("Expensive", showPrice);
            mock.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void MockClassNonVirtualMethodDoesNotWork()
        {
            var student = new Student();

            var mock = new Mock<Product>();
            mock.Setup(p => p.GetColor()).Returns("Red");

            var showColor1 = student.ShowColor1(mock.Object);
            Assert.AreEqual("Red", showColor1);
            mock.Verify();
        }

        [TestMethod]
        public void MockAbstractClassAbstractPropertyCanWork()
        {
            var student = new Student();

            var mock = new Mock<AbstractProduct>();
            mock.Setup(p => p.Color).Returns("Red");

            var showColor2 = student.ShowColor2(mock.Object);
            Assert.AreEqual("Red", showColor2);
            mock.Verify();
        }
    }
}
