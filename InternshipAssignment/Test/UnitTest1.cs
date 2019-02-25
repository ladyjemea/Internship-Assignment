using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternshipAssignment;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        //checks the vessel class
        [TestMethod]
        public void TestMethod1()
        {
            var ship = new Vessel("The mermaid", "2005", 50);

            var result = ship.GetVesselInfo();

            Assert.AreEqual("", result);
        }

        //checks the ferry class
        [TestMethod]
        public void TestMethod2()
        {
            Vessel ship = new Ferry("Fer", "2001", 25.5, "4");

            var result = ship.GetVesselInfo();

            Assert.AreEqual("Ferry Fer 2001 4", result);
        }


        //verfies the Tugboat class
        [TestMethod]
        public void TestMethod3()
        {
            Vessel ship = new Tugboat("Tug", "2013", 65.0, "20");

            var result = ship.GetVesselInfo();

            Assert.AreEqual("Tugboat Tug 2013 20", result);
        }


        //verifies that all the parameters of the submarine class are gotten
        [TestMethod]
        public void TestMethod4()
        {
            Vessel ship = new Submarine("Sub", "1999", 100.2, "50");

            var result = ship.GetVesselInfo();

            Assert.AreEqual("Submarine Sub 1999 50", result);
        }


        //tests the speed for the submarine class
        [TestMethod]
        public void TestMethod5()
        {
            Vessel ship = new Submarine("Sub", "1999", 100.2, "50");

            var result = ship.Speed.ToString("KN",null);

            Assert.AreEqual("100,2", result);
        }

        // texts the conversion of the from kn to ms
        [TestMethod]
        public void TestMethod6()
        {
            Vessel ship = new Submarine("Sub", "1999", 100.2, "50");

            var result = ship.Speed.ToString("ms", null);

            Assert.AreEqual("51,5432098765432", result);
        }


    }
}
